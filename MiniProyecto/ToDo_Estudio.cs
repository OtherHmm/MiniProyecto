using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        public ToDo_Estudio(string tipo, string detalle, byte nTarea) : base(tipo, detalle, nTarea)
        {

        }
        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
    }
}
