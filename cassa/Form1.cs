using BasselTech.UsbBarcodeScanner;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cassa
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private bool scansioneCard= false;
        private UsbBarcodeScanner scanner = new UsbBarcodeScanner();

        private static Font fontStampa = new Font("Arial", 9F, FontStyle.Regular | FontStyle.Regular, GraphicsUnit.Point, 0);

        private int counter = 0; //conta quanti prodostti sono stati inseriti nel carrello

        private List<Prodotto> prodotti = new List<Prodotto>();
        private List<PulsanteProdotto> pulsantiCarrello = new List<PulsanteProdotto>();
        private List<Prodotto> carrello = new List<Prodotto>();

        private List<FidelityCard> carte = new List<FidelityCard>();

        private int iva = 5;
        private int sconto = 0;
        private double prezzo = 0;
        private double prezzoIva = 0;
        private double prezzoScontato = 0;


        public static Font FontStampa { get => fontStampa; set => fontStampa = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            scanner.BarcodeScanned += BarcodeScansionato; //aggiungo l'evento di scansione
            scanner.Start(); //fa iniziare la scansione dei codici

            prodotti.Add(new Alimento("Pasta di semola integrale", "Confezione da 500g, ideale per una dieta sana", 2.50, Reparto.Alimentari, "56881", new DateOnly(2025, 02, 26), 50));
            prodotti.Add(new Prodotto("Passata di pomodoro biologica", "Bottiglia da 700g, pomodori coltivati senza pesticidi", 3.80, Reparto.Alimentari, "38934"));
            prodotti.Add(new Prodotto("Olio extra vergine d'oliva", "Bottiglia da 1 litro, spremitura a freddo", 8.90, Reparto.Alimentari, "43958"));

            // Reparto: Ortofrutta
            prodotti.Add(new Prodotto("Mele biologiche", "Varietà Golden Delicious, 1 kg", 2.20, Reparto.Ortofrutta, "88827"));
            prodotti.Add(new Prodotto("Banane", "Frutto esotico ricco di potassio, 1 kg", 1.80, Reparto.Ortofrutta, "31960"));
            prodotti.Add(new Prodotto("Carote", "Verdura croccante e ricca di vitamine, 1 kg", 1.50, Reparto.Ortofrutta, "60226"));

            // Reparto: Macelleria
            prodotti.Add(new Prodotto("Bistecca di manzo", "Taglio pregiato, ideale per la griglia", 25.00, Reparto.Macelleria, "63348"));
            prodotti.Add(new Prodotto("Salsiccia di maiale", "Carne fresca, perfetta per arrosti e grigliate", 8.50, Reparto.Macelleria, "22352"));
            prodotti.Add(new Prodotto("Pollo intero", "Ideale per forno o arrosto", 6.00, Reparto.Macelleria, "24558"));

            carte.Add(new FidelityCard("mario", "rossi", "29270",10));
            carte.Add(new FidelityCard("Andrea", "natali", "60806", 100));
            carte.Add(new FidelityCard("lorenzo", "gherardi", "16819", 50));
            carte.Add(new FidelityCard("Stefano", "Magni", "97407", -100));

        }

        private void BarcodeScansionato(object? sender, BarcodeScannedEventArgs e)
        {
            scansione(e.Barcode);
        }

        public void scansione(string CodiceScansionato)
        {
            if (!scansioneCard)
                for (int i = 0; i < prodotti.Count; i++)
                {
                    if (prodotti[i].Codice == CodiceScansionato)
                    {
                        //PulsanteProdotto è un una clsse che eredita pulsante che in più contiene un oggetto prodotto
                        PulsanteProdotto pulsanteProdotto = new PulsanteProdotto();
                        pulsanteProdotto.Indice = counter;

                        //personaliziamo il pulsante
                        pulsanteProdotto.Text = prodotti[i].Nome;
                        pulsanteProdotto.Parent = scorrimento;
                        pulsanteProdotto.Size = new Size(scorrimento.Width - 20, 50);
                        pulsanteProdotto.TabStop = false;
                        pulsanteProdotto.Top = counter * 55 + 10;

                        //aggiungiamo gli eventi (tasto sx e dx)
                        pulsanteProdotto.Click += infoProdotto;
                        pulsanteProdotto.MouseDown += eliminaProdotto;

                        //aggiungiamo alla lista dei pulsanti questo pulsante
                        pulsantiCarrello.Add(pulsanteProdotto);

                        //aggiungiamo il prodotto al carrello
                        carrello.Add(prodotti[i]);

                        //aggiorniamo il prezzo
                        aggiornaPrezzo(prodotti[i].Prezzo);
                        counter++;
                        break;
                    }
                    if (i == prodotti.Count - 1)
                        MessageBox.Show("il prodotto non fa parte del nostro negozio");
                }
            else
                for (int i = 0; i < carte.Count; i++)
                {
                    if (carte[i].Codice == CodiceScansionato)
                    { 
                        sconto = carte[i].Sconto;
                        aggiornaPrezzo (0);
                        pulsanteFidelityCard.Enabled = true;
                        scansioneCard = false;
                        break;
                    }
                        
                    if (i == carte.Count - 1)
                    { 
                        MessageBox.Show("questa fidelity card non esiste");
                        pulsanteFidelityCard.Enabled = true;
                        scansioneCard = false;

                    }
                }
        }

        private void aggiornaPrezzo(double spesa)
        {

            prezzo += spesa;
            prezzoScontato = prezzo * sconto / 100;
            prezzoIva = (prezzo - prezzoScontato) * iva / 100;

            totale.Text = $"totale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}€ \ndi cui IVA: {Math.Round(prezzoIva, 2)}€ \nsconto: {sconto}%";
        }

        private void infoProdotto(object sender, EventArgs e)
        {
            PulsanteProdotto pulsante = (PulsanteProdotto)sender;
            MessageBox.Show(carrello[pulsante.Indice].ToString(), "informazioni");

        }

        private void eliminaProdotto(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PulsanteProdotto pulsante = (PulsanteProdotto)sender;
                aggiornaPrezzo(-carrello[pulsante.Indice].Prezzo);
                carrello.RemoveAt(pulsante.Indice);

                //cancelliamo tutti i pulsanti
                for (int i = 0; i < pulsantiCarrello.Count; i++)
                    pulsantiCarrello[i].Dispose();

                //riposizioniamo i pulsanti dal carello
                counter = 0;
                for (int i = 0; i < carrello.Count; i++)
                {
                    PulsanteProdotto pulsanteProdotto = new PulsanteProdotto();
                    pulsanteProdotto.Indice = i;

                    //personaliziamo il pulsante
                    pulsanteProdotto.Text = carrello[i].Nome;
                    pulsanteProdotto.Parent = scorrimento;
                    pulsanteProdotto.Size = new Size(scorrimento.Width - 20, 50);
                    pulsanteProdotto.TabStop = false;
                    pulsanteProdotto.Top = counter * 55 + 10;

                    //aggiungiamo gli eventi (tasto sx e dx)
                    pulsanteProdotto.Click += infoProdotto;
                    pulsanteProdotto.MouseDown += eliminaProdotto;

                    //aggiungiamo alla lista dei pulsanti questo pulsante
                    pulsantiCarrello.Add(pulsanteProdotto);
                    counter++;
                }
            }
        }

        private void disattivaStampa(object sender, EventArgs e)
        {
            disattivaStampaMenu.Checked = !disattivaStampaMenu.Checked;
        }

        private void apriBarcodeSimulator(object sender, EventArgs e)
        {
            Barcodesimulator barcodesimulator = new Barcodesimulator(this);
            barcodesimulator.Show();
        }

        private void apriCrediti(object sender, EventArgs e)
        {
            //apre la pagina dei crediti
            Credits credits = new Credits();
            credits.ShowDialog();
        }

        private void apriImpostazioniScontrino(object sender, EventArgs e)
        {
            ImpostazioniStampa impostazioniStampa = new ImpostazioniStampa();
            impostazioniStampa.ShowDialog();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //formattazione scontrino
            scontrino.Size = new Size(Size.Width / 2, Size.Height - 80);

            //formattazione stampa
            PulsanteScontrino.Size = new Size(Size.Width / 2 - 45, 50);
            PulsanteScontrino.Left = Size.Width / 2 + 20;

            //formattazione totale
            totale.Size = new Size(Size.Width / 2 - 45, 100);
            totale.Left = Size.Width / 2 + 20;

            //formattazione banner
            banner.Size = new Size(Size.Width / 2 - 45, Size.Height / 5);
            banner.Left = Size.Width / 2 + 20;

            //formattazione pulsante carta
            pulsanteFidelityCard.Top = Size.Height / 5 + 54;
            pulsanteFidelityCard.Left = Size.Width / 2 + 20;
            pulsanteFidelityCard.Size = new Size(Size.Width / 4 - 30, 34);

            //formattazione sconto
            pulsanteSconto.Top = Size.Height / 5 + 54;
            pulsanteSconto.Left = Size.Width / 2 + pulsanteFidelityCard.Width + 30;
            pulsanteSconto.Size = new Size(Size.Width / 4 - 30, 34);

            //formattazione dei prodotti nel carrello
            if (pulsantiCarrello.Count != 0)
                for (int i = 0; i < pulsantiCarrello.Count; i++)
                    pulsantiCarrello[i].Size = new Size(scorrimento.Width - 20, 50);
        }

        private void FineScontrino(object sender, EventArgs e)
        {
            if (carrello.Count != 0)
            {
                //componiamo il testo dello scontrino
                string testoScontrino = "PietroSpin - la spesa rocciosa\n\n";
                for (int i = 0; i < carrello.Count; i++)
                    testoScontrino += carrello[i].Nome + "\t\t" + carrello[i].Prezzo + "€ \n";
                testoScontrino += $"\ntotale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}€ \ndi cui IVA: {Math.Round(prezzoIva, 2)}€ \nsconto: {sconto}%";


                //salviamo in un file di testo lo scontrino
                string file = "scontrini/" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt";
                System.IO.File.WriteAllText(file, testoScontrino);

                if (disattivaStampaMenu.Checked)
                    MessageBox.Show(testoScontrino);
                else
                {
                    //avviamo la stampa
                    stampa.DocumentName = file;
                    stampa.Print();
                }


                //cancelliamo tutti i pulsanti
                for (int i = 0; i < pulsantiCarrello.Count; i++)
                    pulsantiCarrello[i].Dispose();

                //ripristiniamo le variabili
                counter = 0;
                prezzo = 0;
                sconto = 0;
                totale.Text = "totale: 0€\r\ndi cui IVA: 0€\r\nsconto: 0%";
                this.ActiveControl = null;
                carrello.Clear();
                pulsantiCarrello.Clear();

            }
            else
                MessageBox.Show("il carrello è vuoto");
        }

        private void stampa_PrintPage(object sender, PrintPageEventArgs e)
        {
            //prendiamo la stringa da file
            PrintDocument pietro = (PrintDocument)sender;
            string testoScontrino = File.ReadAllText(pietro.DocumentName);


            // aggiungiamo la immagine
            Image immagine = Image.FromFile("immagini/logo.png");
            Rectangle rettangoloImmagine = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, 100, 100);
            e.Graphics.DrawImage(immagine, rettangoloImmagine);

            // Offset per il testo dopo l'immagine
            int offsetY = rettangoloImmagine.Height + 10;

            RectangleF areaTesto = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top + offsetY, e.MarginBounds.Width, e.MarginBounds.Height - offsetY);

            int caratteriPerPagina = 0;
            int lineePerPagina = 0;
            e.Graphics.MeasureString(testoScontrino, FontStampa, areaTesto.Size, StringFormat.GenericTypographic, out caratteriPerPagina, out lineePerPagina);

            e.Graphics.DrawString(testoScontrino, FontStampa, Brushes.Black, areaTesto, StringFormat.GenericTypographic);

            testoScontrino = testoScontrino.Substring(caratteriPerPagina);

            e.HasMorePages = (testoScontrino.Length > 0);
        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MoficaProdotti si = new MoficaProdotti(this);
            //si.ShowDialog();
        }

        private void pulsanteFidelityCard_Click(object sender, EventArgs e)
        {
            scansioneCard = true;
            pulsanteFidelityCard.Enabled = false;
            this.ActiveControl = null;
        }

        private void pulsanteSconto_Click(object sender, EventArgs e)
        {
            scansione("38934");
            this.ActiveControl = null;
        }

        private void debugRandomProdotti(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Random random = new Random();
                int numero = random.Next(prodotti.Count);

                scansione(prodotti[numero].Codice);
            }
        }
    }

}
