using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
using System.Diagnostics;
using LedVestPlasmaGenerator.Domain;

namespace LedVestPlasmaGenerator.Plasma
{
    class PlasmaManager
    {
        private DisplayManager displayManager;
        private VestManager vestManager;
        private Stopwatch stopWatch;

        private int itterations;
        private int currentItternation;
        private double movement = 0;
        private double speed;

        private string fileMane;

        private int lastFrameDisplayTime;
        private bool display;

        public PlasmaManager()
        {
            displayManager = new DisplayManager(600, 400);
            vestManager = new VestManager();
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public void ExecutePlasma(int _itterations, int _brightness, int size, double _speed, string _fileName, bool _display, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue)
        {
            itterations = _itterations;
            fileMane = _fileName;
            speed = _speed;
            display = _display;

            IPlasma plasmaGenerator = ChoosePlasma();//TODO send parameter of a plasma name enum

            //the buffer where the data going to file will be constructed. It can get big.
            byte[] buffer = new byte[vestManager.leds.Length * 3 * itterations];

            plasmaGenerator.SetParameters(_brightness, size, _showRed, _showGreen, _showBlue, _morphGreen, _morphBlue);

            while (currentItternation < itterations)
            {
                //calculate current array position for the next frame
                var bufferFrameLocation = currentItternation * vestManager.leds.Length;

                //itterate all LEDS to generate the next frame of plasma 
                for (var i = 0; i < vestManager.leds.Length; i++)
                {
                    byte[] color = plasmaGenerator.RenderPlasmaPixel(vestManager.leds[i].X, vestManager.leds[i].Y, movement);
                    buffer[bufferFrameLocation + (i * 3)]     = color[0];
                    buffer[bufferFrameLocation + (i * 3) + 1] = color[1];
                    buffer[bufferFrameLocation + (i * 3) + 2] = color[2];

                    //show this pixel on display
                    if (display) displayManager.DisplayPixel(color[0], color[1], color[2], vestManager.leds[i], 10);
                }

                movement += speed / 1000;
                currentItternation++;
                if (display)
                {
                    //show this pixel on display
                    int elapsed = (int)(stopWatch.ElapsedMilliseconds - lastFrameDisplayTime);
                    if (elapsed < 40) Thread.Sleep(40 - elapsed);
                }
            }

            //write file 
        }

        private IPlasma ChoosePlasma()
        {
            //replace with case when more exist
            return new PlasmaSinXY( );
        }
    }
}
