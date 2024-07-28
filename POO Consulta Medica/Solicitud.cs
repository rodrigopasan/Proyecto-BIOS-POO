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
        private int _NumeroSolicitud;      
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

        public int NumeroSolicitud
        {
            get { return _NumeroSolicitud; }
            set { _NumeroSolicitud = value; }
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
        public Solicitud(int _NumeroSolicitud, DateTime _FechaSolicitud, bool _Asistencia ,Paciente unP, Consulta unaC)
        {
            NumeroSolicitud = _NumeroSolicitud;
            FechaSolicitud = _FechaSolicitud;
            Asistencia = _Asistencia;
            Paciente = unP;
            Consulta = unaC;

            Solicitud._Contador++;
            this._NumeroInterno = Solicitud._Contador;
        }

        public override string ToString()
        {
            return ($"El numero de soclicitud: {_NumeroSolicitud} + la fecha de solicitud: {_FechaSolicitud} + concurrio: {_Asistencia} + numero de consulta: {_Consulta } + el paciente es: {_Paciente} + numero interno: {_NumeroInterno}");
        }

    }
}
