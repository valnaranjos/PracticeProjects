using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasPendientes
{
    public class GeneradorId
    {
        private const string FilePath = "ultimoId.txt";

        public static int ObtenerNuevoID() 
        {
            int ultimoId = 0;

            if (File.Exists(FilePath))
            {
                int.TryParse(File.ReadAllText(FilePath), out ultimoId);
            }

            ultimoId++;

            File.WriteAllText(FilePath, ultimoId.ToString());

            return ultimoId;
        }
    }
}
