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
        public string Codice 
        { 
            get => codice; 
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{5}$"))
                {
                    throw new ArgumentException("Il codice deve contenere esattamente 5 cifre.");
                }
                codice = value;
            }
        }

        public Prodotto(string nome, string descrizione, double prezzo, Reparto reparto, string codice)
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Reparto = reparto;
            this.Codice = codice;
        }
        public override string ToString()
        {
            return $"nome: {nome}, descrizione: {descrizione}, prezzo: {prezzo}€, reparto: {reparto}";
        }
    }
     
    //Sottoclasse Alimenti
    internal class Alimento : Prodotto
    {
        private DateOnly scadenza;
        private int valoreEnergetico;
        public Alimento(string nome, string descrizione, double prezzo,  Reparto Reparto, string codice, DateOnly scadenza, int valoreEnergetico) : base(nome, descrizione, prezzo, Reparto, codice)
        {
            this.Reparto = Reparto.Alimentari;
            this.Scadenza = scadenza;
            this.valoreEnergetico = valoreEnergetico;
        }

        public DateOnly Scadenza { get => scadenza; set => scadenza = value; }
        public int ValoreEnergetico { get => valoreEnergetico; set => valoreEnergetico = value; }

        public override string ToString()
        {
            return $"nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")} valore energetico: {ValoreEnergetico} Kcal";
        }
    }

    // Sottoclasse OrtoFrutta 
    //internal class OrtoFrutta : Prodotto
    //{
    //    private string paeseProvenienza;
    //    private int peso;

    //    public OrtoFrutta(string nome, string descrizione, double prezzo, Reparto reparto, string codice, string paeseProvenienza) : base(nome, descrizione, prezzo, reparto, codice)
    //    {
    //    }

    //    public override string ToString()
    //    {
    //        return $" Paese di provenienza : {paeseProvenienza} ";
    //    }
    //}

    // Sottoclasse Macelleria 
    //internal class Carne : Prodotto
    //{
    //    private string animale;
    //    private string paeseOrigine;
    //    private int peso;
    //    public Carne(string nome, string descrizione, double prezzo, int codice, Reparto Reparto, string TipoCarne, string PaeseOrigine, string PaeseMacello) : base(nome, descrizione, prezzo, codice, Reparto)
    //    {
    //        this.Reparto = Reparto.Macelleria;
    //        this.TipoCarne = TipoCarne;
    //        this.PaeseOrigine = PaeseOrigine;
    //        this.PaeseMacello = PaeseMacello;
    //    }
    //    public override string ToString()
    //    {
    //        return $"Tipo di carne: {TipoCarne}; Paese di origine : {PaeseOrigine}; Paese Macello:{PaeseMacello}";
    //    }
    //}

    //// Sottoclasse Panetteria 
    //internal class Panetteria : Prodotto
    //{
    //    private string DataProduzione;
    //    public Panetteria(string nome, string descrizione, double prezzo, int codice, Reparto Reparto, string DataProduzione) : base(nome, descrizione, prezzo, codice, Reparto)
    //    {
    //        this.Reparto = Reparto.Panetteria;
    //        this.DataProduzione = DataProduzione;
    //    }
    //    public override string ToString()
    //    {
    //        return $"Data di produzione : {DataProduzione}";
    //    }
    //}
    // Sottoclasse Pescheria 
    //internal class Pescheria : Prodotto
    //{
    //    private string TipoPesce;
    //    private string DataPescaggio;
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
