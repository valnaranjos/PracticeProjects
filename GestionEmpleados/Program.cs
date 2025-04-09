using GestionEmpleados.Model;
using System;


namespace GestionEmpleados
{
    public class Program
    {
        static Empresa empresa = new();
        static void Main()
        {
           
            empresa.CargarDesdeArchivo();

            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
            }

            empresa.GuardarEnArchivo();
        }

        static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("   ");
                Console.WriteLine("   Menú de empleados:");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Listar empleados");
                Console.WriteLine("3. Buscar empleado por ID");
                Console.WriteLine("4. Cambiar estado de empleado");
                Console.WriteLine("5. Editar empleado");
                Console.WriteLine("6. Eliminar empleado");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        AgregarEmpleado();
                        break;
                    case "2":
                        empresa.ListarEmpleados();
                        break;
                    case "3":
                        BuscarEmpleadoPorId();
                        break;
                    case "4":
                        empresa.CambiarEstadoEmpleado();
                        break;
                    case "5":
                        empresa.EditarEmpleado();
                        break;
                    case "6":
                        empresa.EliminarEmpleado();
                        break;
                    case "7":
                        Console.WriteLine("Saliendo del programa...");
                        empresa.GuardarEnArchivo(); // Guardamos antes de salir
                        Environment.Exit(0); // Finaliza inmediatamente el programa
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("Ingrese el nombre:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Ingrese la edad (en numeros):");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el salario (en numeros):");
            int salary = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el cargo: 1. Empleado base | 2. Gerente | 3. Desarrollador | 4. Analista | 5. Administrador ");
            int cargoIndex = int.Parse(Console.ReadLine());
            Empleado.Charge cargo = (Empleado.Charge)(cargoIndex - 1);

            empresa.AgregarEmpleado(name, age, salary, cargo);
            Console.WriteLine("Empleado agregado con éxito. Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarEmpleadoPorId()
        {
            Console.WriteLine("Ingrese el ID del empleado que desea buscar");
            int id = int.Parse(Console.ReadLine());

            empresa.BuscarEmpleadoPorID(id);
        }
    }
}