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
    public partial class frmEditEmpleado : Form
    {
        public frmEditEmpleado()
        {
            InitializeComponent();
        }

        private void frmEditEmpleado_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTipoEnPantalla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public Empleado CrearObjeto()
        {
            string ced = textBox1.Text;
            string nom = textBox2.Text;
            string ape = textBox3.Text;
            char sex = ' ';
            if (radioButton1.Checked)
            {
                sex = Convert.ToChar(radioButton1.Text);
            }
            if (radioButton2.Checked)
            {
                sex = Convert.ToChar(radioButton2.Text);
            }
            DateTime fec = dateTimePicker1.Value;
            string est = comboBox1.SelectedItem.ToString();
            string ciu = textBox4.Text;
            string tip = comboBox2.Text;
            double d1 = double.Parse(textBox5.Text);
            double d2 = double.Parse(textBox6.Text);

            double d3 = 0, d4 = 0;
            Fijo of;
            Contratado oc;
            Comision ocom;
            Comisionado ocmod;



            if (tip.Equals("Fijos"))
            {
                d3 = double.Parse(textBox7.Text);
                of = new Fijo(ced, nom, ape, sex, fec, est, ciu, tip, d1, d2, d3);
                return of;
            }
            if (tip.Equals("Contratados"))
            {
                d3 = double.Parse(textBox7.Text);
                d4 = double.Parse(textBox8.Text);

                oc = new Contratado(ced, nom, ape, sex, fec, est, ciu, tip, d1, d2, d3,d4);
                return oc;
            }
            if (tip.Equals("Comision"))
            {
                ocom = new Comision(ced, nom, ape, sex, fec, est, ciu, tip, d1, d2);
                return ocom;
            }
            if (tip.Equals("Comisionados"))
            {
                ocmod = new Comisionado(ced, nom, ape, sex, fec, est, ciu, tip, d1, d2);
                return ocmod;
            }
            else
            {
                return oc = new Contratado();
            }


          

        }
        public bool Validar()
        {
            bool valor = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 ||(radioButton1.Checked==false & radioButton2.Checked == false))
            {
                valor = false;
            }
            return valor;
        }
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ingrese correctamente los datos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargar(string ced, string nom, string ape, char sex, DateTime fec, string est, string ciu, string tip, double dato1, double dato2,double dato3,double dato4)
        {

            textBox1.Text = ced;
            textBox2.Text = nom;
            textBox3.Text = ape;
            textBox4.Text = ciu;
            textBox5.Text = dato1.ToString();
            textBox6.Text = dato2.ToString();
            if (sex.Equals('M')) radioButton1.Checked = true;
            if (sex.Equals('F')) radioButton2.Checked = true;
            dateTimePicker1.Value = fec;
            comboBox1.SelectedItem = est;
            comboBox2.SelectedItem = tip;
            textBox5.Text = dato1.ToString();
            textBox6.Text = dato2.ToString();
            if (tip.Equals("Fijos") || tip.Equals("Contratados")) textBox7.Text = dato3.ToString();
            if (tip.Equals("Contratados")) textBox8.Text = dato4.ToString();
        }


        public void cargarTipoEnPantalla()
        {
            if (comboBox2.SelectedItem.Equals("Fijos"))
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = false;

                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = false;

                label10.Text = "Salario";
                label11.Text = "IEES";
                label12.Text = "Anticipo";

            }
            if (comboBox2.SelectedItem.Equals("Contratados"))
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;



                label10.Text = "Salario";
                label11.Text = "IEES";
                label12.Text = "Horas";
                label13.Text = "CostoHora";

                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;

            }
            if (comboBox2.SelectedItem.Equals("Comision"))
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = false;
                label13.Visible = false;

                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;



                label10.Text = "VentasBrutas";
                label11.Text = "Sueldo";

            }
            if (comboBox2.SelectedItem.Equals("Comisionados"))
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = false;
                label13.Visible = false;

                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;



                label10.Text = "Ventas";
                label11.Text = "SalarioBase";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
