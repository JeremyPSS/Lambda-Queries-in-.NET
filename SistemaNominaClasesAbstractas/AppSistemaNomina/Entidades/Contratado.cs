using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Entidades
{
    public class Contratado : Fijo
    {
        private double horasTrabajadas;
        private double costoHora;

        public Contratado()
        {
        }

        public Contratado(string ced, string nom, string ape, char sex, DateTime fec, string est, string ciu,string tip, double salario, double iess,      double horasTrabajadas, double costoHora)
        :base(ced,nom,ape,sex,fec,est,ciu,tip,salario,iess,0)
        {
            this.HorasTrabajadas = horasTrabajadas;
            this.CostoHora = costoHora;
            this.Edad = CalcularEdad();
            this.Pago = CalcularSueldo();
        }

        public double HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }
        public double CostoHora { get => costoHora; set => costoHora = value; }

        public override double CalcularSueldo()
        {
            double total=0,ies=0;
             total = horasTrabajadas * costoHora;
            if (horasTrabajadas >= 160)
            {
                ies = total * 0.0932;
            }

            if (this.Fecha.Month == DateTime.Now.Month)
            {
                total = total + 100;
            }
            if (Edad >= 60)
            {
                total = total + 50;
            }



            return total-ies;
        }

        public override int CalcularEdad()
        {
            return DateTime.Now.Year - Fecha.Year;
        }
    }
}
