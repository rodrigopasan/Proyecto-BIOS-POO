using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Comun: Consulta
    {
        private bool _TieneEnfermera;

        public bool TieneEnfermera
        {
            get { return _TieneEnfermera; }
            set { _TieneEnfermera = value; }
        }
        //Constructor
        public Comun(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, bool _Asistencia, bool _TieneEnfermera)
           : base(_NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros,  _Asistencia)
          //public Comun(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, int _NumeroInterno, bool _Asistencia, bool _TieneEnfermera)
           // : base(_NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros, _NumeroInterno, _Asistencia)
        {
            _TieneEnfermera = TieneEnfermera;
        }

        public override string ToString()
        {
            return $"Consulta Comun ({NumeroConsultorio} - {FechaHora} - Dr {NombreMedico} - {CantidadNumeros} - {Asistencia} - {_TieneEnfermera})";
        }
    }
}
