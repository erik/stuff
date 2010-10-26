using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Calc : Form
    {
        public Calc()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox.AppendText("1");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox.AppendText("2");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox.AppendText("3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox.AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox.AppendText("5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox.AppendText("6");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox.AppendText("7");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox.AppendText("8");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox.AppendText("9");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox.AppendText("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox.AppendText(" + ");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox.AppendText(" - ");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox.AppendText(" * ");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox.AppendText(" / ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            string[] segs = text.Split(' ');
            double result = 0;
            for (int i = 0; i < segs.Length; i++)
            {
                try
                {
                    if (isOp(segs[i]))
                    {
                        switch (segs[i])
                        {
                            case "+":
                                result += double.Parse(segs[++i]);
                                break;
                            case "-":
                                result -= double.Parse(segs[++i]);
                                break;
                            case "*":
                                result *= double.Parse(segs[++i]);
                                break;
                            case "/":
                                result /= double.Parse(segs[++i]);
                                break;
                        }
                    }
                    else
                    {
                        result = double.Parse(segs[i]);
                    }
                }
                catch (Exception _)
                {
                    Console.WriteLine(_.ToString());
                    result = 0;
                    break;
                }
            }

            textBox.Text = result.ToString();
        }

        private bool isOp(string s)
        {
            string[] ops = new string[] { "+", "-", "*", "/" };
            for (int i = 0; i < ops.Length; i++)
            {
                if (ops[i] == s)
                {
                    return true;
                }
            }
            return false;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            textBox.Text = "";
        }
    }
}
