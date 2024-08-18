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
        private static int _Contador = 0;
        private bool _Asistencia;
        private DateTime _FechaSolicitud = DateTime.Now;
        private string tipAsistencia;
        private int _Lugar;
        Paciente _Paciente;
        Consulta _Consulta;


        public int NumeroInterno
        {
            get { return _NumeroInterno; }
        }
        public int Lugar
        {
            get { return _Lugar; }
            set { _Lugar = value; }
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
        public Solicitud(int _NumeroInterno, DateTime _FechaSolicitud, bool _Asistencia, int _Lugar ,Paciente unP, Consulta unaC)
        {

            this._FechaSolicitud = DateTime.Now;
            Asistencia = _Asistencia;
            Paciente = unP;
            Consulta = unaC;
            Lugar = _Lugar;
            
            if (_Asistencia == false)
                tipAsistencia = "No";
            else
                tipAsistencia = "Si";

            Solicitud._Contador++;
            this._NumeroInterno = Solicitud._Contador;
        }

        public override string ToString()
        {
            return ($"Numero Interno De Solicitud: {_NumeroInterno}   Consultorio: {_Consulta.NumeroConsultorio}   Fecha: {_FechaSolicitud}   Concurrio: {tipAsistencia}   {_Paciente}");
        }

    }
}
