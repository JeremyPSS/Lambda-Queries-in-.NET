using AppSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Controlador
{
    public class TListaS
    {
        public static List<Empleado> Lista2 = new List<Empleado>();
        public static void Insert(Empleado op)
        {
            Lista2.Add(op);
        }
        public static void Update(Empleado op, int pos)
        {
            Lista2[pos] = op;
        }
        public static void Delete(int pos)
        {
            Lista2.Remove(Lista2.ElementAtOrDefault(pos));
        }
        public static int Buscar(string dato)
        {
            int pos = -1;
            for (int i = 0; i < Lista2.Count; i++)
            {
                if (Lista2[i].Cedula.Equals(dato))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        public static string Imprimir()
        {
            string info = "";
            foreach (Empleado op in Lista2)
            {
                info = info + op.Cedula + "\n" + op.Nombres;
            }

            return info;
        }

        public static void Limpiar()
        {
            Lista2.Clear();
        }
    }
}
