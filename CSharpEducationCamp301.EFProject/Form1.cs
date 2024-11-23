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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EducationCampEfTravelDbEntities db = new EducationCampEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide gui = new Guide();
            gui.GuiName = txtName.Text;
            gui.GuiSurname = txtSurname.Text;
            db.Guide.Add(gui);
            db.SaveChanges();
            MessageBox.Show("Guide added successfully !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var valueRemove = db.Guide.Find(id);
            db.Guide.Remove(valueRemove);
            db.SaveChanges();
            MessageBox.Show("Guide deleted successfully !!!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var valueUpdate= db.Guide.Find(id);
            valueUpdate.GuiName = txtName.Text;
            valueUpdate.GuiSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Guide updated successfully !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = db.Guide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = value;
        }
    }
}
