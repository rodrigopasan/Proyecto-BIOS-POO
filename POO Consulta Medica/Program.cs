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

                Console.Write("Ingrese la fecha de consulta (dd/mm/aaaa hh:mm): ");
                DateTime fecha = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Ingrese el medico: ");
                string nombremedico = Console.ReadLine().Trim();

                Console.Write("Ingrese la cantidad de numeros: ");
                int cantidadnumeros = Convert.ToInt32(Console.ReadLine().Trim());

                //Crea un GUID (NumeroInterno) por defecto "00000000-0000-0000-0000-000000000000"
                Guid numerointerno = new Guid();
                numerointerno = default(Guid);

                Console.Write("Tiene asistencia? :");
                bool asistencia = Convert.ToBoolean(Console.ReadLine().Trim());

                Console.Write("Tiene enfermera?: ");
                // Si no se ingresa el bool por defecto es "false" 
                bool tieneenfermera = false;
                tieneenfermera = Convert.ToBoolean(Console.ReadLine().Trim());

                Comun unaC = new Comun(numeroconsultorio, fecha, nombremedico, cantidadnumeros, numerointerno,  asistencia, tieneenfermera);

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
                
                //Crea un GUID (NumeroInterno) por defecto "00000000-0000-0000-0000-000000000000"
                Guid numerointerno = new Guid();
                numerointerno = default(Guid);

                Console.Write("Tiene asistencia? :");
                bool asistencia = Convert.ToBoolean(Console.ReadLine().Trim());

                Console.Write("Especialidad (Por defecto, General): ");
                // Si no se ingresa una especialidad se queda por defecto "General";
                string especialidad = "General";
                especialidad = Console.ReadLine().Trim();

                Especialista unE = new Especialista(numeroconsultorio, fecha, nombremedico, cantidadnumeros, numerointerno, asistencia, especialidad);
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
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Mantenimiento Paciente");
            Console.WriteLine("---------------------------------------------------------\n\n");

            try
            {
                //numero de cedula
                Console.Write("Inserte número de cedula: ");
                int _numerocedula = Convert.ToInt32(Console.ReadLine().Trim());

                //busco por cedula
                Paciente unP = _log.BuscarPaciente(_numerocedula);

                //si no encuentra la cedula lo crea
                if (unP == null)
                {
                    AltaPaciente(_numerocedula, _log);
                }
                else
                {
                    string _opcion = "0";
                    bool _bandera = false;
                    //se crea una bandera para que corte el ciclo del while con su menu
                    while (!_bandera)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine(" 1 - Modificar");
                        Console.WriteLine(" 2 - Eliminar");
                        Console.WriteLine(" 3 - Salir a Menu Principal");

                        _opcion = Console.ReadLine().Trim();
                        switch (_opcion)
                        {
                            case "1":
                                ModificarPaciente(unP, _log);
                                _bandera = true;
                                break;
                            case "2":
                                EliminarPaciente(unP, _log);
                                _bandera = true;
                                break;
                            case "3":
                                _bandera = true;
                                break;
                            default:
                                Console.WriteLine("Error - Opcion de Menu Invalida");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }


        public static void AltaPaciente(int _numerocedula, Logica _log)
        {
            string _nombrepaciente = "";
            Console.Write("Ingrese el nombre del paciente: ");
            _nombrepaciente = Console.ReadLine().Trim();

            DateTime _fechanacimiento;
            Console.Write("Ingrese la fecha de nacimineto dd/mm/aaaa: ");
            _fechanacimiento = Convert.ToDateTime(Console.ReadLine());

            try
            {
                Paciente unP = new Paciente(_nombrepaciente, _fechanacimiento, _numerocedula);
                if (_log.AltaPaciente(unP))
                {
                    Console.WriteLine("ALta Correcta");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - no se pudo crear el paciente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void AltaConsultaComun(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Agregar Consulta Comun");
                Console.WriteLine("---------------------------------------------------------\n\n");


                    int _numeroconsulta = 0;


                    Console.Write("Número de consultorio: " );
                    int _numeroconsultorio = Convert.ToInt32(Console.ReadLine().Trim());
                     
                    Console.Write("Ingrese la fecha y hora de consulta: ");
                    DateTime _fechaconsulta = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Ingrese el nombre del medico: ");
                    string _nombremedico = Console.ReadLine().Trim();

                    Console.Write("Ingrese la cantidad de numeros: ");
                    int _cantdidadnumero = Convert.ToInt32(Console.ReadLine().Trim());

                    bool _tieneenfermera = false;
                    Console.Write("Tiene enfermera?: " + _tieneenfermera);
                    Console.ReadLine();

                    Comun unaC = new Comun(_numeroconsulta, _numeroconsultorio, _fechaconsulta, _nombremedico, _cantdidadnumero, _tieneenfermera);

                    //inserto consuta comun nueva
                    if (_log.AltaConsultaComun(unaC))
                    {
                        Console.WriteLine("Alta Correcta");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("Error - En Alta Consulta Comun");
                    }
                }
            
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }
        }

        public static void AltaConsultaEspecialista(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Agregar Consulta Especialista");
                Console.WriteLine("---------------------------------------------------------\n\n");

 
                    int _numeroconsulta = 0;


                    Console.Write("Agregar consulta, número de consultorio: ");
                    int _numeroconsultorio = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("Ingrese la fecha y hora de consulta: ");
                    DateTime _fechaconsulta = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Ingrese el nombre del medico: ");
                    string _nombremedico = Console.ReadLine().Trim();

                    Console.Write("Ingrese la cantidad de numeros: ");
                    int _cantdidadnumero = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("Ingrese la especialidad: ");
                    string _especialidad = Console.ReadLine().Trim();

                    Especialista unaE = new Especialista(_numeroconsulta, _numeroconsultorio, _fechaconsulta, _nombremedico, _cantdidadnumero, _especialidad);

                    if (_log.AltaConsultaEspecialista(unaE))
                    {
                        Console.WriteLine("Alta Correcta");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("Error - En Alta Consulta Especialista");
                    }   
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }
        }

        public static void AltaSolicitud(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Agregar Solicitud");
                Console.WriteLine("---------------------------------------------------------\n\n");

                //numero de cedula
                Console.Write("Ingrese el número de cédula del paciente: ");
                int _numerocedula = Convert.ToInt32(Console.ReadLine().Trim());

                //busco por cedula
                Paciente unP = _log.BuscarPaciente(_numerocedula);

                if (unP == null)
                {
                    Console.WriteLine("El paciente no existe");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine(unP.ToString());
                }
                Console.ReadLine();


                Console.Write("Ingrese numero de consulta: ");
                int numconsulta = Convert.ToInt32(Console.ReadLine());
                Consulta unaC = _log.BuscarConsulta(numconsulta);
                if (unaC == null)
                {
                    Console.WriteLine("No hay numero de consultorio no existe");
                    Console.ReadLine();
                     return;  //me voy del listar
                }
                else
                {
                    Console.WriteLine(unaC.ToString());
                }
                Console.ReadLine();
            
                int _numerointerno = 0;


                DateTime _fechasolicitud = DateTime.Today;
                Console.Write("La fecha del dia es: " + _fechasolicitud);
                Console.ReadLine();

                bool _asistencia = false;
                Console.Write("Concurrio?: " + _asistencia);
                Console.ReadLine();

                Solicitud UnaS = new Solicitud(_numerointerno, _fechasolicitud, _asistencia, unP, unaC);
                if (_log.AgregarSolicitud(UnaS))
                {
                    Console.WriteLine("Alta Correcta");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - En Alta Consulta Especialista");
                }


                //si no encuentra la cedula lo crea
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ModificarPaciente(Paciente unP, Logica _log)
        {
            int _cedulapaciente;
            Console.Write("Ingrese el nuevo numero de cedula: ");
            _cedulapaciente = Convert.ToInt32(Console.ReadLine().Trim());

            string _nombrepaciente = "";
            Console.Write("Ingrese Nuevo Nombre: ");
            _nombrepaciente = Console.ReadLine().Trim();

            DateTime _fechanacimiento;
            Console.Write("Ingrese la nueva fecha de nacimineto: ");
            _fechanacimiento = Convert.ToDateTime(Console.ReadLine());

            try
            {
                unP.NombrePaciente = _nombrepaciente;
                if (_log.ModificarPaciente(unP))
                {
                    Console.WriteLine("Modificacion Correcta");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - En Modificacion - Inmobiliaria");
                }
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }
        }
        public static void EliminarPaciente(Paciente unP, Logica _log)
        {
            try
            {
                if (_log.EliminarPaciente(unP))
                {
                    Console.WriteLine("Eliminacion Correcta");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - En Eliminar - Inmobiliaria");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ListadoConsulta(Logica _log)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("               Listado de Consultas");
            Console.WriteLine("---------------------------------------------------------\n\n");

            //busco la informacion
            List<Consulta> _lista = _log.ListaConsulta();

            if (_lista.Count == 0)
            {
                Console.WriteLine("No hay consultas medicas para listar - Para listar Agregue alguna");
                Console.ReadLine();
                return;
            }

            foreach (Consulta C in _lista)
            {
                Console.WriteLine(C.ToString());
            }

            Console.ReadLine();
        }
    }
}
