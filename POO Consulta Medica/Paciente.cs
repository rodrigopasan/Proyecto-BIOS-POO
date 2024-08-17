using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Paciente
    {
        private string _NombrePaciente;
        private DateTime _FechaNacimiento;
        private int _NumeroCedula;
        private bool _TieneSolicitud;
        

        public string NombrePaciente
        {
            get { return _NombrePaciente; }
            set
            {
                var listacaracteres = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "@", "#", "$", "%", "/", "(", ")", "=", "?", "¿", "!", "¡", "|" };
                foreach (var c in listacaracteres)
                {
                    value = value.Replace(c, string.Empty);
                }
                if (value.Trim().Length > 5)
                {          
                    _NombrePaciente = value;
                }
                else
                    throw new Exception("El nombre completo del paciente debe ser mayor de 5 letras...");
           } 
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento;  } 
            set
            {
                if (value > DateTime.Today)
                    throw new Exception("Fecha de nacimiento no valida");
                else
                    _FechaNacimiento = value;
            }
            
        }
        public int NumeroCedula
        {
            get { return _NumeroCedula; }
            set
            {
                if (value.ToString().Trim().Length == 7 || value.ToString().Trim().Length == 8)
                    _NumeroCedula = value;
                else
                    throw new Exception("La cedula son 7 u 8 digitos");
            }
        }
        public bool TieneSolicitud
        {
            get { return _TieneSolicitud; }
            set { _TieneSolicitud = value; }
        }
        //Constructor Completo
        public Paciente(string pNombrePaciente, DateTime pFechaNacimiento, int pNumeroCedula, bool pTieneSolicitud)
        {
            NombrePaciente = pNombrePaciente;
            FechaNacimiento = pFechaNacimiento;
            NumeroCedula = pNumeroCedula;
            TieneSolicitud = pTieneSolicitud;
        }

        public override string ToString()
        {
            return ($"Nombre: {_NombrePaciente}, Cedula: {_NumeroCedula}, Fecha Nacimiento {_FechaNacimiento.Day}/{_FechaNacimiento.Month}/{_FechaNacimiento.Year}");
        }
    }
}


