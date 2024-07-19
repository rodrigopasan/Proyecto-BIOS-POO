using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Especialista: Consulta
    {
        private string _Especialidad;

        public string Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }

        // Constructor
        public Especialista(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, int _NumeroInterno, bool _Asistencia, string _Especialidad)
            :base(_NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros, _NumeroInterno, _Asistencia)
        {
            _Especialidad = Especialidad;
        }


        public override string ToString()
        {
            return $"Consulta Especialista ({NumeroConsultorio} - {FechaHora} - Dr {NombreMedico} - {CantidadNumeros} - {Asistencia} - {Especialidad})";
        }
    }
}
