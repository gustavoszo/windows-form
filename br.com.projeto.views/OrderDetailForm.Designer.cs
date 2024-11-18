namespace Projeto_de_Vendas.br.com.projeto.views
{
    partial class OrderDetailForm
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
            this.txtDate = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.clientLabel = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 100);
            this.panel1.TabIndex = 4;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(175, 27);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(348, 42);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Detalhes da venda";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(97, 182);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(279, 20);
            this.txtDate.TabIndex = 8;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.dateLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dateLabel.Location = new System.Drawing.Point(29, 182);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 20);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "Data:";
            // 
            // txtClient
            // 
            this.txtClient.Enabled = false;
            this.txtClient.Location = new System.Drawing.Point(97, 134);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(279, 20);
            this.txtClient.TabIndex = 6;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.clientLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.clientLabel.Location = new System.Drawing.Point(29, 134);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(66, 20);
            this.clientLabel.TabIndex = 5;
            this.clientLabel.Text = "Cliente:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(564, 134);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(94, 20);
            this.txtTotal.TabIndex = 10;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.totalLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.totalLabel.Location = new System.Drawing.Point(397, 134);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(161, 20);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total da venda (R$):";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.noteLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.noteLabel.Location = new System.Drawing.Point(29, 227);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(113, 20);
            this.noteLabel.TabIndex = 11;
            this.noteLabel.Text = "Observações:";
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Location = new System.Drawing.Point(33, 250);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(473, 79);
            this.txtNote.TabIndex = 12;
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(33, 359);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(625, 160);
            this.table.TabIndex = 13;
            this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 541);
            this.Controls.Add(this.table);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.panel1);
            this.Name = "OrderDetailForm";
            this.Text = "Detalhes da venda";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label noteLabel;
        public System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.TextBox txtClient;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.DataGridView table;
    }
}