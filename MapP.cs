using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using WinFormsApp3;

namespace WindowsFormsApp
{
    public partial class MapP : Form
    {
        private GMapControl gMapControl1;
        private DatabaseManager dbManager;
        private bool isPlan;

        public MapP(bool isPlan)
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            InitializeGMap();
            AddCityMarkers();
            this.isPlan = isPlan;
        }

        private void InitializeGMap()
        {
            gMapControl1 = new GMapControl();
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(0, 0);
            gMapControl1.Zoom = 2;

            Controls.Add(gMapControl1);
        }

        private void AddCityMarkers()
        {
            Dictionary<string, PointLatLng> citiesWithCoordinates = dbManager.GetCitiesWithCoordinates(isPlan);

            foreach (var city in citiesWithCoordinates)
            {
                AddCityMarker(city.Value, city.Key);
            }
        }

        private void AddCityMarker(PointLatLng location, string cityName)
        {
            GMarkerGoogle cityMarker = new GMarkerGoogle(location, GMarkerGoogleType.blue);
            cityMarker.ToolTipText = cityName; // Устанавливаем текст подсказки
            cityMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; // Устанавливаем режим отображения подсказки

            GMapOverlay markersOverlay = new GMapOverlay("markersOverlay");
            markersOverlay.Markers.Add(cityMarker);

            // Добавляем маркер на карту
            gMapControl1.Overlays.Add(markersOverlay);
        }

        private void MapP_Load(object sender, EventArgs e)
        {

        }
    }
}
