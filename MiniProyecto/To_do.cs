using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto
{
    public class To_do
    {
        public string Titulo;
        public string Descripcion;
        public string Categoria;
        public bool Estado;

        public To_do(string titulo)
        {
            Titulo = titulo;
            Estado = false;
        }

        public void Completar()
        {
            Estado = true;
            Console.WriteLine("Tarea Completada");
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Categoría: {Categoria}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}