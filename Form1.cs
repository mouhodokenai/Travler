namespace WinFormsApp3
{
    public partial class Welcome : Form
    {
        
        public Welcome()
        {
            InitializeComponent();
        }

        private void ButPlans_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы (Plans)
            Plans plans = new Plans(this);

            // Показываем форму модально
            plans.Show();
            Hide();
        }

        private void ButTrips_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы (Trips)
            Trips trips = new Trips(this);

            // Показываем форму немодально
            trips.Show();
            Visible = false;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
