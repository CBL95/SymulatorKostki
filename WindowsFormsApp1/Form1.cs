using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double stan = 100;
        private int zaznaczona;
        private double mnoznik = 0.9;
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = true;
            if (toolStripMenuItem5.Checked)
            {
                toolStripMenuItem4.Checked = false;
                toolStripMenuItem3.Checked = false;
                mnoznik = 0.8;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = true;
            if (toolStripMenuItem4.Checked) {
                toolStripMenuItem5.Checked = false;
                toolStripMenuItem3.Checked = false;
                mnoznik = 0.9;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.Checked = true;
            if (toolStripMenuItem3.Checked)
            {
                toolStripMenuItem5.Checked = false;
                toolStripMenuItem4.Checked = false;
                mnoznik = 1.0;
            }
        }

        public Form1()
        {
            InitializeComponent();
            radioButton7.Checked = true;

            // to wszystko poniżej jest dlatego że na start nie wyłączał się tryb gry numerków, sam sobie je wyłączyłem :)
            podana_kwota.Enabled = true;
            Low.Enabled = true;
            High.Enabled = true;
            High.Checked = false;
            Low.Checked = true;
            label5.Enabled = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            textBox1.Enabled = false;
            label3.Enabled = false;

            button2.Hide();// ukrycie przycisku zagraj jeszcze raz na poczatku
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double kwota = double.Parse(podana_kwota.Text);
                double kwota2 = double.Parse(textBox1.Text);

                Random rnd = new Random();
                if (kwota > stan)
                {
                    kwota=stan;
                    podana_kwota.Text = stan.ToString("0.0");
                }

                if(kwota2 > stan)
                {
                    kwota2 = stan;
                    textBox1.Text = stan.ToString("0.0");
                }
                

                int wylosowana = rnd.Next(1, 7);   // generuje liczbę pomiędzy od 1 do 6
                label2.Text = wylosowana.ToString();



                if (radioButton7.Checked)
                {
                    if (Low.Checked)
                    {
                        if (wylosowana >= 1 && wylosowana <= 3)
                        {

                            label2.ForeColor = Color.FromArgb(0, 200, 0); // wygrana
                            stan = stan + (kwota * mnoznik);
                            stan_konta.Text = stan.ToString("0.0");
                            label6.Text = " + " + (kwota * mnoznik).ToString("0.0");
                            label6.ForeColor = Color.FromArgb(0, 200, 0); // + ile wygranej
                        }

                        if (wylosowana >= 4 && wylosowana <= 6)
                        {
                            label2.ForeColor = Color.FromArgb(255, 0, 0); // przegrana
                            stan = stan - kwota;
                            stan_konta.Text = stan.ToString("0.0");
                            label6.Text = " - " + (kwota).ToString("0.0");
                            label6.ForeColor = Color.FromArgb(255, 0, 0); // - ile przegranej
                        }

                    }

                    if (High.Checked)
                    {
                        if (wylosowana >= 4 && wylosowana <= 6)
                        {
                            label2.ForeColor = Color.FromArgb(0, 200, 0); // wygrana
                            stan = stan + (kwota * mnoznik);

                            stan_konta.Text = stan.ToString("0.0");
                            label6.Text = " + " + (kwota * mnoznik).ToString("0.0");
                            label6.ForeColor = Color.FromArgb(0, 200, 0); // + ile wygranej
                        }

                        if (wylosowana >= 1 && wylosowana <= 3)
                        {
                            label2.ForeColor = Color.FromArgb(255, 0, 0); // przegrana
                            stan = stan - kwota;
                            stan_konta.Text = stan.ToString("0.0");
                            label6.Text = " - " + (kwota).ToString("0.0");
                            label6.ForeColor = Color.FromArgb(255, 0, 0); // - ile przegranej
                        }

                    }
                }

                if (radioButton8.Checked)
                {

                    if (radioButton1.Checked) zaznaczona = 1;
                    if (radioButton2.Checked) zaznaczona = 2;
                    if (radioButton3.Checked) zaznaczona = 3;
                    if (radioButton4.Checked) zaznaczona = 4;
                    if (radioButton5.Checked) zaznaczona = 5;
                    if (radioButton6.Checked) zaznaczona = 6;

                    if (wylosowana == zaznaczona)
                    {
                        label2.ForeColor = Color.FromArgb(0, 200, 0); // wygrana
                        stan = stan + (kwota2 * 6 * mnoznik);
                        stan_konta.Text = stan.ToString("0.0");
                        label6.Text = " + " + (kwota2 * 6 * mnoznik).ToString("0.0");
                        label6.ForeColor = Color.FromArgb(0, 200, 0); // + ile wygranej
                    }
                    else
                    {
                        label2.ForeColor = Color.FromArgb(255, 0, 0); // przegrana
                        stan = stan - kwota2;
                        stan_konta.Text = stan.ToString("0.0");
                        label6.Text = " - " + (kwota2).ToString("0.0");
                        label6.ForeColor = Color.FromArgb(255, 0, 0); // - ile przegranej
                    }

                }

                if (stan == 0)
                {
                    MessageBox.Show("Wszystko Przegrales Hehe");
                    button2.Show();
                    button1.Hide();
                    podana_kwota.Text = "0";
                    textBox1.Text = "0";
                    label6.Text = null;
                    label2.Text = "#";
                    label2.ForeColor = Color.FromArgb(0, 0, 0);
                }

            }

            catch (System.FormatException)
            {
                MessageBox.Show("Podawaj tylko liczby!");
            }
            //button1.Hide(); ukrywanie rzeczy
        }


        private void button2_Click(object sender, EventArgs e)
        {
            stan = 100;
            stan_konta.Text = "100";
            button2.Hide();
            button1.Show();
        }







        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                podana_kwota.Enabled = true;
                Low.Enabled = true;
                High.Enabled = true;
                High.Checked = false;
                Low.Checked = true;
                label5.Enabled = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;   
                textBox1.Enabled = false;
                label3.Enabled = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                podana_kwota.Enabled = false;
                Low.Enabled = false;
                High.Enabled = false;
                label5.Enabled = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                textBox1.Enabled = true;
                label3.Enabled = true;
            }
        }

    
    }


    }

