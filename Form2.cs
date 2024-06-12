using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabdilAdadBeHarf_DotNet;
namespace AdadBeHarf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
          
            lblResult.Text = TabdilAdadBeHaroof.GetHoroofSahihAshar(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(textBox1.Text);
                if (textBox1.Text == "")
                    return;
                lblResult.Text = TabdilAdadBeHaroof.GetHoroofSahihAshar(textBox1.Text);
            }
            catch
            {
                textBox1.TextChanged -= TextBox1_TextChanged;    
                
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }
    }
}
