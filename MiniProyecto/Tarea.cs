public class Tarea
{
    public string Tipo { get; set; }
    public string Detalle { get; set; }
    public string Materia { get; set; } // Para tareas de estudio
    public byte Prioridad { get; set; } // Para tareas personales
    public byte TrabajoTarea { get; set; } // Para tareas de trabajo

    public Tarea(string tipo, string detalle, string materia = null, byte prioridad = default, byte trabajoTarea = default)
    {
        Tipo = tipo;
        Detalle = detalle;
        Materia = materia;
        Prioridad = prioridad;
        TrabajoTarea = trabajoTarea;
    }
}