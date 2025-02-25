namespace cassa
{
    partial class ImpostazioniStampa
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
            sceltaFont = new FontDialog();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(5000);
            button1.Name = "button1";
            button1.Size = new Size(467, 140);
            button1.TabIndex = 0;
            button1.Text = "cambia font di stampa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(0, 140);
            button2.Margin = new Padding(5000);
            button2.Name = "button2";
            button2.Size = new Size(467, 142);
            button2.TabIndex = 1;
            button2.Text = "impostazioni stampante";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ImpostazioniStampa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 282);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ImpostazioniStampa";
            Text = "ImpostazioniStampa";
            Resize += ImpostazioniStampa_Resize;
            ResumeLayout(false);
        }

        #endregion

        private FontDialog sceltaFont;
        private Button button1;
        private Button button2;
    }
}