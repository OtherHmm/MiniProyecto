using System;
namespace MiniProyecto
{
    public class ToDo_Estudio : ToDo
    {
        string Materia;
        public ToDo_Estudio(string tipo, string detalle, int nTarea, string materia) : base(tipo, detalle, nTarea)
        {
            Materia = materia;
        }
        public override void AgregarInfoEspecial(int nTarea, string materia = null, byte prioridad = 0, byte trabajoTarea = 0)
        {
            Console.WriteLine("De que materia es tu tarea?");
            Materia = Console.ReadLine();

            base.AgregarInfoEspecial(nTarea, Materia, prioridad, trabajoTarea);
        }
        public override void MostrarInfo(int nTarea)
        {
            base.MostrarInfo(nTarea);
            Console.WriteLine($"\nMateria: {Materia}\n");
        }
        public override void EditarInfo(int nTarea)
        {
            base.EditarInfo(nTarea);
            Console.Write("Ingrese la nueva materia de la tarea (si aplica): ");
            Tareas[nTarea].Materia = Console.ReadLine();
        }
    }
}
