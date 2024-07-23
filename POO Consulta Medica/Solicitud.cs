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

        Paciente _Paciente;
        Consulta _Consulta;
        public int _NumeroInterno
        {
            get { return NumeroInterno; }
            set { NumeroInterno = value; }
        }

        public DateTime _FechaHoraSolicitud 
        {
            get { return FechaHoraSolicitud; }
            set { FechaHoraSolicitud = value; }
        }

     
        public Solicitud(int numeroIntern, DateTime fechaHoraSolicitud,bool asistencia)
        {
            NumeroInterno = numeroIntern;
            FechaHoraSolicitud = fechaHoraSolicitud;
            Asistencia = asistencia;
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
    }
