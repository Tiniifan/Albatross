using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Albatross.UI
{
    public class FlatCheckBox : CheckBox
    {
        [Category("Custom"), Description("The color used for the components background."), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color CheckMarkColor { get; set; } = Color.FromArgb(255, 255, 255);

        public FlatCheckBox()
        {

        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            SolidBrush Brsh = new SolidBrush(BackColor);

            int BoxSide = System.Convert.ToInt32(pevent.Graphics.MeasureString(Text, Font, Width).Height);
            pevent.Graphics.FillRectangle(Brsh, 0, 0, Width, Height);

            if (Checked & Enabled)
            {
                pevent.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, BoxSide - 1, BoxSide - 1));
                pevent.Graphics.DrawString(Text, Font, Brushes.Black, BoxSide, 0);

                using (Font wing = new Font("Wingdings", 14f))
                    pevent.Graphics.DrawString("ü", wing, new SolidBrush(CheckMarkColor), -4, -2);
            }
            else if (Enabled)
            {
                pevent.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, BoxSide - 1, BoxSide - 1));
                pevent.Graphics.DrawString(Text, Font, Brushes.Black, BoxSide, 0);
            }
            else if (Checked & !Enabled)
            {
                pevent.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, BoxSide - 1, BoxSide - 1));
                pevent.Graphics.DrawString(Text, Font, Brushes.Gray, BoxSide, 0);
            }
            else
            {
                pevent.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, BoxSide - 1, BoxSide - 1));
                pevent.Graphics.DrawString(Text, Font, Brushes.Gray, BoxSide, 0);
            }

            Brsh.Dispose();
        }
    }

}
