using System;
namespace MiniProyecto
{
    public class ToDo_Estudio : ToDo
    {
        string Materia;
        public ToDo_Estudio(string tipo, string detalle, byte nTarea, string materia) : base(tipo, detalle, nTarea)
        {
            Materia = materia;
        }
        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
        public void PreguntarInfo()
        {
            Console.WriteLine("De que materia es tu tarea?");
            Materia = Console.ReadLine();
        }
        public override void MostrarInfo(byte nTarea)
        {
            base.MostrarInfo(nTarea);
            Console.WriteLine($"\nMateria: {Materia}\n");
        }
    }
}
