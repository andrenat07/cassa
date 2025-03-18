using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace cassa
{
    public partial class ImpostazioniStampa : Form
    {
        public ImpostazioniStampa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mostriamo il dialogo di scelta del font
            sceltaFont.Font = Main.FontStampa;
            if (sceltaFont.ShowDialog() == DialogResult.OK)
                Main.FontStampa = sceltaFont.Font;
            else
                MessageBox.Show("errore");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("control", "printers");
            //aprimo le impostazioni delle stampanti
        }

        private void ImpostazioniStampa_Resize(object sender, EventArgs e)
        {
            button1.Size = new Size(Width, Height / 2);
        }
    }
}
