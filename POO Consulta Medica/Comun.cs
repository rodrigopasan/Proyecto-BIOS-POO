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
        //Constructor
        public Comun(int _NumeroConsulta, int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, bool _TieneEnfermera)
           : base(_NumeroConsulta, _NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros)
        {
            TieneEnfermera = _TieneEnfermera;
            if (_TieneEnfermera == false)
                _tipEnfermera = "No";
            else
                _tipEnfermera = "Si";

        }

        public override string ToString()
        {
            return $"Tipo: Comun            ID: {NumeroConsulta}     Consultorio:{NumeroConsultorio}     {FechaHora}     {NombreMedico}     Numero del día: {CantidadNumeros}     Enfermería:   {_tipEnfermera}";
        }
    }
}
