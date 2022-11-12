using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Entidades
{
    public class Comision : Empleado
    {
        private double sueldo;
        private double tarifa;
        private double ventasBrutas;

        public Comision()
        {

        }

        public Comision(string ced, string nom, string ape, char sex, DateTime fec, string est, string ciu,string tip, double ventasBrutas,double sue)
        {
            this.Nombres = nom;
            this.Cedula = ced;
            this.Apellidos = ape;
            this.Sexo = sex;
            this.Fecha = fec;
            this.Estado = est;
            this.Ciudad = ciu;
            this.Tipo = tip;
            this.VentasBrutas = ventasBrutas;
            this.sueldo = sue;

            this.Pago = CalcularSueldo();
            this.Edad = CalcularEdad();
        }

        public double Tarifa { get => tarifa; set => tarifa = value; }
        public double VentasBrutas { get => ventasBrutas; set => ventasBrutas = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }

        public override double CalcularSueldo()
        {
            double total=0;
            tarifa = ventasBrutas * (double)0.2;
            total = sueldo + tarifa;

            if (this.Fecha.Month == DateTime.Now.Month)
            {
                total = total + 100;
            }
            if (Edad >= 60)
            {
                total = total + 50;
            }


            return total;
        }
        public override int CalcularEdad()
        {
            return DateTime.Now.Year - Fecha.Year;
        }
    }
}
