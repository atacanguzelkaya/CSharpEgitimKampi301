using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using System;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
	public partial class FrmProduct : Form
	{
		private readonly IProductService _productService;

		public FrmProduct()
		{
			_productService = new ProductManager(new EfProductDal());
			InitializeComponent();
		}

		private void btnList_Click(object sender, EventArgs e)
		{
			var productValues = _productService.TGetAll();
			dataGridView1.DataSource = productValues;
		}

		private void btnListWithCategory_Click(object sender, EventArgs e)
		{
			var productValues = _productService.TGetProductsWithCategory();
			dataGridView1.DataSource = productValues;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int productId = int.Parse(txtProductId.Text);
			var deletedValues = _productService.TGetById(productId);
			_productService.TDelete(deletedValues);
			MessageBox.Show("Ürün silindi.");
		}	
	}
}