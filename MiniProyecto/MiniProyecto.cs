using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProyecto
{
    public class MiniProyecto
    {
        static void Main()
        {
            bool Salir = false;

            while (!Salir)
            {
                Gestor.MostrarMenuInicio(out Salir);
            }
        }
    }
    static public class Gestor
    {
        public static Dictionary<int, ToDo> Tareas = new Dictionary<int, ToDo>(15);

        public static Dictionary<int, ToDo> Actualizar() // volver a poder los indices para que todo quede en orden
        {
            int indice = 1;
            var nuevasTareas = new Dictionary<int, ToDo>();

            foreach (var toDo in Tareas)
            {
                nuevasTareas.Add(indice, toDo.Value);
                indice++;
            }
            return nuevasTareas;
        }

        private static void TareaCrear(out bool salir)
        {
            salir = false;
            while (Tareas.Count <= 15 || salir == false)
            {
                MostrarTareas("\nNo hay tareas :/ ?\n\nAgrega una escribiendo y al terminar ENTER ;D");

                string toDo = Console.ReadLine();
                if (string.IsNullOrEmpty(toDo) || toDo == "0")
                {
                    salir = true;
                }
                else if (int.TryParse(toDo, out int indice) && Tareas.ContainsKey(indice - 1))
                {
                    TareaElegir(indice - 1);
                }
                else
                {
                    Tareas.Add(Tareas.Count, new ToDo(toDo, default, default));
                    Console.Clear();
                }
            }
            salir = false;
        }
        private static void TareaElegir(int indice)
        {
            Console.Clear();
            MostrarTareas(sinTareas: "No hay tareas para seleccionar :[");
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("                  -*  TAREA  *-                      ");
                MostrarTareaDetalles(Tareas[indice]);
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("| 1. Editar tarea                         0. Volver |");
                Console.WriteLine("| 2. Borrar tarea                                   |");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 0:
                        Console.WriteLine("bye...");
                        salir = true;
                        Console.Clear();
                        break;
                    case 1:
                        TareaEditar(indice);
                        break;
                    case 2:
                        TareaBorrar(indice);
                        break;
                    default:
                        MostrarMensajeError("Opción inválida.");
                        break;
                }
            }
        }
        private static void TareaEditar(int key)
        {
            if (key != default)
            {
                Console.WriteLine("Ingrese una descripcion: ");
                string detalle = Console.ReadLine();
                MostrarMenuTareaTipo();
                Tareas[key].Tipo = Console.ReadLine();
                Tareas[key].Detalle = detalle;
            }
            else
            {
                Console.WriteLine("La tarea no existe.");
            }
        }
        private static void TareaBorrar(int key)
        {
            Tareas.Remove(key);
            Console.WriteLine("¡Tarea Eliminada con éxito!");
        }

        public static void MostrarMenuInicio(out bool salir)
        {
            Console.Clear();
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0");
            Console.WriteLine("|     -                                           -      |");
            Console.WriteLine("*  -    -   .*.*.*.   ¡Bienvenido!  .*.*.*.    -     -   *");
            Console.WriteLine("|-        -                                  -          -|");
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0---0---0---0---0\n");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("|  (indice). Para seleccionar una tarea         0. Salir |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            TareaCrear(out salir);
        }
        private static void MostrarTareas(string sinTareas = "No hay tareas :/ ?\nAgrega una ;D")
        {
            if (Tareas.Count == 0)
            {
                Console.WriteLine($"{sinTareas}\n");
                return;
            }

            Console.WriteLine("Lista de tareas\n");
            foreach (var toDo in Tareas)
            {
                Console.WriteLine($"{toDo.Key + 1}. {toDo.Value.Nombre}");
            }
            Console.WriteLine("");
        }

        private static void MostrarMenuTareaTipo()
        {
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0");
            Console.WriteLine("|._.-.  Seleccione una categoria: .-.._.|");
            Console.WriteLine("*---------------------------------------*");
            Console.WriteLine("|1.Estudio   2.Trabajo   3.Personal     |");
            Console.WriteLine("|            0.Cancelar                 |");
            Console.WriteLine("0---0---0---0---0---0---0---0---0---0---0\n");
        }
        private static void MostrarTareaDetalles(ToDo to_doValue)
        {
            Console.WriteLine($"\nTítulo: {to_doValue.Nombre}       ");
            Console.WriteLine($"Tipo: {to_doValue.Tipo}");
            Console.WriteLine($"\nDescripcion: {to_doValue.Detalle}  ");
            Console.WriteLine($"\nPrioridad: {to_doValue.Prioridad}");
        }
        private static void MostrarMensajeError(string mensaje)
        {
            Console.Clear();
            Console.WriteLine($"Error: {mensaje}");
        }
        private static void MostrarTareaDetallesExtra(ToDo tarea)
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

        private static void AgregarInfoExtra(out string materia)
        {
            Console.WriteLine("De que materia es tu tarea?");
            materia = Console.ReadLine();
        } // tipo tarea
        private static void AgregarInfoExtra(out int prioridad)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("|       Cual es la prioridad de tu tarea?         |");
            Console.WriteLine("--------------------------------------------------|");
            Console.WriteLine("|1. Alta                                          |");
            Console.WriteLine("|                 2. Intermedia                   |");
            Console.WriteLine("|                                   3. Baja       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            prioridad = Convert.ToByte(Console.ReadLine());
        } // tipo personal
        private static void AgregarInfoExtra(out char tipo)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| Su tarea pendiente es para oficina (proyecto) o cliente?|");
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine("|1. Proyecto de oficina                                   |");
            Console.WriteLine("|                             2. Cliente                  |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            tipo = Convert.ToChar(Console.ReadLine());
        } // tipo trabajo
    }
}