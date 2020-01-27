using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Braille
{
    public partial class Form1 : Form
    {

        private Dictionary<string, string> alphabet = new Dictionary<string, string>() { { "a", "\u2801" }, { "b", "\u2803" }, { "c", "\u2809" }, { "ç", "\u2821" }, { "d", "\u2819" }, { "e", "\u2811" }, { "f", "\u280b" }, { "g", "\u281b" }, { "ğ", "\u2823" }, { "h", "\u2813" }, { "ı", "\u2814" }, { "i", "\u280a" }, { "j", "\u281a" }, { "k", "\u2805" }, { "l", "\u2807" }, { "m", "\u280d" }, { "n", "\u281d" }, { "o", "\u2815" }, { "ö", "\u282a" }, { "p", "\u280f" }, { "q", "\u281f" }, { "r", "\u2817" }, { "s", "\u280e" }, { "ş", "\u2829" }, { "t", "\u281e" }, { "u", "\u2825" }, { "ü", "\u2833" }, { "v", "\u2827" }, { "w", "\u283a" }, { "x", "\u282d" }, { "y", "\u283d" }, { "z", "\u2835" } };
        private Dictionary<string, string> numbers = new Dictionary<string, string>() { { "0", "\u281a" }, { "1", "\u2801" }, { "2", "\u2803" }, { "3", "\u2809" }, { "4", "\u2819" }, { "5", "\u2811" }, { "6", "\u280b" }, { "7", "\u281b" }, { "8", "\u2813" }, { "9", "\u280a" } };
        private Dictionary<string, string> Punctuations = new Dictionary<string, string>() { { ",", "\u2802" }, { ".", "\u2832" }, { ";", "\u2806" }, { ":", "\u2812" }, { "?", "\u2826" }, { "!", "\u2816" }, { "-", "\u2824" }, { "^", "\u2808" }, { "'", "\u2804" }, { "(", "\u2836" }, { ")", "\u2836" }, { "—", "\u2824\u2824" }, { "<", "\u281c\u281c" } };
        private Dictionary<string, string> operators = new Dictionary<string, string>() { { "*", "\u2830\u2826" }, { "/", "\u2830\u2812" }, { "+", "\u2830\u2822" }, { "-", "\u2830\u2824" }, { "=", "\u2830\u2836" } };                                                                                                                //poetry mark
        private string upperCode = "\u2820", numberCode = "\u283c", leftN = "\u2826", rightN = "\u2834";


        #region visibility
        private void ConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            pictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
        }

        private void FourOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            pictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = true;
            textBox2.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;
            label5.Visible = true;
            label9.Visible = true;
        }


        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label4.Visible = false;
        }

       
    

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        #endregion

        /// <summary>
        /// translates the text in the braille alphabet equivalent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            bool startDigit = false;
            int nCount = 0;
            string text = textBox1.Text;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    if (Char.IsLetter(text[i]))
                    {
                        if (Char.IsUpper(text[i]))
                            sb.Append(upperCode);
                        sb.Append(alphabet[text[i].ToString().ToLower()]);

                        startDigit = false;

                    }
                    else if (Char.IsDigit(text[i]))
                    {
                        if (!startDigit)
                            sb.Append(numberCode);

                        sb.Append(numbers[text[i] + ""]);

                        startDigit = true;
                    }
                    else if (text[i] == '"')
                    {
                        if (nCount % 2 == 1)
                            sb.Append(leftN);
                        else sb.Append(rightN);
                        nCount++;
                    }
                    else if (operators.ContainsKey(text[i] + ""))
                    {
                        sb.Append(operators[text[i] + ""]);
                    }
                    else
                    {
                        sb.Append(Punctuations[text[i] + ""]);
                    }
                }
                catch (KeyNotFoundException)
                {
                    label4.Text = "";
                    textBox1.Text = "";
                    MessageBox.Show("You have entered a character that is outside the alphabet, this is not the place :)");
                    return;
                }



            }
            label4.Text = sb.ToString();
        }


        /// <summary>
        /// performs four operations simply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //I check the validity of the numbers
            int x = 0, y = 0, res = 0;
            try
            {
                Convert.ToInt32(textBox2.Text.Trim());
                Convert.ToInt32(textBox4.Text.Trim());
                x = Convert.ToInt32(textBox2.Text.Trim());
                y = Convert.ToInt32(textBox4.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("You did not enter a number");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Enter fewer numbers");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }
            //I check whether the text entered in the operator section is an operator
            if (!operators.ContainsKey(textBox3.Text.Trim()) || textBox3.Text.Trim().Equals("="))
            {
                MessageBox.Show("You did not enter four operators");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }

            //I am doing the operation of the selected operator

            try
            {
                switch (textBox3.Text.Trim())
                {
                    case "+":
                        {
                            res = x + y;
                            break;
                        }
                    case "-":
                        {
                            res = x - y;
                            break;
                        }
                    case "/":
                        {
                            res = x / y;
                            break;
                        }
                    case "*":
                        {
                            res = x * y;
                            break;
                        }
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Enter a smaller number !!");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("I can't divide by zero");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }



            label5.Text = x + "  " + textBox3.Text + "  " + y + "  =  " + res;

            StringBuilder sb = new StringBuilder();
            string temp = null;
            // I am converting the first number
            if (x < 0)
            {
                sb.Append(Punctuations["-"]);
                x = Math.Abs(x);
            }

            temp = x.ToString();
            sb.Append(numberCode);
            for (int i = 0; i < temp.Length; i++)
                sb.Append(numbers[temp[i] + ""]);
            sb.Append("    ");

            //I added the braille equivalent of the projector
            sb.Append(operators[textBox3.Text.Trim()] + "    ");

            //I am converting the second number
            if (y < 0)
            {
                sb.Append(Punctuations["-"]);
                y = Math.Abs(y);
            }
            Math.Abs(y);
            temp = y.ToString();
            sb.Append(numberCode);
            for (int i = 0; i < temp.Length; i++)
                sb.Append(numbers[temp[i] + ""]);
            sb.Append("    " + operators["="] + "    ");

            //I  converted the result
            if (res < 0)
            {
                sb.Append(Punctuations["-"]);
                res = Math.Abs(res);
            }

            temp = res.ToString();
            sb.Append(numberCode);
            for (int i = 0; i < temp.Length; i++)
                sb.Append(numbers[temp[i] + ""]);

            //show case
            label9.Text = sb.ToString();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public Form1()
        {
            InitializeComponent();
        }


    }
}
