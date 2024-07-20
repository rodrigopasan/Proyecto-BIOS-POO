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

                Console.Write("Tiene enfermera?: ");
                bool tieneenfermera = Convert.ToBoolean(Console.ReadLine().Trim());

                Comun unaC = new Comun(numeroconsultorio, fecha, nombremedico, cantidadnumeros,  asistencia, tieneenfermera);
                //Comun unaC = new Comun(numeroconsultorio, fecha, nombremedico, cantidadnumeros, numerointerno, asistencia, tieneenfermera);
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

        private static void AltaConsultaEspecialista(Logica trabajo)
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

                Console.Write("Especialidad: ");
                string especialidad = Console.ReadLine().Trim();

                Especialista unE = new Especialista(numeroconsultorio, fecha, nombremedico, cantidadnumeros, asistencia, especialidad);
                if(trabajo.AltaConsultaEspecialista(unE))
                    Console.WriteLine("Alta con exito");
                else
                    Console.WriteLine("No se genero el alta de la consulta especialista: ");
                    Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void AltaPaciente(Logica trabajo)
        {
            Console.Clear();
            Console.WriteLine("---- Ingrese una nueva consulta comun");
            try
            {
                Console.Write("Ingrese el numero de documento del paciente sin punto ni guiones: ");
                int numerodocumento = Convert.ToInt32(Console.ReadLine().Trim());

                Console.Write("Ingrese el nombre del paciente: ");
                string nombrepaciente = Console.ReadLine().Trim();

                Console.Write("Ingrese el apellido del paciente: ");
                string apellidopaciente = Console.ReadLine().Trim();

                Console.Write("Ingrese la fecha de nacimiento del paciente (dd/mm/aaaa): ");
                DateTime fechanacimiento = Convert.ToDateTime(Console.ReadLine());

                Paciente unP = new Paciente(nombrepaciente, apellidopaciente, fechanacimiento, numerodocumento);
                if (trabajo.AltaPaciente(unP))
                    Console.WriteLine("Alta con exito");
                else
                    Console.WriteLine("No se genero el alta en paciente: ");
                    Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void ListadoConsulta(Logica trabajo)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------------Listado completo de todas las consultas-----------------");
                //tope me indica la cantidad de consultas que hay en el repositorio
                for (int i = 0; i < trabajo.NumeroConsultorio; i++)
                {
                    //llamo la logica item
                    Console.WriteLine(trabajo.Item(i));
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }//fin listado

        static void Menu(Logica trabajo)
        {
            int opcion = 0;
            while (opcion != 10)
            {
                Console.Clear();
                Console.WriteLine("------------------Menu Principal-------------------");
                Console.WriteLine("1 - Mantenimiento Pacientes");
                Console.WriteLine("2 - Alta Consulta Común");
                Console.WriteLine("3 - Alta Consulta Especialista");
                Console.WriteLine("4 - Agregar Solicitud");
                Console.WriteLine("5 - Marcar Asistenca Solicitud Número");
                Console.WriteLine("6 - Listado Socio de Consulta");
                Console.WriteLine("7 - Listado Consulta");
                Console.WriteLine("8 - Listado Solicitudes de Consulta Paciente");
                Console.WriteLine("9 - Salir");
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
                    AltaPaciente(trabajo);
                    break;
                case 2:
                    AltaConsultaComun(trabajo);
                    break;
                case 3:
                    AltaConsultaEspecialista(trabajo);
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
                    ListadoConsulta(trabajo);
                    break;
                case 8:
                    //Listado solicitudes de consulta paciente(trabajo);
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
