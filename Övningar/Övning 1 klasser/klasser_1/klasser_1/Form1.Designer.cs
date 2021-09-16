
namespace klasser_1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMarke = new System.Windows.Forms.TextBox();
            this.tbxArsmodell = new System.Windows.Forms.TextBox();
            this.tbxKorda_mil = new System.Windows.Forms.TextBox();
            this.btnLaggTill = new System.Windows.Forms.Button();
            this.lbxBilar = new System.Windows.Forms.ListBox();
            this.btnAndra = new System.Windows.Forms.Button();
            this.bortBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kördamil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Årsmodell";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Märke";
            // 
            // tbxMarke
            // 
            this.tbxMarke.Location = new System.Drawing.Point(55, 118);
            this.tbxMarke.Name = "tbxMarke";
            this.tbxMarke.Size = new System.Drawing.Size(100, 20);
            this.tbxMarke.TabIndex = 3;
            // 
            // tbxArsmodell
            // 
            this.tbxArsmodell.Location = new System.Drawing.Point(214, 118);
            this.tbxArsmodell.Name = "tbxArsmodell";
            this.tbxArsmodell.Size = new System.Drawing.Size(100, 20);
            this.tbxArsmodell.TabIndex = 4;
            // 
            // tbxKorda_mil
            // 
            this.tbxKorda_mil.Location = new System.Drawing.Point(369, 118);
            this.tbxKorda_mil.Name = "tbxKorda_mil";
            this.tbxKorda_mil.Size = new System.Drawing.Size(100, 20);
            this.tbxKorda_mil.TabIndex = 5;
            // 
            // btnLaggTill
            // 
            this.btnLaggTill.Location = new System.Drawing.Point(55, 182);
            this.btnLaggTill.Name = "btnLaggTill";
            this.btnLaggTill.Size = new System.Drawing.Size(75, 26);
            this.btnLaggTill.TabIndex = 6;
            this.btnLaggTill.Text = "Lägg till";
            this.btnLaggTill.UseVisualStyleBackColor = true;
            this.btnLaggTill.Click += new System.EventHandler(this.btnLaggTill_Click);
            // 
            // lbxBilar
            // 
            this.lbxBilar.FormattingEnabled = true;
            this.lbxBilar.Location = new System.Drawing.Point(55, 223);
            this.lbxBilar.Name = "lbxBilar";
            this.lbxBilar.Size = new System.Drawing.Size(414, 95);
            this.lbxBilar.TabIndex = 7;
            // 
            // btnAndra
            // 
            this.btnAndra.Location = new System.Drawing.Point(230, 182);
            this.btnAndra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAndra.Name = "btnAndra";
            this.btnAndra.Size = new System.Drawing.Size(64, 26);
            this.btnAndra.TabIndex = 9;
            this.btnAndra.Text = "Ändra";
            this.btnAndra.UseVisualStyleBackColor = true;
            this.btnAndra.Click += new System.EventHandler(this.btnAndra_Click);
            // 
            // bortBtn
            // 
            this.bortBtn.Location = new System.Drawing.Point(394, 184);
            this.bortBtn.Name = "bortBtn";
            this.bortBtn.Size = new System.Drawing.Size(75, 23);
            this.bortBtn.TabIndex = 10;
            this.bortBtn.Text = "bort";
            this.bortBtn.UseVisualStyleBackColor = true;
            this.bortBtn.Click += new System.EventHandler(this.bortBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 330);
            this.Controls.Add(this.bortBtn);
            this.Controls.Add(this.btnAndra);
            this.Controls.Add(this.lbxBilar);
            this.Controls.Add(this.btnLaggTill);
            this.Controls.Add(this.tbxKorda_mil);
            this.Controls.Add(this.tbxArsmodell);
            this.Controls.Add(this.tbxMarke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMarke;
        private System.Windows.Forms.TextBox tbxArsmodell;
        private System.Windows.Forms.TextBox tbxKorda_mil;
        private System.Windows.Forms.Button btnLaggTill;
        private System.Windows.Forms.ListBox lbxBilar;
        private System.Windows.Forms.Button btnAndra;
        private System.Windows.Forms.Button bortBtn;
    }
}

