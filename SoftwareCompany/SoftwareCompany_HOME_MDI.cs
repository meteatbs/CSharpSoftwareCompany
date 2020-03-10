using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareCompany
{
    public partial class SoftwareCompany_HOME_MDI : Form
    {
        private int childFormNumber = 0;

        public SoftwareCompany_HOME_MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

      

       

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void examToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SoftwareCompany_HOME_MDI_Load(object sender, EventArgs e)
        {

        }

        private void ınsertBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Library lib = new Library();
            lib.MdiParent = this;
            lib.Show();
        }
    }
}
