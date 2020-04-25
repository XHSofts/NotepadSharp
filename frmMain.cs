using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Util;
using FontFamily = System.Windows.Media.FontFamily;

//using ICSharpCode.AvalonEdit;
//using ICSharpCode.AvalonEdit.Document;
//using ICSharpCode.AvalonEdit.Folding;
//using ICSharpCode.TextEditor.Document;
//using FoldingManager = ICSharpCode.AvalonEdit.Folding.FoldingManager;
//using HighlightingManager = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager;

namespace NotepadSharp
{
    public partial class frmMain : Form
    {
        private TextEditorControl edit
        {
            get { return this.textEditorControl; }
        }
//        private FoldingManager     foldingManager  = null;
//        private XmlFoldingStrategy foldingStrategy = new XmlFoldingStrategy();

        ResourceManager LocRM = new ResourceManager("NotepadSharp.frmMain", typeof(frmMain).Assembly);

        private string currPressedKey = "";

        private string _currFileEncoding;

        private string currFileEncoding
        {
            get { return _currFileEncoding; }
            set
            {
                _currFileEncoding   = value;
                encodingStatus.Text = currFileEncoding;
            }
        }

        private string _currTitleName;

        private string currTitleName
        {
            get { return _currTitleName; }
            set
            {
                _currTitleName = value;
                UpdateTitle();
            }
        }

        private FileObject _currOpenedFIle;

        private FileObject currOpenedFIle
        {
            get { return _currOpenedFIle; }
            set
            {
                _currOpenedFIle = value;
                currTitleName   = value.fileName;
            }
        }

        private float orgFontSize;
        private int   _currZoomSize = 100;

        private int currZoomSize
        {
            get { return _currZoomSize; }
            set
            {
                //No need to set limitation
//                if (value > 500 || value < 50)
//                {
//                    return;
//                }

                _currZoomSize   = value;
                zoomStatus.Text = value + "%";
                //No need to control this by ourselves.
//                Font newFont = new Font(edit.Font.FontFamily,
//                                        Convert.ToInt32(Math.Round(orgFontSize * ((double) value / 100))),
//                                        edit.Font.Style, edit.Font.Unit, edit.Font.GdiCharSet);
//                edit.Font = newFont;
            }
        }

        private Font _currFont;

        private Font currFont
        {
            get
            {
                if (_currFont is null)
                {
                    return Properties.Settings.Default.font;
                }
                else
                {
                    return _currFont;
                }
            }
            set
            {
                edit.Font                        = value;
                _currFont                        = value;
                orgFontSize                      = value.Size;
                Properties.Settings.Default.font = value;
                Properties.Settings.Default.Save();
            }
        }

        private int _currCaretLine = 1;

        private int currCaretLine
        {
            get { return _currCaretLine; }
            set
            {
                _currCaretLine = value + 1;
                cursorStatus.Text = string.Format(LocRM.GetString("LineColumnStatus"), _currCaretLine.ToString(),
                                                  _currCaretColumn.ToString());
            }
        }

        private int _currCaretColumn = 1;

        private int currCaretColumn
        {
            get { return _currCaretColumn; }
            set
            {
                _currCaretColumn = value + 1;
                cursorStatus.Text = string.Format(LocRM.GetString("LineColumnStatus"), _currCaretLine.ToString(),
                                                  _currCaretColumn.ToString());
            }
        }

        private int _currLength = 0;

        private int currLength
        {
            get { return _currLength; }
            set
            {
                _currLength = value;
                textLengthStatus.Text = string.Format(LocRM.GetString("textLengthStatus"), _currLength.ToString(),
                                                      _currLines.ToString());
            }
        }

        private int _currLines = 0;

        private int currLines
        {
            get { return _currLines; }
            set
            {
                _currLines = value;
                textLengthStatus.Text = string.Format(LocRM.GetString("textLengthStatus"), _currLength.ToString(),
                                                      _currLines.ToString());
            }
        }

        private string _currReturnStyle = "Windows (CRLF)";

