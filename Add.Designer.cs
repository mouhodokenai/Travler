namespace WinFormsApp3
{
    partial class Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            label1 = new Label();
            comboCountry = new ComboBox();
            comboCity = new ComboBox();
            radioPlan = new RadioButton();
            radioTrip = new RadioButton();
            Landmark = new TextBox();
            Date = new DateTimePicker();
            Note = new TextBox();
            AddButton = new Button();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Comfortaa", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(155, 53);
            label1.Name = "label1";
            label1.Size = new Size(578, 64);
            label1.TabIndex = 1;
            label1.Text = "Добавить путешествие";
            label1.Click += label1_Click;
            // 
            // comboCountry
            // 
            comboCountry.BackColor = Color.White;
            comboCountry.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboCountry.FormattingEnabled = true;
            comboCountry.Location = new Point(525, 180);
            comboCountry.MaximumSize = new Size(285, 0);
            comboCountry.Name = "comboCountry";
            comboCountry.Size = new Size(285, 61);
            comboCountry.TabIndex = 2;
            comboCountry.Text = "Страна";
            comboCountry.SelectedIndexChanged += comboCountry_SelectedIndexChanged;
            // 
            // comboCity
            // 
            comboCity.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboCity.FormattingEnabled = true;
            comboCity.Location = new Point(525, 261);
            comboCity.Name = "comboCity";
            comboCity.Size = new Size(285, 61);
            comboCity.TabIndex = 3;
            comboCity.Text = "Город";
            // 
            // radioPlan
            // 
            radioPlan.AutoSize = true;
            radioPlan.BackColor = Color.White;
            radioPlan.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioPlan.Location = new Point(155, 182);
            radioPlan.Name = "radioPlan";
            radioPlan.Size = new Size(285, 59);
            radioPlan.TabIndex = 4;
            radioPlan.TabStop = true;
            radioPlan.Text = "Я планирую...";
            radioPlan.UseVisualStyleBackColor = false;
            // 
            // radioTrip
            // 
            radioTrip.AutoSize = true;
            radioTrip.BackColor = Color.White;
            radioTrip.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioTrip.Location = new Point(155, 263);
            radioTrip.MaximumSize = new Size(500, 59);
            radioTrip.MinimumSize = new Size(285, 59);
            radioTrip.Name = "radioTrip";
            radioTrip.Size = new Size(285, 59);
            radioTrip.TabIndex = 5;
            radioTrip.TabStop = true;
            radioTrip.Text = "Я уже был...";
            radioTrip.UseVisualStyleBackColor = false;
            // 
            // Landmark
            // 
            Landmark.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Landmark.Location = new Point(155, 342);
            Landmark.MinimumSize = new Size(285, 59);
            Landmark.Name = "Landmark";
            Landmark.Size = new Size(655, 59);
            Landmark.TabIndex = 6;
            Landmark.Text = "Достопримечательность";
            // 
            // Date
            // 
            Date.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Date.Location = new Point(155, 505);
            Date.MaximumSize = new Size(500, 59);
            Date.MinimumSize = new Size(500, 59);
            Date.Name = "Date";
            Date.Size = new Size(500, 59);
            Date.TabIndex = 7;
            // 
            // Note
            // 
            Note.Font = new Font("Comfortaa", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Note.Location = new Point(155, 423);
            Note.MinimumSize = new Size(285, 59);
            Note.Name = "Note";
            Note.Size = new Size(655, 59);
            Note.TabIndex = 8;
            Note.Text = "Примечание";
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Comfortaa SemiBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddButton.Location = new Point(155, 611);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(285, 53);
            AddButton.TabIndex = 9;
            AddButton.Text = "Сохранить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Comfortaa SemiBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DeleteButton.Location = new Point(525, 611);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(285, 53);
            DeleteButton.TabIndex = 10;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1005, 707);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(Note);
            Controls.Add(Date);
            Controls.Add(Landmark);
            Controls.Add(radioTrip);
            Controls.Add(radioPlan);
            Controls.Add(comboCity);
            Controls.Add(comboCountry);
            Controls.Add(label1);
            MaximumSize = new Size(1023, 754);
            MinimumSize = new Size(1023, 754);
            Name = "Add";
            Text = "Добавление";
            Load += Add_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboCountry;
        private ComboBox comboCity;
        private RadioButton radioPlan;
        private RadioButton radioTrip;
        private TextBox Landmark;
        private DateTimePicker Date;
        private TextBox Note;
        private Button AddButton;
        private Button DeleteButton;
    }
}