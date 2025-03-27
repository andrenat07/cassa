namespace cassa
{
    partial class gestisciFidelityCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestisciFidelityCard));
            listBox1 = new ListBox();
            panel1 = new Panel();
            nuova = new Button();
            elimina = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(800, 450);
            listBox1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(nuova);
            panel1.Controls.Add(elimina);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(620, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 450);
            panel1.TabIndex = 3;
            // 
            // nuova
            // 
            nuova.Location = new Point(15, 55);
            nuova.Name = "nuova";
            nuova.Size = new Size(153, 37);
            nuova.TabIndex = 3;
            nuova.Text = "nuova";
            nuova.UseVisualStyleBackColor = true;
            nuova.Click += nuova_Click;
            // 
            // elimina
            // 
            elimina.Location = new Point(15, 12);
            elimina.Name = "elimina";
            elimina.Size = new Size(153, 37);
            elimina.TabIndex = 2;
            elimina.Text = "elimina";
            elimina.UseVisualStyleBackColor = true;
            elimina.Click += elimina_click;
            // 
            // gestisciFidelityCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(listBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "gestisciFidelityCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "gestisci fidelity card";
            Load += MoficaProdotti_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBox1;
        private Panel panel1;
        private Button elimina;
        private Button nuova;
    }
}