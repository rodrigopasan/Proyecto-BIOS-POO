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
        private int NumeroInterno;
        private DateTime FechaHoraSolicitud;
        private bool AsistioConsulta;

        private static int Contador=0;

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
            AsistioConsulta = asistio;
        }

        public override string ToString()
        {
        
            return $"Solicitud ({NumeroInterno} - {FechaHoraSolicitud} - Asistencia: {AsistioConsulta})";
        }
    }
}
