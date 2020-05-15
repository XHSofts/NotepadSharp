using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadSharp
{
    //Ref: https://www.cnblogs.com/JiYF/p/9047559.html
    //Override the Panel control to add border prop
    public partial class PanelEx : Panel
    {
        public PanelEx()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        public PanelEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private Color _BorderColor = Color.Black;

        [Browsable(true), Description("边框颜色"), Category("自定义分组")]
        public Color BorderColor
        {
            get => _BorderColor;
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }

        private int _BorderSize = 1;

        [Browsable(true), Description("边框粗细"), Category("自定义分组")]
        public int BorderSize
        {
            get => _BorderSize;
            set
            {
                _BorderSize = value;
                Invalidate();
            }
        }
        /// <summary>
        /// 重写OnPaint方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                    ClientRectangle,
                                    _BorderColor,
                                    _BorderSize,
                                    ButtonBorderStyle.Solid,
                                    _BorderColor,
                                    _BorderSize,
                                    ButtonBorderStyle.Solid,
                                    _BorderColor,
                                    _BorderSize,
                                    ButtonBorderStyle.Solid,
                                    _BorderColor,
                                    _BorderSize,
                                    ButtonBorderStyle.Solid);
        }
    }
}
