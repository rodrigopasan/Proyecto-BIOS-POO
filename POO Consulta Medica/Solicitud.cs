using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Solicitud
    {
        private int _NumeroInterno;
        private static int _Contador = 1;
        private bool _Asistencia;
        private DateTime _FechaSolicitud = DateTime.Today;      
        Paciente _Paciente;
        Consulta _Consulta;

        public int NumeroInterno
        {
            get { return _NumeroInterno; }
        }

        public bool Asistencia
        {
            get { return _Asistencia; }
            set { _Asistencia = value; }
        }

        public DateTime FechaSolicitud
        {
            get { return _FechaSolicitud; }
            set { _FechaSolicitud = value; }
        }

        public Consulta Consulta
        {
            get { return _Consulta; }

            set
            {
                if (value == null)
                    throw new Exception("La consulta no debe estar vacia");
                else
                    _Consulta = value;
            }
        }

        public Paciente Paciente
        {
            get { return _Paciente; }

            set
            {
                if (value == null)
                    throw new Exception("El paciente no debe estar vacio");
                else
                    _Paciente = value;
            }
        }

        //Cosntructor comun
        public Solicitud(DateTime _FechaSolicitud, bool _Asistencia ,Paciente unP, Consulta unaC)
        {

            FechaSolicitud = _FechaSolicitud;
            Asistencia = _Asistencia;
            Paciente = unP;
            Consulta = unaC;

            Solicitud._Contador++;
            this._NumeroInterno = Solicitud._Contador;
        }

        public override string ToString()
        {
            return ($"El numero de consulta: {Consulta.NumeroConsultorio} + la fecha de solicitud: {_FechaSolicitud} + concurrio: {_Asistencia} + el paciente es: {_Paciente} + numero interno: {_NumeroInterno}");
        }

    }
}
