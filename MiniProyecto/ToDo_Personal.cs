using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto
{
    internal class ToDo_Personal : ToDo
    {
        public ToDo_Personal(string tipo, string detalle, byte nTarea) : base(tipo, detalle, nTarea)
        {
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
    }

}
