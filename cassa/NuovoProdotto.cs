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
    partial class NuovoProdotto : Form
    {
        private List<Prodotto> prodotti = new List<Prodotto>();
        private Reparto currentReparto;
        public NuovoProdotto(List<Prodotto> prodotti)
        {
            //prendfiamo il riferimento della lista di prodotti
            InitializeComponent();
            this.prodotti = prodotti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //quandfo si preme crea aggiungiamo alla lista di prodotti il nuovo prodotto
            prodotti.Add(new Prodotto(textBox1.Text, textBox2.Text, (double)numericUpDown1.Value, currentReparto, Convert.ToString(numericUpDown2.Value)));
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //quando si cambia valore nella combobox troviamo il suo reparto di riferimento
            currentReparto = (Reparto)Enum.Parse(typeof(Reparto), comboBox1.SelectedItem.ToString());
        }
    }
}
