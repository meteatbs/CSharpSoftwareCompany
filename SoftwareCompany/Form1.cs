using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//datareader,data adeptar
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//for sql adapter
//using SoftwareCompany.SoftwareCompany_HOME_MDI;

namespace SoftwareCompany
{
   
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Library;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = "";
            this.txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == "")
            {
                MessageBox.Show("The username cannot be unfilled");
            }
            if (this.txtPassword.Text.Length==0)
            {
                MessageBox.Show("Please enter password");
            }
            if (this.txtUsername.Text == "" || this.txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Username or Password is empty");
            }
            string uname = txtUsername.Text.ToString();
            string pass = txtPassword.Text.ToString();
            sqlCon.Open();
            string qry = "select username,password from RegUser where username ='"+uname+"' and password='"+pass+"'";
            SqlDataAdapter sda = new SqlDataAdapter(qry,sqlCon);
            DataTable dt = new DataTable();
            
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Valid Employee " + uname);
                this.Hide();
                SoftwareCompany_HOME_MDI obj1 = new SoftwareCompany_HOME_MDI();
                obj1.Show();
            }
            else
                MessageBox.Show("Invalid Employee " + uname);
            sqlCon.Close();
            btnReset_Click(sender, e);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();
        }
    }
}
