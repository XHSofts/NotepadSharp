namespace NotepadSharp
{
    partial class frmGoto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.lblGoto = new System.Windows.Forms.Label();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.controlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(26, 35);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(281, 25);
            this.txtLine.TabIndex = 0;
            this.txtLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLine_KeyPress);
            // 
            // lblGoto
            // 
            this.lblGoto.AutoSize = true;
            this.lblGoto.Location = new System.Drawing.Point(12, 9);
            this.lblGoto.Name = "lblGoto";
            this.lblGoto.Size = new System.Drawing.Size(52, 15);
            this.lblGoto.TabIndex = 1;
            this.lblGoto.Text = "行号：";
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(117, 66);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(92, 25);
            this.btnGoto.TabIndex = 3;
            this.btnGoto.Text = "跳转";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(215, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // controlToolTip
            // 
            this.controlToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // frmGoto
            // 
            this.AcceptButton = this.btnGoto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(319, 103);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.lblGoto);
            this.Controls.Add(this.txtLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "跳转到...";
            this.Load += new System.EventHandler(this.frmGoto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label lblGoto;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip controlToolTip;
    }
}