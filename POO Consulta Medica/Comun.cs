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
        private string _tipEnfermera;

        public bool TieneEnfermera
        {
            get { return _TieneEnfermera; }
            set { _TieneEnfermera = value; }
        }
        //Constructor con el GUID de _NumeroInterno (Ver clase Consulta)
        public Comun(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, Guid _NumeroInterno, bool _Asistencia, bool _TieneEnfermera)
           : base(_NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros, _NumeroInterno,  _Asistencia)
        {
            TieneEnfermera = _TieneEnfermera;
            if (_TieneEnfermera == false)
                _tipEnfermera = "No";
            else
                _tipEnfermera = "Si";

        }

        public override string ToString()
        {
            return $"Consulta Comun ({NumeroConsultorio} - {FechaHora} - Dr {NombreMedico} - {CantidadNumeros} - {Asistencia} - {TieneEnfermera})";
        }
    }
}
