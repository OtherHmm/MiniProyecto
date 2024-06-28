using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto
{
    internal class ToDo_Personal : ToDo
    {
        public ToDo_Personal(string tipo, string nombre, string detalle) : base(tipo, nombre, detalle)
        {
        }
        public override void AgregarInfo(string tipo, string nombre, string detalle)
        {
            base.AgregarInfo(tipo, nombre, detalle);
        }
    }

}
