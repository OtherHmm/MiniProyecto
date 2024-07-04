using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiniProyecto
{
    public class Base
    {
        static List<string> ListaTareas = new List<string>(15);

        static ToDo ToDo = new ToDo(default, default, default);
        static ToDo_Personal TareaPersonal = new ToDo_Personal(default, default, default, default);
        static ToDo_Trabajo TareaTrabajo = new ToDo_Trabajo(default, default, default, default);
        static ToDo_Estudio TareaEstudio = new ToDo_Estudio(default, default, default, default);

        static void Main()
        {
            bool Salir = false;

            do
            {
                MostrarMenuPrincipal();

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 0:
                        Salir = true;
                        break;
                    case 1:
                        AgregarTarea();
                        break;
                    case 2:
                        SeleccionarTarea();
                        break;
                    default:
                        MostrarMensajeError("Opcíon Invalida");
                        break;
                }

            } while (!Salir);
        }   // Programa Principal

        // Metodos 
        private static void MostrarTareas() 
        {
            if (ConfirmarTareas() == false)
            {
                Console.WriteLine("No hay tareas :/ ?\n");
                return;
            }
            Console.WriteLine("Lista de tareas\n");
            for (int i = 0; i < ListaTareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ListaTareas[i]}");
            }
            Console.WriteLine("");
        }
        private static void MostrarMenuPrincipal() 
        {
            Console.Clear();
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0");
            Console.WriteLine("|     -                                           -      |");
            Console.WriteLine("*  -    -   .*.*.*.   ¡Bienvenido!  .*.*.*.    -     -   *");
            Console.WriteLine("|-        -                                  -          -|");
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0\n");
            MostrarTareas();
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("|  1. Agregar Tarea                 2. Seleccionar |");
            Console.WriteLine("|                                   0. Salir       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
        }
        private static void MostrarMensajeError(string mensaje)    /* Código para mostrar mensajes de error */
        {
            Console.Clear();
            Console.WriteLine($"Error: {mensaje}");
        }

        // Metodos Opcion Agregar

        private static void AgregarTarea() 
        {
            bool cancelar = false;

            do
            {
                Console.Clear();
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");
                Console.WriteLine("|._.-._.-.._. Agregar Tarea ._.-._.-.._.|");
                Console.WriteLine("*---------------------------------------*");
                Console.WriteLine("|      Seleccione una categoria:        |");
                Console.WriteLine("|1.Estudio   2.Trabajo   3.Personal     |");
                Console.WriteLine("|            0.Cancelar                 |");
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0\n");

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 1:
                        AgregarInfoTarea(TareaEstudio, "Estudio");

                        break;
                    case 2:
                        AgregarInfoTarea(TareaTrabajo, "Trabajo");
                        break;
                    case 3:
                        AgregarInfoTarea(TareaPersonal, "Personal");
                        break;
                    case 0:
                        cancelar = true;
                        break;
                    default:
                        MostrarMensajeError("Opción inválida.");
                        break;
                }
            } while (!cancelar);
        }
        private static void AgregarInfoTarea(ToDo tarea, string tipo)
        {
            string nombre = LeerRespuesta("\nDigite el nombre\n");
            string detalle = LeerRespuesta("\nDigite la descripcion\n");

            tarea.AgregarInfo(tipo, detalle, Convert.ToByte(ListaTareas.Count));
            tarea.AgregarInfoEspecial(Convert.ToByte(ListaTareas.Count),default,default, default);

            ListaTareas.Add(nombre);
            Console.WriteLine("Tarea agregada exitosamente.");
            Console.ReadKey();
        }

        // Metodos Opcion Seleccion

        private static void SeleccionarTarea()  
        {
            if (ConfirmarTareas() == false)
            {
                MostrarMensajeError("No hay tareas para seleccionar.");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            MostrarTareas();

            Console.WriteLine("Digite el número de la tarea");
            if (!byte.TryParse(Console.ReadLine(), out byte nTarea) || nTarea < 1 || nTarea > ListaTareas.Count)
            {
                MostrarMensajeError("Número de tarea inválido.");
                return;
            }

            Console.Clear();
            Console.WriteLine("       -*  TAREA  *-         ");
            Console.WriteLine($"\nTítulo: {ListaTareas[nTarea - 1]}");

            ToDo.MostrarInfo(nTarea-1);

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| 1. Editar tarea                         0. Volver|");
            Console.WriteLine("| 2. Borrar tarea                         \n       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            switch (Convert.ToByte(Console.ReadLine()))
            {
                case 1:
                    EditarTarea(nTarea);
                    break;
                case 2:
                    BorrarTarea(nTarea);
                    break;
                case 0:
                    break;
                default:
                    MostrarMensajeError("Opción inválida.");
                    break;
            }
        }
        private static void EditarTarea(byte nTarea)     
        {
            string nuevoTitulo = LeerRespuesta("Ingrese el nuevo título de la tarea");
            ListaTareas[nTarea - 1] = nuevoTitulo;
            ToDo.EditarInfo(nTarea - 1);

        }
        private static void BorrarTarea(byte nTarea)   
        {
            ListaTareas.RemoveAt(nTarea - 1);
            ToDo.BorrarInfo(nTarea -1);
        }
        private static bool ConfirmarTareas()   /* Código para saber si hay tareas */
        {
            if (ListaTareas.Count == 0)
            {
                return false;
            }
            return true;
        }

        // Metodos Leer

        /*
        public static object LeerOpcion<Loquesea>() // Convierte XP
        {
            switch (Type.GetTypeCode(typeof(Loquesea)))
            {
                case TypeCode.Byte:
                    return (Loquesea)(object)Convert.ToByte(Console.ReadLine());
                case TypeCode.Int32:
                    return (Loquesea)(object)Convert.ToInt32(Console.ReadLine());
                case TypeCode.Boolean:
                    return (Loquesea)(object)Convert.ToBoolean(Console.ReadLine());
                case TypeCode.String:
                    return (Loquesea)(object)Console.ReadLine();
                default:
                    Console.WriteLine("Error");
                    return default;
            }
        }*/
        private static string LeerRespuesta(string mensaje)    /* Código para escriubir algo y leer la respuesta */
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }
    }
}