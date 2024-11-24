using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
	public partial class FrmLocation : Form
	{
		public FrmLocation()
		{
			InitializeComponent();
		}
		EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
		private void FrmLocation_Load(object sender, EventArgs e)
		{
			var values = db.Guide.Select(x => new
			{
				FullName = x.Name + " " + x.Surname,
				x.GuideId
			}).ToList();
			cmbGuide.DisplayMember = "FullName";
			cmbGuide.ValueMember = "GuideId";
			cmbGuide.DataSource = values;
		}
		private void btnList_Click(object sender, EventArgs e)
		{
			var values = db.Location.ToList();
			dataGridView1.DataSource = values;
            dataGridView1.Columns["Guide"].Visible = false;
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Location location = new Location();
			location.City = txtCity.Text;
			location.Country = txtCountry.Text;
			location.Capacity = byte.Parse(nubCapacity.Value.ToString());
			location.Price = decimal.Parse(txtPrice.Text);
			location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
			location.DayNight = txtDayNight.Text;

			db.Location.Add(location);
			db.SaveChanges();
			MessageBox.Show("Lokasyon baraşıyla eklendi.");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtId.Text);
			var removeValue = db.Location.Find(id);
			db.Location.Remove(removeValue);
			db.SaveChanges();
			MessageBox.Show("Lokasyon baraşıyla silindi.");
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtId.Text);
			var updateValue = db.Location.Find(id);
			updateValue.City = txtCity.Text;
			updateValue.Country = txtCountry.Text;
			updateValue.Capacity = byte.Parse(nubCapacity.Value.ToString());
			updateValue.Price = decimal.Parse(txtPrice.Text);
			updateValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
			updateValue.DayNight = txtDayNight.Text;
			db.SaveChanges();
			MessageBox.Show("Lokasyon baraşıyla güncellendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}