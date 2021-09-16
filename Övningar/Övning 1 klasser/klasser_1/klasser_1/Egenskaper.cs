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
    public partial class Egenskaper : Form
    {
        int index;
        public string ReturnValue1 { get; set; }
        public int ReturnValue2;
        public double ReturnValue3;
        public Egenskaper(int a)
        {
            index = a;
            InitializeComponent();
        }

        private void tbxNyttMarke_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbNyAm_TextChanged(object sender, EventArgs e)
        {

        }

        private void nyaMil_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAndraEgenskaper_Click(object sender, EventArgs e)
        {


            string m;
            int am;
            double km;

            
            try
            {
                km = double.Parse(nyaMil.Text);

                this.ReturnValue3 = km;

            }
            catch (Exception _ex)
            {
                
            }
            try
            {
                am = Int32.Parse(txbNyAm.Text);

                this.ReturnValue2 = am;

            }
            catch (Exception _ex)
            {
                
            }
            try
            {
                m = tbxNyttMarke.Text.ToString();
                if (m != "")
                {
                    this.ReturnValue1 = m;
                }
            }
            catch (Exception _ex)
            {

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
