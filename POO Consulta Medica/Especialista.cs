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
         public Especialista(int _NumeroConsulta, int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, string _Especialidad)
           : base(_NumeroConsulta, _NumeroConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros)
      
        {
            Especialidad = _Especialidad;
        }


        public override string ToString()
        {
            return $"Especialista {NumeroConsulta}, consultorio: {NumeroConsultorio}, fecha: {FechaHora}, Dr {NombreMedico}, numero: {CantidadNumeros}, especialidad {Especialidad}";
        }
    }
}
