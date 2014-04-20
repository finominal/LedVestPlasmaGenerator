namespace LedVestPlasmaGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ckGreenMorph = new System.Windows.Forms.CheckBox();
            this.ckGreenShow = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckBlueMorph = new System.Windows.Forms.CheckBox();
            this.ckBlueShow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckRedShow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBrightness = new System.Windows.Forms.GroupBox();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.selBrightnes = new System.Windows.Forms.TrackBar();
            this.textSaveAs = new System.Windows.Forms.TextBox();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItterations = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selBrightnes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(444, 409);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ckGreenMorph
            // 
            this.ckGreenMorph.AutoSize = true;
            this.ckGreenMorph.ForeColor = System.Drawing.Color.Green;
            this.ckGreenMorph.Location = new System.Drawing.Point(139, 62);
            this.ckGreenMorph.Name = "ckGreenMorph";
            this.ckGreenMorph.Size = new System.Drawing.Size(62, 19);
            this.ckGreenMorph.TabIndex = 2;
            this.ckGreenMorph.Text = "Morph";
            this.ckGreenMorph.UseVisualStyleBackColor = true;
            // 
            // ckGreenShow
            // 
            this.ckGreenShow.AutoSize = true;
            this.ckGreenShow.Checked = true;
            this.ckGreenShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckGreenShow.ForeColor = System.Drawing.Color.Green;
            this.ckGreenShow.Location = new System.Drawing.Point(71, 62);
            this.ckGreenShow.Name = "ckGreenShow";
            this.ckGreenShow.Size = new System.Drawing.Size(57, 19);
            this.ckGreenShow.TabIndex = 1;
            this.ckGreenShow.Text = "Show";
            this.ckGreenShow.UseVisualStyleBackColor = true;
            this.ckGreenShow.CheckedChanged += new System.EventHandler(this.ckGreenShow_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "GREEN";
            // 
            // ckBlueMorph
            // 
            this.ckBlueMorph.AutoSize = true;
            this.ckBlueMorph.ForeColor = System.Drawing.Color.Blue;
            this.ckBlueMorph.Location = new System.Drawing.Point(139, 98);
            this.ckBlueMorph.Name = "ckBlueMorph";
            this.ckBlueMorph.Size = new System.Drawing.Size(62, 19);
            this.ckBlueMorph.TabIndex = 2;
            this.ckBlueMorph.Text = "Morph";
            this.ckBlueMorph.UseVisualStyleBackColor = true;
            // 
            // ckBlueShow
            // 
            this.ckBlueShow.AutoSize = true;
            this.ckBlueShow.Checked = true;
            this.ckBlueShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBlueShow.ForeColor = System.Drawing.Color.Blue;
            this.ckBlueShow.Location = new System.Drawing.Point(71, 98);
            this.ckBlueShow.Name = "ckBlueShow";
            this.ckBlueShow.Size = new System.Drawing.Size(57, 19);
            this.ckBlueShow.TabIndex = 1;
            this.ckBlueShow.Text = "Show";
            this.ckBlueShow.UseVisualStyleBackColor = true;
            this.ckBlueShow.CheckedChanged += new System.EventHandler(this.ckBlueShow_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "BLUE";
            // 
            // ckRedShow
            // 
            this.ckRedShow.AutoSize = true;
            this.ckRedShow.Checked = true;
            this.ckRedShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckRedShow.ForeColor = System.Drawing.Color.Red;
            this.ckRedShow.Location = new System.Drawing.Point(71, 25);
            this.ckRedShow.Name = "ckRedShow";
            this.ckRedShow.Size = new System.Drawing.Size(57, 19);
            this.ckRedShow.TabIndex = 1;
            this.ckRedShow.Text = "Show";
            this.ckRedShow.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "RED";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckBlueMorph);
            this.groupBox1.Controls.Add(this.ckGreenMorph);
            this.groupBox1.Controls.Add(this.ckRedShow);
            this.groupBox1.Controls.Add(this.ckBlueShow);
            this.groupBox1.Controls.Add(this.ckGreenShow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 133);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Control";
            // 
            // groupBrightness
            // 
            this.groupBrightness.Controls.Add(this.lblBrightness);
            this.groupBrightness.Controls.Add(this.selBrightnes);
            this.groupBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBrightness.Location = new System.Drawing.Point(281, 12);
            this.groupBrightness.Name = "groupBrightness";
            this.groupBrightness.Size = new System.Drawing.Size(238, 68);
            this.groupBrightness.TabIndex = 3;
            this.groupBrightness.TabStop = false;
            this.groupBrightness.Text = "Brightness";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(126, 25);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(32, 15);
            this.lblBrightness.TabIndex = 8;
            this.lblBrightness.Text = "20%";
            // 
            // selBrightnes
            // 
            this.selBrightnes.Location = new System.Drawing.Point(15, 22);
            this.selBrightnes.Minimum = 1;
            this.selBrightnes.Name = "selBrightnes";
            this.selBrightnes.Size = new System.Drawing.Size(104, 42);
            this.selBrightnes.TabIndex = 7;
            this.selBrightnes.Value = 2;
            this.selBrightnes.Scroll += new System.EventHandler(this.selBrightnes_Scroll);
            // 
            // textSaveAs
            // 
            this.textSaveAs.Location = new System.Drawing.Point(12, 180);
            this.textSaveAs.Name = "textSaveAs";
            this.textSaveAs.Size = new System.Drawing.Size(426, 20);
            this.textSaveAs.TabIndex = 0;
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(444, 178);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect.TabIndex = 1;
            this.btnFileSelect.Text = "Browse";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Save As";
            // 
            // txtItterations
            // 
            this.txtItterations.Location = new System.Drawing.Point(12, 234);
            this.txtItterations.Name = "txtItterations";
            this.txtItterations.Size = new System.Drawing.Size(100, 20);
            this.txtItterations.TabIndex = 5;
            this.txtItterations.Text = "100000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Itterations";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 444);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtItterations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFileSelect);
            this.Controls.Add(this.textSaveAs);
            this.Controls.Add(this.groupBrightness);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "MainForm";
            this.Text = "Led Vest Plasma Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBrightness.ResumeLayout(false);
            this.groupBrightness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selBrightnes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox ckGreenMorph;
        private System.Windows.Forms.CheckBox ckGreenShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckBlueMorph;
        private System.Windows.Forms.CheckBox ckBlueShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckRedShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBrightness;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox textSaveAs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItterations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.TrackBar selBrightnes;
    }
}

