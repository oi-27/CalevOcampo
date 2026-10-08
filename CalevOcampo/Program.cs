using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CalevOcampo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 18;
            string[] cedulas = new string[n];
            string[] nombres = new string[n];
            int pacientes = 0;
            int opcion = 0;
            int i, j, posicion;
            string cedula = "";
            string nombre = "";
            bool existente;

            do 
            {
                Console.WriteLine("Hospital San Rafael");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Buscar cedula");
                Console.WriteLine("3. Corregir nombre");
                Console.WriteLine("4. Eliminar paciente");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione opción (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion=0;
                }
                switch (opcion)
                {
                    case 1:
                        if (pacientes < n)
                        {
                            Console.Write("Ingrese el numero de cedula: ");
                            cedula = Console.ReadLine();

                            existente = false;
                            for (i = 0; i < pacientes; i++)
                            {
                                if (cedulas[i] == cedula)
                                {
                                    existente = true;
                                    break;
                                }
                            }

                            if (existente)
                            {
                                Console.WriteLine("La cedula ya esta registrada.");
                            }
                            else
                            {
                                Console.Write("Ingrese el nombre del paciente: ");
                                nombre = Console.ReadLine();

                                cedulas[pacientes] = cedula;
                                nombres[pacientes] = nombre;
                                pacientes = pacientes + 1;

                                Console.WriteLine("Paciente registrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se pueden registrar mas pacientes.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese la cedula para buscar: ");
                        cedula = Console.ReadLine();

                        existente = false;
                        for (i = 0; i < pacientes; i++)
                        {
                            if (cedulas[i] == cedula)
                            {
                                Console.WriteLine("Se encontro paciente: " + nombres[i] + ".");
                                existente = true;
                                break;
                            }
                        }

                        if (!existente)
                        {
                            Console.WriteLine("No se encontro paciente.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese la cedula para corregir nombre: ");
                        cedula = Console.ReadLine();

                        existente = false;
                        for (i = 0; i < pacientes; i++)
                        {
                            if (cedulas[i] == cedula)
                            {
                                Console.WriteLine("Nombre actual: " + nombres[i]);
                                Console.Write("Ingrese el nombre corregido: ");
                                nombre = Console.ReadLine();

                                nombres[i] = nombre;
                                Console.WriteLine("Se corrigio el nombre.");
                                existente = true;
                                break;
                            }
                        }

                        if (!existente)
                        {
                            Console.WriteLine("No se encontro paciente");
                        }
                        break;

                    case 4:
                        Console.Write("Ingrese la cedula del paciente para eliminar: ");
                        cedula = Console.ReadLine();

                        posicion = -1;
                        for (i = 0; i < pacientes; i++)
                        {
                            if (cedulas[i] == cedula)
                            {
                                posicion = i;
                                break;
                            }
                        }

                        if (posicion != -1)
                        {
                            if (posicion < pacientes - 1)
                            {
                                for (j = posicion; j < pacientes - 2; j++)
                                {
                                    cedulas[j] = cedulas[j + 1];
                                    nombres[j] = nombres[j + 1];
                                }
                            }

                            pacientes = pacientes - 1;
                            Console.WriteLine("Se elimino paciente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro paciente.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }

            } while (opcion != 5);
        }
    }
}