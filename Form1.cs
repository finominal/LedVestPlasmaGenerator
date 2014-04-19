using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedVestPlasmaGenerator.Domain;

namespace LedVestPlasmaGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
           Plasma plasmaGenerator = new Plasma();

           plasmaGenerator.GeneratePlasmaForVest(100, 10, 0.067, 100000, true);
        }

    }
}
