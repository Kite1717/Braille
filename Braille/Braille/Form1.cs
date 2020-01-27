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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
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

        public Form1()
        {
            InitializeComponent();
        }


    }
}
