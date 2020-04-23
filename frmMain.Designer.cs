namespace NotepadSharp
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.titleMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomStatusBar = new System.Windows.Forms.StatusStrip();
            this.encodingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.returnStyleStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cursorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.titleMenu.SuspendLayout();
            this.bottomStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleMenu
            // 
            this.titleMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.titleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.EditMenuItem,
            this.FormatMenuItem,
            this.ViewMenuItem,
            this.HelpMenuItem});
            this.titleMenu.Location = new System.Drawing.Point(0, 0);
            this.titleMenu.Name = "titleMenu";
            this.titleMenu.Padding = new System.Windows.Forms.Padding(0);
            this.titleMenu.Size = new System.Drawing.Size(1021, 24);
            this.titleMenu.TabIndex = 0;
            this.titleMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.FileMenuItem.Size = new System.Drawing.Size(63, 24);
            this.FileMenuItem.Text = "文件(&F)";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openFileMenuItem.Text = "打开(&O)";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.EditMenuItem.Size = new System.Drawing.Size(63, 24);
            this.EditMenuItem.Text = "编辑(&E)";
            // 
            // FormatMenuItem
            // 
            this.FormatMenuItem.Name = "FormatMenuItem";
            this.FormatMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.FormatMenuItem.Size = new System.Drawing.Size(67, 24);
            this.FormatMenuItem.Text = "格式(&O)";
            // 
            // ViewMenuItem
            // 
            this.ViewMenuItem.Name = "ViewMenuItem";
            this.ViewMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ViewMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ViewMenuItem.Text = "查看(&V)";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.HelpMenuItem.Size = new System.Drawing.Size(67, 24);
            this.HelpMenuItem.Text = "帮助(&H)";
            // 
            // bottomStatusBar
            // 
            this.bottomStatusBar.AutoSize = false;
            this.bottomStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bottomStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingStatus,
            this.returnStyleStatus,
            this.zoomStatus,
            this.cursorStatus});
            this.bottomStatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.bottomStatusBar.Location = new System.Drawing.Point(0, 533);
            this.bottomStatusBar.Name = "bottomStatusBar";
            this.bottomStatusBar.Size = new System.Drawing.Size(1021, 30);
            this.bottomStatusBar.TabIndex = 2;
            this.bottomStatusBar.Text = "statusStrip1";
            // 
            // encodingStatus
            // 
            this.encodingStatus.AutoSize = false;
            this.encodingStatus.BackColor = System.Drawing.SystemColors.Control;
            this.encodingStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.encodingStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.encodingStatus.Name = "encodingStatus";
            this.encodingStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 20);
            this.encodingStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.encodingStatus.Size = new System.Drawing.Size(110, 25);
            this.encodingStatus.Text = "UTF-8";
            this.encodingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // returnStyleStatus
            // 
            this.returnStyleStatus.AutoSize = false;
            this.returnStyleStatus.BackColor = System.Drawing.SystemColors.Control;
            this.returnStyleStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.returnStyleStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnStyleStatus.Name = "returnStyleStatus";
            this.returnStyleStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 20);
            this.returnStyleStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.returnStyleStatus.Size = new System.Drawing.Size(120, 25);
            this.returnStyleStatus.Text = "Windows（CRLF）";
            this.returnStyleStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoomStatus
            // 
            this.zoomStatus.AutoSize = false;
            this.zoomStatus.BackColor = System.Drawing.SystemColors.Control;
            this.zoomStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.zoomStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zoomStatus.Name = "zoomStatus";
            this.zoomStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 20);
            this.zoomStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zoomStatus.Size = new System.Drawing.Size(50, 25);
            this.zoomStatus.Text = "100%";
            this.zoomStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cursorStatus
            // 
            this.cursorStatus.AutoSize = false;
            this.cursorStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cursorStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.cursorStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cursorStatus.Name = "cursorStatus";
            this.cursorStatus.Padding = new System.Windows.Forms.Padding(20);
            this.cursorStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cursorStatus.Size = new System.Drawing.Size(130, 25);
            this.cursorStatus.Text = "第 1 行，第 1 列";
            this.cursorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEditorControl
            // 
            this.textEditorControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl.EnableFolding = false;
            this.textEditorControl.IsReadOnly = false;
            this.textEditorControl.Location = new System.Drawing.Point(0, 24);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.textEditorControl.ShowVRuler = false;
            this.textEditorControl.Size = new System.Drawing.Size(1021, 509);
            this.textEditorControl.TabIndex = 3;
            this.textEditorControl.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件|*.*";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 563);
            this.Controls.Add(this.textEditorControl);
            this.Controls.Add(this.bottomStatusBar);
            this.Controls.Add(this.titleMenu);
            this.MainMenuStrip = this.titleMenu;
            this.Name = "frmMain";
            this.Text = "NotepadSharp";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.titleMenu.ResumeLayout(false);
            this.titleMenu.PerformLayout();
            this.bottomStatusBar.ResumeLayout(false);
            this.bottomStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip titleMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.StatusStrip bottomStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel encodingStatus;
        private System.Windows.Forms.ToolStripStatusLabel returnStyleStatus;
        private System.Windows.Forms.ToolStripStatusLabel zoomStatus;
        private System.Windows.Forms.ToolStripStatusLabel cursorStatus;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

