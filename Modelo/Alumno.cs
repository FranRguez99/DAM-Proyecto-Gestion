using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDI_GestionEmpresa.Modelo
{
    public class Alumno
    {
        // Campos de la clase Alumno
        public int IdAlumno { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Constructor completo de la clase Alumno
        public Alumno(int idAlumno, string dni, string nombre, string apellido, DateTime fechaNacimiento)
        {
            IdAlumno = idAlumno;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }

    }
}
