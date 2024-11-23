using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEducationCamp301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EducationCampEfTravelDbEntities db = new EducationCampEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocation.Text = db.Location.Count().ToString();

            lblTotalCapacity.Text = db.Location.Sum(x => x.LocCapacity).ToString();

            lblGuide.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.LocCapacity).ToString();

            lblAvgPrice.Text = db.Location.Average(x => x.LocPrice)?.ToString("0.00") + " €";

            int lastLocId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastLocId).Select(y => y.LocCountry).FirstOrDefault();

            lblCappaCap.Text = db.Location.Where(x => x.LocCity == "Cappadocia")
                .FirstOrDefault().LocCapacity.ToString();

            lblAvgCapInTur.Text = db.Location.Where(x => x.LocCountry == "Turkiye")?.Average(y => y.LocCapacity)?.ToString("0.0");

            lblRomeGuide.Text = db.Location.Where(x => x.LocCity == "Rome").Select(x => x.Guide.GuiName + " " + x.Guide.GuiSurname).FirstOrDefault();

            lblLargestTour.Text = db.Location.OrderByDescending(x => x.LocCapacity).FirstOrDefault().LocCity;

            lblHighestTour.Text = db.Location.OrderByDescending(x => x.LocPrice).FirstOrDefault().LocCity;

            lblChrisNolanTour.Text = db.Location.Where(x => x.Guide.GuiName == "Chris" && x.Guide.GuiSurname == "Nolan").Count().ToString();
        }
    }
}