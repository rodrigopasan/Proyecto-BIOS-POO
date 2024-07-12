using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    namespace POO_Consulta_Medica
    {
        class Consulta
        {
            private int numDeConsultorio;
            private DateTime fechaHora;
            private string nombreMedico;
            private int numDeInterno; //nose
            private int cantidadDeNumeros;
            private bool asistencia;

            //atributos
            public int NumDeConsultorio
            {
                get { return numDeConsultorio; }
                set
                {
                    if (value >= 1 && value <= 40)
                    {
                        numDeConsultorio = value;
                    }
                    else
                    {
                        throw new Exception("El número de consultorio debe estar entre 1 y 40.");
                    }
                }
            }

            public DateTime FechaHora
            {
                get { return fechaHora; }
                set
                {
                    if (value > DateTime.Now.AddHours(2))
                    {
                        fechaHora = value;
                    }
                    else
                    {
                        throw new Exception("La fecha y hora de la consulta deben estar al menos 2 horas");
                    }
                }
            }

            public string NombreMedico
            {
                get { return nombreMedico; }
                set { nombreMedico = value; }
            }

            public int CantidadDeNumeros
            {
                get { return cantidadDeNumeros; }
                set
                {
                    if (value > 0)
                    {
                        cantidadDeNumeros = value;
                    }
                    else
                    {
                        throw new Exception("La cantidad de números debe ser mayor a cero");
                    }
                }
            }

            public bool Asistencia
            {
                get { return asistencia; }
                set { asistencia = value; }
            }



            //constru

            public Consulta(int numDeConsultorio, DateTime fechaHora, string nombreMedico, int cantidadDeNumeros)
            {
                NumDeConsultorio = numDeConsultorio;
                FechaHora = fechaHora;
                NombreMedico = nombreMedico;
                CantidadDeNumeros = cantidadDeNumeros;
            }

            public override string ToString()
            {

                return ("Consulta en consultorio " + numDeConsultorio + "Fecha y hora:" + fechaHora + "Médico:" + nombreMedico + "Cantidad de números:" + cantidadDeNumeros + "Asistencia" + Asistencia);
            }
        }
    }
}
