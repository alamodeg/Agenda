using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Program
    {
        static void Main()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("********* AGENDA ELECTRONICA *********\n\n" +
                "1 - Agregar Contacto \n" +
                "2 - Editar Contacto \n" +
                "3 - Eliminar Contacto \n" +
                "4 - Listar Contactos \n" +
                "0 - Salir \n");
                Console.WriteLine("Ingrese una opcion..");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        Console.Clear();
                        Helper.AgregarContacto();
                        break;
                    case 2:
                        Console.Clear();
                        Helper.EditarContacto();
                        break;
                    case 3:
                        Console.Clear();
                        Helper.EliminarContacto();
                        break;
                    case 4:
                        Console.Clear();
                        Helper.ListarContactos();
                        break;
                    case 0:
                        //salir
                        break;
                    default:
                        Console.WriteLine("ERROR ingresando digito! Pulse una tecla para continuar..");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }
    }
}
/*
 * Aquiles,Brinco,19,385654235
Alejandro,Beta Tester,55,381659853
Estela, Berreta,37,381658965
 */
