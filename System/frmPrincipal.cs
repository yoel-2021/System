using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            loadTable(null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string data = txtSearch.Text;
            loadTable(data);
        }
        private void loadTable(string data)
        {
            List<Products> list = new List<Products>();
            ProductsController productsController = new ProductsController();
            dataGridView1.DataSource = productsController.ask(data);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool correct = false;
            
            Products _products = new Products();

            _products.Code =txtCode.Text;
            _products.Name =txtName.Text;
            _products.Description =txtDescription.Text;
            _products.Public_price = double.Parse(txtPublicPrice.Text);
            _products.Stock = int.Parse(txtStock.Text);

            ProductsController productsController = new ProductsController();

            if(txtId.Text != "")
            {
                _products.Id = int.Parse(txtId.Text);
               correct = productsController.update(_products);
            }
            else
            {
                 correct = productsController.insert(_products);
            }

            if (correct)
            {
                MessageBox.Show("Register saved");

                clean();
                loadTable(null);
            }

        }

        private void clean()
        {
            txtId.Clear();
            txtCode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtPublicPrice.Clear();
            txtStock.Clear();
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPublicPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtStock.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool correct = false;
            DialogResult dialog = MessageBox.Show("Are you sure to delete this?","Exit", MessageBoxButtons.YesNoCancel);

            if (dialog == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ProductsController _productsController = new ProductsController();
                correct = _productsController.delete(id);
            }

            if (correct)
            {
                MessageBox.Show("Register deleted");

                clean();
                loadTable(null);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}
