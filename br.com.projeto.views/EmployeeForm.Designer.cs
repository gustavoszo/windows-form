namespace Projeto_de_Vendas.br.com.projeto.views
{
    partial class EmployeeForm
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
            System.Windows.Forms.TabControl tabControlEmployee;
            this.clientTabPage = new System.Windows.Forms.TabPage();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.txtAddressNumber = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.listLabel = new System.Windows.Forms.TabPage();
            this.table = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            tabControlEmployee = new System.Windows.Forms.TabControl();
            tabControlEmployee.SuspendLayout();
            this.clientTabPage.SuspendLayout();
            this.listLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEmployee
            // 
            tabControlEmployee.Controls.Add(this.clientTabPage);
            tabControlEmployee.Controls.Add(this.listLabel);
            tabControlEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabControlEmployee.ItemSize = new System.Drawing.Size(127, 25);
            tabControlEmployee.Location = new System.Drawing.Point(12, 119);
            tabControlEmployee.Name = "tabControlEmployee";
            tabControlEmployee.SelectedIndex = 0;
            tabControlEmployee.Size = new System.Drawing.Size(846, 271);
            tabControlEmployee.TabIndex = 2;
            // 
            // clientTabPage
            // 
            this.clientTabPage.Controls.Add(this.comboBoxPosition);
            this.clientTabPage.Controls.Add(this.labelPosition);
            this.clientTabPage.Controls.Add(this.txtPassword);
            this.clientTabPage.Controls.Add(this.labelPassword);
            this.clientTabPage.Controls.Add(this.txtCpf);
            this.clientTabPage.Controls.Add(this.comboBoxState);
            this.clientTabPage.Controls.Add(this.stateLabel);
            this.clientTabPage.Controls.Add(this.txtCity);
            this.clientTabPage.Controls.Add(this.cityLabel);
            this.clientTabPage.Controls.Add(this.txtAddressNumber);
            this.clientTabPage.Controls.Add(this.numberLabel);
            this.clientTabPage.Controls.Add(this.txtAddress);
            this.clientTabPage.Controls.Add(this.addressLabel);
            this.clientTabPage.Controls.Add(this.txtPhone);
            this.clientTabPage.Controls.Add(this.phoneLabel);
            this.clientTabPage.Controls.Add(this.label2);
            this.clientTabPage.Controls.Add(this.txtEmail);
            this.clientTabPage.Controls.Add(this.emailLabel);
            this.clientTabPage.Controls.Add(this.txtName);
            this.clientTabPage.Controls.Add(this.nameLabel);
            this.clientTabPage.Location = new System.Drawing.Point(4, 29);
            this.clientTabPage.Name = "clientTabPage";
            this.clientTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clientTabPage.Size = new System.Drawing.Size(838, 238);
            this.clientTabPage.TabIndex = 0;
            this.clientTabPage.Text = "Dados Pessoais";
            this.clientTabPage.UseVisualStyleBackColor = true;
            this.clientTabPage.Click += new System.EventHandler(this.clientTabPage_Click);
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Items.AddRange(new object[] {
            "Gerente",
            "Estagiário",
            "Financeiro",
            "Administrativo",
            "Desenvolvedor",
            "Marketing",
            "Recrutamento"});
            this.comboBoxPosition.Location = new System.Drawing.Point(85, 112);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(85, 28);
            this.comboBoxPosition.TabIndex = 20;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelPosition.Location = new System.Drawing.Point(22, 115);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(56, 20);
            this.labelPosition.TabIndex = 19;
            this.labelPosition.Text = "Cargo:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(457, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(145, 26);
            this.txtPassword.TabIndex = 18;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelPassword.Location = new System.Drawing.Point(391, 76);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(60, 20);
            this.labelPassword.TabIndex = 17;
            this.labelPassword.Text = "Senha:";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(441, 25);
            this.txtCpf.Mask = "###,###,###-##";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(151, 26);
            this.txtCpf.TabIndex = 16;
            this.txtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // comboBoxState
            // 
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
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
            this.comboBoxState.Location = new System.Drawing.Point(471, 199);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(85, 28);
            this.comboBoxState.TabIndex = 15;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.stateLabel.Location = new System.Drawing.Point(401, 202);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(64, 20);
            this.stateLabel.TabIndex = 14;
            this.stateLabel.Text = "Estado:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(89, 196);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(279, 26);
            this.txtCity.TabIndex = 13;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cityLabel.Location = new System.Drawing.Point(16, 199);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(67, 20);
            this.cityLabel.TabIndex = 12;
            this.cityLabel.Text = "Cidade: ";
            // 
            // txtAddressNumber
            // 
            this.txtAddressNumber.Location = new System.Drawing.Point(487, 155);
            this.txtAddressNumber.Name = "txtAddressNumber";
            this.txtAddressNumber.Size = new System.Drawing.Size(73, 26);
            this.txtAddressNumber.TabIndex = 11;
            this.txtAddressNumber.TextChanged += new System.EventHandler(this.txtAddressNumber_TextChanged);
            this.txtAddressNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddressNumber_KeyPress);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.numberLabel.Location = new System.Drawing.Point(412, 158);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(69, 20);
            this.numberLabel.TabIndex = 10;
            this.numberLabel.Text = "Número:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 155);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(279, 26);
            this.txtAddress.TabIndex = 9;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addressLabel.Location = new System.Drawing.Point(16, 158);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(82, 20);
            this.addressLabel.TabIndex = 8;
            this.addressLabel.Text = "Endereço:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(674, 25);
            this.txtPhone.Mask = "(99) 00000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(151, 26);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.phoneLabel.Location = new System.Drawing.Point(612, 28);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(62, 20);
            this.phoneLabel.TabIndex = 6;
            this.phoneLabel.Text = "Celular:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(391, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "CPF:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(85, 73);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(279, 26);
            this.txtEmail.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.emailLabel.Location = new System.Drawing.Point(22, 76);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(57, 20);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "E-mail:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 26);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nameLabel.Location = new System.Drawing.Point(24, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Nome:";
            // 
            // listLabel
            // 
            this.listLabel.Controls.Add(this.table);
            this.listLabel.Controls.Add(this.txtSearch);
            this.listLabel.Controls.Add(this.labelSearch);
            this.listLabel.Location = new System.Drawing.Point(4, 29);
            this.listLabel.Name = "listLabel";
            this.listLabel.Padding = new System.Windows.Forms.Padding(3);
            this.listLabel.Size = new System.Drawing.Size(838, 238);
            this.listLabel.TabIndex = 1;
            this.listLabel.Text = "Consulta";
            this.listLabel.UseVisualStyleBackColor = true;
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(28, 61);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(775, 150);
            this.table.TabIndex = 4;
            this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
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
            this.panel1.Size = new System.Drawing.Size(864, 100);
            this.panel1.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(39, 41);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(248, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Cadastro de Funcionario";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDelete.Location = new System.Drawing.Point(432, 405);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 33);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClean.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClean.Location = new System.Drawing.Point(301, 405);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(104, 33);
            this.btnClean.TabIndex = 8;
            this.btnClean.Text = "Limpar";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSave.Location = new System.Drawing.Point(166, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancel.Location = new System.Drawing.Point(556, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(tabControlEmployee);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeForm";
            this.Text = "Gerenciamento de Funcionários";
            this.Load += new System.EventHandler(this.txtSearch_TextChanged);
            tabControlEmployee.ResumeLayout(false);
            this.clientTabPage.ResumeLayout(false);
            this.clientTabPage.PerformLayout();
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
        private System.Windows.Forms.TabPage clientTabPage;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox txtAddressNumber;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabPage listLabel;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btnCancel;
    }
}