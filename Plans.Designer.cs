namespace WinFormsApp3
{
    partial class Plans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plans));
            label1 = new Label();
            listView1 = new ListView();
            AddButton = new Button();
            MapButton = new Button();
            BackButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Comfortaa", 20F);
            label1.Location = new Point(72, 48);
            label1.Name = "label1";
            label1.Size = new Size(889, 55);
            label1.TabIndex = 1;
            label1.Text = "Вы планируете посетить 13 стран 54 города";
            // 
            // listView1
            // 
            listView1.BackgroundImage = (Image)resources.GetObject("listView1.BackgroundImage");
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(72, 161);
            listView1.Name = "listView1";
            listView1.Size = new Size(870, 430);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Comfortaa SemiBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddButton.Location = new Point(72, 615);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(260, 53);
            AddButton.TabIndex = 3;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // MapButton
            // 
            MapButton.Font = new Font("Comfortaa SemiBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MapButton.Location = new Point(377, 615);
            MapButton.Name = "MapButton";
            MapButton.Size = new Size(260, 53);
            MapButton.TabIndex = 6;
            MapButton.Text = "Карта";
            MapButton.UseVisualStyleBackColor = true;
            MapButton.Click += MapButton_Click;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Comfortaa SemiBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 204);
            BackButton.Location = new Point(683, 615);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(260, 53);
            BackButton.TabIndex = 7;
            BackButton.Text = "Назад";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // Plans
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1005, 707);
            Controls.Add(BackButton);
            Controls.Add(MapButton);
            Controls.Add(AddButton);
            Controls.Add(listView1);
            Controls.Add(label1);
            MaximumSize = new Size(1023, 754);
            MinimumSize = new Size(1023, 754);
            Name = "Plans";
            Text = "Планы";
            Load += Plans_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private Button AddButton;
        private Button MapButton;
        private Button BackButton;
    }
}