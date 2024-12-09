public class ToDo
{
    public string Nombre {  get; set; }
    public string Detalle { get; set; }
    public string Tipo { get; set; }
    public string Materia { get; set; } // Para tareas de estudio
    public byte Prioridad { get; set; } // Para tareas personales
    public byte TrabajoTarea { get; set; } // Para tareas de trabajo

    public ToDo(string nombre, string detalle, string tipo, string materia = default, byte prioridad = default, byte trabajoTarea = default)
    {
        Nombre = nombre;
        Detalle = detalle;
        Tipo = tipo;
        Materia = materia;
        Prioridad = prioridad;
        TrabajoTarea = trabajoTarea;
    }
}