using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Entidades
{
    public abstract class Empleado
    {
        private string cedula;
        private string nombres;
        private string apellidos;
        private char sexo;
        private DateTime fecha;
        private string estado;
        private string ciudad;
        private string tipo;
        private double pago;
        private int edad;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double Pago { get => pago; set => pago = value; }
        public int Edad { get => edad; set => edad = value; }

        public abstract double CalcularSueldo();
        public abstract int CalcularEdad();
    }
}
