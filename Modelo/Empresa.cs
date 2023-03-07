using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDI_GestionEmpresa.Modelo
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string cif { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public string localidad { get; set; }
        public string jornada { get; set; }
        public string modalidad { get; set; }
        public string mail { get; set; }
        public string dniRepLegal { get; set; }
        public string nombreRepLegal { get; set; }
        public string apellidoRepLegal { get; set; }
        public string dniTutLab { get; set; }
        public string nombreTutLab { get; set; }
        public string apellidoTutLab { get; set; }
        public string telefonoTutLab { get; set; }

        public Empresa(int idEmpresa, string cif, string nombre, string direccion, string codPostal, string localidad,
                       string jornada, string modalidad, string mail, string dniRepLegal, string nombreRepLegal,
                       string apellidoRepLegal, string dniTutLab, string nombreTutLab, string apellidoTutLab,
                       string telefonoTutLab)
        {
            this.idEmpresa = idEmpresa;
            this.cif = cif;
            this.nombre = nombre;
            this.direccion = direccion;
            this.codPostal = codPostal;
            this.localidad = localidad;
            this.jornada = jornada;
            this.modalidad = modalidad;
            this.mail = mail;
            this.dniRepLegal = dniRepLegal;
            this.nombreRepLegal = nombreRepLegal;
            this.apellidoRepLegal = apellidoRepLegal;
            this.dniTutLab = dniTutLab;
            this.nombreTutLab = nombreTutLab;
            this.apellidoTutLab = apellidoTutLab;
            this.telefonoTutLab = telefonoTutLab;
        }


        public Empresa(string cif, string nombre, string direccion, string codPostal, string localidad,
                       string jornada, string modalidad, string mail, string dniRepLegal, string nombreRepLegal,
                       string apellidoRepLegal, string dniTutLab, string nombreTutLab, string apellidoTutLab,
                       string telefonoTutLab)
        {
            this.cif = cif;
            this.nombre = nombre;
            this.direccion = direccion;
            this.codPostal = codPostal;
            this.localidad = localidad;
            this.jornada = jornada;
            this.modalidad = modalidad;
            this.mail = mail;
            this.dniRepLegal = dniRepLegal;
            this.nombreRepLegal = nombreRepLegal;
            this.apellidoRepLegal = apellidoRepLegal;
            this.dniTutLab = dniTutLab;
            this.nombreTutLab = nombreTutLab;
            this.apellidoTutLab = apellidoTutLab;
            this.telefonoTutLab = telefonoTutLab;
        }
    }

}
