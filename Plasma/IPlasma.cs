using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedVestPlasmaGenerator.Plasma
{
    interface IPlasma
    {
        void SetParameters(int _brightness, int size, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue, bool _showPink);
        byte[] RenderPlasmaPixel(int x, int y, double movement);

    }
}
