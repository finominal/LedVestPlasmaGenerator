
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace LedVestPlasmaGenerator.Domain
{
    public class DisplayManager
    {
        private Form displayForm;
        private bool running = true;
        private const int lowerArea = 60;

        public DisplayManager(int width, int height)
        {
            displayForm = new Form { Width = width, Height = height + lowerArea };
            displayForm.BackColor = Color.Black;

            Button btnCancel = new Button();
            btnCancel.Location = new Point(10, height -40);
            btnCancel.Name = "btnCancel";

            btnCancel.Location = new System.Drawing.Point(10, height );
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.BackColor = System.Drawing.Color.Gray;
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            displayForm.Controls.Add(btnCancel);
            displayForm.Show();
        }


        public void DisplayPixel(int r, int g, int b, LED c, int pxSize)
        {
            //position the pixels so it looks good on the screen
            int x = (int)((c.X * (displayForm.Width / 33) ) + 8); //  /33 to space appropriately, + 8 off edge
            int y = (int)((displayForm.Height - lowerArea) - (c.Y * ((displayForm.Height - lowerArea) / 21)) - 44); //flip by subtracting from wides, - 15 to move off edge

            Graphics graphics = displayForm.CreateGraphics();

            var brush = new SolidBrush(ColorTranslator.FromOle(CreateColorInt(r,g,b)));
           
            graphics.FillEllipse(brush, x, y, pxSize, pxSize);
            
        }

        public void Show(int frameNumber, int totalFrameCount, int loopTime)
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
            result = b & 0x000000FF;
            result <<= 8;
            result += g & 0x000000FF; ;
            result <<= 8;
            result += r & 0x000000FF; ;

            return result;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            running = false;
        }

        public bool IsStillRunning()
        {
            return running;
        }

        public void Close()
        {
            displayForm.Close();
        }
    }
}
