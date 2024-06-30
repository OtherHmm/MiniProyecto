﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto
{
    internal class ToDo_Personal : ToDo
    {
        byte prioridad;
        public ToDo_Personal(string tipo, string detalle, byte nTarea, string fecha, byte prioridad) : base(tipo, detalle, nTarea, fecha)
        {
            this.prioridad = prioridad;
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            base.AgregarInfo(tipo, detalle, nTarea, fecha);
        }

        public void PreguntarInfoPersonal()
        {
            Console.WriteLine("Cual es la prioridad de tu tarea?");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Intermedia");
            Console.WriteLine("3. Baja");
           
            prioridad = Convert.ToByte(Console.ReadLine());
        }
    }

}
