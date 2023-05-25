namespace Parking
{
    partial class FormInitial
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
            components = new System.ComponentModel.Container();
            textBoxPlate = new TextBox();
            labelPlate = new Label();
            labelEntry = new Label();
            labelExiteds = new Label();
            buttonEntry = new Button();
            buttonExit = new Button();
            richTextBoxEntry = new RichTextBox();
            labelHours = new Label();
            richTextBoxExits = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textBoxPlate
            // 
            textBoxPlate.Location = new Point(366, 134);
            textBoxPlate.Name = "textBoxPlate";
            textBoxPlate.Size = new Size(205, 23);
            textBoxPlate.TabIndex = 0;
            // 
            // labelPlate
            // 
            labelPlate.AutoSize = true;
            labelPlate.Location = new Point(411, 105);
            labelPlate.Name = "labelPlate";
            labelPlate.Size = new Size(107, 15);
            labelPlate.TabIndex = 1;
            labelPlate.Text = "Placa (MERCOSUL)";
            // 
            // labelEntry
            // 
            labelEntry.AutoSize = true;
            labelEntry.Location = new Point(98, 38);
            labelEntry.Name = "labelEntry";
            labelEntry.Size = new Size(155, 15);
            labelEntry.TabIndex = 3;
            labelEntry.Text = "Veículos no estacionamento";
            // 
            // labelExiteds
            // 
            labelExiteds.AutoSize = true;
            labelExiteds.Location = new Point(830, 38);
            labelExiteds.Name = "labelExiteds";
            labelExiteds.Size = new Size(40, 15);
            labelExiteds.TabIndex = 5;
            labelExiteds.Text = "Saídas";
            // 
            // buttonEntry
            // 
            buttonEntry.Location = new Point(366, 193);
            buttonEntry.Name = "buttonEntry";
            buttonEntry.Size = new Size(75, 23);
            buttonEntry.TabIndex = 6;
            buttonEntry.Text = "ENTRADA";
            buttonEntry.UseVisualStyleBackColor = true;
            buttonEntry.Click += buttonEntry_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(496, 193);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "SAÍDA";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // richTextBoxEntry
            // 
            richTextBoxEntry.BackColor = SystemColors.ButtonHighlight;
            richTextBoxEntry.Location = new Point(12, 56);
            richTextBoxEntry.Name = "richTextBoxEntry";
            richTextBoxEntry.ReadOnly = true;
            richTextBoxEntry.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxEntry.Size = new Size(290, 405);
            richTextBoxEntry.TabIndex = 9;
            richTextBoxEntry.Text = "";
            // 
            // labelHours
            // 
            labelHours.AutoSize = true;
            labelHours.Location = new Point(442, 28);
            labelHours.Name = "labelHours";
            labelHours.Size = new Size(38, 15);
            labelHours.TabIndex = 20;
            labelHours.Text = "label1";
            // 
            // richTextBoxExits
            // 
            richTextBoxExits.Location = new Point(695, 56);
            richTextBoxExits.Name = "richTextBoxExits";
            richTextBoxExits.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxExits.Size = new Size(305, 405);
            richTextBoxExits.TabIndex = 11;
            richTextBoxExits.Text = "";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FormInitial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 482);
            Controls.Add(richTextBoxExits);
            Controls.Add(labelHours);
            Controls.Add(richTextBoxEntry);
            Controls.Add(buttonExit);
            Controls.Add(buttonEntry);
            Controls.Add(labelExiteds);
            Controls.Add(labelEntry);
            Controls.Add(labelPlate);
            Controls.Add(textBoxPlate);
            Name = "FormInitial";
            Text = "Estacionamento ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPlate;
        private Label labelPlate;
        private Label labelEntry;
        private Label labelExiteds;
        private Button buttonEntry;
        private Button buttonExit;
        private RichTextBox richTextBoxEntry;
        private Label labelHours;
        private RichTextBox richTextBoxExits;
        private System.Windows.Forms.Timer timer1;
    }
}