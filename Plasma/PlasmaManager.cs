using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedVestPlasmaGenerator.Domain;

namespace LedVestPlasmaGenerator.Plasma
{
    class PlasmaManager
    {
        DisplayManager display;
        VestManager vest;

        //color control
        private bool showRed, showGreen, showBlue, morphGreen, morphBlue;

        private int itterations;
        private int currentItternation;

        private string fileMane;

        public PlasmaManager()
        {
            display = new DisplayManager(400, 600);
            vest = new VestManager();
        }

        public void ExecutePlasma(int _itterations, int _brightness, int size, string _fileName, bool _showRed, bool _showGreen, bool _showBlue, bool _morphGreen, bool _morphBlue)
        {
            itterations = _itterations;
            fileMane = _fileName;

            IPlasma plasmaGenerator = ChoosePlasma();

            plasmaGenerator.SetParameters(_brightness, size, showRed, showGreen, showBlue, morphGreen, morphBlue);

            while (currentItternation < itterations)
            { 
                
            }

        }

        private IPlasma ChoosePlasma()
        {
            //replace with case when more exist
            return new PlasmaSinXY( );
        }
    }
}
