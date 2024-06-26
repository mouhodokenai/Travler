using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NLog;

namespace WinFormsApp3
{
    public partial class Add : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private DatabaseManager dbManager = new DatabaseManager();
        public Trip trip;
        public Form form;
        public int Id;
        Welcome welcome;

        public Add(Trip trip, int Id, Form form, Welcome welcome)
        {
            InitializeComponent();
            this.trip = trip;
            this.Id = Id;
            this.form = form;
            this.welcome = welcome;
            InitializeData();
        }

        public Add(Form form, Welcome welcome)
        {
            InitializeComponent();
            InitializeData();
            this.form = form;
            this.welcome = welcome;
        }

        private void InitializeData()
        {
            try
            {
                if (trip != null)
                {
                    label1.Text = "Редактировать путешествие";
                    comboCountry.Text = trip.Country;
                    comboCity.Text = trip.City;
                    if (trip.isPlan)
                    {
                        radioPlan.Checked = true;
                        radioTrip.Checked = false;
                    }
                    else
                    {
                        radioPlan.Checked = false;
                        radioTrip.Checked = true;
                    }
                    Landmark.Text = trip.Landmark;
                    Note.Text = trip.Note;
                    Date.Value = trip.TripDate;

                    DeleteButton.Visible = true;
                }
                else
                {
                    comboCountry.Items.Clear();
                    comboCity.Items.Clear();
                    if (form is Plans)
                    {
                        radioPlan.Checked = true;
                        radioTrip.Checked = false;
                    }
                    else
                    {
                        radioPlan.Checked = false;
                        radioTrip.Checked = true;
                    }

                    List<string> countries = dbManager.GetCountries();
                    if (countries.Count > 0)
                    {
                        comboCountry.Items.AddRange(countries.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("Не удалось загрузить страны из базы данных.");
                        Logger.Warn("Не удалось загрузить страны из базы данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ошибка при инициализации данных.");
                MessageBox.Show("Произошла ошибка при инициализации данных: " + ex.Message);
            }
        }

        private void comboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country_name = "Россия";
            if (comboCountry.SelectedItem != null)
            {
                try
                {
                    country_name = comboCountry.SelectedItem.ToString();
                    MessageBox.Show($"Страна выбрана: {country_name}");
                    Logger.Info($"Страна выбрана: {country_name}");

                    comboCity.Items.Clear();
                    List<string> cities = dbManager.GetCities(country_name);

                    if (cities.Count > 0)
                    {
                        comboCity.Items.AddRange(cities.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("Не удалось загрузить города из базы данных.");
                        Logger.Warn($"Не удалось загрузить города для страны: {country_name}");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Ошибка при загрузке городов.");
                    MessageBox.Show("Произошла ошибка при загрузке городов: " + ex.Message);
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string country = comboCountry.SelectedItem?.ToString();
            string city = comboCity.SelectedItem?.ToString();
            bool isPlan = radioPlan.Checked || !radioTrip.Checked;
            string landmark = Landmark.Text;
            string note = Note.Text;
            DateTime selectedDate = Date.Value;

            // Проверка обязательных полей
            if (string.IsNullOrEmpty(country))
            {
                MessageBox.Show("Пожалуйста, выберите страну.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Warn("Пользователь не выбрал страну.");
                return;
            }
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Пожалуйста, выберите город.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Warn("Пользователь не выбрал город.");
                return;
            }

            // Если все обязательные поля заполнены, продолжаем с добавлением или редактированием
            try
            {
                if (trip != null)
                {
                    dbManager.EditTrip(trip.Id, country, city, landmark, note, selectedDate, isPlan);
                    Logger.Info($"Путешествие отредактировано: {trip.Id}, {country}, {city}");
                }
                else
                {
                    dbManager.InsertTrip(country, city, landmark, note, selectedDate, isPlan);
                    Logger.Info($"Новое путешествие добавлено: {country}, {city}");
                }

                if (isPlan)
                {
                    Plans plan = new Plans(welcome);
                    plan.Show();
                }
                else
                {
                    Trips trip = new Trips(welcome);
                    trip.Show();
                }

                form.Close();
                Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ошибка при добавлении/редактировании путешествия.");
                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (trip != null)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить это путешествие?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dbManager.DeleteTrip(trip.Id); // Вызов метода удаления с использованием id путешествия
                        MessageBox.Show("Путешествие успешно удалено.");
                        Logger.Info($"Путешествие удалено: {trip.Id}");
                        this.Close(); // Закрыть форму после удаления
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Ошибка при удалении путешествия.");
                    MessageBox.Show("Произошла ошибка при удалении путешествия: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите путешествие для удаления.");
                Logger.Warn("Попытка удаления без выбора путешествия.");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            Logger.Info("Форма Add загружена.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Logger.Info("Label1 нажата.");
        }
    }
}


