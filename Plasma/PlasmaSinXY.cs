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
        bool showRed, showGreen, showBlue, morphGreen, morphBlue, showPink;
        double brightness;
        double size;
        double minShade = -1.1;
        double maxShade = 1.1;

        //double  worldWidth = 33;
        //double worldHeight = 19;

        double worldWidth = 278;
        double worldHeight = 224;

        public void SetParameters(int _brightness, int _size, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue, bool _showPink)
        {
            brightness = _brightness * 25;
            size = _size ; //rescale
            showRed = _showRed;
            showGreen = _showGreen;
            showBlue = _showBlue;
            morphGreen = _morphGreen;
            morphBlue = _morphBlue;
            ; showPink = _showPink;
        }

        public byte[] RenderPlasmaPixel(int x, int y, double movement)
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
            var a =  SinVerticle(x, y, size * 2, movement);
            var b =  SinRotating(x, y, size, movement);
            var c = SinCircle(x, y, size, movement);
            var shade = (a + b + c) /2;

            if (showPink)
            {
                sinShadePiBlue = Math.Sin(shade * Math.PI) ;
                sinShadePiRed = Math.Sin(shade * Math.PI);
                sinShadePiGreen = Math.Sin(shade * Math.PI) ;

                result[2] = Map(sinShadePiBlue, brightness/2);
                result[0] = Map(sinShadePiRed, brightness);
                result[1] = Map(sinShadePiGreen, brightness/8);
            }
            else
            {
                //Create Colors from the shade
                if (showRed) sinShadePiRed = Math.Sin(shade * Math.PI);
                if (showGreen) sinShadePiGreen = Math.Sin(shade * Math.PI + (Math.PI / 2));
                if (showBlue) sinShadePiBlue = Math.Sin(shade * Math.PI + Math.PI);


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
                        result[2] = Map(Math.Sin(sinShadePiBlue * Math.PI * Math.Sin(movement / 13)), brightness);
                    }
                    else
                    {
                        result[2] = Map(sinShadePiBlue, brightness);
                    }
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
            var cx = worldWidth * 2 * Math.Sin(movement /5);
            var cy = worldHeight * 2 * Math.Cos(movement /5);
            
            //stationary circle
            //cx = worldWidth / 2 ;
            //cy = worldHeight / 2;
 
            var dist = Math.Sqrt(Math.Pow(cy - y,2) + Math.Pow(cx - x,2));
            var result = Math.Sin((dist / size * 2) + movement);
            return result;
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
