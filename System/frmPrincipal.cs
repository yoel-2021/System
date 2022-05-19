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
    }
}
