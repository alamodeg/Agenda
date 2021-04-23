using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public static class Helper
    {
        /// <summary>
        /// Abre un archivo en modo lectura y muestra los contactos
        /// </summary>
        public static void ListarContactos()
        {
            string ruta = "Contactos.txt"; //ubicacion: bin -> debugg
            if (File.Exists(ruta))
            {
                Console.WriteLine("********* LISTADO DE CONTACTOS *********\n");
                using (StreamReader reader = new StreamReader(ruta))  //evita el uso de archivo.close()
                {
                    string linea = reader.ReadLine();
                    while (linea != null)
                    {
                        string[] separador = linea.Split(','); //separo en cadenas de text el archivo
                        var con = new Persona(separador[0], separador[1], Convert.ToInt32(separador[2]), Convert.ToInt32(separador[3]));
                        Console.WriteLine($"Nombre: {con.Nombre} || Apellido: {con.Apellido} || Edad: {con.Edad} || Cel: {con.Telefono}");
                        linea = reader.ReadLine(); //leo la siguiente linea
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro el archivo");
            }
            Console.WriteLine("\nPresiona cualquier tecla para continuar");
            Console.ReadKey();
        }

        /// <summary>
        /// Abre un archivo en modo escritura y crea un contacto nuevo
        /// </summary>
        public static void AgregarContacto()
        {
            string ruta = "Contactos.txt"; //ubicacion: bin -> debugg
            if (File.Exists(ruta))
            {
                Console.WriteLine("********* CREACION DE CONTACTO *********\n");
                using (StreamWriter writer = new StreamWriter(ruta,true))
                {
                    Console.WriteLine("Ingrese el nombre"); string nomb = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido"); string app = Console.ReadLine();
                    Console.WriteLine("Ingrese la edad"); string edad = Console.ReadLine();
                    Console.WriteLine("Ingrese el celular"); string cel = Console.ReadLine();
                    writer.WriteLine($"{nomb},{app},{edad},{cel}");
                    Console.WriteLine("CONTACTO AGENDADO! Presiona una tecla para continuar..\n");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No se encontro el archivo");
            }
        }

        /// <summary>
        /// Abre una archivo en modo escritura y sobreescribe los datos de un usuario
        /// </summary>
        public static void EditarContacto()
        {
            string respuesta;
            string ruta = "Contactos.txt";
            string ruta_aux = "temp.txt";

            Console.WriteLine("********* MODIFICACION DE CONTACTO *********\n");
            Console.WriteLine("Ingrese el apellido del contacto que desea modificar(respetar Mayus)..");
            var viejo_ap = Console.ReadLine();
            
            using (StreamReader reader = new StreamReader(ruta))
            {
                string linea = reader.ReadLine();
                while (linea != null)
                {
                    string[] separador = linea.Split(',');
                    if (separador[1].Equals(viejo_ap))
                    {
                        Console.WriteLine("USUARIO ENCONTRADO! posee los siguientes datos: \n");
                        Console.WriteLine($"Nombre: {separador[0]} || Apellido: {separador[1]} || Edad: {separador[2]} || Cel: {separador[3]}");
                        Console.WriteLine("¿Desea modificar este contacto(si/no)?");
                        respuesta = Console.ReadLine();
                        
                        if (respuesta.Equals("si"))
                        {
                            Console.WriteLine("Ingrese el nuevo apellido..");
                            string nuevo_ap = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(ruta_aux,true))
                            {
                                writer.WriteLine($"{separador[0]},{nuevo_ap},{separador[2]},{separador[3]}");
                                linea = reader.ReadLine();
                                Console.WriteLine("Moficacion exitosa..");
                                Console.ReadKey();
                            }
                        }
                        else //si tiene el mismo apellido pero es otro usuario
                        {
                            using (StreamWriter writer = new StreamWriter(ruta_aux,true))
                            {
                                writer.WriteLine(linea);
                            }
                            linea = reader.ReadLine();
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(ruta_aux,true))
                        {
                            writer.WriteLine(linea);
                        }
                        linea = reader.ReadLine();
                    }
                }
            }
            File.Delete(ruta);
            File.Move(ruta_aux, ruta); //renombro el temporal para que sea el actual
        }

        /// <summary>
        /// Abre un archivo en modo escritura y elimina un contacto
        /// </summary>
        public static void EliminarContacto()
        {
            string respuesta;
            string ruta = "Contactos.txt";
            string ruta_aux = "temp.txt";

            Console.WriteLine("********* ELIMINACION DE CONTACTO *********\n");
            Console.WriteLine("Ingrese el apellido del contacto que desea eliminar(respetar Mayus)..");
            var viejo_ap = Console.ReadLine();

            using (StreamReader reader = new StreamReader(ruta))
            {
                string linea = reader.ReadLine();
                while (linea != null)
                {
                    string[] separador = linea.Split(',');
                    if (separador[1].Equals(viejo_ap))
                    {
                        Console.WriteLine("USUARIO ENCONTRADO! posee los siguientes datos: \n");
                        Console.WriteLine($"Nombre: {separador[0]} || Apellido: {separador[1]} || Edad: {separador[2]} || Cel: {separador[3]}");
                        Console.WriteLine("¿Desea eliminar este contacto(si/no)?\n");
                        respuesta = Console.ReadLine();

                        if (respuesta.Equals("si"))
                        {
                            string nuevo_ap = Console.ReadLine();
                            linea = reader.ReadLine();
                            Console.WriteLine("Eliminacion exitosa..");
                            Console.ReadKey();
                        }
                        else
                        {
                            using (StreamWriter writer = new StreamWriter(ruta_aux, true))
                            {
                                writer.WriteLine(linea);
                            }
                            linea = reader.ReadLine();
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(ruta_aux, true))
                        {
                            writer.WriteLine(linea);
                        }
                        linea = reader.ReadLine();
                    }
                }
            }
            File.Delete(ruta);
            File.Move(ruta_aux, ruta); //renombro el temporal para que sea el actual
        }
    }
}
