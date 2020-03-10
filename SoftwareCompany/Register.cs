using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SoftwareCompany
{
    public partial class Register : Form
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Library;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtRegiUid.Text = "";
            this.txtRegName.Text = "";
            cmbRegDesignation.SelectedItem = -1;
            cmbRegDepartment.SelectedItem = -1;
            this.txtRegMobile.Text = "";
            this.txtRegEmailId.Text = "";
            this.txtRegUsername.Text = "";
            this.txtRegPassword.Text = "";

        }

        private void btnRegisterLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 r = new Form1();
            r.Show();
        }

        private void btnRegisterRegister_Click(object sender, EventArgs e)
        {
            if (txtRegiUid.Text.Length != 0 || txtRegName.Text.Length != 0 || txtRegMobile.Text.Length != 0 || txtRegUsername.Text.Length != 0
                || txtRegPassword.Text.Length != 0 || txtRegEmailId.Text.Length != 0)
            {
                try
                {
                    string uid = txtRegiUid.Text;
                    string name = txtRegName.Text;
                    string desg = cmbRegDesignation.SelectedItem.ToString();
                    string dept = cmbRegDepartment.SelectedItem.ToString();
                    long mobile = Int64.Parse(txtRegMobile.Text);
                    string email = txtRegEmailId.Text;
                    string username = txtRegUsername.Text;
                    string password = txtRegPassword.Text;
                    sqlCon.Open();
                    string qry = "insert into RegUser(uid,name,desg,dept,mobile,email,username,password) values ('" + uid + "','" +
                       name + "','" + desg + "','" + dept + "'," + mobile + ",'" + email + "','" + username + "','" + password + "')";//mobile is int that is why it doesnt require '
                    SqlCommand cmd = new SqlCommand(qry, sqlCon);
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show(i + " Number of user Registered with username: " + username);
                    else
                        MessageBox.Show("User registration failed. ");
                    sqlCon.Close();
                    button2_Click(sender, e);
                }
                catch (System.Exception exp)
                {

                    MessageBox.Show("Error Occured at User Registration:" + exp.ToString());
                }
            }
            else
                MessageBox.Show("All fields should be filled");
            
        }

       
    }
}
