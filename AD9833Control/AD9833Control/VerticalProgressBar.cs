using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AD9833ControlCustomForms
{
    public class VerticalProgressBar : ProgressBar
    {
        public int _warningLevel;
        public int WarningLevel
        {
            get
            {
                return _warningLevel;
            }

            set
            {
                if (WarningLevel > Maximum)
                    _warningLevel = Maximum;
                else
                    _warningLevel = value;
            }
        }
        //http://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5
        public VerticalProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle recGreen = e.ClipRectangle;
            recGreen.Width = recGreen.Width - 4;

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);
                //ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);

            if (Value <= WarningLevel)
            {
                recGreen.Height = (int)(recGreen.Height * ((double)Value / Maximum)) - 4;
            }
            else
            {
                recGreen.Height = (int)(recGreen.Height * ((double)WarningLevel / Maximum));
                Rectangle recWarn = e.ClipRectangle;
                recWarn.Width = recWarn.Width - 4;
                recWarn.Height = (int)(recWarn.Height * (((double)Value - (double)WarningLevel) / Maximum)) - 4;
                e.Graphics.FillRectangle(Brushes.Red, 2, this.Height - 2 - recGreen.Height - recWarn.Height, recWarn.Width, recWarn.Height);
            }
            e.Graphics.FillRectangle(Brushes.Green, 2, this.Height - 2 - recGreen.Height, recGreen.Width, recGreen.Height);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
        protected override System.Drawing.Size DefaultSize {
            get {
                return new System.Drawing.Size(23, 100);
            }
        }
    }
}
