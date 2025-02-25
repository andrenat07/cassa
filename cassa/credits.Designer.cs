namespace cassa
{
    partial class Credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            testo = new Label();
            SuspendLayout();
            // 
            // testo
            // 
            testo.AutoSize = true;
            testo.Font = new Font("Segoe UI", 20F);
            testo.Location = new Point(12, 9);
            testo.Name = "testo";
            testo.Size = new Size(372, 222);
            testo.TabIndex = 0;
            testo.Text = "Gherardi Lorenzo\r\nNatali Andrea\r\nMagni Stefano\r\n\r\nGitHub repository:\r\ngithub.com/andrenat07/cassa\r\n";
            // 
            // Credits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 250);
            Controls.Add(testo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Credits";
            Text = "credits";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label testo;
    }
}