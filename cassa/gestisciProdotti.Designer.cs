﻿namespace cassa
{
    partial class MoficaProdotti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoficaProdotti));
            listBox1 = new ListBox();
            panel1 = new Panel();
            button1 = new Button();
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
            panel1.Controls.Add(button1);
            panel1.Controls.Add(elimina);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(620, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 450);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(15, 55);
            button1.Name = "button1";
            button1.Size = new Size(153, 37);
            button1.TabIndex = 3;
            button1.Text = "nuovo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            // MoficaProdotti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(listBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MoficaProdotti";
            Text = "MoficaProdotti";
            Load += MoficaProdotti_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBox1;
        private Panel panel1;
        private Button elimina;
        private Button button1;
    }
}