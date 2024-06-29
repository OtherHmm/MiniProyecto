using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        public ToDo_Estudio(string tipo, string nombre, string detalle) : base(tipo, nombre, detalle)
        {

        }
        public override void AgregarInfo(string tipo, string nombre, string detalle)
        {
            base.AgregarInfo(tipo, nombre, detalle);
        }
    }
}