        private string currReturnStyle
        {
            get { return _currReturnStyle; }
            set
            {
                _currReturnStyle       = value;
                returnStyleStatus.Text = value;
            }
        }

        private Boolean _hasSave = true;

        private Boolean hasSave
        {
            get { return _hasSave; }
            set
            {
                _hasSave = value;
                UpdateTitle();
            }
        }

        private Boolean isLoadFile = false; //To determine whether it's loading a new file or

        //    text typing that results to TextChange.
        public frmMain()
        {
            InitializeComponent();

            //            edit                  =  new TextEditor();
            //            editHost.Child        =  edit;
            edit.TextChanged                              += Edit_TextChanged;
            edit.ActiveTextAreaControl.TextArea.Click     += Edit_Click;
            edit.ActiveTextAreaControl.TextArea.MouseMove += TextArea_MouseMove;
            edit.ActiveTextAreaControl.TextArea.KeyDown   += TextArea_KeyDown;
            edit.ActiveTextAreaControl.TextArea.KeyUp     += TextArea_KeyUp;
            edit.ActiveTextAreaControl.Scroll             += ActiveTextAreaControl_Scroll;
            edit.FileNameChanged                          += Edit_FileNameChanged;
            edit.MouseWheel                               += Edit_MouseWheel;
        }

        private void TextArea_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            updateStatusBar();
            UpdateMenuItem();
        }

