using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    public abstract class Consulta
    {
        // hacer caluclo o formula del Numero Interno
        private int _NumeroConsulta;
        private int _NumeroConsultorio;
        private DateTime _FechaHora;
        private string _NombreMedico;
        private int _CantidadNumeros;
        private static int _Contador = 0;


        //Asociacion entre paciente y consulta
        public int NumeroConsulta
        {
            get { return _NumeroConsulta; }
        }

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
                if (value > 0 && value < 10)
                {
                    _CantidadNumeros = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n-> Advertencia");
                    Console.ResetColor();
                    throw new Exception(" - Se llegó al limite de numeros para este consultorio en la fecha solicitada");
                }
            }
        }



        //Constructor Completo
        public Consulta(int _NumeroConsulta, int _NumeroConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros )
        
        {
            NumeroConsultorio = _NumeroConsultorio;
            FechaHora = _FechaHora;
            NombreMedico = _NombreMedico;
            CantidadNumeros = _CantidadNumeros;

            Consulta._Contador++;
            this._NumeroConsulta = Consulta._Contador;
            
        }

        public int DiferenciaHoras(DateTime HoraRegAnterior)
        {
            //HoraRegAnterior es la hora del registro anterior que devuelve el foreach
            //_Diferencia es la diferencia entre _FechaHora y HoraRegAnterior representada en horas (pueden ser negativas)
            TimeSpan _Diferencia = _FechaHora.Subtract(HoraRegAnterior);
            int _DifHs = _Diferencia.Hours;
            return (_DifHs);
        }


        public override string ToString()
        {

            return ($"Consulta: {_NumeroConsulta}, consultorio: {_NumeroConsultorio }, Fecha y hora: {_FechaHora.ToShortDateString() }, Médico: {_NombreMedico}, números: {_CantidadNumeros}");
        }
        
    }
}
