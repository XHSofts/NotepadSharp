﻿namespace NotepadSharp
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
            this.components = new System.ComponentModel.Container();
            this.titleMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PageSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.UseBingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindPrevMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GotoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordWarpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomStatusBar = new System.Windows.Forms.StatusStrip();
            this.encodingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.returnStyleStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cursorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.textLengthStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.ShowHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendIssusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsShowStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ControlCharMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColRulerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.EOLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Container = new NotepadSharp.PanelEx(this.components);
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.ZoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleMenu.SuspendLayout();
            this.bottomStatusBar.SuspendLayout();
            this.Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleMenu
            // 
            this.titleMenu.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.titleMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.titleMenu.Size = new System.Drawing.Size(1021, 24);
            this.titleMenu.TabIndex = 0;
            this.titleMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileMenuItem,
            this.openFileMenuItem,
            this.reOpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.toolStripSeparator1,
            this.PageSetupMenuItem,
            this.PrintMenuItem,
            this.toolStripSeparator2,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.FileMenuItem.Size = new System.Drawing.Size(63, 24);
            this.FileMenuItem.Text = "文件(&F)";
            // 
            // NewFileMenuItem
            // 
            this.NewFileMenuItem.Name = "NewFileMenuItem";
            this.NewFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewFileMenuItem.Size = new System.Drawing.Size(258, 26);
            this.NewFileMenuItem.Text = "新建(&N)";
            this.NewFileMenuItem.Click += new System.EventHandler(this.NewFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(258, 26);
            this.openFileMenuItem.Text = "打开(&O)...";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // reOpenMenuItem
            // 
            this.reOpenMenuItem.Name = "reOpenMenuItem";
            this.reOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.reOpenMenuItem.Size = new System.Drawing.Size(258, 26);
            this.reOpenMenuItem.Text = "重新打开(&R)";
            this.reOpenMenuItem.Click += new System.EventHandler(this.reOpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(258, 26);
            this.SaveMenuItem.Text = "保存(&S)";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsMenuItem.Size = new System.Drawing.Size(258, 26);
            this.SaveAsMenuItem.Text = "另存为(&A)...";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // PageSetupMenuItem
            // 
            this.PageSetupMenuItem.Name = "PageSetupMenuItem";
            this.PageSetupMenuItem.Size = new System.Drawing.Size(258, 26);
            this.PageSetupMenuItem.Text = "页面设置(&U)...";
            // 
            // PrintMenuItem
            // 
            this.PrintMenuItem.Name = "PrintMenuItem";
            this.PrintMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PrintMenuItem.Size = new System.Drawing.Size(258, 26);
            this.PrintMenuItem.Text = "打印(&P)...";
            this.PrintMenuItem.Click += new System.EventHandler(this.PrintMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(258, 26);
            this.ExitMenuItem.Text = "退出(&X)";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoMenuItem,
            this.RedoMenuItem,
            this.toolStripSeparator3,
            this.CutMenuItem,
            this.CopyMenuItem,
            this.PasteMenuItem,
            this.DeleteMenuItem,
            this.toolStripSeparator4,
            this.UseBingMenuItem,
            this.FindMenuItem,
            this.FindNextMenuItem,
            this.FindPrevMenuItem,
            this.ReplaceMenuItem,
            this.GotoMenuItem,
            this.toolStripSeparator5,
            this.SelectAllMenuItem,
            this.DateTimeMenuItem});
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.EditMenuItem.Size = new System.Drawing.Size(63, 24);
            this.EditMenuItem.Text = "编辑(&E)";
            // 
            // UndoMenuItem
            // 
            this.UndoMenuItem.Name = "UndoMenuItem";
            this.UndoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoMenuItem.Size = new System.Drawing.Size(245, 26);
            this.UndoMenuItem.Text = "撤销(&U)";
            this.UndoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // RedoMenuItem
            // 
            this.RedoMenuItem.Name = "RedoMenuItem";
            this.RedoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoMenuItem.Size = new System.Drawing.Size(245, 26);
            this.RedoMenuItem.Text = "重做(&R)";
            this.RedoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // CutMenuItem
            // 
            this.CutMenuItem.Name = "CutMenuItem";
            this.CutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutMenuItem.Size = new System.Drawing.Size(245, 26);
            this.CutMenuItem.Text = "剪切(&T)";
            this.CutMenuItem.Click += new System.EventHandler(this.CutMenuItem_Click);
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.Name = "CopyMenuItem";
            this.CopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyMenuItem.Size = new System.Drawing.Size(245, 26);
            this.CopyMenuItem.Text = "复制(&C)";
            this.CopyMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.Name = "PasteMenuItem";
            this.PasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteMenuItem.Size = new System.Drawing.Size(245, 26);
            this.PasteMenuItem.Text = "粘贴(&P)";
            this.PasteMenuItem.Click += new System.EventHandler(this.PasteMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteMenuItem.Size = new System.Drawing.Size(245, 26);
            this.DeleteMenuItem.Text = "删除(&L)";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // UseBingMenuItem
            // 
            this.UseBingMenuItem.Name = "UseBingMenuItem";
            this.UseBingMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.UseBingMenuItem.Size = new System.Drawing.Size(245, 26);
            this.UseBingMenuItem.Text = "使用 Bing 搜索...";
            this.UseBingMenuItem.Click += new System.EventHandler(this.UseBingMenuItem_Click);
            // 
            // FindMenuItem
            // 
            this.FindMenuItem.Name = "FindMenuItem";
            this.FindMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FindMenuItem.Size = new System.Drawing.Size(245, 26);
            this.FindMenuItem.Text = "查找(&F)...";
            // 
            // FindNextMenuItem
            // 
            this.FindNextMenuItem.Name = "FindNextMenuItem";
            this.FindNextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.FindNextMenuItem.Size = new System.Drawing.Size(245, 26);
            this.FindNextMenuItem.Text = "查找下一个(&N)";
            // 
            // FindPrevMenuItem
            // 
            this.FindPrevMenuItem.Name = "FindPrevMenuItem";
            this.FindPrevMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.FindPrevMenuItem.Size = new System.Drawing.Size(245, 26);
            this.FindPrevMenuItem.Text = "查找上一个(&V)";
            // 
            // ReplaceMenuItem
            // 
            this.ReplaceMenuItem.Name = "ReplaceMenuItem";
            this.ReplaceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.ReplaceMenuItem.Size = new System.Drawing.Size(245, 26);
            this.ReplaceMenuItem.Text = "替换(&E)...";
            // 
            // GotoMenuItem
            // 
            this.GotoMenuItem.Name = "GotoMenuItem";
            this.GotoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.GotoMenuItem.Size = new System.Drawing.Size(245, 26);
            this.GotoMenuItem.Text = "转到(&G)...";
            this.GotoMenuItem.Click += new System.EventHandler(this.GotoMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // SelectAllMenuItem
            // 
            this.SelectAllMenuItem.Name = "SelectAllMenuItem";
            this.SelectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllMenuItem.Size = new System.Drawing.Size(245, 26);
            this.SelectAllMenuItem.Text = "全选(&A)";
            this.SelectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItem_Click);
            // 
            // DateTimeMenuItem
            // 
            this.DateTimeMenuItem.Name = "DateTimeMenuItem";
            this.DateTimeMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.DateTimeMenuItem.Size = new System.Drawing.Size(245, 26);
            this.DateTimeMenuItem.Text = "时间/日期(&D)";
            this.DateTimeMenuItem.Click += new System.EventHandler(this.DateTimeMenuItem_Click);
            // 
            // FormatMenuItem
            // 
            this.FormatMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WordWarpMenuItem,
            this.FontMenuItem});
            this.FormatMenuItem.Name = "FormatMenuItem";
            this.FormatMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.FormatMenuItem.Size = new System.Drawing.Size(67, 24);
            this.FormatMenuItem.Text = "格式(&O)";
            // 
            // WordWarpMenuItem
            // 
            this.WordWarpMenuItem.Checked = true;
            this.WordWarpMenuItem.CheckOnClick = true;
            this.WordWarpMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WordWarpMenuItem.Name = "WordWarpMenuItem";
            this.WordWarpMenuItem.Size = new System.Drawing.Size(169, 26);
            this.WordWarpMenuItem.Text = "自动换行(&W)";
            this.WordWarpMenuItem.CheckedChanged += new System.EventHandler(this.WordWarpMenuItem_CheckedChanged);
            this.WordWarpMenuItem.Click += new System.EventHandler(this.WordWarpMenuItem_Click);
            // 
            // FontMenuItem
            // 
            this.FontMenuItem.Name = "FontMenuItem";
            this.FontMenuItem.Size = new System.Drawing.Size(169, 26);
            this.FontMenuItem.Text = "字体(&F)...";
            this.FontMenuItem.Click += new System.EventHandler(this.FontMenuItem_Click);
            // 
            // ViewMenuItem
            // 
            this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomMenuItem,
            this.IsShowStatusBarMenuItem,
            this.toolStripSeparator7,
            this.ColRulerMenuItem,
            this.toolStripSeparator8,
            this.ControlCharMenuItem,
            this.EOLMenuItem,
            this.SpaceMenuItem,
            this.TabMenuItem});
            this.ViewMenuItem.Name = "ViewMenuItem";
            this.ViewMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ViewMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ViewMenuItem.Text = "查看(&V)";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHelpMenuItem,
            this.SendIssusMenuItem,
            this.toolStripSeparator6,
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.HelpMenuItem.Size = new System.Drawing.Size(66, 24);
            this.HelpMenuItem.Text = "帮助(&H)";
            // 
            // bottomStatusBar
            // 
            this.bottomStatusBar.AutoSize = false;
            this.bottomStatusBar.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bottomStatusBar.ImageScalingSize = new System.Drawing.Size(20, 28);
            this.bottomStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingStatus,
            this.returnStyleStatus,
            this.zoomStatus,
            this.cursorStatus,
            this.textLengthStatus});
            this.bottomStatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.bottomStatusBar.Location = new System.Drawing.Point(0, 538);
            this.bottomStatusBar.Name = "bottomStatusBar";
            this.bottomStatusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bottomStatusBar.Size = new System.Drawing.Size(1021, 25);
            this.bottomStatusBar.TabIndex = 2;
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
            this.encodingStatus.Size = new System.Drawing.Size(150, 25);
            this.encodingStatus.Text = "Unicode (UTF-8)";
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
            this.returnStyleStatus.Size = new System.Drawing.Size(150, 25);
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
            this.cursorStatus.Size = new System.Drawing.Size(160, 25);
            this.cursorStatus.Text = "第 1 行，第 1 列";
            this.cursorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textLengthStatus
            // 
            this.textLengthStatus.AutoSize = false;
            this.textLengthStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textLengthStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.textLengthStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLengthStatus.Name = "textLengthStatus";
            this.textLengthStatus.Padding = new System.Windows.Forms.Padding(20);
            this.textLengthStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textLengthStatus.Size = new System.Drawing.Size(200, 25);
            this.textLengthStatus.Text = "字数：0，行数：0";
            this.textLengthStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件|*.*";
            // 
            // fontDialog
            // 
            this.fontDialog.ShowApply = true;
            // 
            // ShowHelpMenuItem
            // 
            this.ShowHelpMenuItem.Name = "ShowHelpMenuItem";
            this.ShowHelpMenuItem.Size = new System.Drawing.Size(218, 26);
            this.ShowHelpMenuItem.Text = "查看帮助(&H)";
            this.ShowHelpMenuItem.Click += new System.EventHandler(this.ShowHelpMenuItem_Click);
            // 
            // SendIssusMenuItem
            // 
            this.SendIssusMenuItem.Name = "SendIssusMenuItem";
            this.SendIssusMenuItem.Size = new System.Drawing.Size(218, 26);
            this.SendIssusMenuItem.Text = "发送反馈(&F)";
            this.SendIssusMenuItem.Click += new System.EventHandler(this.SendIssusMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(215, 6);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(218, 26);
            this.AboutMenuItem.Text = "关于记事本Sharp(&A)";
            // 
            // ZoomMenuItem
            // 
            this.ZoomMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInMenuItem,
            this.ZoomOutMenuItem,
            this.RestoreZoomMenuItem});
            this.ZoomMenuItem.Name = "ZoomMenuItem";
            this.ZoomMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ZoomMenuItem.Text = "缩放(&Z)";
            // 
            // IsShowStatusBarMenuItem
            // 
            this.IsShowStatusBarMenuItem.CheckOnClick = true;
            this.IsShowStatusBarMenuItem.Name = "IsShowStatusBarMenuItem";
            this.IsShowStatusBarMenuItem.Size = new System.Drawing.Size(216, 26);
            this.IsShowStatusBarMenuItem.Text = "状态栏(&S)";
            this.IsShowStatusBarMenuItem.CheckStateChanged += new System.EventHandler(this.IsShowStatusBarMenuItem_CheckStateChanged);
            this.IsShowStatusBarMenuItem.Click += new System.EventHandler(this.IsShowStatusBarMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(213, 6);
            // 
            // ControlCharMenuItem
            // 
            this.ControlCharMenuItem.CheckOnClick = true;
            this.ControlCharMenuItem.Name = "ControlCharMenuItem";
            this.ControlCharMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ControlCharMenuItem.Text = "控制字符(&C)";
            this.ControlCharMenuItem.CheckStateChanged += new System.EventHandler(this.ControlCharMenuItem_CheckStateChanged);
            // 
            // ColRulerMenuItem
            // 
            this.ColRulerMenuItem.CheckOnClick = true;
            this.ColRulerMenuItem.Name = "ColRulerMenuItem";
            this.ColRulerMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ColRulerMenuItem.Text = "列尺子(&R)";
            this.ColRulerMenuItem.CheckStateChanged += new System.EventHandler(this.ColRulerMenuItem_CheckStateChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // EOLMenuItem
            // 
            this.EOLMenuItem.CheckOnClick = true;
            this.EOLMenuItem.Name = "EOLMenuItem";
            this.EOLMenuItem.Size = new System.Drawing.Size(216, 26);
            this.EOLMenuItem.Text = "换行符(&E)";
            this.EOLMenuItem.CheckStateChanged += new System.EventHandler(this.EOLMenuItem_CheckStateChanged);
            this.EOLMenuItem.Click += new System.EventHandler(this.EOLMenuItem_Click);
            // 
            // SpaceMenuItem
            // 
            this.SpaceMenuItem.CheckOnClick = true;
            this.SpaceMenuItem.Name = "SpaceMenuItem";
            this.SpaceMenuItem.Size = new System.Drawing.Size(216, 26);
            this.SpaceMenuItem.Text = "空格(&S)";
            this.SpaceMenuItem.CheckStateChanged += new System.EventHandler(this.SpaceMenuItem_CheckStateChanged);
            // 
            // TabMenuItem
            // 
            this.TabMenuItem.CheckOnClick = true;
            this.TabMenuItem.Name = "TabMenuItem";
            this.TabMenuItem.Size = new System.Drawing.Size(216, 26);
            this.TabMenuItem.Text = "制表符(&T)";
            this.TabMenuItem.CheckStateChanged += new System.EventHandler(this.TabMenuItem_CheckStateChanged);
            // 
            // Container
            // 
            this.Container.BorderColor = System.Drawing.SystemColors.Control;
            this.Container.BorderSize = 1;
            this.Container.Controls.Add(this.host);
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 24);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(1021, 514);
            this.Container.TabIndex = 4;
            // 
            // host
            // 
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.host.Location = new System.Drawing.Point(0, 0);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(1021, 514);
            this.host.TabIndex = 0;
            this.host.Child = null;
            // 
            // ZoomInMenuItem
            // 
            this.ZoomInMenuItem.Name = "ZoomInMenuItem";
            this.ZoomInMenuItem.ShortcutKeyDisplayString = "Ctrl + 加号键";
            this.ZoomInMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.ZoomInMenuItem.Size = new System.Drawing.Size(232, 26);
            this.ZoomInMenuItem.Text = "放大(&I)";
            this.ZoomInMenuItem.Click += new System.EventHandler(this.ZoomInMenuItem_Click);
            // 
            // ZoomOutMenuItem
            // 
            this.ZoomOutMenuItem.Name = "ZoomOutMenuItem";
            this.ZoomOutMenuItem.ShortcutKeyDisplayString = "Ctrl + 减号键";
            this.ZoomOutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.ZoomOutMenuItem.Size = new System.Drawing.Size(232, 26);
            this.ZoomOutMenuItem.Text = "缩小(&O)";
            this.ZoomOutMenuItem.Click += new System.EventHandler(this.ZoomOutMenuItem_Click);
            // 
            // RestoreZoomMenuItem
            // 
            this.RestoreZoomMenuItem.Name = "RestoreZoomMenuItem";
            this.RestoreZoomMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.RestoreZoomMenuItem.Size = new System.Drawing.Size(232, 26);
            this.RestoreZoomMenuItem.Text = "恢复默认缩放";
            this.RestoreZoomMenuItem.Click += new System.EventHandler(this.RestoreZoomMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 563);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.bottomStatusBar);
            this.Controls.Add(this.titleMenu);
            this.MainMenuStrip = this.titleMenu;
            this.Name = "frmMain";
            this.Text = "NotepadSharp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.titleMenu.ResumeLayout(false);
            this.titleMenu.PerformLayout();
            this.bottomStatusBar.ResumeLayout(false);
            this.bottomStatusBar.PerformLayout();
            this.Container.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem NewFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem PageSetupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem UseBingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindNextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindPrevMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplaceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GotoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem SelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DateTimeMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel textLengthStatus;
        private PanelEx Container;
        private System.Windows.Forms.Integration.ElementHost host;
        private System.Windows.Forms.ToolStripMenuItem WordWarpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontMenuItem;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem reOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendIssusMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsShowStatusBarMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ColRulerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem ControlCharMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EOLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpaceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreZoomMenuItem;
    }
}

