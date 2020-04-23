using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
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
        private int _currZoomSize=100;
        private int currZoomSize
        {
            get { return _currZoomSize; }
            set
            {
                if (value > 500 || value < 50)
                {
                    return;
                }
                _currZoomSize = value;
                zoomStatus.Text = value + "%";
                Font newFont = new Font(edit.Font.FontFamily, Convert.ToInt32(Math.Round(orgFontSize * ((double)value/100))), edit.Font.Style, edit.Font.Unit, edit.Font.GdiCharSet);
                edit.Font = newFont;
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
                orgFontSize = value.Size;
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
                _currCaretLine = value+1;
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
                _currCaretColumn = value+1;
                cursorStatus.Text = string.Format(LocRM.GetString("LineColumnStatus"), _currCaretLine.ToString(),
                                                  _currCaretColumn.ToString());
            }
        }

        public frmMain()
        {
            InitializeComponent();

            //            edit                  =  new TextEditor();
            //            editHost.Child        =  edit;
            edit.TextChanged                            += Edit_TextChanged;
            edit.ActiveTextAreaControl.TextArea.Click   += Edit_Click;
            edit.ActiveTextAreaControl.TextArea.KeyDown += TextArea_KeyDown;
            edit.ActiveTextAreaControl.TextArea.KeyUp += TextArea_KeyUp;
            edit.ActiveTextAreaControl.Scroll           += ActiveTextAreaControl_Scroll;
            edit.FileNameChanged                        += Edit_FileNameChanged;
            edit.MouseWheel += Edit_MouseWheel;
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
            FileStream   fs = new FileStream(edit.FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            currFileEncoding = AutoEncoding(br.ReadBytes(4)).EncodingName;

            br.Close();
            fs.Close();
            currOpenedFIle = new FileObject(System.IO.Path.GetFileName(edit.FileName), edit.FileName, System.IO.Path.GetExtension(edit.FileName));
        }

        private void TextArea_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            currPressedKey = e.KeyCode.ToString();
            updateStatusBar();
        }
        private void TextArea_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            currPressedKey = "";
            updateStatusBar();
        }
        private void ActiveTextAreaControl_Scroll(object sender, ScrollEventArgs e)
        {
            updateStatusBar();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            updateStatusBar();
        }

        private void Edit_TextChanged(object sender, EventArgs e)
        {
            updateStatusBar();
        }

        private void updateStatusBar()
        {
            currCaretLine   = edit.ActiveTextAreaControl.Caret.Line;
            currCaretColumn = edit.ActiveTextAreaControl.Caret.Column;

        }

        public static byte[] FileToByte(string fileUrl)
        {
            try
            {
                using (FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteArray = new byte[fs.Length];
                    fs.Read(byteArray, 0, byteArray.Length);
                    return byteArray;
                }
            }
            catch
            {
                return null;
            }
        }

        private static Encoding AutoEncoding(byte[] bom)
        {
            if (bom.Length != 4)
            {
                throw new ArgumentException("EncodingScrutator.AutoEncoding 参数大小不等于4");
            }

            // Analyze the BOM

            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76)
                return Encoding.UTF7; //85 116 102 55    //utf7 aa 97 97 0 0
            //utf7 编码 = 43 102 120 90

            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
                return Encoding.UTF8; //无签名 117 116 102 56
            // 130 151 160 231
            if (bom[0] == 0xff && bom[1] == 0xfe)
                return Encoding.Unicode; //UTF-16LE

            if (bom[0] == 0xfe && bom[1] == 0xff)
                return Encoding.BigEndianUnicode; //UTF-16BE

            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;

            return Encoding.ASCII; //如果返回ASCII可能是GBK、无签名 utf8
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
                this.Text = currTitleName + " - " + LocRM.GetString("$this.Text");
            }
            else
            {
                this.Text = LocRM.GetString("defaultTitle") + " - " + LocRM.GetString("$this.Text");
            }
        }

        private void rearrangeControl()
        {
            foreach (ToolStripItem c in bottomStatusBar.Items)
            {
                c.Alignment = ToolStripItemAlignment.Right;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            rearrangeControl();
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
            currOpenedFIle = new FileObject(LocRM.GetString("defaultTitle"), "", ".txt");
            edit.ShowLineNumbers = true;

        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName))
            {

                edit.LoadFile(openFileDialog.FileName);
            }
        }
    }
}