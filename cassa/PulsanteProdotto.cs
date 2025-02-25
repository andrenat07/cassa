using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class PulsanteProdotto:Button
    {
        private Prodotto prodotto;


        public Prodotto Prodotto { get => prodotto; set => prodotto = value; }
    }
}
