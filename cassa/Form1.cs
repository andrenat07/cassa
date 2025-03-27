using BasselTech.UsbBarcodeScanner;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO.Ports;

namespace cassa
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        //valore che indica se stiamo scansionando un carta o un prodotto
        private bool scansioneCard = false;

        //oggetto dello scanner
        private UsbBarcodeScanner scanner = new UsbBarcodeScanner();

        //font della stampa (pls non cambiarlo (ne serve 1 monospazziato))
        private static System.Drawing.Font fontStampa = new System.Drawing.Font("Courier New", 10);
        private string testoScontrinoRimanente;
        private bool primaPagina = true;

        private int counter = 0; //conta quanti prodotti sono stati inseriti nel carrello
        private bool? clienteMaggiorenne; //salva se il cliente è maggiornenne

        //liste dei prodotti della spesa
        private List<Prodotto> prodotti = new List<Prodotto>();
        private List<Prodotto> carrello = new List<Prodotto>();
        //è semplicemente una classe che eredita Button e ci aggiunge un intero (l'inidice del prodotto all'interno del pulsante)
        private List<PulsanteProdotto> pulsantiCarrello = new List<PulsanteProdotto>();
        //lista di tutte la carte
        private List<FidelityCard> carte = new List<FidelityCard>();
        //salva il nome del cliente quando viene usata la fidelity card
        private string currentFidelityCard = "";

        //variabili per il prezzo
        private int iva = 5;
        private int sconto = 0;
        private double prezzo = 0;
        private double prezzoIva = 0;
        private double prezzoScontato = 0;


        //property per alcuni attributi
        public static System.Drawing.Font FontStampa { get => fontStampa; set => fontStampa = value; }
        internal List<Prodotto> Prodotti { get => prodotti; set => prodotti = value; }
        internal List<FidelityCard> Carte { get => carte; set => carte = value; }

        private void Form1_Load(object sender, EventArgs e)
        {            
            scanner.BarcodeScanned += BarcodeScansionato; //aggiungo l'evento di scansione
            scanner.Start(); //fa iniziare la scansione dei codici

            //aggiungo dei prodotti alla lista dei prodotti
            Prodotti.Add(new FruttaVerdura("Mela", "Mela rossa biologica", 1.20, "56881", new DateOnly(2025, 4, 10), 52, "Italia", 0.2));
            Prodotti.Add(new FruttaVerdura("Carota", "Carota fresca", 0.80, "38934", new DateOnly(2025, 3, 25), 41, "Italia", 0.15));
            Prodotti.Add(new FruttaVerdura("Banana", "Banana matura", 1.10, "43958", new DateOnly(2025, 4, 5), 89, "Ecuador", 0.25));
            Prodotti.Add(new FruttaVerdura("Patata", "Patata novella", 0.60, "88827", new DateOnly(2025, 3, 28), 77, "Francia", 0.3));

            Prodotti.Add(new Carne("Bistecca", "Bistecca di manzo", 15.50, "31960", new DateOnly(2025, 3, 18), 250, "Manzo", 0.5));
            Prodotti.Add(new Carne("Coscia di pollo", "Pollo allevato a terra", 7.99, "60226", new DateOnly(2025, 3, 22), 165, "Pollo", 0.7));
            Prodotti.Add(new Carne("Salsiccia", "Salsiccia di suino", 9.99, "63348", new DateOnly(2025, 3, 25), 300, "Suino", 0.6));
            Prodotti.Add(new Carne("Agnello", "Costolette di agnello", 18.75, "22352", new DateOnly(2025, 3, 27), 270, "Agnello", 0.8));

            Prodotti.Add(new Pane("Baguette", "Pane francese croccante", 1.50, "24558", new DateOnly(2025, 3, 15), 280, new DateOnly(2025, 3, 14), "Grano"));
            Prodotti.Add(new Pane("Ciabatta", "Pane italiano morbido", 1.80, "87898", new DateOnly(2025, 3, 16), 270, new DateOnly(2025, 3, 15), "Grano"));
            Prodotti.Add(new Pane("Pane integrale", "Pane con farina integrale", 2.00, "17678", new DateOnly(2025, 3, 17), 250, new DateOnly(2025, 3, 16), "Integrale"));
            Prodotti.Add(new Pane("Focaccia", "Focaccia genovese", 2.50, "64328", new DateOnly(2025, 3, 18), 300, new DateOnly(2025, 3, 17), "Grano"));

            Prodotti.Add(new Pesce("Salmone", "Salmone norvegese fresco", 22.99, "58181", new DateOnly(2025, 3, 20), 208, "Norvegia", 1.2));
            Prodotti.Add(new Pesce("Orata", "Orata pescata nel Mediterraneo", 18.50, "98571", new DateOnly(2025, 3, 18), 150, "Italia", 0.9));
            Prodotti.Add(new Pesce("Tonno", "Tonno pinna gialla", 25.99, "54246", new DateOnly(2025, 3, 22), 200, "Spagna", 1.1));
            Prodotti.Add(new Pesce("Gamberi", "Gamberi freschi", 29.50, "47738", new DateOnly(2025, 3, 21), 105, "Argentina", 0.8));

            Prodotti.Add(new Latticini("Latte intero", "Latte fresco intero 1L", 1.30, "95220", new DateOnly(2025, 3, 30), 60, 1));
            Prodotti.Add(new Latticini("Formaggio Parmigiano", "Parmigiano Reggiano stagionato", 12.99, "46564", new DateOnly(2025, 8, 15), 402, 0.5));
            Prodotti.Add(new Latticini("Mozzarella", "Mozzarella di bufala", 3.99, "97536", new DateOnly(2025, 4, 5), 280, 0.25));
            Prodotti.Add(new Latticini("Yogurt", "Yogurt naturale senza zucchero", 0.99, "53125", new DateOnly(2025, 4, 10), 100, 0.15));

            Prodotti.Add(new Acqua("Acqua Naturale", "Acqua minerale naturale", 0.50, "89447", 1.5, "Plastica", "Monte Bianco"));
            Prodotti.Add(new Acqua("Acqua Frizzante", "Acqua minerale frizzante", 0.60, "61041", 1.5, "Vetro", "Fonte Alpina"));
            Prodotti.Add(new Acqua("Acqua Tonica", "Bevanda frizzante con chinino", 1.20, "84340", 1.0, "Vetro", "Fonte Rossa"));
            Prodotti.Add(new Acqua("Acqua di cocco", "Acqua di cocco naturale", 2.50, "16294", 0.5, "Tetra Pak", "Filippine"));

            Prodotti.Add(new Analcolico("Cola", "Bevanda gassata cola", 1.20, "25843", 1.5, "Plastica", 10));
            Prodotti.Add(new Analcolico("Succo d'arancia", "Succo 100% arancia", 2.00, "43395", 1.0, "Tetra Pak", 8));
            Prodotti.Add(new Analcolico("Limonata", "Bevanda gassata al limone", 1.50, "41429", 1.5, "Plastica", 9));
            Prodotti.Add(new Analcolico("Tè freddo", "Tè freddo al limone", 1.80, "17075", 1.5, "Plastica", 7));

            Prodotti.Add(new Alcolico("Birra Lager", "Birra chiara leggera", 2.50, "44223", 0.5, "Vetro", 5));
            Prodotti.Add(new Alcolico("Vino Rosso", "Vino rosso toscano", 15.00, "38915", 0.75, "Vetro", 13));
            Prodotti.Add(new Alcolico("Whisky", "Whisky scozzese invecchiato 12 anni", 45.00, "79029", 0.7, "Vetro", 40));
            Prodotti.Add(new Alcolico("Rum", "Rum caraibico ambrato", 30.00, "94903", 0.7, "Vetro", 37));


            //aggiungo delle fidelity card alla lista delle carte            
            Carte.Add(new FidelityCard("Andrea", "Natali", "60806", 100));
            Carte.Add(new FidelityCard("Lorenzo", "Gherardi", "16819", 50));
            Carte.Add(new FidelityCard("Stefano", "Magni", "97407", -100));
            Carte.Add(new FidelityCard("Pietro", "Manzoni", "74002", 200));
            Carte.Add(new FidelityCard("Giulia Maria", "Maiorana", "68435", 50));
            Carte.Add(new FidelityCard("Mario", "Rossi", "29270", 10));
            Carte.Add(new FidelityCard("Marco","Bianchi","78152",15));
            Carte.Add(new FidelityCard("Elena", "Rossi", "49484",20)); 
            Carte.Add(new FidelityCard("Luca", "Ferrari", "60640",10));
            Carte.Add(new FidelityCard("Giulia" , "Conti" ,"59203", 25));

        }
        //evento che si scatena quando il lettore usb legge un barcode
        private void BarcodeScansionato(object? sender, BarcodeScannedEventArgs e)
        {            
            scansione(e.Barcode);
        }

        //funzione per la scansione
        public void scansione(string CodiceScansionato)
        {
            if (!scansioneCard)//controlla se bisogna scansionare un prodotto o una carta
                for (int i = 0; i < Prodotti.Count; i++)//cicla tutti i prodotti
                {
                    if (Prodotti[i].Codice == CodiceScansionato)//cerca quello con il codice corrispondente
                    {
                        if (Prodotti[i].GetType() == typeof(Alcolico)) //se il prodotto è un alcolico
                        {
                            if (clienteMaggiorenne == null)//se il cliente non è stato ancora identificato
                            {
                                MessageBox.Show("coso per l'invio");//il lettore usb quando legge schiaccia invio quindi non si vedrebbe il messaggio successivo
                                if (MessageBox.Show("il cliente è maggiorenne?", "prodotto alcolico", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    clienteMaggiorenne = false;//salviamo che il cliente è minorenne 
                                    break;//blocchaimo il ciclo quindi il prodotto no viene aggiunto
                                }
                                else
                                    clienteMaggiorenne = true;
                            }

                            else if ((bool)!clienteMaggiorenne) //se il cliente è minorenne
                            {
                                MessageBox.Show("coso per l'invio");
                                if (MessageBox.Show("il cliente è minorenne!!!\nperciò non può comprare una alcolico\nse hai sbagliato clicca annulla", "prodotto alcolico", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                    clienteMaggiorenne = true;
                                else
                                    break;

                            }
                            //nel caso sia maggiorenne aggiunge senza problemi
                        }

                        //PulsanteProdotto è un una clsse che eredita pulsante che in più contiene l'idice nella lista del prodotto
                        PulsanteProdotto pulsanteProdotto = new PulsanteProdotto();
                        pulsanteProdotto.Indice = counter;

                        // proviamo a mandare un messaggio a tutte le porte seriali collegate al pc
                        foreach (var porta in SerialPort.GetPortNames()) 
                        {
                            try
                            {
                                SerialPort miaporta = new SerialPort(porta, 9600);
                                miaporta.Open();
                                miaporta.Write($"{prodotti[i].Nome}!{Math.Round(prodotti[i].Prezzo, 2)}");
                                miaporta.Close();
                            }
                            catch { }
                        }
                        

                        //personaliziamo il pulsante
                        pulsanteProdotto.Text = Prodotti[i].Nome;
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
                        carrello.Add(Prodotti[i]);

                        //aggiorniamo il prezzo
                        aggiornaPrezzo(Prodotti[i].Prezzo);
                        counter++;
                        break; //chiude il ciclo (sia per risparmiare che per non far scatenare l'errore)
                    }
                    if (i == Prodotti.Count - 1)
                        //siamo arrivati alla fine del ciclo ma non è stato trovato nulla 
                        MessageBox.Show("il prodotto non fa parte del nostro negozio");
                }
            else //stiamo scansionando una carta
                for (int i = 0; i < Carte.Count; i++) //cicliamo tra tutte le carte
                {
                    if (Carte[i].Codice == CodiceScansionato) //cerca quella con il codice corrispondente
                    {
                        sconto = Carte[i].Sconto;//applichiamo lo sconto sulla carta
                        pulsanteFidelityCard.Enabled = true;//riattiviamo il pulsante
                        scansioneCard = false;//disattiviamo che stiamo scansionando una carta
                        currentFidelityCard = $"{Carte[i].Cognome} {Carte[i].Nome}";//salviamo l'untente
                        aggiornaPrezzo(0);//riaggiorniamo il prezzo con lo sconto
                        break;//chiude il ciclo (sia per risparmiare che per non far scatenare l'errore)
                    }

                    if (i == Carte.Count - 1)
                    {
                        //siamo arrivati alla fine del ciclo ma non è stato trovato nulla 
                        MessageBox.Show("questa fidelity card non esiste");
                        pulsanteFidelityCard.Enabled = true;
                        scansioneCard = false;

                    }
                }
        }

        //funzione per aggiornare il prezzo
        private void aggiornaPrezzo(double spesa)
        {

            prezzo += spesa; //aggiungiamo la spesa
            prezzoScontato = prezzo * sconto / 100; //calcoliamo lo sconto
            prezzoIva = (prezzo - prezzoScontato) * iva / 100; //calcoliamo l'iva

            //modifichaimo il prezzo e arrotondiamo le cifre a 2 deciamali
            totale.Text = $"totale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}€ \ndi cui IVA: {Math.Round(prezzoIva, 2)}€ \nsconto: {sconto}%";
        }

        //per visualizare le impormazioni di un prodotto
        private void infoProdotto(object sender, EventArgs e)
        {
            //mostriamo le informazioni del prodotto quando si clicca con il sinitro sul carello
            PulsanteProdotto pulsante = (PulsanteProdotto)sender;
            MessageBox.Show(carrello[pulsante.Indice].ToString(), "informazioni");
            this.ActiveControl = null;

        }

        //per aliminare un prodotto dalla spesa
        private void eliminaProdotto(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//se viene premuto con il desctro
            {
                PulsanteProdotto pulsante = (PulsanteProdotto)sender;
                aggiornaPrezzo(-carrello[pulsante.Indice].Prezzo);//aggiorniamo il prezzo togliendo il prodotto 
                carrello.RemoveAt(pulsante.Indice);//rimuoviamo il prodotto dal carello

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

        //quando si finisce lo scontrino
        private void FineScontrino(object sender, EventArgs e)
        {
            if (carrello.Count != 0) //controlla se il carrello non è vuoto
            {
                //componiamo il testo dello scontrino
                string testoScontrino = $"PietroSpin - la spesa rocciosa\n{DateTime.Now.ToString("f")}\n";
                //se c'è una carta salutiamo l'acquirente
                if (currentFidelityCard != "")
                    testoScontrino += $"ciao {currentFidelityCard}\n\n";
                //senò lasciamo lo spazio
                else
                    testoScontrino += "\n";
                //aggiungiamo tutti i prodotti e posizioniamo i nomi a sinistra e i prezzi a destra 
                for (int i = 0; i < carrello.Count; i++)
                    testoScontrino += carrello[i].Nome.PadRight(30) + $"{carrello[i].Prezzo:F2}€".PadLeft(10) + "\n";
                //aggiungiamo il prezzo
                testoScontrino += $"\ntotale: {Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}€ \ndi cui IVA: {Math.Round(prezzoIva, 2)}€ \nsconto: {sconto}%";

                // proviamo a mandare un messaggio a tutte le porte collegate al pc
                foreach (var porta in SerialPort.GetPortNames())
                {
                    try
                    {
                        SerialPort miaporta = new SerialPort(porta, 9600);
                        miaporta.Open();
                        miaporta.Write($"totale!{Math.Round(prezzo - prezzoScontato + prezzoIva, 2)}");
                        miaporta.Close();
                    }
                    catch { }
                }

                //salviamo in un file di testo lo scontrino
                string file = "scontrini/" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt";
                if (!System.IO.Directory.Exists("scontrini"))//se non esiste la cartella scontrini la crea
                    System.IO.Directory.CreateDirectory("scontrini");
                System.IO.File.WriteAllText(file, testoScontrino);//salva nel file txt lo scontrino

                if (disattivaStampaMenu.Checked) //se è distattivata la stampa
                    MessageBox.Show(testoScontrino); //stampiamo con messagebox
                else
                {
                    //avviamo la stampa su stampante
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
                clienteMaggiorenne = null;
                currentFidelityCard = "";
                totale.Text = "totale: 0€\r\ndi cui IVA: 0€\r\nsconto: 0%";
                this.ActiveControl = null;
                carrello.Clear();
                pulsantiCarrello.Clear();

            }
            else //viene notificato che il carello è vuoto
                MessageBox.Show("il carrello è vuoto");
        }

        //fa partire la scansione delle fidelity card
        private void scansioneFidelityCard(object sender, EventArgs e)
        {
            scansioneCard = true;
            pulsanteFidelityCard.Enabled = false;
            this.ActiveControl = null;
        }

        //per aprire il simulatore di barcode
        private void apriBarcodeSimulator(object sender, EventArgs e)
        {
            //costruiamo l'oggetto della form del barcode e gli passiamo il riferimento a questa form
            Barcodesimulator barcodesimulator = new Barcodesimulator(this);
            barcodesimulator.Show();
        }

        //per aprire la form dello sconto
        private void apriSconto(object sender, EventArgs e)
        {
            //costruiamo l'oggetto della form dello sconto
            Sconto scontoForm = new Sconto();
            if (scontoForm.ShowDialog() == DialogResult.OK)
            {
                sconto = scontoForm.Numero;
            }
            currentFidelityCard = "";
            this.ActiveControl = null;
            aggiornaPrezzo(0);

        }

        //evento di quando si muove la form e fa mantentere la dimenzione agli elementi
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

        //creiamo delle shortcut rapide
        private void shortCut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3) //aggiunge prodotti random nel codice
            {
                Random random = new Random();
                int numero;
                if (scansioneCard)
                {
                    numero = random.Next(carte.Count);
                    scansione(carte[numero].Codice);
                }
                else
                {
                    numero = random.Next(Prodotti.Count);
                    scansione(prodotti[numero].Codice);
                }
            }
            else if (e.KeyCode == Keys.F4) //attiva la scansione della card
            {
                scansioneCard = true;
                pulsanteFidelityCard.Enabled = false;
                this.ActiveControl = null;
            }
            else if (e.KeyCode == Keys.F5) //stampa lo scontrino
            {
                FineScontrino(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (WindowState == FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Normal;
                else if (WindowState == FormWindowState.Normal)
                    WindowState = FormWindowState.Maximized;
            }
        }

        //gestione dei prodotti
        private void apriGestioneProdotti(object sender, EventArgs e)
        {
            //costruiamo l'oggetto della form della gestione prodotti e gli passiamo il riferimento a questa form
            MoficaProdotti si = new MoficaProdotti(this);
            si.ShowDialog();            
        }

        //gestione delle carte
        private void apriGestioneFidelityCard(object sender, EventArgs e)
        {
            //costruiamo l'oggetto della form della gestione delle fidelity Card e gli passiamo il riferimento a questa form
            gestisciFidelityCard si = new gestisciFidelityCard(this);
            si.ShowDialog();
        }
        
        //aprire impostazioni scontrino
        private void apriImpostazioniScontrino(object sender, EventArgs e)
        {
            //apriamo le impostazioni dello scontrino
            ImpostazioniStampa impostazioniStampa = new ImpostazioniStampa();
            impostazioniStampa.ShowDialog();
        }

        //apre la form dei crediti
        private void apriCrediti(object sender, EventArgs e)
        {
            //apre la pagina dei crediti
            Credits credits = new Credits();
            credits.ShowDialog();
        }

        //evento di quando si stampa una pagina
        private void stampa_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Se è la prima pagina, carichiamo il testo dal file
            if (testoScontrinoRimanente == null)
            {
                PrintDocument pietro = (PrintDocument)sender;
                testoScontrinoRimanente = File.ReadAllText(pietro.DocumentName);
            }

            int offsetY = e.MarginBounds.Top;

            // Stampiamo l'immagine solo sulla prima pagina
            if (primaPagina)
            {
                System.Drawing.Image immagine = System.Drawing.Image.FromFile("immagini/logo.png");
                Rectangle rettangoloImmagine = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, 100, 100);
                e.Graphics.DrawImage(immagine, rettangoloImmagine);
                offsetY += rettangoloImmagine.Height + 10; // Spostiamo il testo in basso dopo l'immagine
            }

            RectangleF areaTesto = new RectangleF(e.MarginBounds.Left, offsetY, e.MarginBounds.Width, e.MarginBounds.Height - (offsetY - e.MarginBounds.Top));

            int caratteriPerPagina = 0;
            int lineePerPagina = 0;
            e.Graphics.MeasureString(testoScontrinoRimanente, FontStampa, areaTesto.Size, StringFormat.GenericTypographic, out caratteriPerPagina, out lineePerPagina);

            // Prendiamo solo la parte di testo che entra in questa pagina
            string testoDaStampare = testoScontrinoRimanente.Substring(0, Math.Min(caratteriPerPagina, testoScontrinoRimanente.Length));
            e.Graphics.DrawString(testoDaStampare, FontStampa, Brushes.Black, areaTesto, StringFormat.GenericTypographic);

            // Aggiorniamo il testo rimanente
            testoScontrinoRimanente = testoScontrinoRimanente.Substring(testoDaStampare.Length);

            // Controlliamo se ci sono altre pagine
            e.HasMorePages = (testoScontrinoRimanente.Length > 0);

            // Dopo la prima pagina, l'immagine non deve essere più stampata
            primaPagina = false;

            // Se è l'ultima pagina, resettiamo le variabili per la prossima stampa
            if (!e.HasMorePages)
            {
                testoScontrinoRimanente = null;
                primaPagina = true;
            }
        }

        //per disattivare la stampa
        private void disattivaStampa(object sender, EventArgs e)
        {
            //invertiamo il segno della stampa
            disattivaStampaMenu.Checked = !disattivaStampaMenu.Checked;
        }
    }

}
