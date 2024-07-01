using System;
using System.Collections.Generic;

namespace MiniProyecto
{
    public class Base
    {
        private static string[] Tareas = new string[15]; // lista de las tareas
        static byte ContadorTareas = 0;

        static ToDo ToDo = new ToDo(default, default, default);

        static ToDo_Personal TareaPersonal = new ToDo_Personal(default, default, default, default);
        static ToDo_Trabajo TareaTrabajo = new ToDo_Trabajo(default, default, default, default);
        static ToDo_Estudio TareaEstudio = new ToDo_Estudio(default, default, default, default);

        static void Main()
        {
            bool Salir = false;
            bool Cancelar = false;
            
            List<(int Indice, string Nombre, string Tipo, string Detalle)> listaTareas = new List<(int, string, string, string)>();
            do
            {
                try
                {
                    Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0");
                    Console.WriteLine("|     -                                           -      |");
                    Console.WriteLine("*  -    -   .*.*.*.   ¡Bienvenido!  .*.*.*.    -     -   *");
                    Console.WriteLine("|-        -                                  -          -|");
                    Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0");

                    // lista de tareas

                    if (Confirmar() == true)
                    {
                        MostrarTareas();
                    }

                    // menú de opciones
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-"); 
                    Console.WriteLine("|  1. Agregar Tarea                 2. Seleccionar |");
                    Console.WriteLine("|                                   0. Salir       |");
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

                    switch (Convert.ToByte(Console.ReadLine()))
                    {
                        case 1:
                            do
                            {
                                Console.Clear();

                                if (ContadorTareas >= 15)
                                {
                                    Console.WriteLine("La lista de tareas está llena.");
                                    break;
                                }
                                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");
                                Console.WriteLine("|._.-._.-.._. Agregar Tarea ._.-._.-.._.|");
                                Console.WriteLine("*---------------------------------------*");
                                Console.WriteLine("|      Seleccione una categoria:        |");
                                Console.WriteLine("|                                       |");
                                Console.WriteLine("|1.Estudio   2.Trabajo   3.Personal     |");
                                Console.WriteLine("|            0.Cancelar                 |");
                                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");


                                switch (Convert.ToByte(Console.ReadLine()))
                                {
                                    case 1:
                                        TareaEstudio.PreguntarInfo();
                                        AñadirTarea(out string nombre, out string detalle, out byte indice);
                                        TareaEstudio.AgregarInfo("Estudio", detalle, indice);

                                        break;
                                    case 2:
                                        TareaTrabajo.PreguntarInfoTrabajo();
                                        AñadirTarea(out nombre, out detalle, out indice);
                                        TareaTrabajo.AgregarInfo("Trabajo", detalle, indice);

                                        break;
                                    case 3:
                                        TareaPersonal.PreguntarInfoPersonal();
                                        AñadirTarea(out nombre, out detalle, out indice);
                                        TareaPersonal.AgregarInfo("Personal", detalle, indice);

                                        break;
                                    case 0:
                                        Cancelar = true;
                                        break;
                                    default:
                                        MensajeError();
                                        return;
                                }
                            } while (!Cancelar);
                            break;
                        case 2:
                            do
                            {
                                if (Confirmar() == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("No hay tareas para seleccionar.");
                                    Console.WriteLine("");
                                    Cancelar = true;
                                    break;
                                }

                                MostrarTareas();

                                Console.WriteLine("Digite el numero de la tarea\n ");
                                byte nTarea = Convert.ToByte(Console.ReadLine());

                                Console.Clear();
                                
                                Console.WriteLine("       -*  TAREA  *-         "); //muestra los detalles de la tarea de ese numero
                                Console.WriteLine($"Titulo: {Tareas[nTarea-1]}");
                                ToDo.MostrarInfo(nTarea); 

                                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                                Console.WriteLine("| 1. Editar tarea                         0. Volver|");
                                Console.WriteLine("| 2. Borrar tarea                         \n       |");
                                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                                switch (Convert.ToByte(Console.ReadLine()))
                                {
                                    case 1:
                                        Console.Write("Ingrese el nuevo título de la tarea: ");
                                        Tareas[nTarea - 1] = Console.ReadLine();
                                        ToDo.EditarInfo(nTarea);
                                        break;
                                    case 2:
                                        Tareas[nTarea - 1] = default;
                                        ToDo.BorrarInfo(nTarea);
                                        ContadorTareas -= 1;
                                        break;
                                    case 0:
                                        Console.Clear();
                                        Cancelar = true;
                                        break;
                                    default:
                                        MensajeError();
                                        break;
                                }
                            } while (!Cancelar);
                            break;
                        case 0:
                            Console.Clear();
                            Salir = true;
                            break;
                        default:
                            MensajeError();
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MensajeError();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos de manera correcta, por favor.");
                }
                catch (OverflowException)
                {
                    MensajeError();
                }
                catch (NullReferenceException)
                {
                    MensajeError();
                }
                catch (StackOverflowException)
                {
                    MensajeError();
                }
                catch (TypeInitializationException)
                {
                    MensajeError();
                }
                catch (Exception)
                {
                    MensajeError();
                }
            } while (!Salir);
        }

        // Metodos

        public static void AñadirTarea(out string nombre, out string detalle, out byte Indice) // utilizado al agregar tareas
        {
            Console.WriteLine("Digite el nombre");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite la descripcion");
            detalle = Console.ReadLine();

            Tareas[ContadorTareas] = nombre;

            Indice = ContadorTareas;

            ContadorTareas++;

            Console.WriteLine("Tarea agregada exitosamente.");
            Console.ReadKey();
        }
        public static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Error! opcion invalida");
        }
        public static bool Confirmar()
        {
            foreach (string tarea in Tareas)
            {
                if (tarea != default)
                {
                    return true;
                }
            }
            Console.WriteLine("\nNo hay tareas :/ ?\n");
            return false;
        }
        public static void MostrarTareas()
        {
            Console.Clear();

            Console.WriteLine("Lista de tareas\n");

            for (int i = 0; i < Tareas.Length; i++)
            {
                if (Tareas[i] != default)
                {
                    Console.WriteLine($"{i + 1}. {Tareas[i]}");
                }
            }
        }
    }
}