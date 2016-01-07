using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 
using System.Diagnostics;
using LedVestPlasmaGenerator.Domain;
using LedVestPlasmaGenerator.Repository;

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

        private string fileNane;

        private int lastFrameDisplayTime;
        private bool display;

        public PlasmaManager()
        {
            
            vestManager = new VestManager();
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public void GeneratePlasma(int _itterations, int _brightness, int size, double _speed, string _fileName, bool _display, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue, bool _pink)
        {

            itterations = _itterations;
            fileNane = _fileName;
            speed = _speed;
            display = _display;

            IPlasma plasmaGenerator = ChoosePlasma();//TODO send parameter of a plasma name enum

            //the buffer where the data going to file will be constructed. It can get big.
            byte[] buffer = new byte[vestManager.leds.Length * 3 * itterations];

            displayManager = new DisplayManager(vestManager.vestX*2+20, vestManager.vestY*2+20);

            plasmaGenerator.SetParameters(_brightness, size, _showRed, _showGreen, _showBlue, _morphGreen, _morphBlue, _pink);

            while (currentItternation < itterations && displayManager.IsStillRunning())
            {
                //calculate current array position for the next frame
                var bufferFrameLocation = currentItternation * (vestManager.leds.Length *3);

                //itterate all LEDS to generate the next frame of plasma 
                for (var i = 0; i < vestManager.leds.Length; i++)
                {
                    if (i == 0)
                    {
                        var x = 1;
                    }

                    byte[] color = plasmaGenerator.RenderPlasmaPixel(vestManager.leds[i].X, vestManager.leds[i].Y, movement);
                    buffer[bufferFrameLocation + (i * 3)]     = color[0];
                    buffer[bufferFrameLocation + (i * 3) + 1] = color[1];
                    buffer[bufferFrameLocation + (i * 3) + 2] = color[2];

                    //show this pixel on display
                    //if (display) displayManager.DisplayPixel(color[0], color[1], color[2], vestManager.leds[i], 5);
                    if (display) displayManager.DisplayPixel(buffer[bufferFrameLocation + (i * 3)], buffer[bufferFrameLocation + (i * 3) + 1], buffer[bufferFrameLocation + (i * 3) + 2], vestManager.leds[i], 5);
                }
                
                //show the progress
                displayManager.Show(currentItternation, itterations, 0);

                movement += speed / 1000;
                currentItternation++;
                if (display)
                {
                    //show this pixel on display
                    int now = (int)stopWatch.ElapsedMilliseconds;
                    int elapsed = (now - lastFrameDisplayTime);
                    if (elapsed < 33)
                    { Thread.Sleep(33 - elapsed); }
                    lastFrameDisplayTime = now;
                }
            }

            FileManager.WriteBufferToFile(fileNane, buffer, vestManager.leds.Count());
            displayManager.Close();
        }

        private IPlasma ChoosePlasma()
        {
            //replace with case when more exist
            return new PlasmaSinXY( );
        }
    }
}
