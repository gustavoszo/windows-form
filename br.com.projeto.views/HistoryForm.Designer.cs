namespace Projeto_de_Vendas.br.com.projeto.views
{
    partial class HistoryForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimeFinal = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInitial = new System.Windows.Forms.DateTimePicker();
            this.dateFinalLabel = new System.Windows.Forms.Label();
            this.dateInitialLabel = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 4;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(224, 26);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(372, 42);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Histórico de Vendas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimeFinal);
            this.groupBox1.Controls.Add(this.dateTimeInitial);
            this.groupBox1.Controls.Add(this.dateFinalLabel);
            this.groupBox1.Controls.Add(this.dateInitialLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Location = new System.Drawing.Point(596, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 35);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimeFinal
            // 
            this.dateTimeFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFinal.Location = new System.Drawing.Point(400, 45);
            this.dateTimeFinal.Name = "dateTimeFinal";
            this.dateTimeFinal.Size = new System.Drawing.Size(152, 26);
            this.dateTimeFinal.TabIndex = 25;
            // 
            // dateTimeInitial
            // 
            this.dateTimeInitial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInitial.Location = new System.Drawing.Point(129, 44);
            this.dateTimeInitial.Name = "dateTimeInitial";
            this.dateTimeInitial.Size = new System.Drawing.Size(146, 26);
            this.dateTimeInitial.TabIndex = 24;
            // 
            // dateFinalLabel
            // 
            this.dateFinalLabel.AutoSize = true;
            this.dateFinalLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dateFinalLabel.Location = new System.Drawing.Point(308, 45);
            this.dateFinalLabel.Name = "dateFinalLabel";
            this.dateFinalLabel.Size = new System.Drawing.Size(86, 20);
            this.dateFinalLabel.TabIndex = 23;
            this.dateFinalLabel.Text = "Data final:";
            // 
            // dateInitialLabel
            // 
            this.dateInitialLabel.AutoSize = true;
            this.dateInitialLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dateInitialLabel.Location = new System.Drawing.Point(6, 45);
            this.dateInitialLabel.Name = "dateInitialLabel";
            this.dateInitialLabel.Size = new System.Drawing.Size(117, 20);
            this.dateInitialLabel.TabIndex = 22;
            this.dateInitialLabel.Text = "Data de início:";
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(12, 212);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(776, 226);
            this.table.TabIndex = 6;
            this.table.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellDoubleClick);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.table);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryForm";
            this.Text = "Histórico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dateFinalLabel;
        private System.Windows.Forms.Label dateInitialLabel;
        private System.Windows.Forms.DateTimePicker dateTimeFinal;
        private System.Windows.Forms.DateTimePicker dateTimeInitial;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button btnSearch;
    }
}