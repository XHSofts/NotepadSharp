using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using FontFamily = System.Windows.Media.FontFamily;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Indentation.CSharp;
using ICSharpCode.AvalonEdit.Search;
using ICSharpCode.AvalonEdit.Utils;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;
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

        private ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy css =
            new CSharpIndentationStrategy();

        private enum IndentMode
        {
            Mode2,
            Mode4,
            Mode8
        }

        #region Editor Settings

        private Boolean _isShowTab;

        private Boolean isShowTab
        {
            get { return _isShowTab; }
            set
            {
                _isShowTab                          = value;
                TabMenuItem.Checked                 = value;
                edit.TextArea.Options.ShowTabs      = value;
                Properties.Settings.Default.showTab = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isSpaceAsTab;

        private Boolean isSpaceAsTab
        {
            get { return _isSpaceAsTab; }
            set
            {
                _isSpaceAsTab                             = value;
                UseSpaceAsTabMenuItem.Checked             = value;
                edit.TextArea.Options.ConvertTabsToSpaces = value;
                Properties.Settings.Default.isSpaceAsTab  = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isShowStatusBar;

        private Boolean isShowStatusBar
        {
            get { return _isShowStatusBar; }
            set
            {
                _isShowStatusBar                = value;
                IsShowStatusBarMenuItem.Checked = value;
                bottomStatusBar.Visible         = value;
                edit.BringIntoView();
                edit.TextArea.Caret.BringCaretToView();
                Properties.Settings.Default.showStatusBar = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isShowSpace;

        private Boolean isShowSpace
        {
            get { return _isShowSpace; }
            set
            {
                _isShowSpace                          = value;
                SpaceMenuItem.Checked                 = value;
                edit.TextArea.Options.ShowSpaces      = value;
                Properties.Settings.Default.showSpace = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isShowEOL;

        private Boolean isShowEOL
        {
            get { return _isShowEOL; }
            set
            {
                _isShowEOL                          = value;
                EOLMenuItem.Checked                 = value;
                edit.TextArea.Options.ShowEndOfLine = value;
                Properties.Settings.Default.showEOL = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isShowControlChar;

        private Boolean isShowControlChar
        {
            get { return _isShowControlChar; }
            set
            {
                _isShowControlChar                                = value;
                ControlCharMenuItem.Checked                       = value;
                RShowControlCharMenuItem.Checked                  = value;
                edit.TextArea.Options.ShowBoxForControlCharacters = value;
                Properties.Settings.Default.showControlChar       = value;
                Properties.Settings.Default.Save();
            }
        }

        private Boolean _isShowColRuler;

        private Boolean isShowColRuler
        {
            get { return _isShowColRuler; }
            set
            {
                _isShowColRuler                          = value;
                ColRulerMenuItem.Checked                 = value;
                edit.TextArea.Options.ShowColumnRuler    = value;
                Properties.Settings.Default.showColRuler = value;
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

        #endregion

        private class TextWithEncoding
        {
            public string   Content      { get; set; }
            public Encoding TextEncoding { get; set; }
        }

        #region Current Props

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
                if (value > 500)
                {
                    value = 500;
                    return;
                }

                if (value < 50)
                {
                    value = 50;
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

        private Boolean currIsAutoIndent;

        private IndentMode _currIndentMode;

        private IndentMode currIndentMode
        {
            get { return _currIndentMode; }
            set
            {
                _currIndentMode = value;
                int indentValue = 0;
                switch (value)
                {
                    case IndentMode.Mode2:
                        edit.Options.IndentationSize = 2;
                        TabWidthStatus.Text          = LocRM.GetString("TabSize") + ": 2";
                        Indent2MenuItem.Checked      = true;
                        Indent4MenuItem.Checked      = false;
                        Indent8MenuItem.Checked      = false;
                        indentValue                  = 1;
                        break;
                    case IndentMode.Mode4:
                        edit.Options.IndentationSize = 4;
                        TabWidthStatus.Text          = LocRM.GetString("TabSize") + ": 4";
                        Indent2MenuItem.Checked      = false;
                        Indent4MenuItem.Checked      = true;
                        Indent8MenuItem.Checked      = false;
                        indentValue                  = 2;
                        break;
                    case IndentMode.Mode8:
                        edit.Options.IndentationSize = 8;
                        TabWidthStatus.Text          = LocRM.GetString("TabSize") + ": 8";
                        Indent2MenuItem.Checked      = false;
                        Indent4MenuItem.Checked      = false;
                        Indent8MenuItem.Checked      = true;
                        indentValue                  = 3;
                        break;
                }


                Properties.Settings.Default.IndentMode = indentValue;
                Properties.Settings.Default.Save();
            }
        }

        private String _currSyntaxHighlighting;

        private String currSyntaxHighlighting
        {
            get { return _currSyntaxHighlighting; }
            set
            {
                _currSyntaxHighlighting = value;
                foreach (ToolStripMenuItem tsmi in HighLightTypeMenuItem.DropDownItems)
                {
                    if (tsmi.Text == value)
                    {
                        tsmi.Checked = true;
                    }
                    else
                    {
                        tsmi.Checked = false;
                    }
                }

                IHighlightingDefinition currDefine =
                    ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition(value);
                HighLightTypeMenuItem.Text = (value != LocRM.GetString("NormalText") && currDefine is null)
                    ? LocRM.GetString("LoadFail")
                    : value;
                edit.SyntaxHighlighting = currDefine;
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

        #endregion

        private static Task<TextWithEncoding> textReaderTask;
        private        Stopwatch              sw  = new Stopwatch();
        private static TextWithEncoding       txt = new TextWithEncoding();
        PrintDocument                         printDocument;

        public frmMain()
        {
            InitializeComponent();
            fontDialog.Apply += FontDialog_Apply;
            printDocument    =  new PrintDocument();

            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
            if (Environment.GetCommandLineArgs().Length > 1    && Environment.GetCommandLineArgs()[1] != "" &&
                !(Environment.GetCommandLineArgs()[1] is null) && File.Exists(Environment.GetCommandLineArgs()[1]))
            {
                sw.Start();
                //                test = ReadTextAsync(Environment.GetCommandLineArgs()[1]);
                textReaderTask = ReadFileAsync(Environment.GetCommandLineArgs()[1]);
            }
        }

        private void FontDialog_Apply(object sender, EventArgs e)
        {
            currFont    = fontDialog.Font;
            orgFontSize = currFont.Size;
        }

        #region Editor Events

        private Boolean inTheBrackets = false;

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            if (edit.TextArea.Caret.Line >= 2)
            {
                int lastLine  = edit.Document.Lines[edit.TextArea.Caret.Line - 2].EndOffset - 1;
                int currCaret = edit.TextArea.Caret.Offset;

                if (currCaret + 1 <= edit.Document.Text.Length && lastLine >= 0)
                {
                    if ((edit.Document.Text.Substring(lastLine, 1)  == "{" &&
                         edit.Document.Text.Substring(currCaret, 1) == "}") ||
                        (edit.Document.Text.Substring(lastLine, 1)  == "[" &&
                         edit.Document.Text.Substring(currCaret, 1) == "]") ||
                        (edit.Document.Text.Substring(lastLine, 1)  == "(" &&
                         edit.Document.Text.Substring(currCaret, 1) == ")")
                    )
                    {
                        inTheBrackets = true;
                    }
                    else
                    {
                        inTheBrackets = false;
                    }
                }
                else
                {
                    inTheBrackets = false;
                }
            }
            else
            {
                inTheBrackets = false;
            }

            updateStatusBar();
            UpdateMenuItem();
        }

        private void Document_UpdateFinished(object sender, EventArgs e)
        {
            if (isLoadFile)
            {
                currFileEncoding       = edit.Encoding?.EncodingName;
                currSyntaxHighlighting = (edit.SyntaxHighlighting is null ? "普通文本" : edit.SyntaxHighlighting.Name);
                if (!(currSyntaxHighlighting is null) &&
                    (currSyntaxHighlighting.Contains("C") || currSyntaxHighlighting.Contains("PHP") ||
                     currSyntaxHighlighting.Contains("Java")))
                {
                    if (Properties.Settings.Default.isAutoIndent == -1)
                    {
                        if (MessageBox.Show(LocRM.GetString("IsAutoIndent"), LocRM.GetString("$this.Text"),
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            AutoIndentMenuItem.Checked               = true;
                            Properties.Settings.Default.isAutoIndent = 1;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.isAutoIndent = 0;
                            Properties.Settings.Default.Save();
                        }
                    }
                    else if (Properties.Settings.Default.isAutoIndent == 1)
                    {
                        AutoIndentMenuItem.Checked = true;
                    }
                }

                isLoadFile = false;
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
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
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
            updateStatusBar();
            UpdateMenuItem();
        }

        private void TextArea_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (isLoadFile)
            {
                isLoadFile = false; //Restore to default
            }
            if (e.Key == Key.F6)
            {
                if (inTheBrackets && isCoding())
                {
                    String retChar   = "\r\n";
                    int    currCaret = 0;
                    switch (determineReturnStyle())
                    {
                        case "Error":
                        case "Windows (CRLF)":
                            retChar = "\r\n";
                            break;
                        case "Unix (LF)":
                            retChar = "\n";
                            break;
                        case "Macintosh (CR)":
                            retChar = "\r";
                            break;
                    }

                    currCaret = edit.TextArea.Caret.Offset;
                    edit.Document.Insert(currCaret, retChar);
                    edit.TextArea.Caret.Line--;
                    edit.Document.Insert(currCaret, "	");
                    edit.TextArea.Caret.Offset = edit.Document.Lines[edit.TextArea.Caret.Line - 1].EndOffset;
                }
            }

            updateStatusBar();
            UpdateMenuItem();
        }

        private void TextArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (isCoding())
            {
                
                String retChar   = "\r\n";
                int    currCaret = 0;
                int    currIndex = edit.TextArea.Caret.Offset - 1;
                switch (e.Text)
                {
                    case "{":
                        if (!(edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == "}"))
                        {
                            edit.Document.Insert(currIndex + 1, "}");
                        }

                        edit.TextArea.Caret.Offset--;
                        break;
                    case "[":
                        if (!(edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == "]"))
                        {
                            edit.Document.Insert(currIndex + 1, "]");
                        }

                        edit.TextArea.Caret.Offset--;
                        break;
                    case "(":
                        if (!(edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == ")")) { 
                            edit.Document.Insert(currIndex + 1, ")");
                            edit.TextArea.Caret.Offset--;
                        }
                        break;
                    case ")":
                        if (edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == ")")
                        {
                            edit.TextArea.Caret.Offset++;
                            e.Handled = true;
                        }

                        break;
                    case "}":
                        if (edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == "}")
                        {
                           // edit.TextArea.Caret.Offset++;
                            e.Handled = true;

                                switch (determineReturnStyle())
                                {
                                    case "Error":
                                    case "Windows (CRLF)":
                                        retChar = "\r\n";
                                        break;
                                    case "Unix (LF)":
                                        retChar = "\n";
                                        break;
                                    case "Macintosh (CR)":
                                        retChar = "\r";
                                        break;
                                }
                                edit.Document.BeginUpdate();
                                currCaret = edit.TextArea.Caret.Offset;
                                edit.Document.Insert(currCaret, retChar);
                            currCaret = edit.TextArea.Caret.Offset;
                                edit.Document.Insert(currCaret, retChar);
                                edit.TextArea.Caret.Line--;
                                
                                currCaret = edit.TextArea.Caret.Offset;
                                edit.Document.Insert(currCaret, "\t");
                                if (isCoding() && currIsAutoIndent)
                                {
                                    css.IndentLines(edit.Document, 0, edit.LineCount);
                                }
                            edit.TextArea.Caret.Offset = edit.Document.Lines[edit.TextArea.Caret.Line - 1].EndOffset;
                                edit.Document.EndUpdate();
                                e.Handled = true;
                            }

                        break;
                    case ";":

                        if (isCoding() && currIsAutoIndent)
                        {
                            css.IndentLines(edit.Document, 0, edit.LineCount);
                        }

                        break;
                    case "]":
                        if (edit.Text.Length > currIndex + 1 && edit.Text.Substring(currIndex + 1, 1) == "]")
                        {
                            edit.TextArea.Caret.Offset++;
                            e.Handled = true;
                        }

                        break;
                    case " ":
                        if (inTheBrackets)
                        {
                            switch (determineReturnStyle())
                            {
                                case "Error":
                                case "Windows (CRLF)":
                                    retChar = "\r\n";
                                    break;
                                case "Unix (LF)":
                                    retChar = "\n";
                                    break;
                                case "Macintosh (CR)":
                                    retChar = "\r";
                                    break;
                            }
                            edit.Document.BeginUpdate();
                            currCaret = edit.TextArea.Caret.Offset;
                            edit.Document.Insert(currCaret, retChar);
                            edit.TextArea.Caret.Line--;
                            
                            currCaret = edit.TextArea.Caret.Offset;
                            edit.Document.Insert(currCaret, "\t");
                            if (isCoding() && currIsAutoIndent)
                            {
                                css.IndentLines(edit.Document, 0, edit.LineCount);
                            }
                            edit.TextArea.Caret.Offset = edit.Document.Lines[edit.TextArea.Caret.Line - 1].EndOffset ;
                            edit.Document.EndUpdate();
                            e.Handled = true;
                        }

                        break;
                }
            }
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

        #endregion

        #region Util Functions

        private void replaceSelectionTextWith(string strTo)
        {
            if (HaveSelection())
            {
                //Sometime startPosition is bigger than endPosition, this is because you select text 
                //from back to front. REMEMBER, startPosition is the position you START to select.
                int Offset1 = edit.Document.GetOffset(edit.TextArea.Selection.StartPosition.Location);
                int Offset2 = edit.Document.GetOffset(edit.TextArea.Selection.EndPosition.Location);
                //So we have to detect which one is smaller, the smaller one is the start position (The ahead text offset)...
                int startOffset = Offset1 < Offset2 ? Offset1 : Offset2;
                edit.Document.BeginUpdate();
                edit.Document.Remove(startOffset, edit.TextArea.Selection.Length);
                edit.Document.Insert(startOffset,strTo);
                edit.Document.EndUpdate();
            }
        }

        public void WriteToFile(string path, string content)
        {
            FileStream   fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, edit.Encoding);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 获取当前本地时间戳
        /// </summary>
        /// <returns></returns>      
        public long GetCurrentTimeUnix()
        {
            TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long     t   = (long) cha.TotalSeconds;
            return t;
        }

        private void previewMarkDown()
        {
            String rootPath = "";
            if (edit.Document.FileName == "\\Untitled\\" || edit.Document.FileName == "" ||
                (edit.Document.FileName is null))
            {
                rootPath = System.Environment.GetEnvironmentVariable("TEMP");
            }
            else
            {
                rootPath = Path.GetDirectoryName(edit.Document.FileName);
            }

            String fileDisplayName = (edit.Document.FileName == "\\Untitled\\"
                ? LocRM.GetString("defaultTitle")
                : Path.GetFileNameWithoutExtension(edit.Document.FileName));
            rootPath = rootPath.EndsWith("\\") ? rootPath : rootPath + "\\";
            String fileName = rootPath             + fileDisplayName +
                              "_preview@"          +
                              GetCurrentTimeUnix() + ".html";
            String header = @"
<!DOCTYPE html>
<html>
<title>" + fileDisplayName;
            header += @"</title>

<xmp theme=""cerulean"" style=""display:none;"">
";
            String footer = @"
</xmp>

<script src=""http://strapdownjs.com/v/0.2/strapdown.js""></script>
</html>
";
            WriteToFile(fileName, header + edit.Text + footer);

            Process.Start(fileName);
        }

        //Thanks to https://blog.csdn.net/wrgoodliness/article/details/52703660
        String s;

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces, 0);
            int          count, rows;
            Graphics     g = e.Graphics; //获得绘图对象
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //像素偏移方式，像素在水平和垂直距离上均偏移若干个单位，以进行高速锯齿消除。
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            //也可以通过设置Graphics对不平平滑处理方式解决，代码如下： 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            SizeF sf = e.Graphics.MeasureString(s, currFont, e.MarginBounds.Size, stringFormat, out count, out rows);
            //MessageBox.Show("总长度：" + s.Length.ToString() + "#当页长度：" + count.ToString() + "#行数：" + rows.ToString());
            e.Graphics.DrawString(s.Substring(0, count), currFont, new SolidBrush(Color.Black), e.MarginBounds,
                                  stringFormat);
            s = s.Remove(0, count < s.Length ? count : s.Length);
            Debug.Print(s.Length.ToString());
            if (s.Length > 0)
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                s              = edit.Text;
            }
        }

        private Boolean isCoding()
        {
            return !(edit.SyntaxHighlighting is null);
        }

        private string determineReturnStyle()
        {
            try
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
            catch
            {
                return "Error";
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
                UndoMenuItem.Enabled  = true;
                RUndoMenuItem.Enabled = true;
            }
            else
            {
                UndoMenuItem.Enabled  = false;
                RUndoMenuItem.Enabled = false;
            }

            if (edit.CanRedo)
            {
                RedoMenuItem.Enabled  = true;
                RRedoMenuItem.Enabled = true;
            }
            else
            {
                RedoMenuItem.Enabled  = false;
                RRedoMenuItem.Enabled = false;
            }

            if (!File.Exists(edit.Document.FileName) || (edit.Document.FileName is null) ||
                edit.Document.FileName == ""         ||
                (edit.Document.FileName == "\\Untitled\\"))
            {
                reOpenMenuItem.Enabled = false;
            }
            else
            {
                reOpenMenuItem.Enabled = true;
            }

            if (!(edit.Document.FileName is null)          &&
                (edit.Document.FileName != "")             &&
                (edit.Document.FileName != "\\Untitled\\") &&
                Path.GetExtension(edit.Document.FileName) == ".md")
            {
                PreviewInWebMenuItem.Visible = true;
            }
            else
            {
                PreviewInWebMenuItem.Visible = false;
            }

            if (edit.Text != "")
            {
                FindMenuItem.Enabled     = true;
                FindNextMenuItem.Enabled = true;
                FindPrevMenuItem.Enabled = true;
                ReplaceMenuItem.Enabled  = true;
            }
            else
            {
                FindMenuItem.Enabled     = false;
                FindNextMenuItem.Enabled = false;
                FindPrevMenuItem.Enabled = false;
                ReplaceMenuItem.Enabled  = false;
            }

            if (HaveSelection())
            {
                RCutMenuItem.Enabled  = true;
                RCopyMenuItem.Enabled = true;
                RCutMenuItem.Text     = LocRM.GetString("CutMenuItem.Text");
                RCopyMenuItem.Text    = LocRM.GetString("CopyMenuItem.Text");
                CutMenuItem.Enabled   = true;
                CopyMenuItem.Enabled  = true;
                CutMenuItem.Text      = LocRM.GetString("CutMenuItem.Text");
                CopyMenuItem.Text     = LocRM.GetString("CopyMenuItem.Text");
            }
            else
            {
                RCutMenuItem.Enabled  = false;
                RCopyMenuItem.Enabled = false;
                RCutMenuItem.Text     = LocRM.GetString("CutWholeLine");
                RCopyMenuItem.Text    = LocRM.GetString("CopyWholeLine");
                CutMenuItem.Enabled   = false;
                CopyMenuItem.Enabled  = false;
                CutMenuItem.Text      = LocRM.GetString("CutWholeLine");
                CopyMenuItem.Text     = LocRM.GetString("CopyWholeLine");
            }

            if (edit.Text.Length > 0)
            {
                DeleteMenuItem.Enabled = true;
                RDeleteMenuItem.Enabled = true;
            }
            else
            {
                DeleteMenuItem.Enabled  = false;
                RDeleteMenuItem.Enabled = false;
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
                if ((edit.Document.FileName is null) ||
                    edit.Document.FileName == ""     ||
                    (edit.Document.FileName == "\\Untitled\\"))
                {
                    return saveAsFile();
                }
                else
                {
                    if (File.Exists(edit.Document.FileName) &&
                        File.GetAttributes(edit.Document.FileName).ToString().IndexOf("ReadOnly") != -1)
                    {
                        DialogResult dr = MessageBox.Show(LocRM.GetString("FileReadOnly"),
                                                          LocRM.GetString("$this.Text"), MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                File.SetAttributes(edit.Document.FileName, FileAttributes.Normal);
                                edit.Save(edit.Document.FileName);
                                File.SetAttributes(edit.Document.FileName, FileAttributes.ReadOnly);
                                hasSave = true;
                                return true;
                                break;
                            case DialogResult.No:
                                MessageBox.Show(LocRM.GetString("ReadOnlySaveAs"), LocRM.GetString("$this.Text"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return saveAsFile();
                                break;
                        }
                    }

                    if (!File.Exists(edit.Document.FileName))
                    {
                        if (MessageBox.Show(LocRM.GetString("FileNotExistWhileSaving"), LocRM.GetString("$this.Text"),
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            edit.Save(edit.Document.FileName);
                            hasSave = true;
                            return true;
                        }
                        else
                        {
                            return saveAsFile();
                        }
                    }

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
                ReSaveAs:
                DialogResult dr = saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    if (File.Exists(saveFileDialog.FileName) &&
                        File.GetAttributes(saveFileDialog.FileName).ToString().IndexOf("ReadOnly") != -1)
                    {
                        DialogResult dr2 = MessageBox.Show(LocRM.GetString("FileReadOnly"),
                                                           LocRM.GetString("$this.Text"), MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question);
                        switch (dr2)
                        {
                            case DialogResult.Yes:
                                File.SetAttributes(saveFileDialog.FileName, FileAttributes.Normal);
                                edit.Save(saveFileDialog.FileName);
                                File.SetAttributes(saveFileDialog.FileName, FileAttributes.ReadOnly);
                                edit.Load(saveFileDialog.FileName);
                                edit.Document.FileName = saveFileDialog.FileName;
                                hasSave                = true;
                                return true;
                                break;
                            case DialogResult.No:
                                MessageBox.Show(LocRM.GetString("ReadOnlySaveAs"), LocRM.GetString("$this.Text"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                goto ReSaveAs;
                                break;
                        }
                    }

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
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            else if (!hasSave)
            {
                //If file is unsaved....
                dr =
                    MessageBox.Show(string.Format(LocRM.GetString("saveQuestion"), currOpenedFile.fileName),
                                    LocRM.GetString("$this.Text"),
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        #endregion

        //To solve the repaint problem, but, sometimes it doesn't show the 
        //text at startup until I click or something else about UI changing happened,
        //this is not good.
//        protected override CreateParams CreateParams
//        {
//            get
//            {
//                CreateParams cp = base.CreateParams;
//                cp.ExStyle |= 0x02000000;
//                return cp;
//            }
//        }
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #region UI Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            //Try to fix high-dpi blurry
            this.AutoScaleMode = AutoScaleMode.Font;
            //Finally I upgrade to .Net 4.7 to solve this...

            reArrangeControl();
        }

        private async void frmMain_Shown(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(frmMain));

            #region TextEditor ctor

            edit = new TextEditor();

            edit.BorderBrush =
                new SolidColorBrush(System.Windows.Media.Color.FromRgb(160, 160, 160));
            edit.BorderThickness                =  new Thickness(0, 1, 0, 1);
            edit.TextChanged                    += Edit_TextChanged;
            edit.MouseDown                      += Edit_Click;
            edit.TextArea.MouseMove             += TextArea_MouseMove;
            edit.TextArea.PreviewTextInput      += TextArea_PreviewTextInput;
            edit.TextArea.KeyDown               += TextArea_KeyDown;
            edit.TextArea.KeyUp                 += TextArea_KeyUp;
            edit.Document.FileNameChanged       += Edit_FileNameChanged;
            edit.TextArea.MouseWheel            += TextArea_MouseWheel;
            edit.Document.UpdateStarted         += Document_UpdateStarted;
            edit.Document.UpdateFinished        += Document_UpdateFinished;
            edit.TextArea.Caret.PositionChanged += Caret_PositionChanged;

            #endregion

            #region DefaultSettings

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

            orgFontSize                                      = currFont.Size;
            edit.TextArea.Options.EnableTextDragDrop         = true;
            edit.Document.FileName                           = "\\Untitled\\";
            edit.ShowLineNumbers                             = true;
            edit.Encoding                                    = System.Text.Encoding.UTF8;
            edit.TextArea.Options.EnableRectangularSelection = true;

            switch (Properties.Settings.Default.IndentMode)
            {
                case 1:
                    currIndentMode = IndentMode.Mode2;
                    break;
                case 2:
                    currIndentMode = IndentMode.Mode4;
                    break;
                case 3:
                    currIndentMode = IndentMode.Mode8;
                    break;
            }

            isSpaceAsTab      = Properties.Settings.Default.isSpaceAsTab;
            isWordWrap        = Properties.Settings.Default.wordWrap;
            isShowColRuler    = Properties.Settings.Default.showColRuler;
            isShowControlChar = Properties.Settings.Default.showControlChar;
            isShowEOL         = Properties.Settings.Default.showEOL;
            isShowSpace       = Properties.Settings.Default.showSpace;
            isShowStatusBar   = Properties.Settings.Default.showStatusBar;
            isShowTab         = Properties.Settings.Default.showTab;
            //Add the default highlighting defines in AvalonEdit to the status bar DropDownMenu
            foreach (IHighlightingDefinition hr in ICSharpCode
                                                   .AvalonEdit.Highlighting.HighlightingManager.Instance
                                                   .HighlightingDefinitions)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Name         =  "MenuItem" + hr.Name;
                subMenu.Text         =  hr.Name;
                subMenu.CheckOnClick =  true;
                subMenu.Click        += SyntaxMenuItem_Click;
                HighLightTypeMenuItem.DropDownItems.Add(subMenu);
            }

            //Don't forget to add the normal text
            ToolStripMenuItem subMenuLast = new ToolStripMenuItem();
            subMenuLast.Name         =  "MenuItemNormal";
            subMenuLast.Text         =  LocRM.GetString("NormalText");
            subMenuLast.CheckOnClick =  true;
            subMenuLast.Click        += SyntaxMenuItem_Click;
            HighLightTypeMenuItem.DropDownItems.Add(subMenuLast);
            //And don't forget to set the default one...
            currSyntaxHighlighting = LocRM.GetString("NormalText");

            #endregion

            updateStatusBar();
            UpdateMenuItem();

            ElementHost host = new ElementHost
            {
                Dock  = DockStyle.Fill,
                Child = edit
            };
            Container.Controls.Add(host);
            this.ResumeLayout(true);
            this.WindowState = FormWindowState.Normal;


            if (Environment.GetCommandLineArgs().Length > 1    && Environment.GetCommandLineArgs()[1] != "" &&
                !(Environment.GetCommandLineArgs()[1] is null) && File.Exists(Environment.GetCommandLineArgs()[1]))
            {
                edit.SelectionLength   = 0;
                edit.Document.FileName = Environment.GetCommandLineArgs()[1];
                readFileToEdit(await textReaderTask);

                //edit.Load(await test);
            }

            this.Refresh();
        }


        private void readFileToEdit(TextWithEncoding t)
        {
            edit.Text     = t.Content;
            LoadTime.Text = LocRM.GetString("LoadTime") + ":" + sw.ElapsedMilliseconds.ToString() + " ms";
            sw.Reset();
            edit.SetCurrentValue(TextEditor.IsModifiedProperty, false);
            edit.SetCurrentValue(TextEditor.EncodingProperty, (object) t.TextEncoding);
            this.Refresh();
        }

        async Task<TextWithEncoding> ReadFileAsync(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BufferedStream bufferStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = FileReader.OpenStream(bufferStream, Encoding.UTF8))
                    {
                        string result = await streamReader.ReadToEndAsync();
                        txt.Content      = result;
                        txt.TextEncoding = streamReader.CurrentEncoding;
                        return txt;
                    }
                }
            }
        }

        private void anotherVoid()
        {
            SearchPanel.Install(edit.TextArea);
        }

        private async void openFileMenuItem_Click(object sender, EventArgs e)
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
                    sw.Start();
                    textReaderTask = ReadFileAsync(openFileDialog.FileName);
                    readFileToEdit(await textReaderTask);
                    //                    edit.Load(openFileDialog.FileName);
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
            else if (edit.CaretOffset-1 >= 0 && edit.Text.Length > 0)
                edit.Document.Remove(edit.CaretOffset-1, 1);
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

        private void PageSetupMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.EnableMetric = true;
            pageSetupDialog.Document     = printDocument;
            pageSetupDialog.ShowDialog();
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            //   This setting ruins the document printing...
            //   printDocument.OriginAtMargins = true;
            printDocument.DocumentName  = edit.Document.FileName;
            printDialog.Document        = printDocument;
            printPreviewDialog.Document = printDocument;
            s                           = edit.Text;

            if (printDialog.ShowDialog() == DialogResult.OK)

            {
                try

                {
                    printPreviewDialog.ShowDialog();
                    if (MessageBox.Show(LocRM.GetString("ContinuePrint"), LocRM.GetString("$this.Text"),
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        printDocument.Print();
                }

                catch (Exception excep)

                {
                    MessageBox.Show(excep.Message, LocRM.GetString("PrintError"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                }
            }
        }

        private async void reOpenMenuItem_Click(object sender, EventArgs e)
        {
            String preOpenedDocName = edit.Document.FileName;
            edit.Document.FileName = "\\Untitled\\"; //To ensure triggering FileNameChanged event
            edit.SelectionLength   = 0;
            edit.Document.FileName =
                preOpenedDocName; //If not, open the same name file again, will not trigger this event.
            sw.Start();
            textReaderTask = ReadFileAsync(preOpenedDocName);
            readFileToEdit(await textReaderTask);
            //            edit.Load(preOpenedDocName);
        }

        private void ShowHelpMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.cadou-tech.xyz/");
        }

        private void SendIssusMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/XHSofts/NotepadSharp/issues/new");
        }

        private void IsShowStatusBarMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void IsShowStatusBarMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowStatusBar = IsShowStatusBarMenuItem.Checked;
        }

        private void ColRulerMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowColRuler = ColRulerMenuItem.Checked;
        }

        private void ControlCharMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowControlChar = ControlCharMenuItem.Checked;
        }

        private void EOLMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void EOLMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowEOL = EOLMenuItem.Checked;
        }

        private void SpaceMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowSpace = SpaceMenuItem.Checked;
        }

        private void TabMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowTab = TabMenuItem.Checked;
        }

        private void ZoomInMenuItem_Click(object sender, EventArgs e)
        {
            currZoomSize += 10;
        }

        private void ZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            currZoomSize -= 10;
        }

        private void RestoreZoomMenuItem_Click(object sender, EventArgs e)
        {
            currZoomSize = 100;
        }

        private void AutoIndentMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            currIsAutoIndent = AutoIndentMenuItem.Checked;
        }

        private void SyntaxMenuItem_Click(object sender, EventArgs e)
        {
            currSyntaxHighlighting = ((ToolStripMenuItem) sender).Text;
        }

        private void DebugMenu_Click(object sender, EventArgs e)
        {
            replaceSelectionTextWith("1233333");
        }

        private void Indent2MenuItem_Click(object sender, EventArgs e)
        {
            currIndentMode          = IndentMode.Mode2;
            Indent2MenuItem.Checked = true;
            Indent4MenuItem.Checked = false;
            Indent8MenuItem.Checked = false;
        }

        private void Indent4MenuItem_Click(object sender, EventArgs e)
        {
            currIndentMode          = IndentMode.Mode4;
            Indent2MenuItem.Checked = false;
            Indent4MenuItem.Checked = true;
            Indent8MenuItem.Checked = false;
        }

        private void Indent8MenuItem_Click(object sender, EventArgs e)
        {
            currIndentMode          = IndentMode.Mode8;
            Indent2MenuItem.Checked = false;
            Indent4MenuItem.Checked = false;
            Indent8MenuItem.Checked = true;
        }

        private void UseSpaceAsTabMenuItem_Click(object sender, EventArgs e)
        {
            isSpaceAsTab = UseSpaceAsTabMenuItem.Checked;
        }

        static frmFindReplace frmFind = null;

        private void ReplaceMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFind is null)
            {
                frmFind      = new frmFindReplace(edit);
                frmFind.Left = this.Left + 5;
                frmFind.Top  = this.Top  + 44;
            }

            frmFindReplace.ShowForReplace(frmFind, edit);
        }

        private void FindMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFind is null)
            {
                frmFind      = new frmFindReplace(edit);
                frmFind.Left = this.Left + 5;
                frmFind.Top  = this.Top  + 44;
            }

            frmFindReplace.ShowForFind(frmFind, edit);
        }

        private void FindNextMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFind is null)
            {
                frmFind      = new frmFindReplace(edit);
                frmFind.Left = this.Left + 5;
                frmFind.Top  = this.Top  + 44;
                frmFindReplace.ShowForFind(frmFind, edit);
            }
            else
            {
                frmFind.FindNextClick(null, null);
            }
        }

        private void FindPrevMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFind is null)
            {
                frmFind      = new frmFindReplace(edit);
                frmFind.Left = this.Left + 5;
                frmFind.Top  = this.Top  + 44;
                frmFindReplace.ShowForFind(frmFind, edit);
            }
            else
            {
                frmFind.btnFindPrev_Click(null, null);
            }
        }

        private void PreviewInWebMenuItem_Click(object sender, EventArgs e)
        {
            previewMarkDown();
        }

        private void RShowControlCharMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            isShowControlChar = RShowControlCharMenuItem.Checked;
        }

        private void RUndoMenuItem_Click(object sender, EventArgs e)
        {
            UndoMenuItem_Click(sender, e);
        }

        private void RRedoMenuItem_Click(object sender, EventArgs e)
        {
            RedoMenuItem_Click(sender, e);
        }

        private void RCutMenuItem_Click(object sender, EventArgs e)
        {
            CutMenuItem_Click(sender, e);
        }

        private void RCopyMenuItem_Click(object sender, EventArgs e)
        {
            CopyMenuItem_Click(sender, e);
        }

        private void RPasteMenuItem_Click(object sender, EventArgs e)
        {
            PasteMenuItem_Click(sender, e);
        }

        private void RDeleteMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMenuItem_Click(sender, e);
        }

        private void RSelectAllMenuItem_Click(object sender, EventArgs e)
        {
            SelectAllMenuItem_Click(sender, e);
        }

        private void RUseBingMenuItem_Click(object sender, EventArgs e)
        {
            UseBingMenuItem_Click(sender, e);
        }

        private void RUrlEncodeMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(HttpUtility.UrlEncode(edit.TextArea.Selection.GetText(), edit.Encoding));
            }
        }

        private void RUrlDecodeMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(HttpUtility.UrlDecode(edit.TextArea.Selection.GetText(), edit.Encoding));
            }
        }

        private void RBase64EncodeMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(Utils.EncodeBase64(edit.TextArea.Selection.GetText(), edit.Encoding));
            }
        }

        private void RBase64DecodeMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(Utils.DecodeBase64(edit.TextArea.Selection.GetText(), edit.Encoding));
            }
        }

        private void RUniEncodeType1_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(Utils.String2Unicode(edit.TextArea.Selection.GetText(), false));
            }
        }

        private void RUniEncodeType2_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(Utils.String2Unicode(edit.TextArea.Selection.GetText(), true));
            }
        }

        private void RUnicodeDecodeMenuItem_Click(object sender, EventArgs e)
        {
            if (HaveSelection())
            {
                replaceSelectionTextWith(Utils.Unicode2String(edit.TextArea.Selection.GetText()));
            }
        }
        #endregion


    }
}