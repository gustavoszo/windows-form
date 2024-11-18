namespace Projeto_de_Vendas.br.com.projeto.views
{
    partial class ProductForm
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
            System.Windows.Forms.TabControl tabControlProduct;
            this.providerTabPage = new System.Windows.Forms.TabPage();
            this.txtId = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.txtQtAvaiable = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.providerLabel = new System.Windows.Forms.Label();
            this.labelCnpj = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.listLabel = new System.Windows.Forms.TabPage();
            this.table = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            tabControlProduct = new System.Windows.Forms.TabControl();
            tabControlProduct.SuspendLayout();
            this.providerTabPage.SuspendLayout();
            this.listLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlProduct
            // 
            tabControlProduct.Controls.Add(this.providerTabPage);
            tabControlProduct.Controls.Add(this.listLabel);
            tabControlProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabControlProduct.ItemSize = new System.Drawing.Size(127, 25);
            tabControlProduct.Location = new System.Drawing.Point(12, 122);
            tabControlProduct.Name = "tabControlProduct";
            tabControlProduct.SelectedIndex = 0;
            tabControlProduct.Size = new System.Drawing.Size(776, 259);
            tabControlProduct.TabIndex = 3;
            // 
            // providerTabPage
            // 
            this.providerTabPage.Controls.Add(this.txtId);
            this.providerTabPage.Controls.Add(this.IdLabel);
            this.providerTabPage.Controls.Add(this.comboBoxProvider);
            this.providerTabPage.Controls.Add(this.txtQtAvaiable);
            this.providerTabPage.Controls.Add(this.txtPrice);
            this.providerTabPage.Controls.Add(this.providerLabel);
            this.providerTabPage.Controls.Add(this.labelCnpj);
            this.providerTabPage.Controls.Add(this.emailLabel);
            this.providerTabPage.Controls.Add(this.txtDescription);
            this.providerTabPage.Controls.Add(this.descriptionLabel);
            this.providerTabPage.Location = new System.Drawing.Point(4, 29);
            this.providerTabPage.Name = "providerTabPage";
            this.providerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.providerTabPage.Size = new System.Drawing.Size(768, 226);
            this.providerTabPage.TabIndex = 0;
            this.providerTabPage.Text = "Dados do Fornecedor";
            this.providerTabPage.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(56, 32);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(99, 26);
            this.txtId.TabIndex = 20;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdLabel.Location = new System.Drawing.Point(20, 32);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(30, 20);
            this.IdLabel.TabIndex = 19;
            this.IdLabel.Text = "ID:";
            this.IdLabel.Click += new System.EventHandler(this.IdLabel_Click);
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Items.AddRange(new object[] {
            "SP",
            "RJ",
            "MG",
            "ES",
            "SC",
            "BA",
            "PA",
            "RS",
            "AM",
            "AC",
            "GO"});
            this.comboBoxProvider.Location = new System.Drawing.Point(129, 165);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(222, 28);
            this.comboBoxProvider.TabIndex = 18;
            // 
            // txtQtAvaiable
            // 
            this.txtQtAvaiable.Location = new System.Drawing.Point(129, 122);
            this.txtQtAvaiable.Name = "txtQtAvaiable";
            this.txtQtAvaiable.Size = new System.Drawing.Size(73, 26);
            this.txtQtAvaiable.TabIndex = 17;
            this.txtQtAvaiable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtAvaiable_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(504, 78);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(99, 26);
            this.txtPrice.TabIndex = 16;
            // 
            // providerLabel
            // 
            this.providerLabel.AutoSize = true;
            this.providerLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.providerLabel.Location = new System.Drawing.Point(24, 168);
            this.providerLabel.Name = "providerLabel";
            this.providerLabel.Size = new System.Drawing.Size(95, 20);
            this.providerLabel.TabIndex = 8;
            this.providerLabel.Text = "Fornecedor:";
            // 
            // labelCnpj
            // 
            this.labelCnpj.AutoSize = true;
            this.labelCnpj.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelCnpj.Location = new System.Drawing.Point(409, 78);
            this.labelCnpj.Name = "labelCnpj";
            this.labelCnpj.Size = new System.Drawing.Size(89, 20);
            this.labelCnpj.TabIndex = 4;
            this.labelCnpj.Text = "Preço (R$):";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.emailLabel.Location = new System.Drawing.Point(20, 125);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(103, 20);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Qtd Estoque:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 78);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 26);
            this.txtDescription.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 78);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(84, 20);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Descrição:";
            // 
            // listLabel
            // 
            this.listLabel.Controls.Add(this.table);
            this.listLabel.Controls.Add(this.txtSearch);
            this.listLabel.Controls.Add(this.labelSearch);
            this.listLabel.Location = new System.Drawing.Point(4, 29);
            this.listLabel.Name = "listLabel";
            this.listLabel.Padding = new System.Windows.Forms.Padding(3);
            this.listLabel.Size = new System.Drawing.Size(768, 226);
            this.listLabel.TabIndex = 1;
            this.listLabel.Text = "Consulta";
            this.listLabel.UseVisualStyleBackColor = true;
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(17, 61);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(731, 150);
            this.table.TabIndex = 4;
            this.table.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(279, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelSearch.Location = new System.Drawing.Point(24, 23);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(55, 20);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Nome:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(39, 41);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(210, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Cadastro de Produto";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancel.Location = new System.Drawing.Point(547, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 33);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDelete.Location = new System.Drawing.Point(410, 398);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 33);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClean.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClean.Location = new System.Drawing.Point(276, 398);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(104, 33);
            this.btnClean.TabIndex = 13;
            this.btnClean.Text = "Limpar";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSave.Location = new System.Drawing.Point(145, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 443);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(tabControlProduct);
            this.Controls.Add(this.panel1);
            this.Name = "ProductForm";
            this.Text = "Gerenciamento de Produtos";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            tabControlProduct.ResumeLayout(false);
            this.providerTabPage.ResumeLayout(false);
            this.providerTabPage.PerformLayout();
            this.listLabel.ResumeLayout(false);
            this.listLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label providerLabel;
        private System.Windows.Forms.Label labelCnpj;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TabPage listLabel;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtQtAvaiable;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.TabPage providerTabPage;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label IdLabel;
    }
}