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
            InitializeComponent();
            this.lista = lista;
        }

        private void MoficaProdotti_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].Name = "nome";
            //dataGridView1.Columns[1].Name = "prezzo";
            //dataGridView1.Columns[2].Name = "codice";

            //for (int i = 0; i < lista.prodotti.Count; i++) 
            //{
            //    dataGridView1.Rows.Add(lista.prodotti[i].Nome, lista.prodotti[i].Prezzo, lista.prodotti[i].Codice);
            //}
            //this.Controls.Add(dataGridView1);

        }
    }
}
