
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LedVestPlasmaGenerator.Domain
{
    public class DisplayFormManager
    {
        private Form displayForm;

        public DisplayFormManager(int width, int height)
        {
            displayForm = new Form { Width = width, Height = height };
            displayForm.BackColor = Color.Black;
            displayForm.Show();
        }

        public void DisplayPixel(int r, int g, int b, LED c, int pxSize)
        {
            //position the pixels so it looks good on the screen
            int x = (int)((c.X * (displayForm.Width / 33) ) + 8); //  /33 to space appropriately, + 8 off edge
            int y = (int)(displayForm.Height - (c.Y * (displayForm.Height / 21)) - 44); //flip by subtracting from wides, - 15 to move off edge

            Graphics graphics = displayForm.CreateGraphics();

           // Pen pen = new Pen(ColorTranslator.FromWin32(CreateColorInt(r, g, b)));

            var brush = new SolidBrush(ColorTranslator.FromOle(CreateColorInt(r,g,b)));
           
            graphics.FillEllipse(brush, x, y, pxSize, pxSize);
        }

        public void Show(int frameNumber, int totalFrameCount)
        {
            displayForm.Text = frameNumber + " / " + totalFrameCount;
            displayForm.Update();
            displayForm.Show();
        }

        private int CreateColorInt(int r, int g, int b)
        {
            //combine red, green and blue bytes
            int result;
            result = 255;
            result <<= 8;
            result = b*2 & 0x000000FF;
            result <<= 8;
            result += g*2 & 0x000000FF; ;
            result <<= 8;
            result += r*2 & 0x000000FF; ;

            return result;
        }

    }
}
