using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Model
{
    public class Empleado
    {
        private static int _nextId = 1; // Contador estático para IDs

        public int Id { get; set; }

        public string Name {  get; set; }
        public int Age {  get; set; }

        public double Salary { get; set; }
        public bool Status { get; set; }

        public enum Charge
        {
            Base,
            Gerente,
            Desarrollador,
            Analista,
            Administrador
        }
        public Charge Cargo { get; set; }

        public  Empleado(string name, int age, double salary, Charge charge)
        {
            Id = _nextId++;
            Name = name;
            Age = age;
            Salary = salary;
            Cargo = charge;
            Status = true;
        }
    }
}
