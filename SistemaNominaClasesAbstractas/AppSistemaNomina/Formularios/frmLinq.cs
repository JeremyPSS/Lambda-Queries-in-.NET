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
    public partial class frmLinq : Form
    {
        public frmLinq()
        {
            InitializeComponent();
        }

        private void summToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Tipo into t
                      select new { Tipo = t.Key, TotalCobrado = t.Sum(p => p.Pago) }; //o tambien p.CalcularSueldo()
            dataGridView1.DataSource = sql.ToList();
        }

        private void frmLinq_Load(object sender, EventArgs e)
        {
            CargarDatos();
            //ListarEmpleado();
        }

        public void CargarDatos()
        {

            Empleado of = new Fijo("0750", "Joel", "Girgio", 'M', DateTime.Parse("12/01/1980"), "Casado", "Machala", "Fijos", 500, 50, 50);
            Empleado oc = new Contratado("034", "Allison", "Carrion", 'F', DateTime.Parse("12/01/1990"), "Soltero", "Pasaje", "Contratados", 10, 40, 54, 21);
            Empleado oco = new Comisionado("074234", "Ricardo", "Ontaneda", 'M', DateTime.Parse("12/05/1970"), "Viudo", "Arenillas", "Comisionados", 75, 50);
            Empleado oe = new Comision("032", "Erica", "Palmales", 'F', DateTime.Parse("02/06/2002"), "Casado", "Machala", "Comision", 234, 50);
            TLista.Insert(of);
            TLista.Insert(oc);
            TLista.Insert(oco);
            TLista.Insert(oe);
            TLista.Lista.Add(new Fijo("075342341", "Ana", "Vazques", 'F', DateTime.Parse("12/01/2016"), "Divorciado", "Cuenca", "Fijos", 350, 63, 10));
            TLista.Lista.Add(new Contratado("23523452", "Bruno", "Diaz", 'M', DateTime.Parse("12/01/1980"), "Casado", "Quito", "Contratados", 350, 63,100,67));
            TLista.Lista.Add(  new Comisionado("2685756", "Peter", "Parquer", 'M', DateTime.Parse("12/05/1990"), "Soltero", "Huaquillas", "Comisionados", 75, 50));

            TListaS.Lista2.Add(new Fijo("00001", "Miguel", "Pancho", 'F', DateTime.Parse("12/01/2001"), "Viudo", "Quito", "Fijos", 600, 10, 12));
            TListaS.Lista2.Add(new Contratado("073123", "Solomeo", "Paredes", 'M', DateTime.Parse("12/01/1979"), "Divorciado", "Pasaje", "Contratados", 460, 12, 50, 3));
            TListaS.Lista2.Add(new Comisionado("1111110", "Jhonny", "Guaman", 'M', DateTime.Parse("12/05/2003"), "Soltero", "Huaquillas", "Comisionados", 120, 65));
            TListaS.Lista2.Add( new Contratado("034", "Allison", "Carrion", 'F', DateTime.Parse("12/01/1990"), "Soltero", "Pasaje", "Contratados", 10, 40, 54, 21));


        }

        public void ListarEmpleado()
        {
            dataGridView1.DataSource = TLista.Lista.ToList();
        }

        private void selectSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      select le; //seleccione todo
            dataGridView1.DataSource = sql.ToList(); //le digo que se me convierta en lista
        }

        private void selectUpperLowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      select new { Cedula = le.Cedula, Nombres = le.Nombres.ToLower(), Apellidos = le.Apellidos.ToUpper(), Tipo = le.Tipo, Sueldo = le.CalcularSueldo() };
            dataGridView1.DataSource = sql.ToList();
        }

        private void selectAtributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      select new { Cedula = le.Cedula, Nombres = le.Nombres , Apellidos =  le.Apellidos, Tipo = le.Tipo, Sueldo = le.CalcularSueldo()};
            dataGridView1.DataSource = sql.ToList();
        }

        private void consultaasLambdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAtributosP2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      select new {le.Cedula,le.Nombres,  le.Apellidos, le.Tipo,Metodo = le.CalcularSueldo() };
            dataGridView1.DataSource = sql.ToList();
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista where le.Sexo == 'F' select le;
            dataGridView1.DataSource = sql.ToList();
        }

        private void multipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista 
                      where le.Tipo.Equals("Fijos") && le.Sexo=='F' 
                      select le;
            dataGridView1.DataSource = sql.ToList();
        }

        private void orderByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      orderby le.Nombres ascending //el "ascending" si no lo ponemos se pone automaticamente
                      select le;
            dataGridView1.DataSource = sql.ToList();
        }

        private void orderByLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      orderby le.Nombres.Length //ordena por la longitud de la palabra
                      select le;
            dataGridView1.DataSource = sql.ToList();
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Sexo into t
                      select new { Sexo = t.Key, Cantidad = t.Count()};
            dataGridView1.DataSource = sql.ToList();
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Tipo into t
                      select new { Tipo = t.Key, MaximoSueldo = t.Max(p => p.Pago) }; 
            dataGridView1.DataSource = sql.ToList();
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Tipo into t
                      select new { Tipo = t.Key, MinimoSueldo = t.Min(p => p.Pago) };
            dataGridView1.DataSource = sql.ToList();
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Tipo into t
                      select new { Tipo = t.Key, Promedio = t.Average(p => p.Pago) };
            dataGridView1.DataSource = sql.ToList();
        }

        private void whereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            List<Empleado> resul = TLista.Lista.Where(x => x.Tipo.Equals("Fijos")).ToList();
            dataGridView1.DataSource = resul;
            
          

        }

        private void orderByToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Empleado> resul = TLista.Lista.OrderBy(x => x.Sexo).ToList();
            dataGridView1.DataSource = resul;


        }

        private void thenByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Empleado> resul = TLista.Lista.OrderBy(x => x.Nombres).ThenByDescending(x => x.Edad).ToList();
            //or
            //List<Empleado> resul = TLista.Lista.OrderBy(x => x.Sexo).ThenBy(x => x.Nombres).ToList();

            dataGridView1.DataSource = resul;
        }
        
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           bool losJovenes = TLista.Lista.All(s => s.Edad > 12 && s.Edad < 20);
           dataGridView1.Columns.Add("Jovenes","Jovenes");
           dataGridView1.Rows[0].Cells[0].Value = losJovenes;
            

        }

        private void countToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double resul = TLista.Lista.Count(x => x.Edad % 2 == 0);
            dataGridView1.Columns.Add("Edad pares", "edad pares");
            dataGridView1.Rows[0].Cells[0].Value = resul;
        }

        private void maxToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var resul = TLista.Lista.Max(x => {
                if (x.Edad % 2 != 0)
                    return x.Edad;

                return 0;
            });
            dataGridView1.Columns.Add("Edad impar maxima", "edad impar maxima");
            dataGridView1.Rows[0].Cells[0].Value = resul;

        }

        private void ejemplo91ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            List<Empleado> resul = TLista.Lista.Where(x => {
                x.Tipo.Equals("Fijos"); return false;
            }).ToList();
            dataGridView1.DataSource = resul;
            */

            var resul = TLista.Lista.Min(x => {
                if (x.Edad % 2 != 0) return x.Edad;
                return TLista.Lista.Max(i => { if(i.Edad % 2 != 0) return i.Edad; return 0;});
            });
            dataGridView1.Columns.Add("edad impar minima", "Edad impar minima");
            dataGridView1.Rows[0].Cells[0].Value = resul;

        }

        private void ejemplo01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Func<int,bool> iguala51 = x => x == 51;

            bool resul=false;
            for(int i = 0; i < TLista.Lista.Count; i++)
            {
             resul = iguala51(TLista.Lista[i].Edad);
                if (resul == true) break;

            }
            dataGridView1.Columns.Add("edades iguales a 51", "Edades iguales a 51?");
            dataGridView1.Rows[0].Cells[0].Value = resul;
        }

        private void selectSimpleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.ToList();
        }

        private void selectUpperLowerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Select(c => new { c.Cedula, Nombre = c.Nombres.ToUpper(), 
                Apellido = c.Apellidos.ToUpper(), c.Sexo, Tipo = c.Tipo.ToLower(), Sueldo = c.CalcularSueldo() }).ToList();
        }

        private void selectAtributosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Select(c => new { c.Cedula, c.Nombres, c.Apellidos, c.Sexo, 
                c.Tipo, Sueldo = c.CalcularSueldo() }).ToList();
        }

        private void simpleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Where(c => c.Sexo == 'M').ToList();
        }

        private void multipleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Where(c => c.Sexo == 'F' && c.Pago >= 100).Select(c => new {
                c.Cedula, c.Nombres, c.Sexo, c.Tipo, Sueldo = c.CalcularSueldo() }).ToList();
        }

        private void orderByToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.OrderByDescending(c => c.Apellidos).ToList();
        }

        private void orderByLengthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.OrderBy(c => c.Apellidos.Length).ToList();
        }

        private void countToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Tipo).Select(a => new {
                Tipo = a.Key, Cantidad = a.Count() }).ToList();
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Tipo).Select(a => new {
                Tipo = a.Key, TotalCobrado = a.Sum(x => x.Pago) }).ToList();
        }

        private void maxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Tipo).Select(a => new {
                Tipos = a.Key, MaximoSueldo = a.Max(p => p.Pago) }).ToList();
        }

        private void minToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Tipo).Select(a => new {
                Tipos = a.Key, MinimoSueldo = a.Min(p => p.Pago) }).ToList();
        }

        private void averageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Tipo).Select(a => new {
                Tipos = a.Key, SueldoMinimo = a.Average(p => p.Pago) }).ToList();
        }

        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      group le by le.Cedula into t
                      select new { Cedula = t.Key, o = t.Distinct() };
            dataGridView1.DataSource = sql.ToList();
        }

        private void exceptToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var sql = (from le in TLista.Lista select le).Except(from le2 in TListaS.Lista2 select le2);
            dataGridView1.DataSource = sql.ToList();
        }

        private void concatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = TLista.Lista.Concat(TListaS.Lista2);
            dataGridView1.DataSource = sql.ToList();
        }

        private void intercetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> N1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> N2 = new List<int> { 1, 6, 3, 4, 9 };
            var sql = (from le in N1 select le).Intersect(from le2 in N2 select le2);
            foreach (int x in sql)
            {
                Console.WriteLine(x);
            }
        }

        private void unionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = (from le in TLista.Lista select le).Union(from le2 in TListaS.Lista2 select le2);
            dataGridView1.DataSource = sql.ToList();
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = from le in TLista.Lista
                      join l in TListaS.Lista2 on le.Cedula equals l.Cedula
                      select new { le.Nombres, l.Pago };
            dataGridView1.DataSource = sql.ToList();
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sql = TLista.Lista.All(c => c.Pago > 300);
            MessageBox.Show("Empleados con pago mayor a $300: " + sql);
        }

        private void anyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = TLista.Lista.Any(c => c.Ciudad.Equals("Huaquillas"));
            MessageBox.Show("Empleado de huaquillas: " + sql);
        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> N1 = new List<int> { 1, 2, 3, 4, 5 };
            var sql = N1.Contains(4);
            String im = "";
            foreach (int x in N1)
            {
                im = im + x + " ";
            }
            MessageBox.Show("Lista: " + "\n" + im + "\nSe encuentra el número 4 ?= " + sql);
        }

        private void distinctToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.GroupBy(c => c.Cedula).Select(a => new {
                Cedula = a.Key, resul = a.Distinct() }).ToList();
        }

        private void concatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Concat(TListaS.Lista2).ToList();
        }

        private void unionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Union(TListaS.Lista2).ToList();
        }

        private void joinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TLista.Lista.Join(TListaS.Lista2, x => x.Cedula, a => a.Cedula, (x, a) => new {
                x.Nombres, a.Pago }).ToList();
        }

        private void allToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Empleados con pago mayor a 300: " + TLista.Lista.All(c => c.Pago > 300));
        }

        private void anyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Empleado de huaquillas " + TLista.Lista.Any(c => c.Ciudad.Equals("Huaquillas")));
        }

        private void containsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<double> Numeros = new List<double> { 2.5,5.3,12.3,5.3};
            String num = "";
            foreach (int x in Numeros)
            {
                num = num + x + " ";
            }
            MessageBox.Show("Contenido:  " + num + "\nExiste el 2.5  = " + Numeros.Contains(2.5));
        }

        private void groupJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
