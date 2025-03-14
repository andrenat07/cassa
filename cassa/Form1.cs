using BasselTech.UsbBarcodeScanner;
using System.Drawing.Printing;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
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

        private static System.Drawing.Font fontStampa = new System.Drawing. Font("Courier New", 10);

        private int counter = 0; //conta quanti prodostti sono stati inseriti nel carrello
        private bool? clienteMaggiorenne;

        private List<Prodotto> prodotti = new List<Prodotto>();
        private List<PulsanteProdotto> pulsantiCarrello = new List<PulsanteProdotto>();
        private List<Prodotto> carrello = new List<Prodotto>();

        private List<FidelityCard> carte = new List<FidelityCard>();

        private string currentFidelityCard = "";

        private int iva = 5;
        private int sconto = 0;
        private double prezzo = 0;
        private double prezzoIva = 0;
        private double prezzoScontato = 0;



        public static System.Drawing.Font FontStampa { get => fontStampa; set => fontStampa = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            scanner.BarcodeScanned += BarcodeScansionato; //aggiungo l'evento di scansione
            scanner.Start(); //fa iniziare la scansione dei codici

            prodotti.Add(new FruttaVerdura("Mela", "Mela rossa biologica", 1.20, "56881", new DateOnly(2025, 4, 10), 52, "Italia", 0.2));
            prodotti.Add(new FruttaVerdura("Carota", "Carota fresca", 0.80, "43958", new DateOnly(2025, 3, 25), 41, "Italia", 0.15));
            prodotti.Add(new FruttaVerdura("Banana", "Banana matura", 1.10, "88827", new DateOnly(2025, 4, 5), 89, "Ecuador", 0.25));
            prodotti.Add(new FruttaVerdura("Patata", "Patata novella", 0.60, "31960", new DateOnly(2025, 3, 28), 77, "Francia", 0.3));

            prodotti.Add(new Carne("Bistecca", "Bistecca di manzo", 15.50, "60226", new DateOnly(2025, 3, 18), 250, "Manzo", 0.5));
            prodotti.Add(new Carne("Coscia di pollo", "Pollo allevato a terra", 7.99, "63348", new DateOnly(2025, 3, 22), 165, "Pollo", 0.7));
            prodotti.Add(new Carne("Salsiccia", "Salsiccia di suino", 9.99, "22352", new DateOnly(2025, 3, 25), 300, "Suino", 0.6));
            prodotti.Add(new Carne("Agnello", "Costolette di agnello", 18.75, "24558", new DateOnly(2025, 3, 27), 270, "Agnello", 0.8));

            prodotti.Add(new Pane("Baguette", "Pane francese croccante", 1.50, "87898", new DateOnly(2025, 3, 15), 280, new DateOnly(2025, 3, 14), "Grano"));
            prodotti.Add(new Pane("Ciabatta", "Pane italiano morbido", 1.80, "17678", new DateOnly(2025, 3, 16), 270, new DateOnly(2025, 3, 15), "Grano"));
            prodotti.Add(new Pane("Pane integrale", "Pane con farina integrale", 2.00, "64328", new DateOnly(2025, 3, 17), 250, new DateOnly(2025, 3, 16), "Integrale"));
            prodotti.Add(new Pane("Focaccia", "Focaccia genovese", 2.50, "58181", new DateOnly(2025, 3, 18), 300, new DateOnly(2025, 3, 17), "Grano"));

            prodotti.Add(new Pesce("Salmone", "Salmone norvegese fresco", 22.99, "98571", new DateOnly(2025, 3, 20), 208, "Norvegia", 1.2));
            prodotti.Add(new Pesce("Orata", "Orata pescata nel Mediterraneo", 18.50, "54246", new DateOnly(2025, 3, 18), 150, "Italia", 0.9));
            prodotti.Add(new Pesce("Tonno", "Tonno pinna gialla", 25.99, "47738", new DateOnly(2025, 3, 22), 200, "Spagna", 1.1));
            prodotti.Add(new Pesce("Gamberi", "Gamberi freschi", 29.50, "95220", new DateOnly(2025, 3, 21), 105, "Argentina", 0.8));

            prodotti.Add(new Latticini("Latte intero", "Latte fresco intero 1L", 1.30, "46564", new DateOnly(2025, 3, 30), 60, 1));
            prodotti.Add(new Latticini("Formaggio Parmigiano", "Parmigiano Reggiano stagionato", 12.99, "53125", new DateOnly(2025, 8, 15), 402, 0.5));
            prodotti.Add(new Latticini("Mozzarella", "Mozzarella di bufala", 3.99, "89447", new DateOnly(2025, 4, 5), 280, 0.25));
            prodotti.Add(new Latticini("Yogurt", "Yogurt naturale senza zucchero", 0.99, "61041", new DateOnly(2025, 4, 10), 100, 0.15));

            prodotti.Add(new Acqua("Acqua Naturale", "Acqua minerale naturale", 0.50, "84340", 1.5, "Plastica", "Monte Bianco"));
            prodotti.Add(new Acqua("Acqua Frizzante", "Acqua minerale frizzante", 0.60, "16294", 1.5, "Vetro", "Fonte Alpina"));
            prodotti.Add(new Acqua("Acqua Tonica", "Bevanda frizzante con chinino", 1.20, "25843", 1.0, "Vetro", "Fonte Rossa"));
            prodotti.Add(new Acqua("Acqua di cocco", "Acqua di cocco naturale", 2.50, "43395", 0.5, "Tetra Pak", "Filippine"));

            prodotti.Add(new Analcolico("Cola", "Bevanda gassata cola", 1.20, "41429", 1.5, "Plastica", 10));
            prodotti.Add(new Analcolico("Succo d'arancia", "Succo 100% arancia", 2.00, "17075", 1.0, "Tetra Pak", 8));
            prodotti.Add(new Analcolico("Limonata", "Bevanda gassata al limone", 1.50, "44223", 1.5, "Plastica", 9));
            prodotti.Add(new Analcolico("T� freddo", "T� freddo al limone", 1.80, "38915", 1.5, "Plastica", 7));

            prodotti.Add(new Alcolico("Birra Lager", "Birra chiara leggera", 2.50, "79029", 0.5, "Vetro", 5));
            prodotti.Add(new Alcolico("Vino Rosso", "Vino rosso toscano", 15.00, "94903", 0.75, "Vetro", 13));
            prodotti.Add(new Alcolico("Whisky", "Whisky scozzese invecchiato 12 anni", 45.00, "53199", 0.7, "Vetro", 40));
            prodotti.Add(new Alcolico("Rum", "Rum caraibico ambrato", 30.00, "62363", 0.7, "Vetro", 37));


            carte.Add(new FidelityCard("mario", "rossi", "29270",10));
            carte.Add(new FidelityCard("Andrea", "natali", "60806", 100));
            carte.Add(new FidelityCard("lorenzo", "gherardi", "16819", 50));
            carte.Add(new FidelityCard("Stefano", "Magni", "97407", -100));
            carte.Add(new FidelityCard("Pietro", "Manzoni", "74002", 200));

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
                        if (prodotti[i].GetType() == typeof(Alcolico))
                        {                            
                            if (clienteMaggiorenne == null)
                            {
                                MessageBox.Show("coso per l'invio");
                                if (MessageBox.Show("il cliente � maggiorenne?", "prodotto alcolico", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    clienteMaggiorenne = false;
                                    break;
                                }
                                else
                                    clienteMaggiorenne = true;
                            }
                                
                            else if((bool)!clienteMaggiorenne)
                            {
                                MessageBox.Show("coso per l'invio");
                                if(MessageBox.Show("il cliente � minorenne!!!\nperci� non pu� comprare una alcolico\nse hai sbagliato clicca annulla", "prodotto alcolico", MessageBoxButtons.OKCancel)== DialogResult.Cancel)
                                    clienteMaggiorenne=true;
                                else 
                                    break;

                            }
                            
                        }
                            
                        //PulsanteProdotto � un una clsse che eredita pulsante che in pi� contiene un oggetto prodotto
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
                        pulsanteFidelityCard.Enabled = true;
                        scansioneCard = false;
                        currentFidelityCard = $"{carte[i].Cognome} {carte[i].Nome}";
                        aggiornaPrezzo(0);
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

            totale.Text = $"totale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}� \ndi cui IVA: {Math.Round(prezzoIva, 2)}� \nsconto: {sconto}%";
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
            totale.Size = new Size(Size.Width / 2 - 45, 150);
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
                string testoScontrino = $"PietroSpin - la spesa rocciosa\n{DateTime.Now.ToString("f")}\n";
                if (currentFidelityCard != "")
                    testoScontrino += $"ciao {currentFidelityCard}\n\n";
                else
                    testoScontrino += "\n";
                for (int i = 0; i < carrello.Count; i++)
                    testoScontrino += carrello[i].Nome.PadRight(30) + $"{carrello[i].Prezzo:F2}�".PadLeft(10) + "\n";
                testoScontrino += $"\ntotale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}� \ndi cui IVA: {Math.Round(prezzoIva, 2)}� \nsconto: {sconto}%";


                //salviamo in un file di testo lo scontrino
                string file = "scontrini/" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt";
                if (!System.IO.Directory.Exists("scontrini"))
                    System.IO.Directory.CreateDirectory("scontrini");
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
<<<<<<< HEAD
                clienteMaggiorenne = null;
=======
>>>>>>> 1616f5489942c88524b7c26c61c2ebcdee338489
                currentFidelityCard = "";
                totale.Text = "totale: 0�\r\ndi cui IVA: 0�\r\nsconto: 0%";
                this.ActiveControl = null;
                carrello.Clear();
                pulsantiCarrello.Clear();

            }
            else
                MessageBox.Show("il carrello � vuoto");
        }

        private void stampa_PrintPage(object sender, PrintPageEventArgs e)
        {
            //prendiamo la stringa da file
            PrintDocument pietro = (PrintDocument)sender;
            string testoScontrino = File.ReadAllText(pietro.DocumentName);


            // aggiungiamo la immagine
            System.Drawing.Image immagine = System.Drawing.Image.FromFile("immagini/logo.png");
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
            Sconto scontoForm = new Sconto();
            if (scontoForm.ShowDialog() == DialogResult.OK)
            {
                sconto = scontoForm.Numero;
            }
            this.ActiveControl = null;
            aggiornaPrezzo(0);

        }

        private void shortCut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Random random = new Random();
                int numero = random.Next(prodotti.Count);

                scansione(prodotti[numero].Codice);
            }
            else if (e.KeyCode == Keys.F4)
            {
                scansioneCard = true;
                pulsanteFidelityCard.Enabled = false;
                this.ActiveControl = null;
            }
            else if (e.KeyCode == Keys.F5)
            {
                FineScontrino(sender, e);
            }

        }
    }

}
