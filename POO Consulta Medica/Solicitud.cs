using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    using System;

    class Solicitud
    {
<<<<<<< HEAD
        private int NumeroInterno;
        private DateTime FechaHoraSolicitud;
        private bool AsistioConsulta;

        private static int Contador=0;

=======
        private int _NumeroInterno;
        private static int _Contador = 1;
        private bool _Asistencia;
        private DateTime _FechaSolicitud = DateTime.Today;      
>>>>>>> origin/Anibal
        Paciente _Paciente;
        Consulta _Consulta;
        public int _NumeroInterno
        {
            get { return NumeroInterno; }

        }
        public static int _Contador
        {
            get { return Contador; }

        }
        public DateTime _FechaHoraSolicitud
        {
            get { return FechaHoraSolicitud; }
            set { FechaHoraSolicitud = value; }
        }


        public Solicitud(int numeroIntern, DateTime fechaHoraSolicitud, bool asistencia)
        {
            NumeroInterno = numeroIntern;
            FechaHoraSolicitud = fechaHoraSolicitud;
            AsistioConsulta = asistencia;
            NumeroInterno = Contador;
            Contador++;
        }
        public bool _AsistioConsulta
        {
            get { return AsistioConsulta; }
            set { AsistioConsulta = value; }
        }

        public void Asistencia(bool asistio)
        {
<<<<<<< HEAD
            AsistioConsulta = asistio;
=======
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
>>>>>>> origin/Anibal
        }

        public override string ToString()
        {
<<<<<<< HEAD
        
            return $"Solicitud ({NumeroInterno} - {FechaHoraSolicitud} - Asistencia: {AsistioConsulta})";
=======
            return ($"El numero de consulta: {Consulta.NumeroConsultorio} + la fecha de solicitud: {_FechaSolicitud} + concurrio: {_Asistencia} + el paciente es: {_Paciente} + numero interno: {_NumeroInterno}");
>>>>>>> origin/Anibal
        }
    }
}
