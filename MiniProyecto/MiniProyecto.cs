using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace MiniProyecto
{
    public class MiniProyecto
    {
        static void Main()
        {
            bool Salir = false;

            while (!Salir)
            {
                Gestor.MostrarMenuInicio();
            }
        }

        static public class Gestor
        {
            public static Dictionary<byte, To_do> Tareas = new Dictionary<byte, To_do>(15);

            public static void MostrarMenuInicio()
            {
                Console.Clear();
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0");
                Console.WriteLine("|     -                                           -      |");
                Console.WriteLine("*  -    -   .*.*.*.   ¡Bienvenido!  .*.*.*.    -     -   *");
                Console.WriteLine("|-        -                                  -          -|");
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0\n");
                MostrarTareas();
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                Console.WriteLine("|                                   2. Seleccionar |");
                Console.WriteLine("|                                   0. Salir       |");
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            }
            private static void MostrarTareas(string sinTareas = "No hay tareas :/ ?")
            {
                if (Tareas.Count == 0)
                {
                    Console.WriteLine($"{sinTareas}\n");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Lista de tareas\n");
                var tareas = Tareas.Keys.ToList();
                for (int i = 0; i < tareas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tareas[i]}");
                }

                Console.WriteLine("");
                while (true)
                {
                    bool salir = CrearTarea();
                    if (salir== true)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }
            private static bool CrearTarea() // hacer que tengan indice las tareas
            {
                Console.WriteLine("Escribe y luego ENTER para agregar tarea");
                while (Tareas.Count <= 15)
                {
                    Console.Write("Que tienes en mente? ...\t");
                    string to_do = Console.ReadLine();

                    if (string.IsNullOrEmpty(to_do) == true || to_do == "0")
                    {
                        return true;
                    }

                    Tareas.Add(to_do, new To_do(default, default));
                }
                return false;
            }



            public static To_do BuscarTarea(int indice)
            {
                string NombreTarea = Tareas.Keys.ToList().ElementAtOrDefault(indice).ToString();
                return Tareas.TryGetValue(NombreTarea, out To_do tarea) ? tarea : default;
            }
            public static string BuscarKey(To_do valorTarea)
            {
                foreach (var tarea in Tareas)
                {
                    if (tarea.Value == valorTarea)
                    {
                        return tarea.Key;
                    }
                }
                return default;
            }
            public static void EditarInfo(string key)
            {
                if (key != default)
                {
                    Console.Write("Ingrese el nuevo tipo de la tarea: ");
                    Tareas[key].Tipo = Console.ReadLine();
                    Console.Write("Ingrese la nueva descripción de la tarea: ");
                    Tareas[key].Detalle = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("La tarea no existe.");
                }
            }
            public static void AgregarTarea()
            {
                Console.WriteLine("Editando tarea");
                Console.WriteLine("Ingrese una desripcion");
                string detalle = Console.ReadLine();
                MostrarMenuAgregarTarea();
                string tipo = Console.ReadLine();

                byte prioridad = 1;
                string materia = "ojdoj";
                byte trabajaotarea = 2;

                switch (tipo)
                {
                    case "1":
                        materia = "ojdoj";
                        break;
                    case "2":
                        trabajaotarea = 2;
                        break;
                    default:
                        break;
                }

                Tareas.Add(nombre, new To_do(tipo, detalle, materia, prioridad, trabajaotarea));
            }
            public static void MostrarMenuAgregarTarea()
            {
                Console.Clear();
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");
                Console.WriteLine("|._.-._.-.._.  Editar Tarea ._.-._.-.._.|");
                Console.WriteLine("*---------------------------------------*");
                Console.WriteLine("|      Seleccione una categoria:        |");
                Console.WriteLine("|1.Estudio   2.Trabajo   3.Personal     |");
                Console.WriteLine("|            0.Cancelar                 |");
                Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0\n");
            }
            public static void MostrarInfo(To_do tarea)
            {
                if (tarea == default)
                {
                    Console.WriteLine("La tarea no existe.");
                }
                else
                {
                    Console.WriteLine($"\nCategoria:    {tarea.Tipo}");
                    Console.WriteLine($"\nDescripcion:\n{tarea.Detalle}");
                }
            }
            public static void BorrarInfo(string key)
            {
                Tareas.Remove(key);
                Console.WriteLine("¡Tarea Eliminada con éxito!");
                Console.ReadKey();
            }
            private static void MostrarMensajeError(string mensaje)    /* Código para mostrar mensajes de error */
            {
                Console.Clear();
                Console.WriteLine($"Error: {mensaje}");
            }

            // Metodos Opcion Seleccion

            private static void SeleccionarTarea()
            {
                Console.Clear();
                MostrarTareas(sinTareas: "No hay tareas para seleccionar :[");

                Console.WriteLine("Digite el número de la tarea");
                if (!byte.TryParse(Console.ReadLine(), out byte nTarea) || nTarea < 1 || nTarea > ListaTareas.Capacity)
                {
                    MostrarMensajeError("Número de tarea inválido.");
                    return;
                }

                Console.Clear();
                Console.WriteLine("       -*  TAREA  *-         ");
                Console.WriteLine($"\nTítulo: {ListaTareas[nTarea - 1]}");

                ToDo.MostrarInfo(nTarea - 1);

                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                Console.WriteLine("| 1. Editar tarea                         0. Volver|");
                Console.WriteLine("| 2. Borrar tarea                         \n       |");
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 0:
                        Console.WriteLine("bye...");
                        break;
                    case 1:
                        EditarTarea(nTarea);
                        break;
                    case 2:
                        BorrarTarea(nTarea);
                        break;
                    default:
                        MostrarMensajeError("Opción inválida.");
                        break;
                }
            }

            /*
            public Gestor(string tipo, string detalle, int nTarea, string materia = default, byte prioridad = default, byte trabajoTarea = default)
            {
                if (Tareas.Count <= nTarea)
                {
                    Tareas.Add(new Tarea(tipo, detalle, materia, prioridad, trabajoTarea));
                }
                else
                {
                    Tareas[nTarea] = new Tarea(tipo, detalle, materia, prioridad, trabajoTarea);
                }
            }
            */
        }
        /*
        public static List<string> ListaTareas = new List<string>(15);

        static ToDo ToDo = new ToDo(default, default, default);
        static ToDo_Personal TareaPersonal = new ToDo_Personal(default, default, default, default);
        static ToDo_Trabajo TareaTrabajo = new ToDo_Trabajo(default, default, default, default);
        static ToDo_Estudio TareaEstudio = new ToDo_Estudio(default, default, default, default);
        */
        /*
        // Metodos 
        private static void MostrarTareas(string sinohaytareas = "No hay tareas :/ ?")
        {
            if (ListaTareas.Count == 0)
            {
                Console.WriteLine($"{sinohaytareas}\n");
                Console.ReadKey();
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
        private static void MostrarMenuAgregarTarea()
        {
            Console.Clear();
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");
            Console.WriteLine("|._.-._.-.._. Agregar Tarea ._.-._.-.._.|");
            Console.WriteLine("*---------------------------------------*");
            Console.WriteLine("|      Seleccione una categoria:        |");
            Console.WriteLine("|1.Estudio   2.Trabajo   3.Personal     |");
            Console.WriteLine("|            0.Cancelar                 |");
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0\n");
        }
        private static void MostrarMensajeError(string mensaje)    // Código para mostrar mensajes de error
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
                MostrarMenuAgregarTarea();

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 0:
                        cancelar = true;
                        break;
                    case 1:
                        AgregarInfoTarea(TareaEstudio, "Estudio");
                        break;
                    case 2:
                        AgregarInfoTarea(TareaTrabajo, "Trabajo");
                        break;
                    case 3:
                        AgregarInfoTarea(TareaPersonal, "Personal");
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
            tarea.AgregarInfoEspecial(Convert.ToByte(ListaTareas.Count), default, default, default);

            ListaTareas.Add(nombre);
            Console.WriteLine("Tarea agregada exitosamente.");
            Console.ReadKey();
        }

        // Metodos Opcion Seleccion

        private static void SeleccionarTarea()
        {
            Console.Clear();
            MostrarTareas(sinohaytareas: "No hay tareas para seleccionar :[");

            Console.WriteLine("Digite el número de la tarea");
            if (!byte.TryParse(Console.ReadLine(), out byte nTarea) || nTarea < 1 || nTarea > ListaTareas.Capacity)
            {
                MostrarMensajeError("Número de tarea inválido.");
                return;
            }

            Console.Clear();
            Console.WriteLine("       -*  TAREA  *-         ");
            Console.WriteLine($"\nTítulo: {ListaTareas[nTarea - 1]}");

            ToDo.MostrarInfo(nTarea - 1);

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| 1. Editar tarea                         0. Volver|");
            Console.WriteLine("| 2. Borrar tarea                         \n       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            switch (Convert.ToByte(Console.ReadLine()))
            {
                case 0:
                    Console.WriteLine("bye...");
                    break;
                case 1:
                    EditarTarea(nTarea);
                    break;
                case 2:
                    BorrarTarea(nTarea);
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
            ToDo.BorrarInfo(nTarea - 1);
        }

        // Metodos Leer

        private static string LeerRespuesta(string mensaje)    // Código para escriubir algo y leer la respuesta
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }*/
    }
}