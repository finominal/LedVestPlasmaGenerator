using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedVestPlasmaGenerator.Plasma
{
    public class PlasmaSinXY : IPlasma
    {
        //color control
        bool showRed, showGreen, showBlue, morphGreen, morphBlue;
        double brightness;
        double size;
        double minShade = -1.1;
        double maxShade = 1.1;

        double  worldWidth = 33;
        double worldHeight = 19;

        public void SetParameters(int _brightness, int _size, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue)
        {
            brightness = _brightness;
            size = _size;
            showRed = _showRed;
            showGreen = _showGreen;
            showBlue = _showBlue;
            morphGreen = _morphGreen;
            morphBlue = _morphBlue;
        }

        public byte[] RenderPlasmaFrame(int x, int y, double movement)
        {
            byte[] result = new byte[3];
            double sinShadePiRed, sinShadePiGreen, sinShadePiBlue;
            sinShadePiRed = sinShadePiGreen = sinShadePiBlue = 0; 

            //create three different sin waves and combine the results
            //var shade = (
            //            SinVerticle(vest.leds[i].X, vest.leds[i].Y, size)
            //            + SinRotating(vest.leds[i].X, vest.leds[i].Y, size)
            //            + SinCircle(vest.leds[i].X, vest.leds[i].Y, size)
            //            );

            //separated for debugging
            var a = SinVerticle(x, y, size, movement);
            var b = SinRotating(x, y, size, movement);
            var c = 0; // SinCircle(x, y, size, movement);
            var shade = a + b + c;

            //Create Colors from the shade
            if (showRed) sinShadePiRed = Math.Sin(shade * Math.PI);
            if (showGreen) sinShadePiGreen = Math.Sin(shade * Math.PI + 2);
            if (showBlue) sinShadePiBlue = Math.Sin(shade * Math.PI + 4);

            //map colors
            if (showRed) result[0] = Map(sinShadePiRed, brightness);

            
            if (showGreen)
            {
                if (morphGreen)
                {
                    result[1] = Map(Math.Sin(sinShadePiGreen * (Math.Sin(movement / 2))), brightness);
                }
                else
                {
                    result[1] = Map(sinShadePiGreen, brightness);
                }
            }

            if (showBlue)
            {
                if (morphBlue)
                {
                    result[2] = Map(Math.Sin(sinShadePiBlue * Math.PI * Math.Sin(movement / 7)), brightness);
                }
                else
                {
                    result[2] = Map(sinShadePiBlue, brightness);
                }
            }

            return result;
       }

        private double SinVerticle(double x, double y, double size, double movement)
        {
            return (double)Math.Sin(x / size + movement);
        }

        private double SinRotating(double x, double y, double size, double movement)
        {
            return (double)Math.Sin((x * Math.Sin(movement / 9) + y * Math.Cos(movement / 6)) / (size * .6));
        }

        private double SinCircle(double x, double y, double size, double movement)
        {
            //moving circle 
            var cx = worldWidth * Math.Sin(movement / 5);
            var cy = worldHeight * Math.Cos(movement / 10);
            
            //stationary circle
            //cx = worldWidth / 2.5 * ledFactor;
            //cy = worldHeight / 2.5 * ledFactor;

            var dist = Math.Sqrt(Math.Sqrt(cy - y) + Math.Sqrt(cx - x));
            return Math.Sin((dist / size) + movement);
        }

        private byte Map(double source, double brightness)
        {
            var normalized = source - minShade;
            var scope = maxShade - minShade;

            var percentage = normalized / scope;
            return (byte)(brightness * percentage);
        }
    }
}
