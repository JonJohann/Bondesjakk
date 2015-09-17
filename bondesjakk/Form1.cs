using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bondesjakk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Trykk bår du er klar til å spille.");

            DialogResult svar = MessageBox.Show("Skal spiller 1 (X) begynne?", "Velg spiller", MessageBoxButtons.YesNo);

            if (svar == DialogResult.Yes)
            {
                spillerX = true;
            }
            else if (svar == DialogResult.No)
            {
                spillerX = false;
            }
        }

        bool spillerX;
        int antall_trekk = 0;
        int antSeierX, antSeierO = 0;

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "")
            {
                if (spillerX)
                    btn1.Text = "X";
                else
                    btn1.Text = "O";
                spillerX = !spillerX;

                antall_trekk = antall_trekk + 1;
            }
            sjekk_Vinner();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                if (spillerX)
                    btn2.Text = "X";
                else
                    btn2.Text = "O";
                spillerX = !spillerX;
            }
            sjekk_Vinner();
        }

        private void sjekk_Vinner()
        {
            //Variable for å registrere 3 like på rad.
            bool h3prX = (btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X") ||
                        (btn4.Text == "X" && btn5.Text == "X" && btn6.Text == "X") ||
                        (btn7.Text == "X" && btn8.Text == "X" && btn9.Text == "X");
            bool v3prX = (btn1.Text == "X" && btn4.Text == "X" && btn7.Text == "X") ||
                        (btn2.Text == "X" && btn5.Text == "X" && btn8.Text == "X") ||
                        (btn3.Text == "X" && btn6.Text == "X" && btn9.Text == "X");
            bool d3prX = (btn1.Text == "X" && btn5.Text == "X" && btn9.Text == "X") ||
                        (btn3.Text == "X" && btn5.Text == "X" && btn7.Text == "X");
            bool h3prO = (btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O") ||
                        (btn4.Text == "O" && btn5.Text == "O" && btn6.Text == "O") ||
                        (btn7.Text == "O" && btn8.Text == "O" && btn9.Text == "O");
            bool v3prO = (btn1.Text == "O" && btn4.Text == "O" && btn7.Text == "O") ||
                        (btn2.Text == "O" && btn5.Text == "O" && btn8.Text == "O") ||
                        (btn3.Text == "O" && btn6.Text == "O" && btn9.Text == "O");
            bool d3prO = (btn1.Text == "O" && btn5.Text == "O" && btn9.Text == "O") ||
                        (btn3.Text == "O" && btn5.Text == "O" && btn7.Text == "O");

            bool vinnerX = h3prX || v3prX || d3prX;
            bool vinnerO = h3prO || v3prO || d3prO;

            string melding = "";

            if (vinnerX || vinnerO)
            {
                deaktiver_SpillKnapper();
                if (vinnerX)
                {
                    melding = "Spiller 1 - X, har vunnet";
                    antSeierX++; // NB! Samme som antSeierX = antSeierX + 1;
                }
                else if (vinnerO)
                {
                    melding = "Spiller 2 - O, har vunnet";
                    antSeierO++;
                }
            }
            else if (!vinnerX && !vinnerO && antall_trekk == 9)
            {
                melding = "Ingen vinner!";
                deaktiver_SpillKnapper();
            }

            info.Text = melding;
            lbSeiereX.Text = Convert.ToString(antSeierX);
            lbSeiereO.Text = Convert.ToString(antSeierO);
        }




        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Text == "")
            {
                if (spillerX)
                    btn.Text = "X";
                else
                    btn.Text = "O";
                spillerX = !spillerX;

                antall_trekk = antall_trekk + 1;
            }
                sjekk_Vinner();
        }

        private void deaktiver_SpillKnapper()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;

            btnNy.Visible = true;
            info.Visible = true;
        }

        private void btnNy_Click(object sender, EventArgs e)
        {
            antall_trekk = 0;

            btnNy.Visible = false;
            info.Visible = false;

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

        }
    }
}
