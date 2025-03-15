using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cassa
{
    partial class NuovaCard : Form
    {
        List<FidelityCard> carte=new List<FidelityCard>();
        public NuovaCard(List<FidelityCard> carte)
        {
            InitializeComponent();
            this.carte = carte;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carte.Add(new FidelityCard(textBox1.Text, textBox2.Text, numericUpDown2.Value.ToString() , (int)numericUpDown1.Value));
            Close();
        }
    }
}
