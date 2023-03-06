using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDI_GestionEmpresa.Modelo
{
    public class Tutor
    {
        // Campos de la clase Tutor
        public int idTutor { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

        // Constructor completo de la clase Tutor
        public Tutor(int idTutor, string nombre, string email, string telefono)
        {
            this.idTutor = idTutor;
            this.nombre = nombre;
            this.email = email;
            this.telefono = telefono;
        }
    }
}