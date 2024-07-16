using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Program
    {
       private static void AltaConsultaComun(Logica trabajo)
        {
            Console.Clear();
            Console.WriteLine("---- Ingrese una nueva consulta comun");
            try
            {
                //peticion de los datos
                Console.Write("Ingrese numero de consultorio del 1 al 40: ");
                int numeroconsultorio = Convert.ToInt32(Console.ReadLine().Trim());

                Console.Write("Ingrese la fecha de consulta (dd/mm/aaaa): ");
                DateTime fecha = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Ingrese el medico: ");
                string nombremedico = Console.ReadLine().Trim();

                Console.Write("Ingrese la cantidad de numeros: ");
                int cantidadnumeros = Convert.ToInt32(Console.ReadLine().Trim());

                Console.Write("Tiene asistencia? :");
                bool asistencia = Convert.ToBoolean(Console.ReadLine().Trim());

                Console.Write("Tiene enfermera?");
                bool tieneenfermera = Convert.ToBoolean(Console.ReadLine().Trim());

                Comun unaC = new Comun(numeroconsultorio, fecha, nombremedico, cantidadnumeros, asistencia, tieneenfermera);
                if (trabajo.AltaConsultaComun(unaC))
                    Console.WriteLine("Alta con exito");
                else
                    Console.WriteLine("No se genero el alta de la consulta comun");
                    Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        static void Menu(Logica trabajo)
        {
            int opcion = 0;
            while (opcion != 9)
            {
                Console.Clear();
                Console.WriteLine("------------------Menu Principal-------------------");
                Console.WriteLine("1 - Modificar Paciente");
                Console.WriteLine("2 - Alta consulta comun");
                Console.WriteLine("3 - Alta consulta especial");
                Console.WriteLine("4 - Agregar solicitud");
                Console.WriteLine("5 - Marcar asistenca solicitud numero");
                Console.WriteLine("6 - Listado socio de consulta");
                Console.WriteLine("7 - Listado consulta");
                Console.WriteLine("8 - Salir");
                Console.Write("Ingrese su opcion: ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Proceso(trabajo, opcion);
                }
                catch
                {
                    Console.WriteLine("Opcion invalida - 1-8");
                    Console.ReadLine();
                }
            }
        }
        static void Proceso(Logica trabajo, int opcion)  
        {
            switch (opcion)
            {
                case 1:
                    //ModfcaPaciente(trabajo);
                    break;
                case 2:
                    AltaConsultaComun(trabajo);
                    break;
                case 3:
                   // AltaConsultaEspecial(trabajo);
                    break;
                case 4:
                    //AgregarSolicitud(trabajo);
                    break;
                case 5:
                    //MarcarAsistenciaSolicitudNumero(trabajo);
                    break;
                case 6:
                   // ListaSocioConsulta(trabajo);
                    break;
                case 7:
                    //ListadoConsulta(trabajo);
                    break;
                default:
                    Console.WriteLine("Opcion invalida - 1 a 8");
                    Console.ReadLine();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Logica _trabajo = new Logica();
            Menu(_trabajo);
            Console.WriteLine("Gracias por su preferencia");
            Console.ReadLine();
        }
    }
}
