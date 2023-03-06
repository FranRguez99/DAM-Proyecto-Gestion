using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDI_GestionEmpresa.Modelo
{
    public class Asignacion
    {
        public int idAsignacion { get; set; }

        public int idAlumno { get; set; }

        public int idEmpresa { get; set; }

        public int idTutor { get; set; }

        public string nombreAlumno { get; set; }

        public string nombreEmpresa { get; set; }

        public string nombreTutor { get; set; }


        public Asignacion()
        {
            
        }

        public Asignacion(int idAsignacion, int idAlumno, int idEmpresa, int idTutor)
        {
            this.idAsignacion = idAsignacion;
            this.idAlumno = idAlumno;
            this.idEmpresa = idEmpresa;
            this.idTutor = idTutor;
        }
        public Asignacion(string nombreAlumno, string nombreEmpresa, string nombreTutor)
        {
            this.nombreAlumno = nombreAlumno;
            this.nombreEmpresa = nombreEmpresa;
            this.nombreTutor = nombreTutor;
        }

    }
}


    

