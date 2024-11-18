namespace Projeto_de_Vendas.br.com.projeto.views
{
    partial class PaymentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMoney = new System.Windows.Forms.RadioButton();
            this.radioCard = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 100);
            this.panel1.TabIndex = 4;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(250, 29);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(218, 42);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Pagamento";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnConfirm.Location = new System.Drawing.Point(88, 408);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(316, 33);
            this.btnConfirm.TabIndex = 28;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.totalLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.totalLabel.Location = new System.Drawing.Point(71, 345);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(113, 26);
            this.totalLabel.TabIndex = 29;
            this.totalLabel.Text = "Total (R$):";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(190, 351);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(168, 20);
            this.txtTotal.TabIndex = 30;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.noteLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.noteLabel.Location = new System.Drawing.Point(441, 141);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(135, 26);
            this.noteLabel.TabIndex = 31;
            this.noteLabel.Text = "Observação:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(446, 170);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(254, 150);
            this.txtNote.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMoney);
            this.groupBox1.Controls.Add(this.radioCard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(76, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 153);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forma de Pagamento";
            // 
            // radioMoney
            // 
            this.radioMoney.AutoSize = true;
            this.radioMoney.Location = new System.Drawing.Point(32, 94);
            this.radioMoney.Name = "radioMoney";
            this.radioMoney.Size = new System.Drawing.Size(81, 22);
            this.radioMoney.TabIndex = 1;
            this.radioMoney.TabStop = true;
            this.radioMoney.Text = "Dinheiro";
            this.radioMoney.UseVisualStyleBackColor = true;
            // 
            // radioCard
            // 
            this.radioCard.AutoSize = true;
            this.radioCard.Location = new System.Drawing.Point(32, 43);
            this.radioCard.Name = "radioCard";
            this.radioCard.Size = new System.Drawing.Size(71, 22);
            this.radioCard.TabIndex = 0;
            this.radioCard.TabStop = true;
            this.radioCard.Text = "Cartão";
            this.radioCard.UseVisualStyleBackColor = true;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 478);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panel1);
            this.Name = "PaymentForm";
            this.Text = "Pagamento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label totalLabel;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMoney;
        private System.Windows.Forms.RadioButton radioCard;
    }
}