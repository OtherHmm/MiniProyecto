using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        /*

        public string Materia;

        public To_doEstudio(string titulo, string materia) : base(titulo)
        {
            Materia = materia;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Materia: {Materia}");
        }
    */
        public ToDo_Estudio(string tipo, string nombre, string detalle) : base(tipo, nombre, detalle)
        {
        }
    }
}
