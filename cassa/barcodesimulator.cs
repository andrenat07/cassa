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
    public partial class Barcodesimulator : Form
    {
        private Main prima;
        public Barcodesimulator(Main prima)
        {
            //prendiamo il riferimento della form primaria
            InitializeComponent();
            this.prima = prima;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //quando premiamo l'invia usiamo la funzione  scansione della form1 
            prima.scansione(textBox1.Text);
            textBox1.Text = "";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //quando premiamo invio usiamo la funzione  scansione della form1 
            if (e.KeyCode == Keys.Enter)//controlliamo se il tasto è invio
            {
                prima.scansione(textBox1.Text);
                textBox1.Text = "";
            }

        }

        private void Barcodesimulator_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
