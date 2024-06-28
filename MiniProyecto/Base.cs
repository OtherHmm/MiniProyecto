﻿using System;
using System.Reflection.Emit;

namespace MiniProyecto
{
    public class Base
    {
        static void Main()
        {
            string Nombre = default;
            string Tipo = default;
            string Detalle = default;

            bool Salir = false;
            bool Cancelar = false;

            ToDo            ToDo            = new ToDo          (Nombre, Tipo, Detalle);
            ToDo_Personal   TareaPersonal   = new ToDo_Personal (Nombre, Tipo, Detalle);
            ToDo_Trabajo    TareaTrabajo    = new ToDo_Trabajo  (Nombre, Tipo, Detalle);
            ToDo_Estudio    TareaEstudio    = new ToDo_Estudio  (Nombre, Tipo, Detalle);

            do
            {
                // bienvenida

                Console.WriteLine("Lista de tareas\n");
                Console.WriteLine("Para seleccionar y ver detalles de uan tarea digite el numero de la tarea");

                // lista de tareas

                ToDo.MostrarTareas();

                // menú de opciones
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("a. Agregar Tarea     c. Salir");
                Console.WriteLine("b. Ordenar Tareas    \n      ");

                if (Convert.ToByte(Console.ReadLine()) < 16 && Convert.ToByte(Console.ReadLine()) > 0)
                {
                    do
                    {
                        ToDo.MostrarInfo();

                        Console.WriteLine("1. Editar tarea");
                        Console.WriteLine("2. Borrar tarea");
                        Console.WriteLine("3. Volver");

                        switch (Convert.ToByte(Console.ReadLine()))
                        {
                            case 1:
                                // Editar
                                break;
                            case 2:
                                ToDo.BorrarInfo(Convert.ToByte(Console.ReadLine()));
                                break;
                            case 3:
                                Cancelar = true;
                                break;
                            default:
                                break;
                        }
                    } while (!Cancelar);
                    

                }
                switch (Console.ReadLine())
                {
                    case "c":
                        Salir = true;
                        break;
                    case "a":
                        do
                        {
                            Console.WriteLine("Agregar Tarea\n");

                            Console.WriteLine("Seleccione una categoria: \n 1. Estudio, 2. Trabajo, 3. Personal");
                            Console.WriteLine("     0. Cancelar");

                            string nombre;
                            string detalle;

                            switch (Convert.ToByte(Console.ReadLine()))
                            {
                                case 1:
                                    CompletarInfo(out nombre, out detalle);
                                    TareaEstudio.AgregarInfo("Estudio", nombre, detalle);
                                    break;
                                case 2:
                                    CompletarInfo(out nombre, out detalle);
                                    TareaTrabajo.AgregarInfo("Trabajo", nombre, detalle);
                                    break;
                                case 3:
                                    CompletarInfo(out nombre, out detalle);
                                    TareaPersonal.AgregarInfo("Trabajo", nombre, detalle);
                                    break;
                                case 4:

                                    Cancelar = true;
                                    break;

                                default:
                                    Console.WriteLine("Tipo de tarea no válido.");
                                    return;
                            }
                        } while (!Cancelar);
                        break;
                    case "b":
                        break;
                    default:
                        MensajeError();
                        break;
                }

            } while (!Salir);

        }

        // Metodos

        public static void CompletarInfo(out string nombre, out string detalle) // utilizado al agregar tareas
        {
            Console.WriteLine("Digite el nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite la descripcion");
            detalle = Console.ReadLine();
        }

        public static void EditarTarea()
        {
            Console.WriteLine("Ingrese el título de la tarea a editar:");
            string tarea = Compendio.BuscarTarea(Console.ReadLine());

            if (tarea != null)
            {
                Compendio.EditarTarea(tarea);
                Console.WriteLine("Tarea Editada.");
            }
        }
        public static void OrdenarTareas()
        {

        }
        public static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Error! opcion invalida");
            Console.ReadKey();
        }
    }
}