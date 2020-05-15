using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NotepadSharp
{
    public partial class frmGoto : Form
    {
        readonly ResourceManager LocRM = new ResourceManager("NotepadSharp.frmGoto", typeof(frmGoto).Assembly);
        
        private int _lineGoto;
        public int lineGoto
        {
            get => _lineGoto;
            set
            {
                _lineGoto = value;
                txtLine.Text = value.ToString();
            }
        }
        public frmGoto(int lineNumber)
        {
            InitializeComponent();
            lineGoto = lineNumber;
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtLine.Text) <= 0)
                {
                    MessageBox.Show(this, string.Format(LocRM.GetString("errorSubmit"), Int32.Parse(txtLine.Text)),
                                    LocRM.GetString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                lineGoto     = Int32.Parse(txtLine.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (OverflowException eX)
            {
                MessageBox.Show(this, string.Format(LocRM.GetString("overflowError"), txtLine.Text),
                                LocRM.GetString("$this.Text"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmGoto_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(frmGoto));
            txtLine.SelectAll();
        }

        private void txtLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                var Sender = (TextBox)sender;
                controlToolTip.Show(LocRM.GetString("errorTyping"), Sender);
                e.Handled = true;
            }
        }
    }
}
