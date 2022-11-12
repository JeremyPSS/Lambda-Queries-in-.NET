using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSistemaNomina.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void linToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmLinq"] == null)
            {
                frmLinq frm = new frmLinq
                {
                    MdiParent = this
                };
                frm.Show();
            }
        }

        private void administrarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdminEmpleado"]==null)
            {
                frmAdminEmpleado frm = new frmAdminEmpleado
                {
                    MdiParent = this
                };
            frm.Show();
            }

        }






    }
}
