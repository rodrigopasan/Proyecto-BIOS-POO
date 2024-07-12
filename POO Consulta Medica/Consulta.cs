using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{

        class Consulta
        {
            private int _NumConsultorio;
            private DateTime _FechaHora;
            private string _NombreMedico;
            private int _NumInterno;
            private int _CantidadNumeros;
            private bool _Asistencia;

        //atributos
        public int NumeroConsultorio
            {
                get { return _NumConsultorio; }
                set
                {
                    if (value >= 1 && value <= 40)
                    {
                        _NumConsultorio = value;
                    }
                    else
                    {
                        throw new Exception("El número de consultorio debe estar entre 1 y 40.");
                    }
                }
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
        public int NumInterno
        {
            get {return _NumInterno; }
            set { _NumInterno = value; }
            }

        public bool Asistencia
            {
                get { return _Asistencia; }
            }



            //constru

            public Consulta(int _NumConsultorio, DateTime _FechaHora, string _NombreMedico, int _NumInterno, int _CantidadNumeros)
            {
                NumeroConsultorio = _NumConsultorio;
                FechaHora = _FechaHora;
                NombreMedico = _NombreMedico;
                NumInterno = _NumInterno;
                CantidadNumeros = _CantidadNumeros;
            }

            public override string ToString()
            {

                return ($"Consulta en consultorio + {_NumConsultorio} + Fecha y hora:  {_FechaHora}  Médico: + {_NombreMedico} cantidad de números: + {_CantidadNumeros} Numero Interno: {_NumInterno} Asistencia {Asistencia}");
            }
        }
    }

