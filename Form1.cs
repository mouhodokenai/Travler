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
            // ������� ��������� ����� ����� (Plans)
            Plans plans = new Plans(this);

            // ���������� ����� ��������
            plans.Show();
            Hide();
        }

        private void ButTrips_Click(object sender, EventArgs e)
        {
            // ������� ��������� ����� ����� (Trips)
            Trips trips = new Trips(this);

            // ���������� ����� ����������
            trips.Show();
            Visible = false;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
