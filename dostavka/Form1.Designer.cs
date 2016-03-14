namespace dostavka
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Column_PK_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DriverMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_PK_Order,
            this.Column_DateTime,
            this.Column_Address,
            this.Column_ClientPhone,
            this.Column_Driver,
            this.Column_Status,
            this.Column_Sum,
            this.Column_Part,
            this.Column_DriverMoney});
            this.dataGridView1.Location = new System.Drawing.Point(29, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(939, 324);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Показать заказы:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Все",
            "В ожидании",
            "Выполяемые",
            "Отмененные",
            "Выполненные"});
            this.comboBox2.Location = new System.Drawing.Point(132, 30);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(843, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column_PK_Order
            // 
            this.Column_PK_Order.HeaderText = "Номер заказа";
            this.Column_PK_Order.Name = "Column_PK_Order";
            this.Column_PK_Order.ReadOnly = true;
            // 
            // Column_DateTime
            // 
            this.Column_DateTime.HeaderText = "Дата и время";
            this.Column_DateTime.Name = "Column_DateTime";
            this.Column_DateTime.ReadOnly = true;
            // 
            // Column_Address
            // 
            this.Column_Address.HeaderText = "Адрес доставки";
            this.Column_Address.Name = "Column_Address";
            this.Column_Address.ReadOnly = true;
            // 
            // Column_ClientPhone
            // 
            this.Column_ClientPhone.HeaderText = "Телефон клиента";
            this.Column_ClientPhone.Name = "Column_ClientPhone";
            this.Column_ClientPhone.ReadOnly = true;
            // 
            // Column_Driver
            // 
            this.Column_Driver.HeaderText = "Водитель";
            this.Column_Driver.Name = "Column_Driver";
            this.Column_Driver.ReadOnly = true;
            // 
            // Column_Status
            // 
            this.Column_Status.HeaderText = "Статус";
            this.Column_Status.Name = "Column_Status";
            this.Column_Status.ReadOnly = true;
            // 
            // Column_Sum
            // 
            this.Column_Sum.HeaderText = "Сумма";
            this.Column_Sum.Name = "Column_Sum";
            this.Column_Sum.ReadOnly = true;
            // 
            // Column_Part
            // 
            this.Column_Part.HeaderText = "Доля фирмы";
            this.Column_Part.Name = "Column_Part";
            this.Column_Part.ReadOnly = true;
            // 
            // Column_DriverMoney
            // 
            this.Column_DriverMoney.HeaderText = "Деньги от водителя";
            this.Column_DriverMoney.Name = "Column_DriverMoney";
            this.Column_DriverMoney.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(452, 186);
            this.Name = "Form1";
            this.Text = "Список заказов";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PK_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DriverMoney;
    }
}

