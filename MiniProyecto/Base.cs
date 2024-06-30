using System;

namespace MiniProyecto
{
    public class Base
    {
        private static string[] Tareas = new string[15]; // tareas
        static byte ContadorTareas = 0;

        static void Main()
        {
            bool Salir = false;
            bool Cancelar = false;

            ToDo ToDo = new ToDo(default, default, default, default);

            ToDo_Personal TareaPersonal = new ToDo_Personal(default, default, default, default, default);
            ToDo_Trabajo TareaTrabajo = new ToDo_Trabajo(default, default, default, default, default);
            ToDo_Estudio TareaEstudio = new ToDo_Estudio(default, default, default, default, default);
            List<(int Indice, DateTime Fecha, string Nombre, string Tipo, string Detalle)> listaTareas = new List<(int, DateTime, string, string, string)>();
            do
            {
                try
                {
                    Console.WriteLine("------------------- ¡Bienvenido! ------------------");

                    // lista de tareas

                    if (Confirmar() == true)
                    {
                        MostrarTareas();
                    }

                    // menú de opciones
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("  1. Agregar Tarea                 3. Seleccionar");
                    Console.WriteLine("  2. Ordenar Tareas                0. Salir      ");
                    Console.WriteLine("---------------------------------------------------");

                    byte opc = Convert.ToByte(Console.ReadLine());

                    switch (opc)
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
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine("            Agregar Tarea              ");
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine("      Seleccione una categoria:        ");
                                Console.WriteLine("                                       ");
                                Console.WriteLine("1.Estudio   2.Trabajo   3.Personal     ");
                                Console.WriteLine("            0.Cancelar                 ");
                                Console.WriteLine("---------------------------------------");


                                switch (Convert.ToByte(Console.ReadLine()))
                                {
                                    case 1:
                                        TareaEstudio.PreguntarInfo();
                                        AñadirTarea(out string nombre, out string detalle, out byte indice, out string fecha);
                                        TareaEstudio.AgregarInfo("Estudio", detalle, indice, fecha);

                                        break;
                                    case 2:
                                        TareaTrabajo.PreguntarInfoTrabajo();
                                        AñadirTarea(out nombre, out detalle, out indice, out fecha);
                                        TareaTrabajo.AgregarInfo("Trabajo", detalle, indice, fecha);

                                        break;
                                    case 3:
                                        TareaPersonal.PreguntarInfoPersonal();
                                        AñadirTarea(out nombre, out detalle, out indice, out fecha);
                                        TareaPersonal.AgregarInfo("Personal", detalle, indice, fecha);

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
                            OrdenarTareasPorFecha();
                            
                              

                               for (int i = 0; i < ContadorTareas; i++)
                                {
                                    if (!string.IsNullOrEmpty(Tareas[i]))
                                    {
                                        DateTime fecha;
                                        string fechaStr = ToDo.ObtenerFecha(i);
                                        if (DateTime.TryParse(fechaStr, out fecha))
                                        {
                                            listaTareas.Add((i, fecha, Tareas[i], ToDo.ObtenerTipo(i), ToDo.ObtenerDetalle(i)));
                                        }
                                    }
                                }

                                listaTareas = listaTareas.OrderBy(t => t.Fecha).ToList();

                              
                                for (int i = 0; i < listaTareas.Count; i++)
                                {
                                    Tareas[i] = listaTareas[i].Nombre;
                                    ToDo.ActualizarTarea(i, listaTareas[i].Tipo, listaTareas[i].Detalle, listaTareas[i].Fecha.ToString("yyyy-MM-dd"));
                                }

                                Console.WriteLine("Tareas ordenadas por fecha con éxito.");
                                Console.ReadKey();
                            
                            break;
                        case 3:
                            do
                            {
                                if (Confirmar() == false)
                                {
                                    Cancelar = true;
                                    break;
                                }

                                MostrarTareas();

                                Console.WriteLine("Digite el numero de la tarea");
                                byte nTarea = Convert.ToByte(Console.ReadLine());

                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine(Tareas[nTarea - 1]);
                                Console.WriteLine();

                                ToDo.MostrarInfo(nTarea); //muestra los detalles de la tarea de ese numero

                                Console.WriteLine("1. Editar tarea      0. Volver");
                                Console.WriteLine("2. Borrar tarea      \n       ");

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
                                        break;
                                    case 0:
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

        public static void AñadirTarea(out string nombre, out string detalle, out byte Indice, out string fecha) // utilizado al agregar tareas
        {
            Console.WriteLine("Digite el nombre");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite la descripcion");
            detalle = Console.ReadLine();

            Console.WriteLine("Digite la fecha limite");
            fecha = Console.ReadLine();

            Tareas[ContadorTareas] = nombre;

            Indice = ContadorTareas;

            ContadorTareas++;

            Console.WriteLine("Tarea agregada exitosamente.");
        }
        public static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Error! opcion invalida");
            Console.ReadKey();
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
                if (Tareas[i] == default)
                {
                    Console.WriteLine("");
                }
            }
        }
        public static void OrdenarTareasPorFecha()
        {
            
            List<(int Indice, DateTime Fecha, string Nombre, string Tipo, string Detalle)> listaTareas = new List<(int, DateTime, string, string, string)>();

            for (int i = 0; i < ContadorTareas; i++)
            {
                if (!string.IsNullOrEmpty(Tareas[i]))
                {
                    DateTime fecha;
                    string fechaStr = ToDo.ObtenerFecha(i);
                    if (DateTime.TryParse(fechaStr, out fecha))
                    {
                        listaTareas.Add((i, fecha, Tareas[i], ToDo.ObtenerTipo(i), ToDo.ObtenerDetalle(i)));
                    }
                }
            }

            listaTareas = listaTareas.OrderBy(t => t.Fecha).ToList();
            for (int i = 0; i < listaTareas.Count; i++)
            {
                Tareas[i] = listaTareas[i].Nombre;
                ToDo.ActualizarTarea(i, listaTareas[i].Tipo, listaTareas[i].Detalle, listaTareas[i].Fecha.ToString("yyyy-MM-dd"));
            }

            Console.WriteLine("Tareas ordenadas por fecha con éxito.");
            Console.ReadKey();
        }
    }
}