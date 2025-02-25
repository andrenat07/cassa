using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    enum Reparto
    {

        Alimentari,
        Ortofrutta,
        Macelleria,
        Pescheria,
        Panetteria,
        Pasticceria,
        Surgelati,
        Latticini,
        Bevande,
        CuraPersona,
        PuliziaCasa,
        Elettronica,
        Giocattoli,
        Animali
    }
    internal class Prodotto
    {
        private string nome;
        private string descrizione;
        private double prezzo;
        private string codice;
        private Reparto reparto;

        public string Nome { get => nome; set => nome = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public double Prezzo { get => prezzo; set => prezzo = value; }
        internal Reparto Reparto { get => reparto; set => reparto = value; }
        public string Codice { get => codice; set => codice = value; }

        public Prodotto(string nome, string descrizione, double prezzo, Reparto reparto, string codice)
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Reparto = reparto;
            this.Codice = codice;
        }

        public Prodotto() { }


        public override string ToString()
        {
            return $"nome: {nome}, descrizione: {descrizione}, prezzo: {prezzo}€, reparto: {reparto}";
        }
    }
    //internal class alimento : prodotto
    //{

    //}
    //internal class ortofrutta : prodotto
    //{

    //}
    //internal class macelleria : prodotto
    //{

    //}
    //internal class pescheria : prodotto
    //{

    //}
    //internal class panetteria : prodotto
    //{

    //}
    //internal class surgelati : prodotto
    //{

    //}
    //internal class latticini : prodotto
    //{

    //}
    //internal class bevande : prodotto
    //{

    //}
    //internal class curapersona : prodotto
    //{

    //}
    //internal class puliziacasa : prodotto
    //{

    //}
    //internal class elettronica : prodotto
    //{

    //}
    //internal class giocattoli : prodotto
    //{

    //}
    //in
}
