using AppSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSistemaNomina.Controlador
{
    public class TLista
    {
        public static List<Empleado> Lista = new List<Empleado>();
        public static void Insert(Empleado op)
        {
            Lista.Add(op);
        }
        public static void Update(Empleado op, int pos)
        {
            Lista[pos] = op;
        }
        public static void Delete(int pos)
        {
            Lista.Remove(Lista.ElementAtOrDefault(pos));
        }
        public static int Buscar(string dato)
        {
            int pos = -1;
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].Cedula.Equals(dato))
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
            foreach (Empleado op in Lista)
            {
                info = info + op.Cedula + "\n" + op.Nombres;
            }

            return info;
        }

        public static void Limpiar()
        {
            Lista.Clear();
        }



    }
}
