using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace latihan1
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
        }

        double HasilTemp;
        char LambangOperator;
        bool OperatorDitekan;

        private void fokuskan()
        {
            textUtama.Focus();
            textUtama.Select(textUtama.Text.Length, 1);
        }

        private void clearHasil()
        {
            HasilTemp = 0;
            LambangOperator = ' ';
            OperatorDitekan = false;
        }

        private void clearkan()
        {
            textUtama.Text = "0";
            textTemp.Text = "";
            clearHasil();
        }

        private void Kalkulator_Load(object sender, EventArgs e)
        {
            clearkan();
            fokuskan();
        }

        private void btnAngka_Click(object sender, EventArgs e)
        {
            Button btnA = (Button)sender;
            if (textUtama.Text == "0")
            {
                textUtama.Clear();
            }
            if (LambangOperator == '=')
            {
                textUtama.Clear();
                LambangOperator = ' ';
                HasilTemp = 0;
            }
            textUtama.Text = textUtama.Text + btnA.Text;
            OperatorDitekan = false;
            fokuskan();
        }

        private void btnKoma_Click(object sender, EventArgs e)
        {
            if (textUtama.Text.Contains(',') == false)
            {
                textUtama.Text = textUtama.Text + ",";
            }
            if (LambangOperator == '=')
            {
                clearHasil();
            }
            fokuskan();
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            textUtama.Text = (Convert.ToDouble(textUtama.Text) * -1).ToString();
            fokuskan();
        }

        private void C_Click(object sender, EventArgs e)
        {
            clearkan();
            fokuskan();
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textUtama.Text = "0";
            if (LambangOperator == '0')
            {
                clearHasil();
            }
            fokuskan();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            textUtama.Text = textUtama.Text.Remove(textUtama.Text.Length - 1);
            if ((textUtama.Text == "") || (textUtama.Text == "_"))
            {
                textUtama.Text = "0";
            }
            if (LambangOperator == '=')
            {
                clearHasil();
            }
            fokuskan();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btnOP = (Button)sender;
            if (OperatorDitekan == false)
            {
                if (textTemp.Text == "")
                {
                    HasilTemp = Convert.ToDouble(textUtama.Text);
                }
                else
                {
                    if (LambangOperator == '+')
                    {
                        HasilTemp = HasilTemp + Convert.ToDouble(textUtama.Text);
                    }
                    else if (LambangOperator == '-')
                    {
                        HasilTemp = HasilTemp - Convert.ToDouble(textUtama.Text);
                    }
                    else if (LambangOperator == ':')
                    {
                        HasilTemp = HasilTemp / Convert.ToDouble(textUtama.Text);
                    }
                    else if (LambangOperator == 'X')
                    {
                        HasilTemp = HasilTemp * Convert.ToDouble(textUtama.Text);
                    }
                }
            }

            if (btnOP.Text == "=")
            {
                textTemp.Text = "";
                textUtama.Text = HasilTemp.ToString();
            }
            else
            {
                textTemp.Text = HasilTemp.ToString() + btnOP.Text;
                textUtama.Text = "0";
            }

            LambangOperator = Convert.ToChar(btnOP.Text);
            OperatorDitekan = true;
            fokuskan();


        }
    }
}
