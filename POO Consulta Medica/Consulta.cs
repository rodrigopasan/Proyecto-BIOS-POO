using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Consulta
    {
        // hacer caluclo o formula del Numero Interno
        private int _NumeroConsultorio;
        private DateTime _FechaHora;
        private string _NombreMedico;
        private int _NumeroInterno; //nose
        private int _CantidadNumeros;
        private bool _Asistencia;

        //atributos
        public int NumeroConsultorio
        { 
            set
            {
                if (value >= 1 && value <= 40)
                    throw new Exception("El número de consultorio debe estar entre 1 y 40.");
                else
                    _NumeroConsultorio = value;    
            }
            get { return _NumeroConsultorio; }
        }

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set
            {
                if (value > DateTime.Now.AddHours(2))
                {
                    _FechaHora = value;
                }
                else
                {
                    throw new Exception("La fecha y hora de la consulta deben estar al menos 2 horas");
                }
            }
        }

        public string NombreMedico
        {
            get { return _NombreMedico; }
            set { _NombreMedico = value; }
        }

        public int CantidadNumeros
        {
            get { return _CantidadNumeros; }
            set
            {
                if (value > 0)
                {
                    _CantidadNumeros = value;
                }
                else
                {
                    throw new Exception("La cantidad de números debe ser mayor a cero");
                }
            }
        }
        public int NumeroInterno
        { 
            get { return _NumeroInterno; }

            set
            {
                for(int i = 0; i < 40; i++)
                {
                    _NumeroInterno++;
                        i++;
                    
                }
            }
            
        }
        public bool Asistencia
        {
            get { return _Asistencia; }
            set { _Asistencia = value; }
        }

        //Constructor Completo
        public Consulta(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, bool _Asistencia)
        {
            NumeroConsultorio = _NumeroConsultorio;
            FechaHora = _FechaHora;
            NombreMedico = _NombreMedico;
            CantidadNumeros = _CantidadNumeros;
            NumeroInterno = _NumeroInterno;
            Asistencia = _Asistencia;
        }

        public override string ToString()
        {

            return ($"Consulta en consultorio: {_NumeroConsultorio } Fecha y hora: {_FechaHora } Médico: {_NombreMedico} Cantidad de números: {_CantidadNumeros} Asistencia {_Asistencia}");
        }
        
        //Asociacion con paciente
        private Paciente _SolicitudNumero;
    }
}
