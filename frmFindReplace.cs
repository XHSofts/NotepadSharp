using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using MessageBox = System.Windows.Forms.MessageBox;

namespace NotepadSharp
{
    //From https://www.codeproject.com/Tips/768408/A-Find-and-Replace-Tool-for-AvalonEdit
    //Thanks
    public partial class frmFindReplace : Form
    {
        ResourceManager LocRM = new ResourceManager("NotepadSharp.frmFindReplace", typeof(frmFindReplace).Assembly);

        private static string textToFind    = "";
        private static bool   caseSensitive = Properties.Settings.Default.findCaseSensitive;
        private static bool   wholeWord     = Properties.Settings.Default.findWholeWord;
        private static bool   useRegex      = Properties.Settings.Default.findUseRegex;
        private static bool   useWildcards  = Properties.Settings.Default.findUseWildcards;
        private static bool   searchUp      = Properties.Settings.Default.findSearchUp;

        private TextEditor editor;

        public frmFindReplace(TextEditor editor)
        {
            InitializeComponent();
            this.editor = editor;

            txtFind.Text            = txtFind2.Text = textToFind;
            cbCaseSensitive.Checked = caseSensitive;
            cbWholeWord.Checked     = wholeWord;
            cbRegex.Checked         = useRegex;
            cbWildcards.Checked     = useWildcards;
            cbSearchUp.Checked      = searchUp;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void frmFindReplace_FormClosed(object sender, FormClosedEventArgs e)
        {
            //textToFind                                    = txtFind2.Text;
            Properties.Settings.Default.findCaseSensitive = cbCaseSensitive.Checked;
            Properties.Settings.Default.findWholeWord     = cbWholeWord.Checked;
            Properties.Settings.Default.findUseRegex      = cbRegex.Checked;
            Properties.Settings.Default.findUseWildcards  = cbWildcards.Checked;
            Properties.Settings.Default.findSearchUp      = cbSearchUp.Checked;
            Properties.Settings.Default.Save();
//            theDialog = null;
        }

        public void btnFindPrev_Click(object sender, EventArgs e)
        {
            if (!FindNext(txtFind2.Text, true))
            {
                MessageBox.Show(String.Format(LocRM.GetString("TextNotFound"), txtFind2.Text),
                                LocRM.GetString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SystemSounds.Beep.Play();
            }
        }

        public void FindNextClick(object sender, EventArgs e)
        {
            if (!FindNext(txtFind.Text, false))
            {
                MessageBox.Show(String.Format(LocRM.GetString("TextNotFound"), txtFind.Text),
                                LocRM.GetString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SystemSounds.Beep.Play();
            }
        }

        private void btnFindPrev2_Click(object sender, EventArgs e)
        {
            if (!FindNext(txtFind2.Text, true))
            {
                MessageBox.Show(String.Format(LocRM.GetString("TextNotFound"), txtFind2.Text),
                                LocRM.GetString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SystemSounds.Beep.Play();
            }
        }

        public void FindNext2Click(object sender, EventArgs e)
        {
            if (!FindNext(txtFind2.Text, false))
            {
                MessageBox.Show(String.Format(LocRM.GetString("TextNotFound"), txtFind2.Text),
                                LocRM.GetString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SystemSounds.Beep.Play();
            }
        }

        private void ReplaceClick(object sender, EventArgs e)
        {
            Regex  regex    = GetRegEx(txtFind2.Text);
            string input    = editor.Text.Substring(editor.SelectionStart, editor.SelectionLength);
            Match  match    = regex.Match(input);
            bool   replaced = false;
            if (match.Success && match.Index == 0 && match.Length == input.Length)
            {
                editor.Document.Replace(editor.SelectionStart, editor.SelectionLength, txtReplace.Text);
                replaced = true;
            }

            if (!FindNext(txtFind2.Text, false) && !replaced)
                SystemSounds.Beep.Play();
        }

        private void ReplaceAllClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format(LocRM.GetString("replaceConfirm"), txtFind2.Text, txtReplace.Text),
                                LocRM.GetString("$this.Text"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                Regex regex  = GetRegEx(txtFind2.Text, true);
                int   offset = 0;
                editor.BeginChange();
                foreach (Match match in regex.Matches(editor.Text))
                {
                    editor.Document.Replace(offset + match.Index, match.Length, txtReplace.Text);
                    offset += txtReplace.Text.Length - match.Length;
                }

                editor.EndChange();
            }
        }

        private bool FindNext(string textToFind, Boolean searchUp)
        {
            Regex regex = GetRegEx(textToFind, searchUp);
            int start = regex.Options.HasFlag(RegexOptions.RightToLeft)
                ? editor.SelectionStart
                : editor.SelectionStart + editor.SelectionLength;
            Match match = regex.Match(editor.Text, start);

            if (!match.Success) // start again from beginning or end
            {
                if (regex.Options.HasFlag(RegexOptions.RightToLeft))
                    match = regex.Match(editor.Text, editor.Text.Length);
                else
                    match = regex.Match(editor.Text, 0);
            }

            if (match.Success)
            {
                editor.Select(match.Index, match.Length);
                TextLocation loc = editor.Document.GetLocation(match.Index);
                editor.ScrollTo(loc.Line, loc.Column);
            }

            return match.Success;
        }

        private Regex GetRegEx(string textToFind, bool leftToRight = false)
        {
            RegexOptions options = RegexOptions.None;
            if ( /*cbSearchUp.Checked == true && !*/leftToRight)
                options |= RegexOptions.RightToLeft;
            if (cbCaseSensitive.Checked == false)
                options |= RegexOptions.IgnoreCase;

            if (cbRegex.Checked == true)
            {
                return new Regex(textToFind, options);
            }
            else
            {
                string pattern = Regex.Escape(textToFind);
                if (cbWildcards.Checked == true)
                    pattern = pattern.Replace("\\*", ".*").Replace("\\?", ".");
                if (cbWholeWord.Checked == true)
                    pattern = "\\b" + pattern + "\\b";
                return new Regex(pattern, options);
            }
        }

        private static frmFindReplace theDialog = null;

        public static void ShowForReplace(frmFindReplace newFrm, TextEditor editor)
        {
            if (theDialog == null)
            {
                theDialog = newFrm;
            }

            theDialog.mainTab.SelectedIndex = 1;
            theDialog.Height                = 329;
            theDialog.mainTab.Height        = 209;
            theDialog.panelCheckBox.Top     = 221;
            theDialog.Show();
            theDialog.Activate();
            theDialog.txtFind2.Focus();
            if (!editor.TextArea.Selection.IsMultiline && editor.TextArea.Selection.GetText() != "")
            {
                theDialog.txtFind.Text = theDialog.txtFind2.Text = editor.TextArea.Selection.GetText();
                theDialog.txtFind.SelectAll();
                theDialog.txtFind2.SelectAll();
                theDialog.txtFind2.Focus();
            }
        }

        public static void ShowForFind(frmFindReplace newFrm, TextEditor editor)
        {
            if (theDialog == null)
            {
                theDialog = newFrm;
            }

            theDialog.mainTab.SelectedIndex = 0;
            theDialog.Height                = 279;
            theDialog.mainTab.Height        = 156;
            theDialog.panelCheckBox.Top     = 174;
            theDialog.Show();
            theDialog.Activate();
            theDialog.txtFind.Focus();
            if (!editor.TextArea.Selection.IsMultiline && editor.TextArea.Selection.GetText() != "")
            {
                theDialog.txtFind.Text = theDialog.txtFind2.Text = editor.TextArea.Selection.GetText();
                theDialog.txtFind.SelectAll();
                theDialog.txtFind2.SelectAll();
                theDialog.txtFind.Focus();
            }
        }

        private void txtFind2_TextChanged(object sender, EventArgs e)
        {
            txtFind.Text = txtFind2.Text;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            txtFind2.Text = txtFind.Text;
        }

        private void frmFindReplace_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(frmFindReplace));
        }

        private void frmFindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //textToFind                                    = txtFind2.Text;
            Properties.Settings.Default.findCaseSensitive = cbCaseSensitive.Checked;
            Properties.Settings.Default.findWholeWord     = cbWholeWord.Checked;
            Properties.Settings.Default.findUseRegex      = cbRegex.Checked;
            Properties.Settings.Default.findUseWildcards  = cbWildcards.Checked;
            Properties.Settings.Default.findSearchUp      = cbSearchUp.Checked;
            Properties.Settings.Default.Save();
            Hide();
            e.Cancel = true;
        }

        private void mainTab_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTab.SelectedIndex == 0)
            {
                txtFind.Focus();
                theDialog.Height  = 279;
                mainTab.Height    = 156;
                panelCheckBox.Top = 174;
            }
            else
            {
                theDialog.Height  = 329;
                mainTab.Height    = 209;
                panelCheckBox.Top = 221;
                if (txtFind2.Text != "")
                    txtReplace.Focus();
                else
                    txtFind2.Focus();
            }
        }
    }
}