using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Logica
    {

        private List<Paciente> _lista;
        private List<Consulta> _listaConsulta;

        public int NumeroCedula
        {
            get { return _lista.Count; }
        }

        public int NumeroConsultorio
        {
            get { return _listaConsulta.Count; }
        }

        public Logica()
        {
            _lista = new List<Paciente>();
            _listaConsulta = new List<Consulta>();   
        }

        public bool AltaPaciente(Paciente unPaciente)
        {
            Paciente _busco = BuscarPaciente(unPaciente.NumeroCedula);

            if (_busco != null)
                throw new Exception("Ya existe un paciente con ese numero de cedula");
            else
            {
                _lista.Add(unPaciente);
            }
            return true;
        }

        public Paciente BuscarPaciente(int pNumeroCedula)
        {
            foreach (Paciente P in _lista)
            {
                if (P != null)
                    if (P.NumeroCedula == pNumeroCedula)
                        return P;
            }//fin foreach
            return null;
        }

        public bool EliminarPaciente(Paciente unPaciente)
        {

            for (int i = 0; i < _lista.Count; i++)
            {
                if (_lista[i].NumeroCedula == unPaciente.NumeroCedula)
                {
                    _lista.RemoveAt(i);
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
        public Consulta BuscarConsultorio(int pNumeroConsultorio)
        {
            foreach(Consulta C in _listaConsulta)
            {
                if (C != null)
                    if (C.NumeroConsultorio == pNumeroConsultorio)
                        return C;
            }//fin foreach
            return null;
        }
        public bool AltaConsultaComun(Consulta unaConsulta)
        {
            Consulta _buscoConsultorio = BuscarConsultorio(unaConsulta.NumeroConsultorio);
            if(_buscoConsultorio != null)
                throw new Exception("El numero de consultorio ya esta en uso");
            else
            {
                _listaConsulta.Add(unaConsulta);
            }
            return true;
        }

        public bool AltaConsultaEspecialista(Consulta unaConsultaEspecialista)
        {
            Consulta _buscoConsultorio = BuscarConsultorio(unaConsultaEspecialista.NumeroConsultorio);
            if (_buscoConsultorio != null)
                throw new Exception("El numero de consultorio ya esta en uso");
            else
            {
                _listaConsulta.Add(unaConsultaEspecialista);
            }
            return true;
        }
        //obtener una consulta en una posicion x en mi repositorio
        public Consulta Item(int pos)
        {
            if (pos >= 0 && pos < _listaConsulta.Count)
                return _listaConsulta[pos];
            else
                throw new Exception("Indice de Conjunto Invalido");
        }
    }
}
