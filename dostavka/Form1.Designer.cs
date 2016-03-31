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
            this.Column_PK_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DriverMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DispatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DispatcherProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DispatcherLogoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CafesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(29, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(930, 360);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
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
            this.comboBox2.Location = new System.Drawing.Point(132, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(836, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DispatcherToolStripMenuItem,
            this.ReferencesToolStripMenuItem,
            this.StatisticsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DispatcherToolStripMenuItem
            // 
            this.DispatcherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DispatcherProfileToolStripMenuItem,
            this.DispatcherLogoutToolStripMenuItem1});
            this.DispatcherToolStripMenuItem.Name = "DispatcherToolStripMenuItem";
            this.DispatcherToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.DispatcherToolStripMenuItem.Text = "Диспетчер";
            // 
            // DispatcherProfileToolStripMenuItem
            // 
            this.DispatcherProfileToolStripMenuItem.Name = "DispatcherProfileToolStripMenuItem";
            this.DispatcherProfileToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.DispatcherProfileToolStripMenuItem.Text = "Редактировать профиль";
            this.DispatcherProfileToolStripMenuItem.Click += new System.EventHandler(this.DispatcherProfileToolStripMenuItem_Click);
            // 
            // DispatcherLogoutToolStripMenuItem1
            // 
            this.DispatcherLogoutToolStripMenuItem1.Name = "DispatcherLogoutToolStripMenuItem1";
            this.DispatcherLogoutToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.DispatcherLogoutToolStripMenuItem1.Text = "Выход";
            this.DispatcherLogoutToolStripMenuItem1.Click += new System.EventHandler(this.DispatcherLogoutToolStripMenuItem1_Click);
            // 
            // ReferencesToolStripMenuItem
            // 
            this.ReferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DriversToolStripMenuItem,
            this.ClientsToolStripMenuItem,
            this.CafesToolStripMenuItem});
            this.ReferencesToolStripMenuItem.Name = "ReferencesToolStripMenuItem";
            this.ReferencesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.ReferencesToolStripMenuItem.Text = "Справочники";
            // 
            // DriversToolStripMenuItem
            // 
            this.DriversToolStripMenuItem.Name = "DriversToolStripMenuItem";
            this.DriversToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.DriversToolStripMenuItem.Text = "Водители";
            this.DriversToolStripMenuItem.Click += new System.EventHandler(this.DriversToolStripMenuItem_Click);
            // 
            // ClientsToolStripMenuItem
            // 
            this.ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            this.ClientsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ClientsToolStripMenuItem.Text = "Клиенты";
            this.ClientsToolStripMenuItem.Click += new System.EventHandler(this.ClientsToolStripMenuItem_Click);
            // 
            // CafesToolStripMenuItem
            // 
            this.CafesToolStripMenuItem.Name = "CafesToolStripMenuItem";
            this.CafesToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.CafesToolStripMenuItem.Text = "Кафе";
            this.CafesToolStripMenuItem.Click += new System.EventHandler(this.CafesToolStripMenuItem_Click);
            // 
            // StatisticsToolStripMenuItem
            // 
            this.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            this.StatisticsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.StatisticsToolStripMenuItem.Text = "Статистика";
            this.StatisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 440);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(452, 186);
            this.Name = "Form1";
            this.Text = "Список заказов";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DispatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DispatcherProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DispatcherLogoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CafesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatisticsToolStripMenuItem;
    }
}

