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
using LedVestPlasmaGenerator.Validation;

namespace LedVestPlasmaGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!AreParametersValid()) return;

            Plasma plasmaGenerator = new Plasma();

            plasmaGenerator.GeneratePlasmaForVest(
                (double)selBrightnes.Value * 25,
                5, //size, inverse
                0.097, //advance time
                100000, //itterations
                true, //display, slower to do this by a factor of 1000
                ckRedShow.Checked,
                ckGreenShow.Checked,
                ckBlueShow.Checked,
                ckGreenMorph.Checked,
                ckBlueMorph.Checked,
                textSaveAs.Text
             );
        }

        private bool AreParametersValid()
        {
            Validator validate = new Validator();

            if (this.textSaveAs.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to save as.");
                this.textSaveAs.Focus();
                return false;
            }

            if (!validate.IsNumeric(txtItterations.Text))
            {
                MessageBox.Show("The number of itterations must be a numeric value.");
                this.txtItterations.Focus();
                return false;
            }

            return true;
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            var fileName = CreateFileName("LedFile (*.led)|*.led");
            if (fileName != null)
            {
                textSaveAs.Text = fileName;
            }
        }

        private String CreateFileName(String filter)
        {
            var dlg = new SaveFileDialog { Filter = filter, RestoreDirectory = true };
            if (textSaveAs.Text.Length > 0)
            {
                dlg.InitialDirectory = GetCurrentFilePath();
            }

            return dlg.ShowDialog(this) == DialogResult.OK ? dlg.FileName : null;
        }

        private String GetCurrentFilePath()
        {
            return textSaveAs.Text.Substring(0, textSaveAs.Text.LastIndexOf("\\") + 1);
        }

        private void selBrightnes_Scroll(object sender, EventArgs e)
        {
            lblBrightness.Text = (selBrightnes.Value * 10).ToString() + "%" ;
        }

        private void ckGreenShow_CheckedChanged(object sender, EventArgs e)
        {
            //disable the morphing check, just to look neater
            ckGreenMorph.Enabled = ckGreenShow.Checked;
        }

        private void ckBlueShow_CheckedChanged(object sender, EventArgs e)
        {
            //disable the morphing check, just to look neater
            ckBlueMorph.Enabled = ckBlueShow.Checked;
        }
    }
}
