using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class PulsanteProdotto:Button
    {

        //aggiungiamo al pulsante l'indice del prodotto di riferimento nella lista del carrello
        private int indice;

        public int Indice { get => indice; set => indice = value; }
    }
}
