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
        private string _ApellidoPaciente;
        private DateTime _FechaNacimiento;
        private int _NumeroCedula;
        

        public string NombrePaciente
        {
            get { return _NombrePaciente; }
            set { _NombrePaciente = value; } 
        }

        public string ApellidoPaciente
        {
            get { return _ApellidoPaciente; }
            set { _ApellidoPaciente = value; }
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
                if (value <= 0)
                    throw new Exception("El numero de cedula debe de ser numero positivo");
                else
                    _NumeroCedula = value;
            }
        
        }
        //Constructor Completo
        public Paciente(string pNombrePaciente, string pApellidoPaciente, DateTime pFechaNacimiento, int pNumeroCedula)
        {
            NombrePaciente = pNombrePaciente;
            ApellidoPaciente = pApellidoPaciente;
            FechaNacimiento = pFechaNacimiento;
            NumeroCedula = pNumeroCedula;
        }

        public override string ToString()
        {
            return ($"Nombre: {_NombrePaciente} Apelldio: {_ApellidoPaciente} Numero Cedula: {_NumeroCedula} Fehca Nacimiento {_FechaNacimiento}");
        }
    }
}


