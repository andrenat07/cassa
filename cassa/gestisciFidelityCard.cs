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
    public partial class gestisciFidelityCard : Form
    {
        private Main lista;
        public gestisciFidelityCard(Main lista)
        {
            //prendiamo il riferimento della prima form
            InitializeComponent();
            this.lista = lista;


        }

        private void MoficaProdotti_Load(object sender, EventArgs e)
        {
            //aggiungiamo tutte le carte alla tabella
            foreach (var item in lista.Carte)
                listBox1.Items.Add(item);

        }

        private void elimina_click(object sender, EventArgs e)
        {
            //quando si preme il tatsto elimina cancella il prodotto selezionato
            if (listBox1.SelectedItems != null)
            {
                lista.Carte.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

        }

        private void nuova_Click(object sender, EventArgs e)
        {
            //quando si preme nuova
            //costruiamo l'oggetto della form NuovaCard gli passiamo il riferimento alla lista di carte
            NuovaCard si = new NuovaCard(lista.Carte); 
            si.ShowDialog();
            listBox1.Items.Clear();//ripristiniamo la tabella
            foreach (var item in lista.Carte)
                listBox1.Items.Add(item);//reinseriamo le carte
        }
    }
}
