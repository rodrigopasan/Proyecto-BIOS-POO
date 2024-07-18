using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Logica
    {
        private int _Tope;
        private Paciente[] _lista;
        private Consulta[] _listaConsulta;

        public int Tope
        {
            get { return _Tope; }
        }


        public int NumeroCedula
        {
            get { return _Tope; }
        }

        public int NumeroConsultorio
        {
            get { return _Tope; }
        }
        public Logica()
        {
            _lista = new Paciente[1000];
            _listaConsulta = new Consulta[40];
            _Tope = 0;
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
        public bool AltaPaciente(Paciente unPaciente)
        {
            Paciente _busco = BuscarPaciente(unPaciente.NumeroCedula);
            if (_busco != null)
                throw new Exception("Ya existe un paciente con ese numero de cedula");
            else
            {
                if (_Tope < _lista.Length)
               { 
                    _lista[_Tope] = unPaciente;
                _Tope++;
               }
                 else
                     throw new Exception("No hay mas lugar para almacenar");
            }
            return true;
        }
        public bool EliminarPaciente(Paciente unPaciente)
        {

            for (int i = 0; i < _Tope; i++)
            {
                if (_lista[i].NumeroCedula == unPaciente.NumeroCedula)
                {
                    _lista[i] = _lista[_Tope - 1];
                    _lista[_Tope - 1] = null;
                    _Tope--;
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
                if (_Tope < _listaConsulta.Length)
                {
                    _listaConsulta[_Tope] = unaConsulta;
                    _Tope++;
                }
                else
                    throw new Exception("No hay consultorio disponible");
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
                if (_Tope < _listaConsulta.Length)
                {
                    _listaConsulta[_Tope] = unaConsultaEspecialista;
                    _Tope++;
                }
                else
                    throw new Exception("No hay consultorio disponible");
            }
            return true;
        }
        //obtener una consulta en una posicion x en mi repositorio
        public Consulta Item(int pos)
        {
            if (pos >= 0 && pos < _Tope)
                return _listaConsulta[pos];
            else
                throw new Exception("Indice de Conjunto Invalido");
        }
    }
}
