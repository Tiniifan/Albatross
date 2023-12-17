using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Runtime.InteropServices;

// VSTabControl by tobeypeters

namespace Albatross.UI
{
    //TODO:
    //      ADD a multi-tab select system
    [
        ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch),
        DefaultProperty("TabPages"), DefaultEvent("SelectedIndexChanged"),
    ]

    public partial class VSTabControl : TabControl
    {
        [Category("Custom"), Description("The color used for the components background."), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color Background { get; set; } = Color.FromArgb(0, 0, 0);

        [Category("Custom"), Description("The color used for the components tab background.  Only fully shows, if the tabs background color is set to transparent."), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color BackgroundTab { get; set; } = Color.FromArgb(0, 0, 0);

        [Category("Custom"), Description("The color used for the components border."), DefaultValue(typeof(Color), "0, 122, 204")]
        public Color Border { get; set; } = Color.FromArgb(0, 122, 204);

        [Category("Custom"), Description("Indicates whether or not you the components Tabpages Headers have border edges."), DefaultValue(true)]
        public bool BorderEdges { get; set; } = true;

        private int _BorderSize = 1;
        [Category("Custom"), Description("The size of the components border."), DefaultValue(1)]
        public int BorderSize
        {
            get => _BorderSize;
            set => _BorderSize = value.LimitToRange(1, 2); //Two is the largest it can be.  Anymore won't be seen.
        }

        [Category("Custom"), Description("The color used for the components Active tabs color."), DefaultValue(typeof(Color), "0, 122, 204")]
        public Color ActiveTab { get; set; } = Color.FromArgb(0, 122, 204);

        [Category("Custom"), Description("The color used for the components Alternative tab indicator color.\nUsage : Set the Tag property of the desired TabPage(s) to 1."), DefaultValue(typeof(Color), "OrangeRed")]
        public Color AlternativeTab { get; set; } = Color.OrangeRed;

        [Category("Custom"), Description("The color used for the components InActive tabs color."), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color InActiveTab { get; set; } = Color.FromArgb(0, 0, 0);

        [Category("Custom"), Description("The color used for the components Active Tab Indicator."), DefaultValue(typeof(Color), "0, 122, 204")]
        public Color ActiveIndicator { get; set; } = Color.FromArgb(0, 122, 204);
        [Category("Custom"), Description("The color used for the components InActive Tab Indicator."), DefaultValue(typeof(Color), "0, 122, 204")]
        public Color InActiveIndicator { get; set; } = Color.FromArgb(0, 122, 204);
        [Category("Custom"), Description("The size of the components Indicator."), DefaultValue(6)]
        public int IndicatorSize { get; set; } = 6; //Might become obsolete

        [Category("Custom"), Description("The color used for the components Divider."), DefaultValue(typeof(Color), "0, 122, 204")]
        public Color Divider { get; set; } = Color.FromArgb(0, 122, 204);

        private int _DividerSize = 2;
        [Category("Custom"), Description("The size of the components Divider."), DefaultValue(2)]
        public int DividerSize
        {
            get => _DividerSize;
            set => _DividerSize = value.LimitToRange(1, 2);
        }

        [Category("Custom"), Description("The color used for the components Active tabs text."), DefaultValue(typeof(Color), "255, 255, 255")]
        public Color ActiveText { get; set; } = Color.FromArgb(255, 255, 255);
        [Category("Custom"), Description("The color used for the components InActive tabs text."), DefaultValue(typeof(Color), "255, 255, 255")]
        public Color InActiveText { get; set; } = Color.FromArgb(255, 255, 255);

        [Category("Custom"), Description("Indicates whether or not you can rearrange the components Tabpages.  CLICK on the Tabpages HEADER with the LEFT mousebutton and HOLD DOWN the <SHIFT> KEY, to drag it LEFT or RIGHT."), DefaultValue(false)]
        public bool CanDrag { get; set; }

        StringFormat format = new StringFormat { Alignment = StringAlignment.Center };

        private Bitmap bitDrag = default(Bitmap);

        private bool bDrag, bMouseDown, bShiftKey;
        private Point ptPreviousLocation, ptMaxDrag;
        private int DraggedIndex = -1;

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED to stop flicker
                return cp;
            }
        }

        public VSTabControl()
        {
            //InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.CacheText, true);

            Alignment = TabAlignment.Top;

            Margin = new Padding(0);
            Padding = new Point(0, 0);

            Font = new Font("Leelawadee UI", Font.Size);
        }

        private void SetDragState() => bDrag = (CanDrag && bMouseDown && bShiftKey);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bMouseDown = true;

            SetDragState();

            Rectangle rectDrag = GetTabRect(SelectedIndex);

            ptPreviousLocation = new Point(rectDrag.X, rectDrag.Y);

            rectDrag.Width += 1; rectDrag.Height += 1;

            Bitmap src = new Bitmap(Width, Height);

            DrawToBitmap(src, ClientRectangle);

            using (Graphics g = Graphics.FromImage(bitDrag = new Bitmap(rectDrag.Width, rectDrag.Height)))
            {
                g.DrawImage(src, new Rectangle(0, 0, bitDrag.Width, bitDrag.Height), rectDrag, GraphicsUnit.Pixel);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (bDrag)
            {
                if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                {
                    ptPreviousLocation = new Point(((e.X < 0) ? 0 : (e.X > ptMaxDrag.X) ? ptMaxDrag.X : e.X), (Alignment == TabAlignment.Top ? BorderSize : ptMaxDrag.Y));
                }

                if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left)
                {
                    ptPreviousLocation = new Point(ptMaxDrag.X, ((e.Y < 0) ? 0 : (e.Y > ptMaxDrag.Y) ? ptMaxDrag.Y : e.Y));
                }
                for (int i = 0; i < TabCount; i++)
                {
                    if (GetTabRect(i).Contains(PointToClient(Cursor.Position))) { DraggedIndex = i; break; }
                }

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            void SwapTabPages(TabPage inDestTab)
            {
                int SourceIndex = TabPages.IndexOf(SelectedTab);
                int DestinationIndex = TabPages.IndexOf(inDestTab);

                TabPages[DestinationIndex] = SelectedTab;
                TabPages[SourceIndex] = inDestTab;

                if (SelectedIndex == SourceIndex) { SelectedIndex = DestinationIndex; }
                else if (SelectedIndex == DestinationIndex) { SelectedIndex = SourceIndex; }
            }

            bDrag = bMouseDown = false;

            if (DraggedIndex > -1)
            {
                SwapTabPages(TabPages[DraggedIndex]);

                DraggedIndex = -1;
            }

            SetDragState();

            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs ke) { bShiftKey = ke.Shift; SetDragState(); }

        protected override void OnKeyUp(KeyEventArgs e) { bDrag = bShiftKey = false; SetDragState(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if (DesignMode) return;

            e.Graphics.Clear(Background); //Background

            Rectangle container = new Rectangle(0, 0, Width - (BorderSize % 2), Height - (BorderSize % 2));
            Rectangle containerHead = default(Rectangle);

            if (TabCount > 0)
            {
                using (SolidBrush brushBackgroundTab = new SolidBrush(BackgroundTab))
                using (SolidBrush brushDivider = new SolidBrush(Divider))
                {
                    //Draws the background of the tab control
                    {
                        e.Graphics.FillRectangle(brushBackgroundTab, DisplayRectangle);
                    }

                    //Divider Line
                    {
                        //Rectangle rectDivider = GetTabRect(SelectedIndex);

                        //if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                        {
                            e.Graphics.FillRectangle(brushDivider,
                                                     0,
                                                     (((Alignment == TabAlignment.Top) ? (TabPages[SelectedIndex].Top - DividerSize - (DividerSize % 2)) :
                                                     (TabPages[SelectedIndex].Bottom + (DividerSize % 2)))),
                                                     (Width - BorderSize), DividerSize
                                                    );
                        }

                        if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left)
                        {
                            e.Graphics.FillRectangle(brushDivider,
                                                     ((Alignment == TabAlignment.Right) ? (TabPages[SelectedIndex].Right + (DividerSize % 2)) : TabPages[SelectedIndex].Left - DividerSize - (DividerSize % 2)),
                                                     BorderSize,
                                                     DividerSize,
                                                     (Height - (BorderSize * 2))
                                                     );
                        }
                    }
                }
            }

            using (Pen penActive = new Pen(ActiveTab))
            using (Pen penBorder = new Pen(Border, BorderSize))
            using (SolidBrush brushActive = new SolidBrush(ActiveTab))
            using (SolidBrush brushInActive = new SolidBrush(InActiveTab))
            using (SolidBrush brushAlternative = new SolidBrush(AlternativeTab))
            using (SolidBrush brushActiveIndicator = new SolidBrush(ControlPaint.Light(ActiveIndicator, .75f)))
            using (SolidBrush brushInActiveIndicator = new SolidBrush(InActiveIndicator))
            using (SolidBrush brushActiveText = new SolidBrush(ActiveText))
            using (SolidBrush brushInActiveText = new SolidBrush(InActiveText))
            using (SolidBrush brushDrag = new SolidBrush(ControlPaint.Dark(ActiveTab, .5f)))
            {
                penBorder.Alignment = penActive.Alignment = PenAlignment.Inset; //Only way to set the proper alignment, that I know of

                e.Graphics.DrawRectangle(penBorder, container); //Border

                if (TabCount > 0)
                {
                    ptMaxDrag = new Point(0, 0);

                    for (int i = 0; i < TabCount; i++)
                    {
                        containerHead = GetTabRect(i);

                        e.Graphics.FillRectangle((SelectedIndex == i) ? (bDrag ? brushDrag : brushActive) : brushInActive, containerHead); //Header Background

                        //Header Edges
                        if (BorderEdges && (i == SelectedIndex))
                        {
                            Point ptA = new Point(0, 0); Point ptB = new Point(0, 0);
                            Point ptC = new Point(0, 0); Point ptD = new Point(0, 0);

                            ptA.X = ptB.X = ptD.X = containerHead.X;
                            ptA.Y = ptB.Y = ptC.Y = containerHead.Y;
                            ptA.Y = ptC.Y = ptD.Y = containerHead.Y + containerHead.Height - 1;

                            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                            {
                                ptD.X = ptC.X = containerHead.X + containerHead.Width;
                                ptC.Y = containerHead.Y;

                                if (Alignment == TabAlignment.Bottom)
                                {
                                    VSTabControlFunction.Swap(ref ptA, ref ptB); VSTabControlFunction.Swap(ref ptC, ref ptD);
                                }
                            }

                            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left)
                            {
                                ptA.Y = containerHead.Y;
                                ptB.X = ptC.X = containerHead.X + containerHead.Width - 1;

                                if (Alignment == TabAlignment.Left)
                                {
                                    VSTabControlFunction.Swap(ref ptA, ref ptC); VSTabControlFunction.Swap(ref ptB, ref ptD);
                                }
                            }

                            e.Graphics.DrawLine(new Pen(ControlPaint.Light(brushActive.Color)), ptA, ptB);
                            e.Graphics.DrawLine(new Pen(ControlPaint.Light(brushActive.Color)), ptB, ptC);
                            e.Graphics.DrawLine(new Pen(ControlPaint.Dark(brushActive.Color)), ptC, ptD);
                        }

                        //Indicator
                        {
                            Rectangle rectDivider = default(Rectangle);

                            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                            {
                                rectDivider = new Rectangle(containerHead.X, containerHead.Y + ((Alignment == TabAlignment.Top) ? containerHead.Height : -DividerSize), containerHead.Width, DividerSize);
                            }
                            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left)
                            {
                                rectDivider = new Rectangle(containerHead.X - ((Alignment == TabAlignment.Right) ? DividerSize : -containerHead.Width), containerHead.Y, DividerSize, containerHead.Height); //Indicator
                            }

                            e.Graphics.FillRectangle(((VSTabControlFunction.TagToInt(TabPages[i]) == 1) ? brushAlternative : ((i == SelectedIndex) ? brushActiveIndicator : brushInActiveIndicator)), rectDivider);
                        }

                        //Text
                        if (!(bDrag && i == SelectedIndex))
                        {
                            int angle = 0;
                            {
                                if (Alignment == TabAlignment.Right) angle = 90;
                                if (Alignment == TabAlignment.Left) angle = 270;
                            }

                            float w, h;

                            w = h = 0f;

                            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) { w = containerHead.X + (containerHead.Width / 2); }
                            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left) { w = containerHead.X; h = containerHead.Y + (containerHead.Height / 2); }

                            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) { h = containerHead.Y + ((Alignment == TabAlignment.Top) ? IndicatorSize : 0) + ((containerHead.Height - IndicatorSize) / 2); }
                            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left) { w += (((Alignment == TabAlignment.Right) ? 0 : IndicatorSize) + ((containerHead.Width - IndicatorSize) / 2)); }

                            e.Graphics.TranslateTransform(w, h);
                            {
                                Size textSize = e.Graphics.MeasureString(TabPages[i].Text, Font).ToSize();

                                e.Graphics.RotateTransform(angle);
                                e.Graphics.DrawString(TabPages[i].Text, Font, ((SelectedIndex == i) ? brushActiveText : brushInActiveText), new PointF((-textSize.Width / 2f), (-textSize.Height / 2f)));
                            }
                            e.Graphics.ResetTransform();
                        }

                        if (bMouseDown)
                        {
                            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) { if (i > 0) { ptMaxDrag.X += GetTabRect(i).Width; } }
                            if (Alignment == TabAlignment.Top) { ptMaxDrag.Y = BorderSize; }
                            if (Alignment == TabAlignment.Bottom) { ptMaxDrag.Y = containerHead.Y; };

                            if (Alignment == TabAlignment.Right || Alignment == TabAlignment.Left) { ptMaxDrag.X = containerHead.X; if (i > 0) { ptMaxDrag.Y += containerHead.Height; } }
                        }

                        if (bDrag && (bitDrag != null)) { e.Graphics.DrawImage(bitDrag, new Point(ptPreviousLocation.X, ptPreviousLocation.Y)); }
                    }
                }
            }
        }
    }

    public static class VSTabControlFunction
    {
        /// <summary> Essentially ... clamp </summary>
        public static int LimitToRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }

        /// <summary> Swap function that uses <Generics>. </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b; b = temp;
        }

        /// <summary> Converts the <Tag> property of a control to an integer. </summary>
        public static int TagToInt(object inObject) => Convert.ToInt32((inObject as Control).Tag);
    }
}