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
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using FontFamily = System.Windows.Media.FontFamily;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Folding;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using FoldingManager = ICSharpCode.AvalonEdit.Folding.FoldingManager;
using FontStyle = System.Drawing.FontStyle;
using HighlightingManager = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager;
using MessageBox = System.Windows.Forms.MessageBox;

namespace NotepadSharp
{
    public partial class frmMain : Form
    {
        private TextEditor edit;
//        {
//            get { return this.textEditorControl; }
//        }
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

        private FileObject _currOpenedFile;

        private FileObject currOpenedFile
        {
            get { return _currOpenedFile; }
            set
            {
                _currOpenedFile = value;
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
                if (value > 500 || value < 50)
                {
                    return;
                }

                _currZoomSize   = value;
                zoomStatus.Text = value + "%";

                edit.FontSize = Convert.ToInt32(Math.Round(orgFontSize * ((double) value / 100)));
                edit.TextArea.Caret.BringCaretToView();
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
                edit.FontFamily = new FontFamily(value.FontFamily.Name);
                edit.FontSize =
                    Convert.ToInt32(Math.Round(value.Size * ((double) currZoomSize / 100))); //value.Size;
                fontDialog.Font                  = value;
                _currFont                        = value;
                Properties.Settings.Default.font = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isWordWrap;

        private Boolean isWordWrap
        {
            get { return _isWordWrap; }
            set
            {
                _isWordWrap                          = value;
                WordWarpMenuItem.Checked             = value;
                edit.WordWrap                        = value;
                Properties.Settings.Default.wordWrap = value;
                Properties.Settings.Default.Save();
            }
        }

        private int _currCaretLine = 1;

        private int currCaretLine
        {
            get { return _currCaretLine; }
            set
            {
                _currCaretLine = value;
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
                _currCaretColumn = value;
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

            edit                                =  new TextEditor();
            edit.BorderBrush=new SolidColorBrush(System.Windows.Media.Color.FromRgb(160,160,160));
            edit.BorderThickness=new Thickness(0,1,0,1);
            host.Child                          =  edit;
            edit.TextChanged                    += Edit_TextChanged;
            edit.MouseDown                      += Edit_Click;
            edit.TextArea.MouseMove             += TextArea_MouseMove;
            edit.TextArea.KeyDown               += TextArea_KeyDown;
            edit.TextArea.KeyUp                 += TextArea_KeyUp;
            edit.Document.FileNameChanged       += Edit_FileNameChanged;
            edit.TextArea.MouseWheel            += TextArea_MouseWheel;
            edit.Document.UpdateStarted         += Document_UpdateStarted;
            edit.Document.UpdateFinished        += Document_UpdateFinished;
            edit.TextArea.Caret.PositionChanged += Caret_PositionChanged;

            fontDialog.Apply += FontDialog_Apply;
        }

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            updateStatusBar();
            UpdateMenuItem();
        }

        private void FontDialog_Apply(object sender, EventArgs e)
        {
            currFont    = fontDialog.Font;
            orgFontSize = currFont.Size;
        }

        private void Document_UpdateFinished(object sender, EventArgs e)
        {
            if (isLoadFile)
            {
                currFileEncoding = edit.Encoding?.EncodingName;
                isLoadFile       = false;
            }

            if (edit.Document.FileName == "\\Untitled\\" || edit.Document.FileName == "" ||
                (edit.Document.FileName is null))
            {
                currReturnStyle = "Windows (CRLF)";
            }
            else
            {
                currReturnStyle = determineReturnStyle();
            }
        }

        private void Document_UpdateStarted(object sender, EventArgs e)
        {
            int a = 1;
        }

        private void TextArea_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (currPressedKey.Contains("Ctrl"))
            {
                if (e.Delta > 0)
                {
                    currZoomSize += 10;
                }
                else
                {
                    currZoomSize -= 10;
                }

                e.Handled = true;
            }
        }

        private void TextArea_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            currPressedKey = "";
            updateStatusBar();
            UpdateMenuItem();
        }

        private void TextArea_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }

