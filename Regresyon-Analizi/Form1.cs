using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regresyon_Analizi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int n;
        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(comboBox1.Text);
            groupBox2.Enabled = true;
            comboBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < n)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
                if (listBox1.Items.Count < n)
                {
                    label2.Text = (listBox1.Items.Count + 1).ToString() + ". Dönem Satışı:";
                }             
            }
            if (listBox1.Items.Count == n)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
            this.ActiveControl = textBox1;
        }
        double a, b;

        private void button5_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text);
            double tahmin = a + b * x;
            label12.Text = Math.Round(tahmin,2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            double[] satislar = new double[n];
            int[] xdizisi = new int[n];
            for (int i = 0; i < n; i++)
            {
                satislar[i] = Convert.ToDouble(listBox1.Items[i]);
                xdizisi[i] = i + 1;
            }

            double xtoplam = 0;
            double ytoplam = 0;
            double xytoplam = 0;
            double xkaretoplam = 0;
            for (int i = 0; i < n; i++)
            {
                xtoplam += xdizisi[i];
                ytoplam += satislar[i];
                xytoplam += xdizisi[i] * satislar[i];
                xkaretoplam += xdizisi[i] * xdizisi[i];
            }
            b = (n * xytoplam - xtoplam * ytoplam) / (n * xkaretoplam - xtoplam * xtoplam);
            a = (ytoplam - b * xtoplam) / n;

            label4.Text = Math.Round(a,2).ToString();
            label6.Text = Math.Round(b, 2).ToString();
            label7.Text = "y = " + Math.Round(a, 2).ToString() + " + " + Math.Round(b, 2).ToString() + " X";
            label14.Text = Math.Round((a + b * (n+1)),2).ToString();
            // toplam sapmanın hesaplanması \\
            double toplamsapma = 0;
            double[] tahminler = new double[n];
            for (int i = 0; i < n; i++)
            {
                tahminler[i] = a + b * (i + 1);
                toplamsapma += Math.Abs(satislar[i] - tahminler[i]);
            }
            label13.Text = Math.Round(toplamsapma,2).ToString();
            groupBox4.Enabled = true;

        }
    }
}
