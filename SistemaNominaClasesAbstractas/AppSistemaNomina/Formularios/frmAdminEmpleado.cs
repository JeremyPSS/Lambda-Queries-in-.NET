using AppSistemaNomina.Controlador;
using AppSistemaNomina.Entidades;
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
    public partial class frmAdminEmpleado : Form
    {
        public frmAdminEmpleado()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }


        public void ListarEmpleado()
        {
            dataGridView1.DataSource = TLista.Lista.ToList();
        }
        public void Nuevo()
        {
            frmEditEmpleado frm = new frmEditEmpleado();
            frm.Text = "Ingresar Persona";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Empleado op = frm.CrearObjeto();
                TLista.Insert(op);
                frm.Close();

            }
            ListarEmpleado();
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("! Deseas eliminar persona", "Eliminar Persona", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Empleado op = dataGridView1.CurrentRow.DataBoundItem as Empleado;
                        int pos = TLista.Buscar(op.Cedula);
                        TLista.Delete(pos);
                        MessageBox.Show("Persona eliminada");
                        ListarEmpleado();
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila eliminar");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Edit()
        {
            
            

            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int pos = 0;
                    Empleado op = dataGridView1.CurrentRow.DataBoundItem as Empleado;
                    if (op.Tipo.Equals("Fijos"))
                    {
                        Fijo oe = dataGridView1.CurrentRow.DataBoundItem as Fijo;
                        pos = TLista.Buscar(oe.Cedula);
                        frmEditEmpleado frm = new frmEditEmpleado();
                        frm.Text = "Editar Empleado";
                        frm.cargar(oe.Cedula, oe.Nombres, oe.Apellidos, oe.Sexo, oe.Fecha, oe.Estado, oe.Ciudad, oe.Tipo, oe.Salario, oe.Iess,oe.Anticipo,0);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            Empleado ot = frm.CrearObjeto();
                            TLista.Update(ot, pos);

                            frm.Close();

                        }
                        ListarEmpleado();
                    }
                    if(op.Tipo.Equals("Contratados"))
                    {
                        
                        Contratado oc = dataGridView1.CurrentRow.DataBoundItem as Contratado;
                        pos = TLista.Buscar(oc.Cedula);
                        frmEditEmpleado frm = new frmEditEmpleado();
                        frm.Text = "Editar Empleado";
                        frm.cargar(oc.Cedula, oc.Nombres, oc.Apellidos, oc.Sexo, oc.Fecha, oc.Estado, oc.Ciudad, oc.Tipo, oc.Salario, oc.Iess,oc.HorasTrabajadas,oc.CostoHora);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            Empleado ot = frm.CrearObjeto();
                            TLista.Update(ot, pos);
                            frm.Close();

                        }
                        ListarEmpleado();
                        
                    }
                    if (op.Tipo.Equals("Comision"))
                    {

                        Comision ocom = dataGridView1.CurrentRow.DataBoundItem as Comision;
                        pos = TLista.Buscar(ocom.Cedula);
                        frmEditEmpleado frm = new frmEditEmpleado();
                        frm.Text = "Editar Empleado";
                        frm.cargar(ocom.Cedula, ocom.Nombres, ocom.Apellidos, ocom.Sexo, ocom.Fecha, ocom.Estado, ocom.Ciudad, ocom.Tipo, ocom.VentasBrutas, ocom.Sueldo, 0,0 );
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            Empleado ot = frm.CrearObjeto();
                            TLista.Update(ot, pos);
                            frm.Close();

                        }
                        ListarEmpleado();

                    }
                    if (op.Tipo.Equals("Comisionados"))
                    {

                        Comision ocomd = dataGridView1.CurrentRow.DataBoundItem as Comision;
                        pos = TLista.Buscar(ocomd.Cedula);
                        frmEditEmpleado frm = new frmEditEmpleado();
                        frm.Text = "Editar Empleado";
                        frm.cargar(ocomd.Cedula, ocomd.Nombres, ocomd.Apellidos, ocomd.Sexo, ocomd.Fecha, ocomd.Estado, ocomd.Ciudad, ocomd.Tipo, ocomd.VentasBrutas, ocomd.Sueldo, 0, 0);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            Empleado ot = frm.CrearObjeto();
                            TLista.Update(ot, pos);
                            frm.Close();

                        }
                        ListarEmpleado();

                    }
                }
                else
                    MessageBox.Show("Seleccione la fila a editar");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarDatos()
        {
            
            Empleado of = new Fijo("0750", "Joel", "Girgio", 'M', DateTime.Parse("12/01/1980"), "Casado", "Machala", "Fijos", 500, 50,50);
            Empleado oc = new Contratado("034", "Allison", "Carrion", 'F', DateTime.Parse("12/01/1990"), "Casado", "Pasaje", "Contratados", 10, 40,54,21);
            Empleado oco = new Comisionado("074234", "Ricardo", "Ontaneda", 'M', DateTime.Parse("12/05/1970"), "Casado", "Arenillas", "Comisionados", 75, 50);
            Empleado oe = new Comision("032", "Erica", "Palmales", 'F', DateTime.Parse("02/06/2002"), "Casado", "Machala", "Comision", 234, 50);
            TLista.Insert(of);
            TLista.Insert(oc);
            TLista.Insert(oco);
            TLista.Insert(oe);
        }

        private void frmAdminEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ListarEmpleado();
        }
    }
}
