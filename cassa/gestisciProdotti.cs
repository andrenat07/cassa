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
    public partial class MoficaProdotti : Form
    {
        private Main lista;
        public MoficaProdotti(Main lista)
        {
            //prendiamo il rifermineto alla prima form
            InitializeComponent();
            this.lista = lista;


        }

        private void MoficaProdotti_Load(object sender, EventArgs e)
        {
            //aggiungiamo tutti i prodotti nella tabella
            foreach (var item in lista.Prodotti)
                listBox1.Items.Add(item);

        }

        private void elimina_click(object sender, EventArgs e)
        {
            //eliminiamo il prodotto selezionato
            if(listBox1.SelectedItems!= null)
            {
                lista.Prodotti.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //costruiamo l'oggetto della form NuovoProdotto gli passiamo il riferimento alla lista di prodotti
            NuovoProdotto si = new NuovoProdotto(lista.Prodotti);
            si.ShowDialog();
            listBox1.Items.Clear();
            foreach (var item in lista.Prodotti)
                listBox1.Items.Add(item);
        }
    }
}