        private void Edit_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (currPressedKey == "ControlKey")
            {
                if (e.Delta > 0)
                {
                    currZoomSize += 10;
                }
                else
                {
                    currZoomSize -= 10;
                }
            }
        }

        private void Edit_FileNameChanged(object sender, EventArgs e)
        {
            if (edit.FileName == "\\Untitled\\") return;
            currFileEncoding = edit.Encoding.EncodingName;
            currOpenedFIle = new FileObject(System.IO.Path.GetFileName(edit.FileName), edit.FileName,
                                            System.IO.Path.GetExtension(edit.FileName));
            currReturnStyle = determineReturnStyle();
            hasSave         = true;
            isLoadFile      = true;
        }

        private void TextArea_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }

            currPressedKey = e.KeyCode.ToString();
            updateStatusBar();
            UpdateMenuItem();
        }

        private void TextArea_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            currPressedKey = "";
            updateStatusBar();
            UpdateMenuItem();
        }

        private void ActiveTextAreaControl_Scroll(object sender, ScrollEventArgs e)
        {
            updateStatusBar();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            updateStatusBar();
            UpdateMenuItem();
        }

        private void Edit_TextChanged(object sender, EventArgs e)
        {
            if (edit.FileName == "\\Untitled\\" && edit.ActiveTextAreaControl.TextArea.Document.TextContent == "")
            {
                hasSave = true;
            }
            else
            {
                hasSave = false;
            }

            updateStatusBar();
            UpdateMenuItem();
        }

        private string determineReturnStyle()
        {
            if (edit.ActiveTextAreaControl.TextArea.Document.TextContent.Contains("\r\n"))
            {
                return "Windows (CRLF)";
            }
            else if (edit.ActiveTextAreaControl.TextArea.Document.TextContent.Contains("\n"))
            {
                return "Unix (LF)";
            }
            else if (edit.ActiveTextAreaControl.TextArea.Document.TextContent.Contains("\r"))
            {
                return "Macintosh (CR)";
            }
            else
            {
                return "Mixed";
            }
        }

        private void updateStatusBar()
        {
            currCaretLine   = edit.ActiveTextAreaControl.Caret.Line;
            currCaretColumn = edit.ActiveTextAreaControl.Caret.Column;
            currLength      = edit.ActiveTextAreaControl.TextArea.Document.TextLength;
            currLines       = edit.ActiveTextAreaControl.TextArea.Document.TotalNumberOfLines;
        }

        private void initHighlight()
        {
            string                 path = Application.StartupPath + "\\HighlightFiles";
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(path))
            {
                fsmp = new FileSyntaxModeProvider(path);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }
        }

        private void UpdateTitle()
        {
            if (currTitleName != "")
            {
                this.Text = (hasSave ? "" : "*") + currTitleName + " - " + LocRM.GetString("$this.Text");
            }
            else
            {
                this.Text = (hasSave ? "" : "*") + LocRM.GetString("defaultTitle") + " - " +
                            LocRM.GetString("$this.Text");
            }
        }

        private void UpdateMenuItem()
        {
            if (edit.ActiveTextAreaControl.TextArea.Document.UndoStack.CanUndo)
            {
                UndoMenuItem.Enabled = true;
            }
            else
            {
                UndoMenuItem.Enabled = false;
            }

            if (edit.ActiveTextAreaControl.TextArea.Document.UndoStack.CanRedo)
            {
                RedoMenuItem.Enabled = true;
            }
            else
            {
                RedoMenuItem.Enabled = false;
            }

            if (HaveSelection())
            {
                CutMenuItem.Enabled  = true;
                CopyMenuItem.Enabled = true;
                CutMenuItem.Text     = LocRM.GetString("CutMenuItem.Text");
                CopyMenuItem.Text    = LocRM.GetString("CopyMenuItem.Text");
                DeleteMenuItem.Text  = LocRM.GetString("DeleteMenuItem.Text");
            }
            else
            {
                CutMenuItem.Enabled  = false;
                CopyMenuItem.Enabled = false;
                CutMenuItem.Text     = LocRM.GetString("CutWholeLine");
                CopyMenuItem.Text    = LocRM.GetString("CopyWholeLine");
                DeleteMenuItem.Text  = LocRM.GetString("DeleteWholeLine");
            }
        }

        /// <summary>Performs an action encapsulated in IEditAction.</summary>
        /// <remarks>
        /// There is an implementation of IEditAction for every action that 
        /// the user can invoke using a shortcut key (arrow keys, Ctrl+X, etc.)
        /// The editor control doesn't provide a public funciton to perform one
        /// of these actions directly, so I wrote DoEditAction() based on the
        /// code in TextArea.ExecuteDialogKey(). You can call ExecuteDialogKey
        /// directly, but it is more fragile because it takes a Keys value (e.g.
        /// Keys.Left) instead of the action to perform.
        /// <para/>
        /// Clipboard commands could also be done by calling methods in
        /// editor.ActiveTextAreaControl.TextArea.ClipboardHandler.
        /// </remarks>
        private void DoEditAction(TextEditorControl editor, ICSharpCode.TextEditor.Actions.IEditAction action)
        {
            if (editor != null && action != null)
            {
                TextArea area = editor.ActiveTextAreaControl.TextArea;
                editor.BeginUpdate();
                try
                {
                    lock (editor.Document)
                    {
                        action.Execute(area);
                        if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/)
                        {
                            if (area.Document.TextEditorProperties.DocumentSelectionMode ==
                                DocumentSelectionMode.Normal)
                            {
                                area.SelectionManager.ClearSelection();
                            }
                        }
                    }
                }
                finally
                {
                    editor.EndUpdate();
                    area.Caret.UpdateCaretPosition();
                }
            }
        }

        private bool HaveSelection()
        {
            return edit.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
        }


        private void reArrangeControl()
        {
            foreach (ToolStripItem c in bottomStatusBar.Items)
            {
                c.Alignment = ToolStripItemAlignment.Right;
            }
        }

        private void saveFile()
        {
            try
            {
                if (!File.Exists(edit.FileName) || (edit.FileName is null) || edit.FileName == "" ||
                    (edit.FileName == "\\Untitled\\"))
                {
                    saveAsFile();
                }
                else
                {
                    edit.SaveFile(edit.FileName);
                    hasSave = true;
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(LocRM.GetString("ErrorSaving") + "\r\n" + eX.Message, LocRM.GetString("$this.Text"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void saveAsFile()
        {
            try
            {
                DialogResult dr = saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    edit.SaveFile(saveFileDialog.FileName);
                    hasSave = true;
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(LocRM.GetString("ErrorSaving") + "\r\n" + eX.Message, LocRM.GetString("$this.Text"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Boolean checkUnsave()
        {
            Boolean      result = true;
            DialogResult dr     = DialogResult.Cancel;
            if ((edit.FileName != "\\Untitled\\" && edit.FileName != "" && !(edit.FileName is null)) &&
                !File.Exists(edit.FileName))
            {
                //If the file is missing when checking...
                dr =
                    MessageBox.Show(string.Format(LocRM.GetString("FileNotExistWhenCheck"), currOpenedFIle.fileName),
                                    LocRM.GetString("$this.Text"),
                                    MessageBoxButtons.YesNoCancel);
            }
            else if (!hasSave)
            {
                //If file is unsaved....
                dr =
                    MessageBox.Show(string.Format(LocRM.GetString("saveQuestion"), currOpenedFIle.fileName),
                                    LocRM.GetString("$this.Text"),
                                    MessageBoxButtons.YesNoCancel);
            }
            else
            {
                //Otherwise, the result is true...
                return result;
            }

            switch (dr)
            {
                case DialogResult.Yes:
                    saveFile();
                    result = true;
                    break;
                case DialogResult.No:
                    result = true;
                    break;
                case DialogResult.Cancel:
                    result = false;
                    break;
            }

            return result;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Try to fix high-dpi blurry
            this.AutoScaleMode = AutoScaleMode.Font;
            edit.AutoScaleMode = AutoScaleMode.Font;
            //Finally I upgrade to .Net 4.7 to solve this...

            reArrangeControl();
            MultiLanguage.LoadLanguage(this, typeof(frmMain));
            //Load TextEditor default settings
            if (currFont is null)
            {
                switch (MultiLanguage.DefaultLanguage)
                {
                    case "zh-CN":
                        currFont = new Font("微软雅黑", 12);
                        break;
                    case "en-US":
                        currFont = new Font("Arial", 12);
                        break;
                }
            }
            else
            {
                currFont = Properties.Settings.Default.font;
            }

            initHighlight();
            edit.FileName        = "\\Untitled\\";
            currOpenedFIle       = new FileObject(LocRM.GetString("defaultTitle"), "", ".txt");
            edit.ShowLineNumbers = true;
            edit.Encoding        = System.Text.Encoding.UTF8;

            updateStatusBar();
            UpdateMenuItem();
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                DialogResult dr = openFileDialog.ShowDialog();
                if ((dr == DialogResult.OK) && (openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName)))
                {
                    edit.FileName = "\\Untitled\\";
                    edit.LoadFile(openFileDialog.FileName);
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            if (edit.ActiveTextAreaControl.TextArea.Document.UndoStack.CanUndo)
            {
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Undo());
            }
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            if (edit.ActiveTextAreaControl.TextArea.Document.UndoStack.CanRedo)
            {
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Redo());
            }
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Cut());
                if (isLoadFile)
                {
                    isLoadFile = false; //Restore to default
                }
            }
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Copy());
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Paste());
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.Delete());
            else
                DoEditAction(edit, new ICSharpCode.TextEditor.Actions.DeleteLine());
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }
        }

        private void NewFileMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                currOpenedFIle =
                    new FileObject(LocRM.GetString("defaultTitle"), "", ".txt");
                edit.BeginUpdate();
                edit.FileName                                   = "\\Untitled\\";
                edit.ActiveTextAreaControl.Document.TextContent = string.Empty;
                edit.ActiveTextAreaControl.Document.UndoStack.ClearAll();
                edit.ActiveTextAreaControl.Document.BookmarkManager.Clear();
                edit.ActiveTextAreaControl.Document.UpdateQueue.Clear();
                edit.EndUpdate();
                edit.OptionsChanged();
                this.Refresh();
            }
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            DoEditAction(edit, new ICSharpCode.TextEditor.Actions.SelectWholeDocument());
            edit.ActiveTextAreaControl.TextArea.Caret.Position = edit.Document.OffsetToPosition(edit
                                                                                                .Document
                                                                                                .TextLength);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                edit.ActiveTextAreaControl.TextArea.Text = "";
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkUnsave())
            {
                edit.ActiveTextAreaControl.TextArea.Text = "";
                e.Cancel                                 = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }
    }
}