using System;
using System.Threading;

namespace MiniProyecto
{
    public class Base
    {
        static string[] Tareas = new string[15]; // tareas
        static byte ContadorTareas = 0;

        static void Main()
        {
            bool Salir = false;
            bool Cancelar = false;

            ToDo ToDo = new ToDo(default, default, default);

            ToDo_Personal TareaPersonal = new ToDo_Personal( default, default, default);
            ToDo_Trabajo TareaTrabajo = new ToDo_Trabajo(default, default, default);
            ToDo_Estudio TareaEstudio = new ToDo_Estudio(default, default, default);

            do
            {
                try
                {
                    // bienvenida

                    Console.WriteLine("Lista de tareas\n");
                Console.WriteLine("Para ver detalles de una tarea digite el numero\n");

                // lista de tareas

                MostrarTareas();

                // menú de opciones
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("1. Agregar Tarea     3. Seleccionar");
                Console.WriteLine("2. Ordenar Tareas    0. Salir      ");

                byte opc = Convert.ToByte(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        do
                        {
                            if (ContadorTareas >= 15)
                            {
                                Console.WriteLine("La lista de tareas está llena.");
                                break;
                            }

                            Console.WriteLine("Agregar Tarea\n");
                            Console.WriteLine("Seleccione una categoria: \n 1. Estudio, 2. Trabajo, 3. Personal");
                            Console.WriteLine("     0. Cancelar");


                            switch (Convert.ToByte(Console.ReadLine()))
                            {
                                case 1:
                                    AñadirTarea(out string nombre, out string detalle, out byte indice);
                                    TareaEstudio.AgregarInfo("Estudio", detalle, indice);

                                    break;
                                case 2:
                                    AñadirTarea(out nombre, out detalle, out indice);
                                    TareaTrabajo.AgregarInfo("Trabajo",  detalle, indice);

                                    break;
                                case 3:
                                    AñadirTarea(out nombre, out detalle, out indice);
                                    TareaPersonal.AgregarInfo("Personal",  detalle, indice);

                                    break;
                                case 4:
                                    Cancelar = true;
                                    break;
                                default:
                                    MensajeError();
                                    return;
                            }
                        } while (!Cancelar);
                        break;
                    case 2:
                        // metodo de ordenacion
                        break;
                    case 3:
                        do
                        {
                            Console.Clear();
                            MostrarTareas();

                            Console.WriteLine("Digite el numero de la tarea");
                            byte nTarea = Convert.ToByte(Console.ReadLine());

                            Console.WriteLine(Tareas[nTarea]);

                            ToDo.MostrarInfo(nTarea); //muestra los detalles de la tarea de ese numero

                            Console.WriteLine("1. Editar tarea      3. Volver");
                            Console.WriteLine("2. Borrar tarea      \n       ");

                            switch (Convert.ToByte(Console.ReadLine()))
                            {
                                case 1:
                                    Console.Write("Ingrese el nuevo título de la tarea: ");
                                    Tareas[nTarea] = Console.ReadLine();
                                    ToDo.EditarInfo(nTarea);
                                    break;
                                case 2:
                                    Tareas[nTarea] = default;
                                    ToDo.BorrarInfo(nTarea);
                                    break;
                                case 3:
                                    Cancelar = true;
                                    break;
                                default:
                                    MensajeError();
                                    break;
                            }
                        } while (!Cancelar);
                        break;
                    case 0:
                        Salir = true;
                        break;
                    default:
                        MensajeError();
                        break;
                }
             }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo.");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos de manera correcta, por favor.");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
                catch (NullReferenceException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
                catch (StackOverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
                catch (TypeInitializationException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
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
        }
        public static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Error! opcion invalida");
            Console.ReadKey();
        } 
        public static void MostrarTareas()
        {
            for (int i = 0; i < Tareas.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Tareas[i]}");
            }
            Console.WriteLine("");
        } 

    }
}