            currPressedKey = e.Key.ToString();
            updateStatusBar();
            UpdateMenuItem();
        }

        private void TextArea_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            updateStatusBar();
            UpdateMenuItem();
        }

        private void Edit_FileNameChanged(object sender, EventArgs e)
        {
            if (edit.Document.FileName == "\\Untitled\\")
            {
                currOpenedFile =
                    new FileObject(LocRM.GetString("defaultTitle"), "", ".txt");
            }
            else
            {
                currOpenedFile = new FileObject(System.IO.Path.GetFileName(edit.Document.FileName),
                                                edit.Document.FileName,
                                                System.IO.Path.GetExtension(edit.Document.FileName));
                edit.SyntaxHighlighting =
                    HighlightingManager
                        .Instance.GetDefinitionByExtension(System.IO.Path.GetExtension(edit.Document.FileName));
                hasSave    = true;
                isLoadFile = true;
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            updateStatusBar();
            UpdateMenuItem();
        }

        private void Edit_TextChanged(object sender, EventArgs e)
        {
            if ((edit.Document.FileName == "\\Untitled\\" && edit.TextArea.Document.Text == "") || isLoadFile)
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
            if (edit.TextArea.Document.Text.Contains("\r\n"))
            {
                return "Windows (CRLF)";
            }
            else if (edit.TextArea.Document.Text.Contains("\n"))
            {
                return "Unix (LF)";
            }
            else if (edit.TextArea.Document.Text.Contains("\r"))
            {
                return "Macintosh (CR)";
            }
            else
            {
                return "Windows (CRLF)";
            }
        }

        private void updateStatusBar()
        {
            currFileEncoding = edit.Encoding?.EncodingName;
            currCaretLine    = edit.TextArea.Caret.Line;
            currCaretColumn  = edit.TextArea.Caret.Column;
            currLength       = edit.Document.TextLength;
            currLines        = edit.Document.LineCount;
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
            if (edit.CanUndo)
            {
                UndoMenuItem.Enabled = true;
            }
            else
            {
                UndoMenuItem.Enabled = false;
            }

            if (edit.CanRedo)
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
            }
            else
            {
                CutMenuItem.Enabled  = false;
                CopyMenuItem.Enabled = false;
                CutMenuItem.Text     = LocRM.GetString("CutWholeLine");
                CopyMenuItem.Text    = LocRM.GetString("CopyWholeLine");
            }
        }

        private bool HaveSelection()
        {
            return !edit.TextArea.Selection.IsEmpty;
        }


        private void reArrangeControl()
        {
            foreach (ToolStripItem c in bottomStatusBar.Items)
            {
                c.Alignment = ToolStripItemAlignment.Right;
            }
        }

        private Boolean saveFile()
        {
            try
            {
                if (!File.Exists(edit.Document.FileName) || (edit.Document.FileName is null) ||
                    edit.Document.FileName == ""         ||
                    (edit.Document.FileName == "\\Untitled\\"))
                {
                    return saveAsFile();
                }
                else
                {
                    edit.Save(edit.Document.FileName);
                    hasSave = true;
                    return true;
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(LocRM.GetString("ErrorSaving") + "\r\n" + eX.Message, LocRM.GetString("$this.Text"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        private Boolean saveAsFile()
        {
            try
            {
                DialogResult dr = saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    edit.Save(saveFileDialog.FileName);
                    edit.Load(saveFileDialog.FileName);
                    edit.Document.FileName = saveFileDialog.FileName;
                    hasSave                = true;
                    return true;
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(LocRM.GetString("ErrorSaving") + "\r\n" + eX.Message, LocRM.GetString("$this.Text"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        private Boolean checkUnsave()
        {
            Boolean      result = true;
            DialogResult dr     = DialogResult.Cancel;
            if ((edit.Document.FileName != "\\Untitled\\" && edit.Document.FileName != "" &&
                 !(edit.Document.FileName is null)) &&
                !File.Exists(edit.Document.FileName))
            {
                //If the file is missing when checking...
                dr =
                    MessageBox.Show(string.Format(LocRM.GetString("FileNotExistWhenCheck"), currOpenedFile.fileName),
                                    LocRM.GetString("$this.Text"),
                                    MessageBoxButtons.YesNoCancel);
            }
            else if (!hasSave)
            {
                //If file is unsaved....
                dr =
                    MessageBox.Show(string.Format(LocRM.GetString("saveQuestion"), currOpenedFile.fileName),
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
                    result = saveFile();
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
            //Finally I upgrade to .Net 4.7 to solve this...

            reArrangeControl();
            MultiLanguage.LoadLanguage(this, typeof(frmMain));
            //Load TextEditor default settings
            if (currFont is null)
            {
                switch (MultiLanguage.DefaultLanguage)
                {
                    case "zh-CN":
                        currFont = new Font("微软雅黑", 14);
                        break;
                    case "en-US":
                        currFont = new Font("Arial", 14);
                        break;
                }
            }
            else
            {
                currFont = Properties.Settings.Default.font;
            }

            orgFontSize            = currFont.Size;
            edit.Document.FileName = "\\Untitled\\";
            edit.TextArea.Options.ShowTabs = true;
            edit.ShowLineNumbers                             = true;
            edit.Encoding                                    = System.Text.Encoding.UTF8;
            edit.TextArea.Options.EnableRectangularSelection = true;

            isWordWrap = Properties.Settings.Default.wordWrap;
            updateStatusBar();
            UpdateMenuItem();

            if (Environment.GetCommandLineArgs().Length > 1    && Environment.GetCommandLineArgs()[1] != "" &&
                !(Environment.GetCommandLineArgs()[1] is null) && File.Exists(Environment.GetCommandLineArgs()[1]))
            {
                edit.SelectionLength   = 0;
                edit.Document.FileName = Environment.GetCommandLineArgs()[1];
                edit.Load(Environment.GetCommandLineArgs()[1]);
            }
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                DialogResult dr = openFileDialog.ShowDialog();
                if ((dr == DialogResult.OK) && (openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName)))
                {
                    edit.Document.FileName = "\\Untitled\\"; //To ensure triggering FileNameChanged event
                    edit.SelectionLength   = 0;
                    edit.Document.FileName =
                        openFileDialog.FileName; //If not, open the same name file again, will not trigger this event.
                    edit.Load(openFileDialog.FileName);
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            if (edit.CanUndo)
            {
                edit.Undo();
            }
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            if (edit.CanRedo)
            {
                edit.Redo();
            }
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                edit.Cut();
                edit.SelectionLength = 0;
                if (isLoadFile)
                {
                    isLoadFile = false; //Restore to default
                }
            }
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                edit.Copy();
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            edit.Paste();
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
                edit.Delete();
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }
        }

        private void NewFileMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                edit.Document.FileName = "\\Untitled\\";
                edit.Document.Text     = string.Empty;
                edit.Document.UndoStack.ClearAll();
                this.Refresh();
            }
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            edit.SelectAll();
            edit.TextArea.Caret.Offset = (edit.Document.TextLength);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (checkUnsave())
            {
                edit.Document.Text = "";
                hasSave            = true;
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkUnsave())
            {
                edit.Document.Text = "";
                e.Cancel           = false;
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

        private void WordWarpMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void WordWarpMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            isWordWrap = WordWarpMenuItem.Checked;
        }

        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowEffects = false;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                currFont    = fontDialog.Font;
                orgFontSize = currFont.Size;
            }
        }

        private void UseBingMenuItem_Click(object sender, EventArgs e)
        {
            String searchText = "";
            if (HaveSelection())
            {
                searchText = edit.SelectedText;
            }
            else
            {
                searchText = edit.Text;
            }

            System.Diagnostics.Process.Start("https://www.bing.com/search?q=" + searchText);
        }

        private void DateTimeMenuItem_Click(object sender, EventArgs e)
        {
            edit.Document.Insert(edit.TextArea.Caret.Offset, DateTime.Now.ToString());
        }

        private void GotoMenuItem_Click(object sender, EventArgs e)
        {
            var GoToLinePrompt = new frmGoto(edit.TextArea.Caret.Line + 1);
            GoToLinePrompt.Left = this.Left + 5;
            GoToLinePrompt.Top  = this.Top  + 44;

            if (GoToLinePrompt.ShowDialog(this) != DialogResult.OK) return;

            var TargetLineIndex = GoToLinePrompt.lineGoto;

            if (TargetLineIndex > edit.Document.LineCount)
            {
                MessageBox.Show(this, LocRM.GetString("LineNumAboveTotalError"), LocRM.GetString("$this.Text"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            edit.TextArea.Caret.Line = TargetLineIndex;
            edit.TextArea.Caret.BringCaretToView();
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}