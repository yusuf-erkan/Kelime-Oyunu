using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }
        private void btndat_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }
        private void btntopla_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n" + "+" + "\r\n";
        }
        private void btncikar_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n" + "-" + "\r\n";
        }
        private void btncarp_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n" + "x" + "\r\n";
        }
        private void btnBol_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n" + "÷" + "\r\n";
        }
        private void btnesit_Click(object sender, EventArgs e)
        {
            esittir();
        }
        private void esittir()
        {
            decimal a = 0;
            decimal b = 0;
            decimal c = 0;
            string[] dizi1;
            dizi1 = textBox1.Text.Split('\n');
            ArrayList dizi = new ArrayList();
            dizi.AddRange(dizi1);
            bool x = true;

            while (x)
            {

                for (int i = 1; i < dizi.Count; i += 2)
                {

                    if (dizi.BinarySearch("x\r") == i)
                    {
                        a = Convert.ToDecimal(dizi[i - 1]);
                        b = Convert.ToDecimal(dizi[i + 1]);
                        c = a * b;

                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.Add(c.ToString());
                    }

                    if (dizi.BinarySearch("÷\r") == i)
                    {
                        a = Convert.ToDecimal(dizi[i - 1]);
                        b = Convert.ToDecimal(dizi[i + 1]);
                        if (b != 0)
                        {
                            c = a / b;
                            dizi.RemoveAt(i - 1);
                            dizi.RemoveAt(i - 1);
                            dizi.RemoveAt(i - 1);
                            dizi.Add(c.ToString());
                        }
                        else
                            textBox1.Text += "\r\n" + "=" + "\r\n" + "Bölen sayı 0 olamaz" + "\r\n";
                    }
                }
                for (int i = 1; i < dizi.Count; i += 2)
                {
                    if (dizi.BinarySearch("+\r") == i)
                    {
                        a = Convert.ToDecimal(dizi[i - 1]);
                        b = Convert.ToDecimal(dizi[i + 1]);
                        c = a + b;
                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.Add(c.ToString());
                    }

                    if (dizi.BinarySearch("-\r") == i)
                    {
                        a = Convert.ToDecimal(dizi[i - 1]);
                        b = Convert.ToDecimal(dizi[i + 1]);
                        c = a - b;
                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.RemoveAt(i - 1);
                        dizi.Add(c.ToString());
                    }
                }
                if (dizi.Count == 1)
                    x = false;
            }
            textBox1.Text += ("\r\n" + "=" + "\r\n" + dizi[dizi.Count - 1]);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.TextLength - 1, 1);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar <= 57 && e.KeyChar >= 47)
            {
                e.Handled = false;
            }
            else e.Handled = true;
            if (e.KeyChar == (char)'/')
            {
                e.Handled = true;
                textBox1.Text += "\r\n" + "÷" + "\r\n";
            }
            if (e.KeyChar == (char)'*')
            {
                e.Handled = true;
                textBox1.Text += "\r\n" + "x" + "\r\n";
            }
            if (e.KeyChar == (char)'-')
            {
                e.Handled = true;
                textBox1.Text += "\r\n" + "-" + "\r\n";
            }
            if (e.KeyChar == (char)'+')
            {
                e.Handled = true;
                textBox1.Text += "\r\n" + "+" + "\r\n";
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                esittir();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
