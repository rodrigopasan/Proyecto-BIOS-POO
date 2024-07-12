using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    public abstract class Paciente
    {
        private string _NombrePaciente;
        private string _ApellidoPaciente;
        private DateTime _FechaNacimiento;
        private int _NumeroCedula;
        private static HashSet<int> _NumCedUsados;

        public string NombrePaciente
        {
            set { _NombrePaciente = value; } 
        }

        public string ApellidoPaciente
        {
            set { _ApellidoPaciente = value; }
        }
        public DateTime FechaNacimiento
        {
              
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
                if (_NumCedUsados.Contains(value))
                    throw new Exception("el numero de cedula ya existe");
                if (_NumeroCedula != 0)
                    _NumCedUsados.Remove(_NumeroCedula);
                _NumeroCedula = value;
                _NumCedUsados.Add(_NumeroCedula);
            }
        }

        public override string ToString()
        {
            return ($"Nombre: {_NombrePaciente} Apelldio: {_ApellidoPaciente} Numero Cedula: {_NumeroCedula} Fehca Nacimiento {_FechaNacimiento}");
        }
    }
}


