using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class FidelityCard
    {
        private string nome;
        private string cognome;
        private string codice;
        private int sconto;

        public FidelityCard(string nome, string cognome, string codice, int sconto)
        {
            this.Nome = nome;
            this.cognome = cognome;
            this.Codice = codice;
            this.Sconto = sconto;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Codice { get => codice; set => codice = value; }
        public int Sconto { get => sconto; set => sconto = value; }
    }
}
