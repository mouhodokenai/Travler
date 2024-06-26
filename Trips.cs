using System;
using System.Windows.Forms;
using System.Collections.Generic;
using WindowsFormsApp;

namespace WinFormsApp3
{
    public partial class Trips : Form
    {
        private DatabaseManager dbManager = new DatabaseManager();
        public Welcome form;

        public Trips(Welcome form)
        {
            InitializeComponent();
            LoadTrips();
            InitializeListView();
            this.form = form;
        }

        public Trips()
        {
            InitializeComponent();
            LoadTrips();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // Настройка ListView
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // Добавление столбцов
            listView1.Columns.Add("Дата", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Страна", 155, HorizontalAlignment.Left);
            listView1.Columns.Add("Город", 155, HorizontalAlignment.Left);
            listView1.Columns.Add("Достопимечательность", 220, HorizontalAlignment.Left);
            listView1.Columns.Add("Примечание", 220, HorizontalAlignment.Left);

            // Добавление обработчика событий
            //listView1.ItemActivate += new EventHandler(ListView1_ItemActivate);
            // Добавление обработчика событий
            listView1.MouseDoubleClick += new MouseEventHandler(ListView1_MouseDoubleClick);
        }
        private void LoadTrips()
        {
            label1.Text = dbManager.GetTripsStat();
            List<Trip> trips = dbManager.GetTrips();

            foreach (var trip in trips)
            {
                ListViewItem item = new ListViewItem(trip.TripDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(trip.Country);
                item.SubItems.Add(trip.City);
                item.SubItems.Add(trip.Landmark);
                item.SubItems.Add(trip.Note);

                // Создаем кортеж из объекта trip и его id
                var tripInfo = new Tuple<Trip, int>(trip, trip.Id);

                // Сохраняем кортеж в Tag
                item.Tag = tripInfo;

                listView1.Items.Add(item);
            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            Add add = new Add(this, form);

            // Показываем форму немодально
            add.Show();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            MapP map = new MapP(false);
            map.Show();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    var hitTest = listView1.HitTest(e.Location);
                    if (hitTest.Item != null)
                    {
                        var tripInfo = (Tuple<Trip, int>)hitTest.Item.Tag; // Извлекаем кортеж из Tag
                        int id = tripInfo.Item2; // Получаем id из кортежа
                        Trip trip = tripInfo.Item1; // Получаем объект Trip из кортежа
                        Add add = new Add(trip, id, this, form);

                        // Показываем форму немодально
                        add.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            form.Visible = true;
            Visible = false;
            Close();
        }

        private void Trips_Load(object sender, EventArgs e)
        {

        }
    }
}


