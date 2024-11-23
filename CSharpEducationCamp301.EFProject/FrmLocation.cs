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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EducationCampEfTravelDbEntities db = new EducationCampEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                Fullname = x.GuiName + " " + x.GuiSurname,
                x.GuideId
            }).ToList();

            cmbGuide.DisplayMember = "Fullname";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location
            {
                LocCity = txtCity.Text,
                LocCountry = txtCountry.Text,
                LocCapacity = Convert.ToByte(nudCapacity.Value),
                LocPrice = Convert.ToDecimal(txtPrice.Text),
                DayNight = txtDayNight.Text,
                GuideId = Convert.ToInt32(cmbGuide.SelectedValue)
            };

            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Location successfully added !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            db.Location.Remove(db.Location.Find(id));
            db.SaveChanges();
            MessageBox.Show("Location successfully deleted !!!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Location udLocation = db.Location.Find(Convert.ToInt32(txtId.Text));
            udLocation.LocCity = txtCity.Text;
            udLocation.LocCountry = txtCountry.Text;
            udLocation.LocCapacity = Convert.ToByte(nudCapacity.Value);
            udLocation.LocPrice = Convert.ToDecimal(txtPrice.Text);
            udLocation.DayNight = txtDayNight.Text;
            udLocation.GuideId = Convert.ToInt32(cmbGuide.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Location successfully updated !!");
        }
    }
}
