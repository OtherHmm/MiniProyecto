using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        string materia;
        public ToDo_Estudio(string tipo, string detalle, byte nTarea, string fecha, string materia) : base(tipo, detalle, nTarea, fecha)
        {
            this.materia = materia;
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            base.AgregarInfo(tipo, detalle, nTarea, fecha);
        }

        public void PreguntarInfo()
        {
            Console.WriteLine("De que materia es tu tarea?");
            materia = Console.ReadLine();
 
        }
    }
}
