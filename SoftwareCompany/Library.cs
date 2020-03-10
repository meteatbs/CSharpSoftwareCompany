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
    public partial class Library : Form
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Library;Integrated Security=True");
        public Library()
        {
            InitializeComponent();
        }

        private void btnLibNewClear_Click(object sender, EventArgs e)
        {
            this.txtLibIsbn.Text = "";
            this.txtLibBookname.Text = "";
            this.txtLibSubject.Text = "";
            this.txtLibAuthor.Text = "";
            this.txtLibPrice.Text = "";
            this.txtLibQuantity.Text = "";
            this.txtLibPublisher.Text = "";
            this.cmbLibBranch.SelectedIndex = -1;
            
            showBooks();
            
            
                
        }

        private void btnLibInsert_Click(object sender, EventArgs e)
        {
            
            if (txtLibIsbn.Text.Length != 0 || txtLibBookname.Text.Length != 0 || txtLibSubject.Text.Length != 0 || txtLibAuthor.Text.Length != 0
                || txtLibPrice.Text.Length != 0 || txtLibQuantity.Text.Length != 0||txtLibPublisher.Text.Length!=0|| txtLibPublisher.Text.Length != 0)
            {
                try
                {
                    string isbn = txtLibIsbn.Text;
                    string bookname = txtLibBookname.Text;

                    string subject = txtLibSubject.Text;
                    string author = txtLibAuthor.Text;
                    int price = Int32.Parse(txtLibPrice.Text);
                    int quantity = Int32.Parse(txtLibQuantity.Text);
                    string publisher = txtLibPublisher.Text;
                    string branch = cmbLibBranch.SelectedItem.ToString();
                    sqlCon.Open();
                    string qry = "insert into BookInfo(ISBN,book_name,subject,author,price,quantity,publisher,branch) values ('" + isbn + "','" +
                       bookname + "','" + subject + "','" + author + "'," + price + "," + quantity + ",'" + publisher + "','" + branch + "')";//mobile is int that is why it doesnt require '
                    SqlCommand cmd = new SqlCommand(qry, sqlCon);
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show(i + " Number of Books inserted into table  : " + bookname);
                    else
                        MessageBox.Show("Book insertion failed. "+bookname);
                    
                    sqlCon.Close();
                    showBooks();//called showbooks method to fill data gridview
                    //btnLibNewClear_Click(sender, e);
                    this.txtLibIsbn.Text = "";
                    this.txtLibBookname.Text = "";
                    this.txtLibSubject.Text = "";
                    this.txtLibAuthor.Text = "";
                    this.txtLibPrice.Text = "";
                    this.txtLibQuantity.Text = "";
                    this.txtLibPublisher.Text = "";
                    this.cmbLibBranch.SelectedIndex = -1;
                }
                catch (System.Exception exp)
                {

                    MessageBox.Show("Error Occured at Book Not saved:" + exp.ToString());
                }
            }
            else
                MessageBox.Show("All fields should be filled");

        }
        public void showBooks()
        {
            try
            {
                sqlCon.Open();
                
                SqlDataAdapter sda = new SqlDataAdapter("Select * from BookInfo", sqlCon);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvBookInfo.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvBookInfo.Rows.Add();
                    dgvBookInfo.Rows[n].Cells[0].Value = item[0].ToString();
                    dgvBookInfo.Rows[n].Cells[1].Value = item[1].ToString();
                    dgvBookInfo.Rows[n].Cells[2].Value = item[2].ToString();
                    dgvBookInfo.Rows[n].Cells[3].Value = item[3].ToString();
                    dgvBookInfo.Rows[n].Cells[4].Value = item[4].ToString();
                    dgvBookInfo.Rows[n].Cells[5].Value = item[5].ToString();
                    dgvBookInfo.Rows[n].Cells[6].Value = item[6].ToString();
                    dgvBookInfo.Rows[n].Cells[7].Value = item[7].ToString();
                  
                }
                sqlCon.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Error in show book methods " + exp.ToString());
            }



        }

        private void Library_Load(object sender, EventArgs e)
        {
            
            showBooks();
            
           
        }

        private void dgvBookInfo_MouseClick(object sender, MouseEventArgs e)
        {
            txtLibIsbn.Text = dgvBookInfo.SelectedRows[0].Cells[0].Value.ToString();
            txtLibBookname.Text = dgvBookInfo.SelectedRows[0].Cells[1].Value.ToString();
            txtLibSubject.Text = dgvBookInfo.SelectedRows[0].Cells[2].Value.ToString();
            txtLibAuthor.Text = dgvBookInfo.SelectedRows[0].Cells[3].Value.ToString();
            txtLibPrice.Text = dgvBookInfo.SelectedRows[0].Cells[4].Value.ToString();
            txtLibQuantity.Text = dgvBookInfo.SelectedRows[0].Cells[5].Value.ToString();
            txtLibPublisher.Text = dgvBookInfo.SelectedRows[0].Cells[6].Value.ToString();
            cmbLibBranch.Text = dgvBookInfo.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnLibUpdate_Click(object sender, EventArgs e)
        {


            if (txtLibIsbn.Text.Length != 0 || txtLibBookname.Text.Length != 0 || txtLibSubject.Text.Length != 0 || txtLibAuthor.Text.Length != 0
                || txtLibPrice.Text.Length != 0 || txtLibQuantity.Text.Length != 0 || txtLibPublisher.Text.Length != 0 || txtLibPublisher.Text.Length != 0)
            {
                try
                {
                    string isbn = txtLibIsbn.Text;
                    string bookname = txtLibBookname.Text;

                    string subject = txtLibSubject.Text;
                    string author = txtLibAuthor.Text;
                    int price = Int32.Parse(txtLibPrice.Text);
                    int quantity = Int32.Parse(txtLibQuantity.Text);
                    string publisher = txtLibPublisher.Text;
                    string branch = cmbLibBranch.SelectedItem.ToString();
                    sqlCon.Open();
                    string qry = "UPDATE  BookInfo SET book_name='" + bookname + "',subject='" + subject + "',author='" + author + "',price=" + price + ",quantity=" + quantity + ",publisher='" + publisher + "',branch='" + branch + "' where ISBN='"+isbn+"'";
                      
                    SqlCommand cmd = new SqlCommand(qry, sqlCon);//ISBN='"+isbn +
              int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show(" Book updated" + bookname);
                    else
                        MessageBox.Show(" Book update failed. " + bookname);

                    sqlCon.Close();
                    showBooks();//called showbooks method to fill data gridview
                    //btnLibNewClear_Click(sender, e);
                    this.txtLibIsbn.Text = "";
                    this.txtLibBookname.Text = "";
                    this.txtLibSubject.Text = "";
                    this.txtLibAuthor.Text = "";
                    this.txtLibPrice.Text = "";
                    this.txtLibQuantity.Text = "";
                    this.txtLibPublisher.Text = "";
                    this.cmbLibBranch.SelectedIndex = -1;
                }
                catch (System.Exception exp)
                {

                    MessageBox.Show("Error Occured at Book Not saved:" + exp.ToString());
                }
            }
            else
                MessageBox.Show("All fields should be filled");

        }

        private void btnLibDelete_Click(object sender, EventArgs e)
        {
            if (txtLibIsbn.Text.Length != 0 || txtLibBookname.Text.Length != 0 || txtLibSubject.Text.Length != 0 || txtLibAuthor.Text.Length != 0
              || txtLibPrice.Text.Length != 0 || txtLibQuantity.Text.Length != 0 || txtLibPublisher.Text.Length != 0 || txtLibPublisher.Text.Length != 0)
            {
                try
                {
                    string isbn = txtLibIsbn.Text;
                  
                    sqlCon.Open();
                    string qry = "DELETE FROM  BookInfo  where ISBN='" + isbn + "'";

                    SqlCommand cmd = new SqlCommand(qry, sqlCon);//ISBN='"+isbn +
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show(" Book deleted from table" + isbn);
                    else
                        MessageBox.Show(" Book deletion failed. " + isbn);

                    sqlCon.Close();
                    showBooks();//called showbooks method to fill data gridview
                    //btnLibNewClear_Click(sender, e);
                    this.txtLibIsbn.Text = "";
                    this.txtLibBookname.Text = "";
                    this.txtLibSubject.Text = "";
                    this.txtLibAuthor.Text = "";
                    this.txtLibPrice.Text = "";
                    this.txtLibQuantity.Text = "";
                    this.txtLibPublisher.Text = "";
                    this.cmbLibBranch.SelectedIndex = -1;
                }
                catch (System.Exception exp)
                {

                    MessageBox.Show("Error Occured at Book Not saved:" + exp.ToString());
                }
            }
            else
                MessageBox.Show("All fields should be filled");
        }

        private void txtLibSearchname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM BookInfo where (book_name like'%" + txtLibSearchname.Text + "%' or subject like '%" + txtLibSearchname.Text + "%' or author like '%" + txtLibSearchname + "%')", sqlCon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvBookInfo.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvBookInfo.Rows.Add();
                    dgvBookInfo.Rows[n].Cells[0].Value = item[0].ToString();
                    dgvBookInfo.Rows[n].Cells[1].Value = item[1].ToString();
                    dgvBookInfo.Rows[n].Cells[2].Value = item[2].ToString();
                    dgvBookInfo.Rows[n].Cells[3].Value = item[3].ToString();
                    dgvBookInfo.Rows[n].Cells[4].Value = item[4].ToString();
                    dgvBookInfo.Rows[n].Cells[5].Value = item[5].ToString();
                    dgvBookInfo.Rows[n].Cells[6].Value = item[6].ToString();
                    dgvBookInfo.Rows[n].Cells[7].Value = item[7].ToString();
                    
                }
                sqlCon.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error in Search the book " + exp.ToString());
            }

        }
        }
    }
  



