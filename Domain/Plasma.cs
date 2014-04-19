using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LedVestPlasmaGenerator.Domain
{
    public class Plasma
    {
        VestManager vest;

        const int worldWidth = 645;
        const int worldHeight = 360;

        const int displayPixelSize = 10;

        double movement;
        double brightness;
        double size;

        double movementFactor;

        //keep track of how many itterations have been 
        int totalItterations;
        int currentItteration;

        //faster rendering if variables are global
        int redShade, greenShade, blueShade; //rendered color shades
        double dist, cx, cy; //circle animation

        //helps manage maximum brightness
        double minShade = -1.2;
        double maxShade = 1.2;

        double sinShadePiRed, sinShadePiGreen, sinShadePiBlue;

        double minShadeR, minShadeG, minShadeB;
        double maxShadeR, maxShadeG, maxShadeB;
        double shade = 0.1F;

        bool showDisplay;

        DisplayFormManager displayFormManager;

        public void GeneratePlasmaForVest(double _brightness, double _size, double _movementFactor, int _itterations, bool _display )
        {
            //copy in the variables
            brightness = _brightness;
            size = _size;
            movementFactor = _movementFactor;
            totalItterations = _itterations;
            showDisplay = _display;

            //declare a new instance of the vest manager
            vest = new VestManager();

            displayFormManager = new DisplayFormManager(worldWidth, worldHeight);

            while (currentItteration++ < totalItterations)
            {
                RenderPlasmaFrame();
            }
        }

        public void RenderPlasmaFrame()
        {
            //each itteration is advanced through time with the movement value, smaller value = slower movement

            for (int i = 0; i < vest.leds.Length; i++)
            {

                //create three different sin waves and combine the results
                var shade = (
                            SinVerticle(vest.leds[i].X, vest.leds[i].Y, size)
                            + SinRotating(vest.leds[i].X, vest.leds[i].Y, size)
                            + SinCircle(vest.leds[i].X, vest.leds[i].Y, size)
                            );

                //Create Colors from the shade
                sinShadePiRed = Math.Sin(shade * Math.PI);
                sinShadePiGreen = Math.Sin(shade * Math.PI + 2);
                sinShadePiBlue = Math.Sin(shade * Math.PI + 4);

                SelfCorrectMapping();
                
                //map static colors
                redShade = Map(sinShadePiRed, brightness);
                greenShade = Map( sinShadePiGreen, brightness);
                blueShade = Map( sinShadePiBlue, brightness);

                //map to morphing colors
                //greenShade = Map(Math.Sin(sinShadePiGreen * (Math.Sin(movement / 2)), brightness);
                //blueShade = Map(Math.Sin(sinShadePiBlue * Math.PI * Math.Sin(movement / 7)), brightness);

                //WriteLedDataToFileBuffer(redShade, greenShade, blueShade, i);

                if (showDisplay) displayFormManager.DisplayPixel(redShade, greenShade, blueShade, vest.leds[i], displayPixelSize); 

            }
            displayFormManager.Show(currentItteration, totalItterations);//show the current frame of plasma
        }

        double SinVerticle(double x, double y, double s)
        {
            return (double)Math.Sin(x / s + movement);
        }

        double SinRotating(double x, double y, double s)
        {
            return (double)Math.Sin((x * Math.Sin(movement / 9) + y * Math.Cos(movement / 6)) / (size * .6));
        }

        double SinCircle(double x, double y, double s)
        {
            cx = worldWidth * Math.Sin(movement / 5) ;
            cy = worldHeight * Math.Cos(movement / 10) ;
            //cx = worldWidth / 2.5 * ledFactor;
            //cy = worldHeight / 2.5 * ledFactor;

            dist = Math.Sqrt(Math.Sqrt(cy - y) + Math.Sqrt(cx - x));
            return Math.Sin((dist / s) + movement);
        }


        void SelfCorrectMapping()
        {
            // tune mapping values to ensure maximum led resolution
            if (sinShadePiRed < minShade) minShade = sinShadePiRed;
            if (sinShadePiRed > maxShade) maxShade = sinShadePiRed;
            if (sinShadePiGreen < minShade) minShade = sinShadePiGreen;
            if (sinShadePiGreen > maxShade) maxShade = sinShadePiGreen;
            if (sinShadePiBlue < minShade) minShade = sinShadePiBlue;
            if (sinShadePiBlue > maxShade) maxShade = sinShadePiBlue;
        }

        private void WriteBufferToFile(string saveFileName)
        {
            //FileManager.WriteBufferToFile(saveFileName, copyBuffer);
        }
        
        private byte Map(double source, double brightness )
        {
            var normalized = source - minShade;
            var scope = maxShade - minShade;
            
            var percentage = normalized / scope;
            return (byte)(brightness * percentage); 
        }

        private int Color(int r, int g, int b)
        {
            int result;

            result = r & 0x000F; //MSB, mask first 8 bits
            result <<= 8;
            result += g & 0x000F;
            result <<= 8;
            result += b & 0x000F;

            return result;

        }

        /*
          GeneratePlasmaForVest(128, 80, 4, 0.067, true  );
         
         */

    }
}
