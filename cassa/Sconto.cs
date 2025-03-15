﻿using System;
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
    public partial class Sconto : Form
    {
        private int numero = 10;


        public Sconto()
        {
            InitializeComponent();
        }

        public int Numero { get => numero; set => numero = value; }

        public void button1_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numero = (int)numericUpDown1.Value;
        }
    }
}
