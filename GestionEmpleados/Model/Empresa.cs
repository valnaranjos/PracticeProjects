using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Model
{
    public class Empresa
    {
        private List<Empleado> empleados = new();

        public Empresa()
        {
            empleados = [];
        }

        public void AgregarEmpleado(string name, int age, double salary, Empleado.Charge cargo)
        {
            Empleado nuevoEmpleado = new(name, age, salary, cargo);
            empleados.Add(nuevoEmpleado);
            Console.WriteLine($"Empleado agregado: {nuevoEmpleado.Id} - {nuevoEmpleado.Name} ");
        }

        public void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para mostrar.");
                return;
            }

            Console.WriteLine("Lista de empleados:");
            foreach (Empleado emp in empleados)
            {
                Console.WriteLine($"{emp.Id}:{emp.Name} ({emp.Cargo}) - {(emp.Status ? "Activo" : "Inactivo")} ");
            }


            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public void CambiarEstadoEmpleado()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para editar.");
                return;
            }

            Console.WriteLine("Ingrese el ID del empleado");
            int ID = int.Parse(Console.ReadLine());


            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].Id == ID)
                {
                    empleados[i].Status = empleados[i].Status ? false : true;
                    Console.WriteLine($"El estado de {empleados[i].Id} ha sido cambiado a {(empleados[i].Status ? "Activo" : "Inactivo")}");
                }
            }
        }
        public Empleado? BuscarEmpleadoPorID(int id)
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para editar.");
            }

            Empleado? emp = empleados.FirstOrDefault(e => e.Id == id);


            if (emp != null)
            {
                Console.WriteLine($"{emp.Id}: {emp.Name}, {emp.Age} ({emp.Cargo}) - {(emp.Status ? "Activo" : "Inactivo")} - ${emp.Salary}");
            }
            else
            {
                Console.WriteLine($"El empleado con el ID {id} no existe");
            }

            return empleados.FirstOrDefault(e => e.Id == id);
        }

        public void EditarEmpleado()
        {
            Console.WriteLine("Ingrese el ID del empleado que desea editar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Empleado? emp = BuscarEmpleadoPorID(id);

            if (emp == null)
            {
                Console.WriteLine($"No se encontró un empleado con el ID {id}.");
                return;
            }

            Console.WriteLine($"Editando a: {emp.Id}:{emp.Name}, {emp.Age} ({emp.Cargo}) - {(emp.Status ? "Activo" : "Inactivo")} - ${emp.Salary}");

            Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
            string nuevoNombre = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                emp.Name = nuevoNombre;

            Console.Write("Nueva edad (dejar vacío para no cambiar): ");
            string nuevaEdad = Console.ReadLine() ?? "";
            if (int.TryParse(nuevaEdad, out int edad))
                emp.Age = edad;

            Console.Write("Nuevo salario (dejar vacío para no cambiar): ");
            string nuevoSalario = Console.ReadLine() ?? "";
            if (double.TryParse(nuevoSalario, out double salario))
                emp.Salary = salario;

            Console.WriteLine("Empleado actualizado correctamente.");
        }

        public void EliminarEmpleado()
        {
            Console.WriteLine("Ingrese el ID del empleado que desea editar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Empleado? emp = BuscarEmpleadoPorID(id);

            if (emp == null)
            {
                Console.WriteLine($"No se encontró un empleado con el ID {id}.");
                return;
            }

            empleados.Remove(emp);
            Console.WriteLine($"Empleado {id} fue eliminado correctamente");
        }

        public void GuardarEnArchivo()
        {
            using (StreamWriter writer = new StreamWriter("empleados.txt"))
            {
                foreach (var emp in empleados)
                {
                    writer.WriteLine($"{emp.Id};{emp.Name};{emp.Age};{emp.Cargo};{emp.Salary};{emp.Status}");
                }
            }

            Console.WriteLine("Empleados guardados correctamente.");
        }

        public void CargarDesdeArchivo()
        {
            if (!File.Exists("empleados.txt"))
            {
                Console.WriteLine("No hay archivo de empleados para cargar.");
                return;
            }

            string[] lineas = File.ReadAllLines("empleados.txt");
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(';');

                int id = int.Parse(datos[0]);
                string name = datos[1];
                int age = int.Parse(datos[2]);

                Empleado.Charge cargo = Enum.Parse<Empleado.Charge>(datos[3]);
                double salary = double.Parse(datos[4]);
                bool status = bool.Parse(datos[5]);

                Empleado emp = new Empleado(name, age, salary, cargo)
                {
                    Id = id,
                    Status = status
                };

                empleados.Add(emp);
            }

            Console.WriteLine("Empleados cargados correctamente.");    

        }
    }
}
