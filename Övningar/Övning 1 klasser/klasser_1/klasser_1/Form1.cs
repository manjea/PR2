using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace klasser_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLaggTill_Click(object sender, EventArgs e)
        {
            string m;
            int am;
            double km;
            
            try
            {
                m = tbxMarke.Text;
                am = Int32.Parse(tbxArsmodell.Text);
                km = double.Parse(tbxKorda_mil.Text);
                Bil bil1 = new Bil(m, am, km);
                lbxBilar.Items.Add(bil1.marke + "\t" + bil1.arsmodell + "\t" + bil1.mil);
            }
            catch (Exception _ex)
            {
                MessageBox.Show("fel: " + _ex);
            }
        }
    }
}
