using System;
using System.Collections.Concurrent;
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
    
    class Prodotto
    {
        protected string nome;
        protected string descrizione;
        protected double prezzo;
        protected string codice;
        protected Reparto reparto;

        public string Nome { get => nome; set => nome = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public double Prezzo { get => prezzo; set => prezzo = value; }
        internal Reparto Reparto { get => reparto; set => reparto = value; }
        public string Codice 
        { 
            get => codice; 
            set
            {
                //if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{5}$"))
                //{
                //    throw new ArgumentException("Il codice deve contenere esattamente 5 cifre.");
                //}
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
            return $"Nome: {nome}, descrizione: {descrizione}, prezzo: {prezzo}€, reparto: {reparto}";
        }
    }

     
    //Sottoclasse Alimenti
    internal class Alimento : Prodotto
    {
        protected DateOnly scadenza;
        protected int valoreEnergetico;
        public Alimento(string nome, string descrizione, double prezzo,  Reparto reparto, string codice, DateOnly scadenza, int valoreEnergetico) : base(nome, descrizione, prezzo, reparto, codice)
        {
            Scadenza = scadenza;
            ValoreEnergetico = valoreEnergetico;
        }

        public DateOnly Scadenza { get => scadenza; set => scadenza = value; }
        public int ValoreEnergetico { get => valoreEnergetico; set => valoreEnergetico = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal";
        }
    }

    // Sottoclasse OrtoFrutta 
    internal class FruttaVerdura : Alimento
    {
        private string provenienza;
        private double peso;

        public FruttaVerdura(string nome, string descrizione, double prezzo, string codice, DateOnly scadenza, int valoreEnergetico, string provenienza, double peso) : base(nome, descrizione, prezzo, Reparto.Ortofrutta, codice, scadenza,valoreEnergetico)
        {
            Provenienza = provenienza;
            Peso = peso;

        }

        public string Provenienza { get => provenienza; set => provenienza = value; }
        public double Peso { get => peso; set => peso = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal, provenienza: {provenienza}, peso: {peso}";
        }
    }

    // Sottoclasse Macelleria 
    internal class Carne : Alimento
    {
        private string animale;
        private double peso;
        public Carne(string nome, string descrizione, double prezzo, string codice, DateOnly scadenza, int valoreEnergetico, string animale, double peso) :  base(nome, descrizione, prezzo,Reparto.Macelleria , codice, scadenza, valoreEnergetico)
        {
            Animale = animale;
            Peso = peso;
        }

        public string Animale { get => animale; set => animale = value; }
        public double Peso { get => peso; set => peso = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal, animale: {Animale}, peso: {Peso}";
        }
    }

    //// Sottoclasse Panetteria 
    internal class Pane : Alimento
    {
        private DateOnly DataProduzione;
        private string farina;
        public Pane(string nome, string descrizione, double prezzo, string codice, DateOnly scadenza, int valoreEnergetico, DateOnly dataProduzione, string farina) : base(nome, descrizione, prezzo,Reparto.Panetteria, codice, scadenza, valoreEnergetico)
        {
            DataProduzione = dataProduzione;
            Farina=farina;
            
        }

        public DateOnly DataProduzione1 { get => DataProduzione; set => DataProduzione = value; }
        public string Farina { get => farina; set => farina = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal, data produzione: {DataProduzione.ToString("dd MM yyyy")}, farina: {farina}";
        }
    }


    // Sottoclasse Pescheria 
    internal class Pesce : Alimento
    {

        private string provenienza;
        private double peso;

        public Pesce(string nome, string descrizione, double prezzo, string codice, DateOnly scadenza, int valoreEnergetico, string provenienza, double peso) : base(nome, descrizione, prezzo,Reparto.Ortofrutta, codice, scadenza, valoreEnergetico)
        {
            Provenienza = provenienza;
            Peso = peso;
        }

        public string Provenienza { get => provenienza; set => provenienza = value; }
        public double Peso { get => peso; set => peso = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal, provenienza: {provenienza} , peso: {peso}";
        }
    }

    //sottoclasse latticini
    internal class Latticini : Alimento
    {
        private Double percentualeLatticini;

        public Latticini(string nome, string descrizione, double prezzo, string codice, DateOnly scadenza, int valoreEnergetico, Double quantitàLatticini) : base(nome, descrizione, prezzo, Reparto.Latticini, codice, scadenza, valoreEnergetico)
        {
            PercentualeLatticini = percentualeLatticini;
        }
        public Double PercentualeLatticini { get => percentualeLatticini; set => percentualeLatticini = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, Data di scadenza: {Scadenza.ToString("dd MM yyyy")}, valore energetico: {ValoreEnergetico} Kcal, percentuale latticini {percentualeLatticini}";
        }
    }


    internal class Bevanda : Prodotto
    {
        protected double litri;
        protected string contenitore; //lattina - bottiglia plastica - bottiglia vetro

        protected double Litri { get => litri; set => litri = value; }
        protected string Contenitore { get => contenitore; set => contenitore = value; }

        public Bevanda(string nome, string descrizione, double prezzo, string codice, double litri, string contenitore): base(nome,descrizione,prezzo,Reparto.Bevande,codice)
        {
            Litri = litri;
            Contenitore = contenitore;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, litri: {litri}, contenitore: {contenitore}";
        }
    }

    internal class Acqua : Bevanda
    {
        private string fonte;
        public Acqua(string nome, string descrizione, double prezzo, string codice, double litri, string contenitore, string fonte) : base(nome, descrizione, prezzo, codice, litri, contenitore)
        {
            Fonte = fonte;
        }

        public string Fonte { get => fonte; set => fonte = value; }
        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, litri: {litri}, contenitore: {contenitore}, fonte: {fonte}";
        }
    }

    internal class Analcolico : Bevanda
    {
        private int carboidrati;

        public Analcolico(string nome, string descrizione, double prezzo, string codice, double litri, string contenitore, int carboidrati) : base(nome, descrizione, prezzo, codice, litri, contenitore)
        {
            Carboidrati = carboidrati;
        }

        public int Carboidrati { get => carboidrati; set => carboidrati = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, litri: {litri}, contenitore: {contenitore}, carboidrati: {carboidrati}";
        }
    }

    internal class Alcolico : Bevanda
    {
        private int gradazioneAlcolica;

        public Alcolico(string nome, string descrizione, double prezzo, string codice, double litri, string contenitore, int gradazioneAlcolica) : base(nome, descrizione, prezzo, codice, litri, contenitore)
        {
            GradazioneAlcolica = gradazioneAlcolica;
        }

        public int GradazioneAlcolica { get => gradazioneAlcolica; set => gradazioneAlcolica = value; }

        public override string ToString()
        {
            return $"Nome: {Nome}, descrizione: {Descrizione}, prezzo: {Prezzo}€, reparto: {Reparto}, litri: {litri}, contenitore: {contenitore}, gradazione alcolica: {gradazioneAlcolica}%";
        }
    }

}
