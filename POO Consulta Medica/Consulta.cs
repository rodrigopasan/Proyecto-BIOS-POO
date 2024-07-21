using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Consulta
    {
        private int _NumeroConsultorio;
        private DateTime _FechaHora;
        private string _NombreMedico;
        private Guid _NumeroInterno;
        private int _CantidadNumeros;
        private bool _Asistencia;

        //atributos
        public int NumeroConsultorio
        { 
            set
            {
                if (value >= 1 && value <= 40)
                    _NumeroConsultorio = value;
                else
                    throw new Exception("El número de consultorio debe estar entre 1 y 40.");
            }
            get { return _NumeroConsultorio; }
        }

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set
            {
                if (value >= DateTime.Now)
                {
                    _FechaHora = value;
                }
                else
                {
                    throw new Exception("La fecha ingresada es en pasado, ingrese una fecha a futuro.");
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
        public Guid NumeroInterno
        {
            get { return _NumeroInterno; }

            set { _NumeroInterno = value; }

        }
        public bool Asistencia
        {
            get { return _Asistencia; }
            set { _Asistencia = value; }
        }

        //Constructor Completo
            // Se agrega "Guid _NumeroInterno" para comenzar a trabajar con NumeroInterno, esto se refleja a lo largo de las clases asociadas.
        public Consulta(int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, Guid _NumeroInterno, bool _Asistencia)
        {
            NumeroConsultorio = _NumeroConsultorio;
            FechaHora = _FechaHora;
            NombreMedico = _NombreMedico;
            CantidadNumeros = _CantidadNumeros;
            NumeroInterno = _NumeroInterno;
            Asistencia = _Asistencia;
        }

        public int DiferenciaHoras(DateTime HoraRegAnterior)
        {
            //HoraRegAnterior es la hora del registro anterior que devuelve el foreach
            //_Diferencia es la diferencia entre _FechaHora y HoraRegAnterior representada en horas (pueden ser negativas)
            TimeSpan _Diferencia = _FechaHora.Subtract(HoraRegAnterior);
            int _DifHs = _Diferencia.Hours;
            return (_DifHs);
        }

        // Se crea ObtenerNumeroInterno para utilizar en Logica y obtener un GUID (Por ejemplo: fb7f4727-3bfb-491e-a561-27d7579d48b0)
            // De esta manera los numeros internos no se repiten y permiten identificar a cada entrada de consulta como unica
        public Guid ObtenerNumeroInterno ()
        {
            Guid id = Guid.NewGuid();
            return id;
        }

        public override string ToString()
        {

            return ($"Consulta en consultorio: {_NumeroConsultorio } Fecha y hora: {_FechaHora.ToShortDateString() } Médico: {_NombreMedico} Cantidad de números: {_CantidadNumeros} Asistencia {_Asistencia}");
        }
        
    }
}
