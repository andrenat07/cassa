namespace cassa
{
    partial class NuovoProdotto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            numericUpDown2 = new NumericUpDown();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(159, 185);
            label1.TabIndex = 0;
            label1.Text = "Nome:\r\nDescrizione:\r\nPrezzo:\r\nReparto:\r\nCodice:\r\n";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(175, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(266, 23);
            textBox2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(113, 95);
            numericUpDown1.Maximum = new decimal(new int[] { 1241513983, 370409800, 542101, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(328, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Alimentari", "Ortofrutta", "Macelleria", "Pescheria", "Panetteria", "Pasticceria", "Surgelati", "Latticini", "Bevande", "CuraPersona", "PuliziaCasa", "Elettronica", "Giocattoli", "Animali" });
            comboBox1.Location = new Point(128, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(313, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(115, 171);
            numericUpDown2.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(326, 23);
            numericUpDown2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(12, 211);
            button1.Name = "button1";
            button1.Size = new Size(429, 40);
            button1.TabIndex = 6;
            button1.Text = "crea";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NuovoProdotto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 263);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuovoProdotto";
            Text = "Nuovo Prodotto";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown2;
        private Button button1;
    }
}