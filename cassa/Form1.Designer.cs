namespace cassa
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            scontrino = new GroupBox();
            scorrimento = new Panel();
            menuStrip1 = new MenuStrip();
            impostazioniToolStripMenuItem = new ToolStripMenuItem();
            prodottiToolStripMenuItem = new ToolStripMenuItem();
            fidelityCardToolStripMenuItem = new ToolStripMenuItem();
            stampaScontrinoToolStripMenuItem = new ToolStripMenuItem();
            modalitàProfToolStripMenuItem = new ToolStripMenuItem();
            barcodeFakeToolStripMenuItem = new ToolStripMenuItem();
            disattivaStampaMenu = new ToolStripMenuItem();
            creditToolStripMenuItem = new ToolStripMenuItem();
            PulsanteScontrino = new Button();
            banner = new PictureBox();
            pulsanteFidelityCard = new Button();
            pulsanteSconto = new Button();
            totale = new Label();
            stampa = new System.Drawing.Printing.PrintDocument();
            scontrino.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)banner).BeginInit();
            SuspendLayout();
            // 
            // scontrino
            // 
            scontrino.Controls.Add(scorrimento);
            scontrino.Location = new Point(10, 27);
            scontrino.Name = "scontrino";
            scontrino.Size = new Size(408, 400);
            scontrino.TabIndex = 0;
            scontrino.TabStop = false;
            scontrino.Text = "carrello";
            // 
            // scorrimento
            // 
            scorrimento.AutoScroll = true;
            scorrimento.Dock = DockStyle.Fill;
            scorrimento.Location = new Point(3, 19);
            scorrimento.Name = "scorrimento";
            scorrimento.Size = new Size(402, 378);
            scorrimento.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { impostazioniToolStripMenuItem, modalitàProfToolStripMenuItem, creditToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // impostazioniToolStripMenuItem
            // 
            impostazioniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prodottiToolStripMenuItem, fidelityCardToolStripMenuItem, stampaScontrinoToolStripMenuItem });
            impostazioniToolStripMenuItem.Name = "impostazioniToolStripMenuItem";
            impostazioniToolStripMenuItem.Size = new Size(87, 20);
            impostazioniToolStripMenuItem.Text = "impostazioni";
            // 
            // prodottiToolStripMenuItem
            // 
            prodottiToolStripMenuItem.Name = "prodottiToolStripMenuItem";
            prodottiToolStripMenuItem.Size = new Size(199, 22);
            prodottiToolStripMenuItem.Text = "gestione prodotti";
            prodottiToolStripMenuItem.Click += apriGestioneProdotti;
            // 
            // fidelityCardToolStripMenuItem
            // 
            fidelityCardToolStripMenuItem.Name = "fidelityCardToolStripMenuItem";
            fidelityCardToolStripMenuItem.Size = new Size(199, 22);
            fidelityCardToolStripMenuItem.Text = "gestione carte";
            fidelityCardToolStripMenuItem.Click += apriGestioneFidelityCard;
            // 
            // stampaScontrinoToolStripMenuItem
            // 
            stampaScontrinoToolStripMenuItem.Name = "stampaScontrinoToolStripMenuItem";
            stampaScontrinoToolStripMenuItem.Size = new Size(199, 22);
            stampaScontrinoToolStripMenuItem.Text = "impostazioni scrontrino";
            stampaScontrinoToolStripMenuItem.Click += apriImpostazioniScontrino;
            // 
            // modalitàProfToolStripMenuItem
            // 
            modalitàProfToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { barcodeFakeToolStripMenuItem, disattivaStampaMenu });
            modalitàProfToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            modalitàProfToolStripMenuItem.Name = "modalitàProfToolStripMenuItem";
            modalitàProfToolStripMenuItem.Size = new Size(78, 20);
            modalitàProfToolStripMenuItem.Text = "similazione";
            // 
            // barcodeFakeToolStripMenuItem
            // 
            barcodeFakeToolStripMenuItem.Name = "barcodeFakeToolStripMenuItem";
            barcodeFakeToolStripMenuItem.Size = new Size(180, 22);
            barcodeFakeToolStripMenuItem.Text = "simulatore barcode";
            barcodeFakeToolStripMenuItem.Click += apriBarcodeSimulator;
            // 
            // disattivaStampaMenu
            // 
            disattivaStampaMenu.Name = "disattivaStampaMenu";
            disattivaStampaMenu.Size = new Size(180, 22);
            disattivaStampaMenu.Text = "disattiva stampa";
            disattivaStampaMenu.Click += disattivaStampa;
            // 
            // creditToolStripMenuItem
            // 
            creditToolStripMenuItem.Name = "creditToolStripMenuItem";
            creditToolStripMenuItem.Size = new Size(49, 20);
            creditToolStripMenuItem.Text = "credit";
            creditToolStripMenuItem.Click += apriCrediti;
            // 
            // PulsanteScontrino
            // 
            PulsanteScontrino.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PulsanteScontrino.Location = new Point(428, 377);
            PulsanteScontrino.Name = "PulsanteScontrino";
            PulsanteScontrino.Size = new Size(363, 50);
            PulsanteScontrino.TabIndex = 2;
            PulsanteScontrino.TabStop = false;
            PulsanteScontrino.Text = "stampa scontrino";
            PulsanteScontrino.UseVisualStyleBackColor = true;
            PulsanteScontrino.Click += FineScontrino;
            // 
            // banner
            // 
            banner.Image = (Image)resources.GetObject("banner.Image");
            banner.Location = new Point(428, 36);
            banner.Name = "banner";
            banner.Size = new Size(363, 105);
            banner.SizeMode = PictureBoxSizeMode.Zoom;
            banner.TabIndex = 3;
            banner.TabStop = false;
            // 
            // pulsanteFidelityCard
            // 
            pulsanteFidelityCard.Location = new Point(428, 159);
            pulsanteFidelityCard.Name = "pulsanteFidelityCard";
            pulsanteFidelityCard.Size = new Size(176, 34);
            pulsanteFidelityCard.TabIndex = 4;
            pulsanteFidelityCard.TabStop = false;
            pulsanteFidelityCard.Text = "fidelity card";
            pulsanteFidelityCard.UseVisualStyleBackColor = true;
            pulsanteFidelityCard.Click += scansioneFidelityCard;
            // 
            // pulsanteSconto
            // 
            pulsanteSconto.Location = new Point(614, 159);
            pulsanteSconto.Name = "pulsanteSconto";
            pulsanteSconto.Size = new Size(176, 34);
            pulsanteSconto.TabIndex = 5;
            pulsanteSconto.TabStop = false;
            pulsanteSconto.Text = "sconto";
            pulsanteSconto.UseVisualStyleBackColor = true;
            pulsanteSconto.Click += apriSconto;
            // 
            // totale
            // 
            totale.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            totale.Font = new Font("Segoe UI", 20F);
            totale.Location = new Point(428, 220);
            totale.Name = "totale";
            totale.Size = new Size(363, 150);
            totale.TabIndex = 6;
            totale.Text = "totale: 0€\r\ndi cui IVA: 0€\r\nsconto: 0%";
            totale.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stampa
            // 
            stampa.PrintPage += stampa_PrintPage;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 441);
            Controls.Add(pulsanteSconto);
            Controls.Add(pulsanteFidelityCard);
            Controls.Add(banner);
            Controls.Add(PulsanteScontrino);
            Controls.Add(menuStrip1);
            Controls.Add(scontrino);
            Controls.Add(totale);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 450);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += shortCut;
            Resize += Main_Resize;
            scontrino.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)banner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox scontrino;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem impostazioniToolStripMenuItem;
        private ToolStripMenuItem prodottiToolStripMenuItem;
        private ToolStripMenuItem fidelityCardToolStripMenuItem;
        private ToolStripMenuItem stampaScontrinoToolStripMenuItem;
        private ToolStripMenuItem modalitàProfToolStripMenuItem;
        private ToolStripMenuItem creditToolStripMenuItem;
        private ToolStripMenuItem barcodeFakeToolStripMenuItem;
        private ToolStripMenuItem disattivaStampaMenu;
        private Button PulsanteScontrino;
        private PictureBox banner;
        private Button pulsanteFidelityCard;
        private Button pulsanteSconto;
        private Panel scorrimento;
        private Label totale;
        private System.Drawing.Printing.PrintDocument stampa;
    }
}
