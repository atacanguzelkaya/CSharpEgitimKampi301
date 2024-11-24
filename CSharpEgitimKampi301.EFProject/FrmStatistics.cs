using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = ((double)db.Location.Average(x => x.Capacity)).ToString("0.00");
            lblAvgLocationPrice.Text = ((double)db.Location.Average(x => x.Price)).ToString("0.00") + " ₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeAvgCapacity.Text = ((double)db.Location.Where(x => x.Country == "Türkiye").Average(x => x.Capacity)).ToString("0.00");

            var romeGuideId = db.Location.Where(x => x.City == "Roma Turu").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            var maxCapacity = db.Location.Max(y => y.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault();

            var maxPrice = db.Location.Max(y => y.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault();

            var guideIdByNameAtacanGuzelkaya = db.Guide.Where(x => x.Name == "Atacan" && x.Surname == "Güzelkaya").Select(y => y.GuideId).FirstOrDefault();
            lblAtacanGuzelkayaLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAtacanGuzelkaya).Count().ToString();
        }
    }
}