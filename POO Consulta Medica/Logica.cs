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
        public Consulta BuscarConsulta(int pNumeroConsulta)
        {
            foreach (Consulta C in _listaConsulta) //Va a recorrer las entradas de Consultas
            {
                if (C.NumeroConsulta == pNumeroConsulta)
                    return (C);
            }//fin foreach
            return null;
        }
        public Consulta ValidarAlta(int pNumeroConsultorio, DateTime pFechaHora)
        {
            foreach (Consulta C in _listaConsulta)
            {
                if (C != null) //Para la primera vuelta que no va a tener datos
                { 
                    if (C.FechaHora == pFechaHora && C.NumeroConsultorio == pNumeroConsultorio)
                    {
                        return C; // Devuelve la consulta en conflicto
                    }

                }
            }
            return null; // No hay conflicto
        }

        public bool AltaConsultaComun(Consulta unaConsulta)
        {
            Consulta consultaConflictiva = ValidarAlta(unaConsulta.NumeroConsultorio, unaConsulta.FechaHora);
            if (consultaConflictiva == null)
            {
                _listaConsulta.Add(unaConsulta);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nERROR ->");
                Console.ResetColor();
                throw new Exception($"Existe una consulta con la fecha solicitada ({unaConsulta.FechaHora}) en el consultorio seleccionado ({unaConsulta.NumeroConsultorio})");
                
            }
        }

        public bool AltaConsultaEspecialista(Consulta unaConsultaEspecialista)
        {
            Consulta consultaConflictiva = ValidarAlta(unaConsultaEspecialista.NumeroConsultorio, unaConsultaEspecialista.FechaHora);
            if (consultaConflictiva == null)
            {
                _listaConsulta.Add(unaConsultaEspecialista);
                return true;
            }
            else
            {
                throw new Exception($"Existe una consulta con la fecha solicitada ({unaConsultaEspecialista.FechaHora}) en el consultorio seleccionado ({unaConsultaEspecialista.NumeroConsultorio})");
            }
        }

        public Solicitud BuscarSolicitud(int sNumeroInterno)
        {
            foreach(Solicitud S in _listaSolicitud)
            {
                if (S != null)
                    if (S.NumeroInterno == sNumeroInterno)
                        return S;
            }
            return null;
        }
        public Solicitud LugarSolicitud(Solicitud unaSolicitud)
        {
            int cantidadsolicitudes = CantidadSolicitudes(unaSolicitud);
            unaSolicitud.Lugar = cantidadsolicitudes + 1;
            return null;
        }
        public Consulta ValidarSolicitud(Solicitud unaSolicitud, Consulta unaConsulta)
        {
            int cantidadsolicitudes = CantidadSolicitudes(unaSolicitud);
            int maxnumconsulta = unaConsulta.CantidadNumeros;

            if (cantidadsolicitudes >= maxnumconsulta)
            {
                return unaConsulta;
            }
            return null;
        }
        public bool AgregarSolicitud(Solicitud unaSolicitud)
        {
            Consulta solicitudConflictiva = ValidarSolicitud(unaSolicitud, unaSolicitud.Consulta);
            if (solicitudConflictiva != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nERROR -> ");
                Console.ResetColor();
                throw new Exception($"Se supero el máximo de numeros habilitados ({unaSolicitud.Consulta.CantidadNumeros}) para la consulta: {unaSolicitud.Consulta.NumeroConsulta}");
            }
            else
            {
                Solicitud obtenerlugarsolicitud = LugarSolicitud(unaSolicitud);
                if (obtenerlugarsolicitud != null)
                {
                    throw new Exception("Error al modificar el lugar de la solicitud...");
                }
                else
                {
                    _listaSolicitud.Add(unaSolicitud);
                }

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
       
        public Solicitud BusSolCons(int numConsulta)
        {
            foreach(Solicitud S in _listaSolicitud)
            {
                if (S.Consulta.NumeroConsulta == numConsulta)
                    return S;
            }
            return null;
        }
        public List<Solicitud> BuscarSolicitudesPorConsulta(int numConsulta)
        {
            List<Solicitud> solicitudesEncontradas = new List<Solicitud>();

            foreach (Solicitud S in _listaSolicitud)
            {
                if (S.Consulta.NumeroConsulta == numConsulta)
                {
                    solicitudesEncontradas.Add(S);
                }
            }

            return solicitudesEncontradas;
        }

        public int CantidadSolicitudes(Solicitud unaSolicitud)
        {
            List<Solicitud> solicitudes = BuscarSolicitudesPorConsulta(unaSolicitud.Consulta.NumeroConsulta);
            return solicitudes.Count;
        }
        public bool ActualizarSolicitud(Solicitud solicitudActualizada)
        {
            for (int i = 0; i < _listaSolicitud.Count; i++)
            {
                if (_listaSolicitud[i].NumeroInterno == solicitudActualizada.NumeroInterno)
                {
                    _listaSolicitud[i] = solicitudActualizada; // Actualiza la solicitud en la lista
                    return true;
                }
            }
            return false;
        }

        public List<Solicitud> ListadoSolicitudesPaciente(Paciente paciente)
        {
            List<Solicitud> solicitudesPaciente = new List<Solicitud>();

            foreach (Solicitud solicitud in _listaSolicitud)
            {
                if (solicitud.Paciente.NumeroCedula == paciente.NumeroCedula)
                {
                    solicitudesPaciente.Add(solicitud);
                }
            }

            return solicitudesPaciente;
        }
              
        public List<Consulta> OrdenarFechas(List<Consulta> listaConsultas)
        {
            return listaConsultas.OrderBy(c => c.FechaHora).ToList();
        }

    }


}
