namespace NotepadSharp
{
    partial class frmFindReplace
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
            this.mainTab = new System.Windows.Forms.TabControl();
            this.FindTab = new System.Windows.Forms.TabPage();
            this.btnFindPrev = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lbl2Find = new System.Windows.Forms.Label();
            this.ReplaceTab = new System.Windows.Forms.TabPage();
            this.btnFindPrev2 = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnFindNext2 = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.lblReplaceTo = new System.Windows.Forms.Label();
            this.txtFind2 = new System.Windows.Forms.TextBox();
            this.lblFind2 = new System.Windows.Forms.Label();
            this.cbCaseSensitive = new System.Windows.Forms.CheckBox();
            this.cbWholeWord = new System.Windows.Forms.CheckBox();
            this.cbRegex = new System.Windows.Forms.CheckBox();
            this.cbWildcards = new System.Windows.Forms.CheckBox();
            this.cbSearchUp = new System.Windows.Forms.CheckBox();
            this.panelCheckBox = new System.Windows.Forms.Panel();
            this.mainTab.SuspendLayout();
            this.FindTab.SuspendLayout();
            this.ReplaceTab.SuspendLayout();
            this.panelCheckBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.FindTab);
            this.mainTab.Controls.Add(this.ReplaceTab);
            this.mainTab.Location = new System.Drawing.Point(2, 10);
            this.mainTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(352, 170);
            this.mainTab.TabIndex = 0;
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.mainTab_SelectedIndexChanged);
            this.mainTab.TabIndexChanged += new System.EventHandler(this.mainTab_TabIndexChanged);
            // 
            // FindTab
            // 
            this.FindTab.Controls.Add(this.btnFindPrev);
            this.FindTab.Controls.Add(this.btnFindNext);
            this.FindTab.Controls.Add(this.txtFind);
            this.FindTab.Controls.Add(this.lbl2Find);
            this.FindTab.Location = new System.Drawing.Point(4, 22);
            this.FindTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindTab.Name = "FindTab";
            this.FindTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindTab.Size = new System.Drawing.Size(344, 144);
            this.FindTab.TabIndex = 0;
            this.FindTab.Text = "查找";
            this.FindTab.UseVisualStyleBackColor = true;
            // 
            // btnFindPrev
            // 
            this.btnFindPrev.Location = new System.Drawing.Point(127, 65);
            this.btnFindPrev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFindPrev.Name = "btnFindPrev";
            this.btnFindPrev.Size = new System.Drawing.Size(99, 26);
            this.btnFindPrev.TabIndex = 3;
            this.btnFindPrev.Text = "查找上一个";
            this.btnFindPrev.UseVisualStyleBackColor = true;
            this.btnFindPrev.Click += new System.EventHandler(this.btnFindPrev_Click);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(230, 65);
            this.btnFindNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(99, 26);
            this.btnFindNext.TabIndex = 2;
            this.btnFindNext.Text = "查找下一个";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.FindNextClick);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(12, 24);
            this.txtFind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(318, 21);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lbl2Find
            // 
            this.lbl2Find.AutoSize = true;
            this.lbl2Find.Location = new System.Drawing.Point(6, 10);
            this.lbl2Find.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl2Find.Name = "lbl2Find";
            this.lbl2Find.Size = new System.Drawing.Size(101, 12);
            this.lbl2Find.TabIndex = 0;
            this.lbl2Find.Text = "要查找的字符串：";
            // 
            // ReplaceTab
            // 
            this.ReplaceTab.Controls.Add(this.btnFindPrev2);
            this.ReplaceTab.Controls.Add(this.btnReplaceAll);
            this.ReplaceTab.Controls.Add(this.btnReplace);
            this.ReplaceTab.Controls.Add(this.btnFindNext2);
            this.ReplaceTab.Controls.Add(this.txtReplace);
            this.ReplaceTab.Controls.Add(this.lblReplaceTo);
            this.ReplaceTab.Controls.Add(this.txtFind2);
            this.ReplaceTab.Controls.Add(this.lblFind2);
            this.ReplaceTab.Location = new System.Drawing.Point(4, 22);
            this.ReplaceTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReplaceTab.Name = "ReplaceTab";
            this.ReplaceTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReplaceTab.Size = new System.Drawing.Size(344, 144);
            this.ReplaceTab.TabIndex = 1;
            this.ReplaceTab.Text = "替换";
            this.ReplaceTab.UseVisualStyleBackColor = true;
            // 
            // btnFindPrev2
            // 
            this.btnFindPrev2.Location = new System.Drawing.Point(12, 106);
            this.btnFindPrev2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFindPrev2.Name = "btnFindPrev2";
            this.btnFindPrev2.Size = new System.Drawing.Size(78, 24);
            this.btnFindPrev2.TabIndex = 9;
            this.btnFindPrev2.Text = "查找上一个";
            this.btnFindPrev2.UseVisualStyleBackColor = true;
            this.btnFindPrev2.Click += new System.EventHandler(this.btnFindPrev2_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(254, 106);
            this.btnReplaceAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(76, 24);
            this.btnReplaceAll.TabIndex = 8;
            this.btnReplaceAll.Text = "替换全部";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.ReplaceAllClick);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(176, 106);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(74, 24);
            this.btnReplace.TabIndex = 7;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.ReplaceClick);
            // 
            // btnFindNext2
            // 
            this.btnFindNext2.Location = new System.Drawing.Point(94, 106);
            this.btnFindNext2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFindNext2.Name = "btnFindNext2";
            this.btnFindNext2.Size = new System.Drawing.Size(78, 24);
            this.btnFindNext2.TabIndex = 6;
            this.btnFindNext2.Text = "查找下一个";
            this.btnFindNext2.UseVisualStyleBackColor = true;
            this.btnFindNext2.Click += new System.EventHandler(this.FindNext2Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(12, 74);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(318, 21);
            this.txtReplace.TabIndex = 5;
            // 
            // lblReplaceTo
            // 
            this.lblReplaceTo.AutoSize = true;
            this.lblReplaceTo.Location = new System.Drawing.Point(6, 60);
            this.lblReplaceTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReplaceTo.Name = "lblReplaceTo";
            this.lblReplaceTo.Size = new System.Drawing.Size(53, 12);
            this.lblReplaceTo.TabIndex = 4;
            this.lblReplaceTo.Text = "替换为：";
            // 
            // txtFind2
            // 
            this.txtFind2.Location = new System.Drawing.Point(12, 24);
            this.txtFind2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFind2.Name = "txtFind2";
            this.txtFind2.Size = new System.Drawing.Size(318, 21);
            this.txtFind2.TabIndex = 3;
            this.txtFind2.TextChanged += new System.EventHandler(this.txtFind2_TextChanged);
            // 
            // lblFind2
            // 
            this.lblFind2.AutoSize = true;
            this.lblFind2.Location = new System.Drawing.Point(6, 10);
            this.lblFind2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFind2.Name = "lblFind2";
            this.lblFind2.Size = new System.Drawing.Size(101, 12);
            this.lblFind2.TabIndex = 2;
            this.lblFind2.Text = "要查找的字符串：";
            // 
            // cbCaseSensitive
            // 
            this.cbCaseSensitive.AutoSize = true;
            this.cbCaseSensitive.Location = new System.Drawing.Point(10, 5);
            this.cbCaseSensitive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCaseSensitive.Name = "cbCaseSensitive";
            this.cbCaseSensitive.Size = new System.Drawing.Size(84, 16);
            this.cbCaseSensitive.TabIndex = 1;
            this.cbCaseSensitive.Text = "区分大小写";
            this.cbCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // cbWholeWord
            // 
            this.cbWholeWord.AutoSize = true;
            this.cbWholeWord.Location = new System.Drawing.Point(10, 23);
            this.cbWholeWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbWholeWord.Name = "cbWholeWord";
            this.cbWholeWord.Size = new System.Drawing.Size(72, 16);
            this.cbWholeWord.TabIndex = 2;
            this.cbWholeWord.Text = "全字匹配";
            this.cbWholeWord.UseVisualStyleBackColor = true;
            // 
            // cbRegex
            // 
            this.cbRegex.AutoSize = true;
            this.cbRegex.Location = new System.Drawing.Point(122, 5);
            this.cbRegex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.Size = new System.Drawing.Size(108, 16);
            this.cbRegex.TabIndex = 3;
            this.cbRegex.Text = "使用正则表达式";
            this.cbRegex.UseVisualStyleBackColor = true;
            // 
            // cbWildcards
            // 
            this.cbWildcards.AutoSize = true;
            this.cbWildcards.Location = new System.Drawing.Point(122, 23);
            this.cbWildcards.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbWildcards.Name = "cbWildcards";
            this.cbWildcards.Size = new System.Drawing.Size(84, 16);
            this.cbWildcards.TabIndex = 4;
            this.cbWildcards.Text = "使用通配符";
            this.cbWildcards.UseVisualStyleBackColor = true;
            // 
            // cbSearchUp
            // 
            this.cbSearchUp.AutoSize = true;
            this.cbSearchUp.Location = new System.Drawing.Point(298, 213);
            this.cbSearchUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSearchUp.Name = "cbSearchUp";
            this.cbSearchUp.Size = new System.Drawing.Size(72, 16);
            this.cbSearchUp.TabIndex = 5;
            this.cbSearchUp.Text = "向上搜索";
            this.cbSearchUp.UseVisualStyleBackColor = true;
            this.cbSearchUp.Visible = false;
            // 
            // panelCheckBox
            // 
            this.panelCheckBox.Controls.Add(this.cbWildcards);
            this.panelCheckBox.Controls.Add(this.cbRegex);
            this.panelCheckBox.Controls.Add(this.cbWholeWord);
            this.panelCheckBox.Controls.Add(this.cbCaseSensitive);
            this.panelCheckBox.Location = new System.Drawing.Point(18, 184);
            this.panelCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCheckBox.Name = "panelCheckBox";
            this.panelCheckBox.Size = new System.Drawing.Size(238, 50);
            this.panelCheckBox.TabIndex = 6;
            // 
            // frmFindReplace
            // 
            this.AcceptButton = this.btnFindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 225);
            this.Controls.Add(this.panelCheckBox);
            this.Controls.Add(this.cbSearchUp);
            this.Controls.Add(this.mainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmFindReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "查找与替换";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindReplace_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFindReplace_FormClosed);
            this.Load += new System.EventHandler(this.frmFindReplace_Load);
            this.mainTab.ResumeLayout(false);
            this.FindTab.ResumeLayout(false);
            this.FindTab.PerformLayout();
            this.ReplaceTab.ResumeLayout(false);
            this.ReplaceTab.PerformLayout();
            this.panelCheckBox.ResumeLayout(false);
            this.panelCheckBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage FindTab;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lbl2Find;
        private System.Windows.Forms.TabPage ReplaceTab;
        private System.Windows.Forms.CheckBox cbCaseSensitive;
        private System.Windows.Forms.CheckBox cbWholeWord;
        private System.Windows.Forms.CheckBox cbRegex;
        private System.Windows.Forms.CheckBox cbWildcards;
        private System.Windows.Forms.CheckBox cbSearchUp;
        private System.Windows.Forms.TextBox txtFind2;
        private System.Windows.Forms.Label lblFind2;
        private System.Windows.Forms.Label lblReplaceTo;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnFindNext2;
        private System.Windows.Forms.Button btnFindPrev;
        private System.Windows.Forms.Button btnFindPrev2;
        private System.Windows.Forms.Panel panelCheckBox;
    }
}