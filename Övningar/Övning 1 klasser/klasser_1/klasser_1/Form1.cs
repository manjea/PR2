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
        List<Bil> bilLista;
        public Form1()
        {
            bilLista = new List<Bil>();
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
                bilLista.Add(bil1);
                lbxBilar.Items.Add(bil1.returnInfo());
            }
            catch (Exception _ex)
            {
                MessageBox.Show("fel: " + _ex);
            }
        }

        private void btnAndra_Click(object sender, EventArgs e)
        {
            pnlEgenskaper.Visible = true;
        }

        private void btnAndraEgenskaper_Click(object sender, EventArgs e)
        {


            string m;
            int am;
            double km;


            try
            {
                int index = lbxBilar.SelectedIndex;
                km = double.Parse(nyaMil.Text);

                bilLista[index].setMil(km);
                lbxBilar.Items.Clear();

                for (int i = 0; i < bilLista.Count; i++)
                {
                    lbxBilar.Items.Add(bilLista[i].returnInfo());
                }
            }
            catch (Exception _ex)
            {
                
            }
            try
            {
                int index = lbxBilar.SelectedIndex;
                am = Int32.Parse(txbNyAm.Text);

                bilLista[index].setArsmodell(am);
                lbxBilar.Items.Clear();

                for (int i = 0; i < bilLista.Count; i++)
                {
                    lbxBilar.Items.Add(bilLista[i].returnInfo());
                }
            }
            catch (Exception _ex)
            {
                
            }
            try
            {
                int index = lbxBilar.SelectedIndex;
                m = tbxNyttMarke.Text.ToString();
                if (m != "")
                {
                    bilLista[index].setMarke(m);
                    lbxBilar.Items.Clear();

                    for (int i = 0; i < bilLista.Count; i++)
                    {
                        lbxBilar.Items.Add(bilLista[i].returnInfo());
                    }
                }
            }
            catch (Exception _ex)
            {

            }

            pnlEgenskaper.Visible = false;
        }
    }
}
