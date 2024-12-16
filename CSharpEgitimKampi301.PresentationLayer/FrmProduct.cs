using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
	public partial class FrmProduct : Form
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public FrmProduct()
		{
			_productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
		}
        private void FrmProduct_Load(object sender, EventArgs e)
        {
			var value = _categoryService.TGetAll();
			cmbProductCategory.DisplayMember = "CategoryName";
			cmbProductCategory.ValueMember = "CategoryId";
			cmbProductCategory.DataSource = value;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
			Product product = new Product();
			product.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
			product.ProductName = txtProductName.Text;
			product.ProductDescription = txtProductDescription.Text;
			product.ProductPrice = decimal.Parse(txtProductPrice.Text);
			product.ProductStock = int.Parse(txtProductStock.Text);
			_productService.TInsert(product);
			MessageBox.Show("Ürün eklendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            var productList = new List<Product> { values };
            dataGridView1.DataSource = productList;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
            value.ProductName = txtProductName.Text;
            value.ProductDescription = txtProductDescription.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            _productService.TUpdate(value);
            MessageBox.Show("Ürün Güncellendi");
        }
    }
}