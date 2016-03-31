namespace dostavka
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Comment = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cafe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Dish = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_Countryside = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Status1 = new System.Windows.Forms.Button();
            this.button_Status2 = new System.Windows.Forms.Button();
            this.button_Status3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_DriverMoney = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label_PK = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_Discount = new System.Windows.Forms.Label();
            this.comboBox_Client = new System.Windows.Forms.ComboBox();
            this.comboBox_Driver = new System.Windows.Forms.ComboBox();
            this.label_Part = new System.Windows.Forms.Label();
            this.label_Sum = new System.Windows.Forms.Label();
            this.button_AddLine = new System.Windows.Forms.Button();
            this.button_RemoveLines = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.labelClientMoney = new System.Windows.Forms.Label();
            this.labelDostavka = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePickerReg = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата и время доставки:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Комментарий:";
            // 
            // textBox_Comment
            // 
            this.textBox_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Comment.Location = new System.Drawing.Point(138, 545);
            this.textBox_Comment.Name = "textBox_Comment";
            this.textBox_Comment.Size = new System.Drawing.Size(540, 20);
            this.textBox_Comment.TabIndex = 3;
            this.textBox_Comment.TextChanged += new System.EventHandler(this.textBox_Comment_TextChanged);
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
            this.Column_Tag,
            this.Column_Cafe,
            this.Column_Dish,
            this.Column_Price,
            this.Column_Amount,
            this.Column_Cost});
            this.dataGridView1.Location = new System.Drawing.Point(35, 233);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(654, 169);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // Column_Tag
            // 
            this.Column_Tag.HeaderText = "Tag";
            this.Column_Tag.Name = "Column_Tag";
            this.Column_Tag.Visible = false;
            // 
            // Column_Cafe
            // 
            this.Column_Cafe.HeaderText = "Кафе";
            this.Column_Cafe.Name = "Column_Cafe";
            // 
            // Column_Dish
            // 
            this.Column_Dish.HeaderText = "Название блюда";
            this.Column_Dish.Name = "Column_Dish";
            // 
            // Column_Price
            // 
            this.Column_Price.HeaderText = "Цена за ед.";
            this.Column_Price.Name = "Column_Price";
            this.Column_Price.ReadOnly = true;
            // 
            // Column_Amount
            // 
            this.Column_Amount.HeaderText = "Кол-во";
            this.Column_Amount.Name = "Column_Amount";
            this.Column_Amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Cost
            // 
            this.Column_Cost.HeaderText = "Стоимость";
            this.Column_Cost.Name = "Column_Cost";
            this.Column_Cost.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список блюд:";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Address.Location = new System.Drawing.Point(138, 502);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(448, 20);
            this.textBox_Address.TabIndex = 7;
            this.textBox_Address.TextChanged += new System.EventHandler(this.textBox_Address_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Адрес доставки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 8;
            // 
            // checkBox_Countryside
            // 
            this.checkBox_Countryside.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Countryside.AutoSize = true;
            this.checkBox_Countryside.Location = new System.Drawing.Point(593, 505);
            this.checkBox_Countryside.Name = "checkBox_Countryside";
            this.checkBox_Countryside.Size = new System.Drawing.Size(85, 17);
            this.checkBox_Countryside.TabIndex = 9;
            this.checkBox_Countryside.Text = "За городом";
            this.checkBox_Countryside.UseVisualStyleBackColor = true;
            this.checkBox_Countryside.CheckedChanged += new System.EventHandler(this.checkBox_Countryside_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Деньги для кафе:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Доля фирмы:";
            // 
            // button_Status1
            // 
            this.button_Status1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Status1.Location = new System.Drawing.Point(423, 36);
            this.button_Status1.Name = "button_Status1";
            this.button_Status1.Size = new System.Drawing.Size(127, 23);
            this.button_Status1.TabIndex = 16;
            this.button_Status1.Text = "начать выполнение";
            this.button_Status1.UseVisualStyleBackColor = true;
            this.button_Status1.Click += new System.EventHandler(this.button_Status1_Click);
            // 
            // button_Status2
            // 
            this.button_Status2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Status2.Location = new System.Drawing.Point(560, 36);
            this.button_Status2.Name = "button_Status2";
            this.button_Status2.Size = new System.Drawing.Size(118, 23);
            this.button_Status2.TabIndex = 17;
            this.button_Status2.Text = "отменить заказ";
            this.button_Status2.UseVisualStyleBackColor = true;
            this.button_Status2.Click += new System.EventHandler(this.button_Status2_Click);
            // 
            // button_Status3
            // 
            this.button_Status3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Status3.Location = new System.Drawing.Point(560, 36);
            this.button_Status3.Name = "button_Status3";
            this.button_Status3.Size = new System.Drawing.Size(118, 23);
            this.button_Status3.TabIndex = 18;
            this.button_Status3.Text = "завершить";
            this.button_Status3.UseVisualStyleBackColor = true;
            this.button_Status3.Click += new System.EventHandler(this.button_Status3_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(374, 582);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "сохранить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(529, 582);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(149, 23);
            this.button7.TabIndex = 20;
            this.button7.Text = "отмена";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(168, 84);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker2.TabIndex = 21;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(26, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Заказ №:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(529, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Статус:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Деньги от водителя:";
            // 
            // textBox_DriverMoney
            // 
            this.textBox_DriverMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_DriverMoney.Location = new System.Drawing.Point(357, 456);
            this.textBox_DriverMoney.Name = "textBox_DriverMoney";
            this.textBox_DriverMoney.Size = new System.Drawing.Size(100, 20);
            this.textBox_DriverMoney.TabIndex = 25;
            this.textBox_DriverMoney.Text = "0.00";
            this.textBox_DriverMoney.Leave += new System.EventHandler(this.textBox_DriverMoney_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Клиент:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Водитель:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "добавить нового";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Скидка:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label_PK
            // 
            this.label_PK.AutoSize = true;
            this.label_PK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_PK.Location = new System.Drawing.Point(96, 13);
            this.label_PK.Name = "label_PK";
            this.label_PK.Size = new System.Drawing.Size(28, 17);
            this.label_PK.TabIndex = 34;
            this.label_PK.Text = "----";
            // 
            // label_Status
            // 
            this.label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status.Location = new System.Drawing.Point(592, 13);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(86, 17);
            this.label_Status.TabIndex = 35;
            this.label_Status.Text = "label_Status";
            // 
            // label_Discount
            // 
            this.label_Discount.AutoSize = true;
            this.label_Discount.Location = new System.Drawing.Point(116, 144);
            this.label_Discount.Name = "label_Discount";
            this.label_Discount.Size = new System.Drawing.Size(21, 13);
            this.label_Discount.TabIndex = 36;
            this.label_Discount.Text = "0%";
            // 
            // comboBox_Client
            // 
            this.comboBox_Client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Client.FormattingEnabled = true;
            this.comboBox_Client.Location = new System.Drawing.Point(119, 119);
            this.comboBox_Client.Name = "comboBox_Client";
            this.comboBox_Client.Size = new System.Drawing.Size(282, 21);
            this.comboBox_Client.TabIndex = 37;
            this.comboBox_Client.SelectedIndexChanged += new System.EventHandler(this.comboBox_Client_SelectedIndexChanged);
            // 
            // comboBox_Driver
            // 
            this.comboBox_Driver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Driver.FormattingEnabled = true;
            this.comboBox_Driver.Location = new System.Drawing.Point(119, 170);
            this.comboBox_Driver.Name = "comboBox_Driver";
            this.comboBox_Driver.Size = new System.Drawing.Size(282, 21);
            this.comboBox_Driver.TabIndex = 38;
            this.comboBox_Driver.SelectedIndexChanged += new System.EventHandler(this.comboBox_Driver_SelectedIndexChanged);
            // 
            // label_Part
            // 
            this.label_Part.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Part.AutoSize = true;
            this.label_Part.Location = new System.Drawing.Point(354, 427);
            this.label_Part.Name = "label_Part";
            this.label_Part.Size = new System.Drawing.Size(28, 13);
            this.label_Part.TabIndex = 39;
            this.label_Part.Text = "0.00";
            // 
            // label_Sum
            // 
            this.label_Sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Sum.AutoSize = true;
            this.label_Sum.Location = new System.Drawing.Point(135, 427);
            this.label_Sum.Name = "label_Sum";
            this.label_Sum.Size = new System.Drawing.Size(28, 13);
            this.label_Sum.TabIndex = 40;
            this.label_Sum.Text = "0.00";
            // 
            // button_AddLine
            // 
            this.button_AddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddLine.Location = new System.Drawing.Point(532, 204);
            this.button_AddLine.Name = "button_AddLine";
            this.button_AddLine.Size = new System.Drawing.Size(75, 23);
            this.button_AddLine.TabIndex = 41;
            this.button_AddLine.Text = "добавить";
            this.button_AddLine.UseVisualStyleBackColor = true;
            this.button_AddLine.Click += new System.EventHandler(this.button_AddLine_Click);
            // 
            // button_RemoveLines
            // 
            this.button_RemoveLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RemoveLines.Location = new System.Drawing.Point(614, 204);
            this.button_RemoveLines.Name = "button_RemoveLines";
            this.button_RemoveLines.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveLines.TabIndex = 42;
            this.button_RemoveLines.Text = "удалить";
            this.button_RemoveLines.UseVisualStyleBackColor = true;
            this.button_RemoveLines.Click += new System.EventHandler(this.button_RemoveLines_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 463);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Деньги с клиента:";
            // 
            // labelClientMoney
            // 
            this.labelClientMoney.AutoSize = true;
            this.labelClientMoney.Location = new System.Drawing.Point(136, 463);
            this.labelClientMoney.Name = "labelClientMoney";
            this.labelClientMoney.Size = new System.Drawing.Size(28, 13);
            this.labelClientMoney.TabIndex = 44;
            this.labelClientMoney.Text = "0.00";
            // 
            // labelDostavka
            // 
            this.labelDostavka.AutoSize = true;
            this.labelDostavka.Location = new System.Drawing.Point(136, 444);
            this.labelDostavka.Name = "labelDostavka";
            this.labelDostavka.Size = new System.Drawing.Size(28, 13);
            this.labelDostavka.TabIndex = 46;
            this.labelDostavka.Text = "0.00";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 444);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Доставка:";
            // 
            // dateTimePickerReg
            // 
            this.dateTimePickerReg.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerReg.Enabled = false;
            this.dateTimePickerReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReg.Location = new System.Drawing.Point(168, 58);
            this.dateTimePickerReg.Name = "dateTimePickerReg";
            this.dateTimePickerReg.Size = new System.Drawing.Size(233, 20);
            this.dateTimePickerReg.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "Заказ принят: ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 617);
            this.Controls.Add(this.dateTimePickerReg);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelDostavka);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labelClientMoney);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button_RemoveLines);
            this.Controls.Add(this.button_AddLine);
            this.Controls.Add(this.label_Sum);
            this.Controls.Add(this.label_Part);
            this.Controls.Add(this.comboBox_Driver);
            this.Controls.Add(this.comboBox_Client);
            this.Controls.Add(this.label_Discount);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_PK);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_DriverMoney);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button_Status3);
            this.Controls.Add(this.button_Status2);
            this.Controls.Add(this.button_Status1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_Countryside);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_Comment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(543, 545);
            this.Name = "Form2";
            this.Text = "Заказ на доставку";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Comment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_Countryside;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Status1;
        private System.Windows.Forms.Button button_Status2;
        private System.Windows.Forms.Button button_Status3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_DriverMoney;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_PK;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_Discount;
        private System.Windows.Forms.ComboBox comboBox_Client;
        private System.Windows.Forms.ComboBox comboBox_Driver;
        private System.Windows.Forms.Label label_Part;
        private System.Windows.Forms.Label label_Sum;
        private System.Windows.Forms.Button button_AddLine;
        private System.Windows.Forms.Button button_RemoveLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Tag;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Cafe;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Dish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelClientMoney;
        private System.Windows.Forms.Label labelDostavka;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePickerReg;
        private System.Windows.Forms.Label label15;
    }
}