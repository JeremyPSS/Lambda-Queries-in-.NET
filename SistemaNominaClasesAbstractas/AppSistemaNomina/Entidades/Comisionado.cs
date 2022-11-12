using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Entidades
{
    public class Comisionado:Comision
    {
        private double porcentajeVentas;

        public Comisionado()
        {
        }

        public Comisionado(string ced, string nom, string ape, char sex, DateTime fec, string est, string ciu, string tip, double ventasBrutas, double sue) 
        : base(ced, nom, ape, sex, fec, est, ciu,tip, ventasBrutas, sue)
        {
            this.Pago = CalcularSueldo();
            this.Edad = CalcularEdad();
        }

        public double PorcentajeVentas { get => porcentajeVentas; set => porcentajeVentas = value; }

        public override double CalcularSueldo()
        {
            double total = 0;
            porcentajeVentas = this.VentasBrutas * (double)0.2; //porcentaje de sus ventas
            double remcompenza = this.Sueldo / (double)110; //agrega un 10% mas al sueldo base
            total = this.Sueldo + porcentajeVentas + remcompenza;

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
