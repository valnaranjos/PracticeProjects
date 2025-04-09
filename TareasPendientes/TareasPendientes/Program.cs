using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

 namespace TareasPendientes
{
    public class Program
    {
        static readonly List<Tarea> listaTareas = [];
        static void Main()
        {
            File.WriteAllText("ultimoId.txt", "0");
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ =====");
                Console.WriteLine("1. Agregar tarea ");
                Console.WriteLine("2. Ver todas las tareas");
                Console.WriteLine("3. Marcar tarea como completa");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        VerTareas();
                        break;
                    case "3":
                        CambiarEstado();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "5":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AgregarTarea()
        {
            string descripcion = "";

            do
            {
                Console.WriteLine("Ingrese la descripción de la tarea (max 100 caracteres)");
                descripcion = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(descripcion) || descripcion.Length > 100)
                {
                    Console.WriteLine("La descripción debe tener entre 1 y 100 carácteres");

                }
            }
            while (string.IsNullOrEmpty(descripcion) || descripcion.Length > 100);


            Tarea nuevaTarea = new(descripcion);

            listaTareas.Add(nuevaTarea);

            Console.WriteLine("Tarea agregada con éxito.Presiona una tecla para continuar...");
        
            Console.ReadKey();
        }

        static void VerTareas()
        {
            if(listaTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para mostrar.");
            }
            Console.WriteLine("Lista de tareas: ");

            foreach (Tarea t in listaTareas)
            {
                Console.WriteLine($"{t.Id}.{t.Descripcion}: {t.Estado}");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        static void CambiarEstado()
        {
            Console.WriteLine("Ingrese el # de la tarea que desea cambiar estado");
            int tarea = int.Parse(Console.ReadLine());

            for (int i = 0; i < listaTareas.Count; i++)
            {
                if (listaTareas[i].Id == tarea)
                {
                    listaTareas[i].Estado = "Completada";
                    Console.WriteLine($"Estado de la tarea {tarea}. {listaTareas[i].Descripcion} ha sido cambiado a Completada.)");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar... ");
            Console.ReadKey();
        }

        static void EliminarTarea()
        {
            Console.WriteLine("Ingrese el # de la tarea que desea eliminar");
            int tarea = 0; int.Parse(Console.ReadLine());

            Tarea tareaAEliminar = listaTareas.FirstOrDefault(t => t.Id == tarea);

            if (tareaAEliminar == null)
            {
                Console.WriteLine("Tarea no encontrada. Presiona una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"¿Está seguro de eliminar la tarea \"{tareaAEliminar.Descripcion}\"? (S/N)");
            string confirmacion = Console.ReadLine()?.ToUpper();

            if (confirmacion == "S")
            {
                listaTareas.Remove(tareaAEliminar);
                Console.WriteLine("Tarea eliminada con éxito. Presiona una tecla para continuar...");
            }
            else
            {
                Console.WriteLine("Operación cancelada. Presiona una tecla para continuar...");
            }

            Console.ReadKey();
        }

    }
}

