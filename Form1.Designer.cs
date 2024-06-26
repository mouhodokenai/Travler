namespace WinFormsApp3
{
    partial class Welcome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            label1 = new Label();
            ButPlans = new Button();
            ButTrips = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Comfortaa", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(164, 50);
            label1.Name = "label1";
            label1.Size = new Size(705, 97);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать!";
            // 
            // ButPlans
            // 
            ButPlans.BackColor = Color.Coral;
            ButPlans.Font = new Font("Comfortaa", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButPlans.ForeColor = Color.Sienna;
            ButPlans.Image = (Image)resources.GetObject("ButPlans.Image");
            ButPlans.Location = new Point(-6, 372);
            ButPlans.Name = "ButPlans";
            ButPlans.Size = new Size(1016, 169);
            ButPlans.TabIndex = 2;
            ButPlans.Text = "Я планирую...";
            ButPlans.UseVisualStyleBackColor = false;
            ButPlans.Click += ButPlans_Click;
            // 
            // ButTrips
            // 
            ButTrips.Font = new Font("Comfortaa", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButTrips.ForeColor = Color.Sienna;
            ButTrips.Image = (Image)resources.GetObject("ButTrips.Image");
            ButTrips.Location = new Point(-6, 536);
            ButTrips.Name = "ButTrips";
            ButTrips.Size = new Size(1016, 177);
            ButTrips.TabIndex = 3;
            ButTrips.Text = "Я уже был...";
            ButTrips.UseVisualStyleBackColor = true;
            ButTrips.Click += ButTrips_Click;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSalmon;
            BackgroundImage = Properties.Resources._1613297731_126_p_sinii_fon_gori_215__1_;
            ClientSize = new Size(1004, 707);
            Controls.Add(ButTrips);
            Controls.Add(ButPlans);
            Controls.Add(label1);
            ForeColor = Color.Cornsilk;
            Name = "Welcome";
            Text = "Добро пожаловать";
            Load += Welcome_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ButPlans;
        private Button ButTrips;
    }
}
