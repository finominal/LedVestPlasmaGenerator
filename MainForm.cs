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
using LedVestPlasmaGenerator.Plasma;


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

            PlasmaManager plasma = new PlasmaManager();

            plasma.GeneratePlasma(int.Parse(txtItterations.Text), selBrightnes.Value, selSize.Value*5, selSpeed.Value*2, txtSaveAs.Text,
                ckDisplay.Checked, //display 
                ckRedShow.Checked, ckGreenShow.Checked, ckBlueShow.Checked, ckGreenMorph.Checked, ckBlueMorph.Checked, ckPinkShow.Checked);
        
        }
        
        private bool AreParametersValid()
        {
            Validator validate = new Validator();

            if (this.txtSaveAs.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to save as.");
                this.txtSaveAs.Focus();
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
                txtSaveAs.Text = fileName;
            }
        }

        private String CreateFileName(String filter)
        {
            var dlg = new SaveFileDialog { Filter = filter, RestoreDirectory = true };
            if (txtSaveAs.Text.Length > 0)
            {
                dlg.InitialDirectory = GetCurrentFilePath();
            }

            return dlg.ShowDialog(this) == DialogResult.OK ? dlg.FileName : null;
        }

        private String GetCurrentFilePath()
        {
            return txtSaveAs.Text.Substring(0, txtSaveAs.Text.LastIndexOf("\\") + 1);
        }

        private void selBrightnes_Scroll(object sender, EventArgs e)
        {
            lblBrightness.Text = (selBrightnes.Value * 10).ToString() + "%" ;
        }

        private void ckGreenShow_CheckedChanged(object sender, EventArgs e)
        {
            //disable the morphing check, just to look neater
            ckGreenMorph.Enabled = ckGreenShow.Checked;
            ckPinkShow.Checked = false;
        }

        private void ckBlueShow_CheckedChanged(object sender, EventArgs e)
        {
            //disable the morphing check, just to look neater
            ckBlueMorph.Enabled = ckBlueShow.Checked;
            
            ckPinkShow.Checked = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtSize.Text = selSize.Value.ToString();
        }

        private void selSpeed_Scroll(object sender, EventArgs e)
        {
            txtSpeed.Text = selSpeed.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtItterations.Text = "100000";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ckBlueShow.Checked = ckRedShow.Checked = ckGreenShow.Checked = false;
        }

        private void ckRedShow_CheckedChanged(object sender, EventArgs e)
        {
            ckPinkShow.Checked = false;
        }
    }
}
