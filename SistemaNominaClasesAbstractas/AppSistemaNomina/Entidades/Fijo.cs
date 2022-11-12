using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Entidades
{
    public class Fijo: Empleado
    {
        private double salario;
        private double iess;
        private double anticipo;

        public Fijo()
        {
        }

        public Fijo(string ced, string nom, string ape, char sex, DateTime fec, string est,string ciu,string tip,   double salario, double iess, double anticipo)
        {
            this.Nombres = nom;
            this.Cedula = ced;
            this.Apellidos = ape;
            this.Sexo = sex;
            this.Fecha = fec;
            this.Estado = est;
            this.Ciudad = ciu;
            this.Tipo = tip;
            this.Salario = salario;
            this.Iess = iess;
            this.Anticipo = anticipo;
            this.Pago = CalcularSueldo();
            this.Edad = CalcularEdad();
        }

       
        public double Iess { get => iess; set => iess = value; }
        public double Anticipo { get => anticipo; set => anticipo = value; }
        public double Salario { get => salario; set => salario = value; }

        public override int CalcularEdad()
        {
            return DateTime.Now.Year - Fecha.Year;
        }

        public override double CalcularSueldo()
        {
            double total = 0;
            total = salario - (iess + anticipo); ;
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
    }
}
