using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Logica
    {

        private List<Paciente> _listaPaciente;
        private List<Consulta> _listaConsulta;
        private List<Solicitud> _listaSolicitud;

        //Constructor
        public Logica()
        {
            _listaPaciente = new List<Paciente>();
            _listaConsulta = new List<Consulta>();
            _listaSolicitud = new List<Solicitud>();  
        }

        public bool AltaPaciente(Paciente unPaciente)
        {
            Paciente _busco = BuscarPaciente(unPaciente.NumeroCedula);

            if (_busco != null)
                throw new Exception("Ya existe un paciente con ese numero de cedula");
            else
            {
                _listaPaciente.Add(unPaciente);
            }
            return true;
        }

        public Paciente BuscarPaciente(int pNumeroCedula)
        {
            foreach (Paciente P in _listaPaciente)
            {
                if (P != null)
                    if (P.NumeroCedula == pNumeroCedula)
                        return P;
            }//fin foreach
            return null;
        }

        public bool EliminarPaciente(Paciente unPaciente)
        {

            for (int i = 0; i < _listaPaciente.Count; i++)
            {
                if (_listaPaciente[i].NumeroCedula == unPaciente.NumeroCedula)
                {
                    _listaPaciente.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool ModificarPaciente(Paciente unPaciente)
        {
            if (EliminarPaciente(unPaciente))
                return AltaPaciente(unPaciente);
            else
                return false;
        }
        public Consulta BuscarConsulta(int pNumeroConsultorio, DateTime pFechaHora)
        {
            foreach (Consulta C in _listaConsulta) //Va a recorrer las entradas de Consultas
            {
                if (C != null)  //Para la primera vuelta que no va a tener datos
                {
                    if (C.FechaHora == pFechaHora) //Si en alguna de las vueltas coinciden las fechas va a dar error
                        throw new Exception("Existe una consulta con la fecha solicitada");
                    else
                    {
                        return C;
                    }
                }
            }//fin foreach
            return null;
        }
        public bool AltaConsultaComun(Consulta unaConsulta)
        {
            Consulta _buscoConsulta = BuscarConsulta(unaConsulta.NumeroConsultorio, unaConsulta.FechaHora);
            if (_buscoConsulta != null)
                if (unaConsulta.NumeroConsultorio == _buscoConsulta.NumeroConsultorio)
                {
                    // Se verifica que existan dos horas de diferencia para la fecha solicitada
                    // Se utiliza la función DiferenciaHoras y se le pasa como parametro "_buscoConsultorio.FechaHora"
                    int dif2horas = unaConsulta.DiferenciaHoras(_buscoConsulta.FechaHora);
                    if (dif2horas >= 2 || dif2horas <= -2)
                    {
                        _listaConsulta.Add(unaConsulta);
                        return true;
                    }
                    else
                    {
                        double sumarhoras = dif2horas; //La suma de horas se debe trabajar con double
                        throw new Exception("\n" + "---> Error: Los registros de consultas deben estar distanciados por un mínimo de 2 horas" + "\n" + "\n" + "Consultorio Nº: " + unaConsulta.NumeroConsultorio + "\n" + "Fecha de registro en conflicto: " + _buscoConsulta.FechaHora + "\n" + "Fecha de registro solicitada: " + unaConsulta.FechaHora + "\n" + "\n" + "Fecha sugerida 1: " + _buscoConsulta.FechaHora.AddHours(-2) + "\n" + "Fecha sugerida 2: " + _buscoConsulta.FechaHora.AddHours(2) + "\n" + "\n" + "Recuerde que puede realizar una busqueda de las consultas desde el menú principal");
                    }
                }
            _listaConsulta.Add(unaConsulta);
            return true;
        }

        public bool AltaConsultaEspecialista(Consulta unaConsultaEspecialista)
        {
            Consulta _buscoConsulta = BuscarConsulta(unaConsultaEspecialista.NumeroConsultorio, unaConsultaEspecialista.FechaHora);
            if (_buscoConsulta != null)
                if (unaConsultaEspecialista.NumeroConsultorio == _buscoConsulta.NumeroConsultorio)
                {
                    // Se verifica que existan dos horas de diferencia para la fecha solicitada
                    // Se utiliza la función DiferenciaHoras y se le pasa como parametro "_buscoConsultorio.FechaHora"
                    int dif2horas = unaConsultaEspecialista.DiferenciaHoras(_buscoConsulta.FechaHora);
                    if (dif2horas >= 2 || dif2horas <= -2)
                    {
                        _listaConsulta.Add(unaConsultaEspecialista);
                        return true;
                    }
                    else
                    {
                        double sumarhoras = dif2horas; //La suma de horas se debe trabajar con double
                        throw new Exception("\n" + "---> Error: Los registros de consultas deben estar distanciados por un mínimo de 2 horas" + "\n" + "\n" + "Consultorio Nº: " + unaConsultaEspecialista.NumeroConsultorio + "\n" + "Fecha de registro en conflicto: " + _buscoConsulta.FechaHora + "\n" + "Fecha de registro solicitada: " + unaConsultaEspecialista.FechaHora + "\n" + "\n" + "Fecha sugerida 1: " + _buscoConsulta.FechaHora.AddHours(-2) + "\n" + "Fecha sugerida 2: " + _buscoConsulta.FechaHora.AddHours(2) + "\n" + "\n" + "Recuerde que puede realizar una busqueda de las consultas desde el menú principal");
                    }
                }
            _listaConsulta.Add(unaConsultaEspecialista);
            return true;
        }

        public Solicitud BuscarSolicitud(int sNumeroInterno)
        {
            foreach(Solicitud S in _listaSolicitud)
            {
                if (S != null)
                    if (S.Consulta.NumeroConsultorio == sNumeroInterno)
                        return S;
            }
            return null;
        }
        public bool AgregarSolicitud(Solicitud unaSolicitud)
        {
            Solicitud _buscoSolicitud = BuscarSolicitud(unaSolicitud.NumeroSolicitud);
            if (_buscoSolicitud != null)
                throw new Exception("El numero de consultorio ya esta en uso");
            else
            {
                _listaSolicitud.Add(unaSolicitud);
            }
            return true;
        }

        public List<Solicitud> ListaSolicitud()
        {
            return _listaSolicitud;
        }

        public List<Consulta> ListaConsulta()
        {
            return _listaConsulta;
        }

        //obtener una consulta en una posicion x en mi repositorio
        public Consulta Item(int pos)
        {
            if (pos >= 0 && pos < _listaConsulta.Count)
                return _listaConsulta[pos];
            else
                throw new Exception("Indice de Conjunto Invalido");
        }
        //comento para ver si sube
    }
}
