using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class LogicaConsulta
    {

        public void AltaConsultaComun(int _NumConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, bool _Asistencia, bool _TieneEnfermera)
        {
            try
            {
                Comun NuevaConsultaComun = new Comun(_NumConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros,_Asistencia, _TieneEnfermera);
                Console.WriteLine("Consulta común agregada " + NuevaConsultaComun);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }


        public void AltaConsultaEspecialista(int _NumConsultorio, DateTime _FechaHora, string _NombreMedico, int _CantidadNumeros, bool _Asistencia, string _Especialidad)
        {
            try
            {

                Especialista NuevaConsultaEspecialista = new Especialista(_NumConsultorio, _FechaHora, _NombreMedico, _CantidadNumeros,_Asistencia, _Especialidad);



                Console.WriteLine("Consulta especialista agregada " + NuevaConsultaEspecialista);
            }
            catch
            {
                Console.WriteLine("Error al agregar la consulta especialista ");
            }
        }
    }
}

