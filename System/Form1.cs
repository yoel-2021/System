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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        //Action of botton Register
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.User = txtUser.Text;
            user.Password = txtPassword.Text;
            user.ConPassword = txtConPasword.Text;
            user.Name = txtName.Text;

            try { 
            Controller controller = new Controller();
            string response = controller.ctrlRegister(user);

            if (response.Length > 0)
            {
                MessageBox.Show(response, "Warning",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User exits yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }catch(Exception ex) 
            { MessageBox.Show(ex.Message); 
            }
            txtUser.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtConPasword.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmRegister.ActiveForm.Hide();
            frmLogin login = new frmLogin();

            login.Show();
            
        }
    }
}
