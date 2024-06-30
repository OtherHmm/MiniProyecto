using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        string materia;
        public ToDo_Estudio(string tipo, string detalle, byte nTarea, string materia) : base(tipo, detalle, nTarea)
        {
            this.materia = materia;
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }

        public void PreguntarInfo()
        {
            Console.WriteLine("De que materia es tu tarea?");
            materia = Console.ReadLine();
 
        }
    }
}
