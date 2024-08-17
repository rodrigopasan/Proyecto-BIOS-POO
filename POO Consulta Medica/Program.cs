using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Consulta_Medica
{
    class Program

    {
        static void Main(string[] args)
        {
            //Repositorio
            Logica _log = new Logica();
            int opcionMenu = 0;
            // Bucle principal del menú, se ejecuta hasta que se seleccione la opción de salir (9)
            while (opcionMenu != 9)
            {
                Menu();
                opcionMenu = SeleccionoOpcionMenu();
                procesoMenu(_log, opcionMenu);
            }

        }
        // Método para mostrar el menú principal
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Caso de Estudio Final");
            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine("1 - Mantenimiento Pacientes");
            Console.WriteLine("2 - Alta Consulta Común");
            Console.WriteLine("3 - Alta Consulta Especialista");
            Console.WriteLine("4 - Agregar Solicitud");
            Console.WriteLine("5 - Marcar Asistenca Solicitud Número");
            Console.WriteLine("6 - Listado Solicitudes de Consultas");
            Console.WriteLine("7 - Listado Consulta");
            Console.WriteLine("8 - Listado Solicitudes de Consulta Paciente");
            Console.WriteLine("9 - Salir");

        }
        // Método para capturar la opción seleccionada por el usuario
        public static int SeleccionoOpcionMenu()
        {
            Console.WriteLine();
            Console.Write("Ingrese una opción: ");
            try
            {
                var opcion = Convert.ToInt32(Console.ReadLine().Trim());
                return opcion;
            }
            catch
            {
               return 0;
            }
        }
        // Método para procesar la opción seleccionada del menú
        public static void procesoMenu(Logica _log, int opcionMenu)
        {
            switch (opcionMenu)
            {
                case 1:
                    MantenimientoPaciente(_log);
                    break;
                case 2:
                    AltaConsultaComun(_log);
                    break;
                case 3:
                    AltaConsultaEspecialista(_log);
                    break;
                case 4:
                    AltaSolicitud(_log);
                    break;
                case 5:
                    MarcarAsistenciaSolicitudNumero(_log);
                    break;
                case 6:
                    ListadoSolicitudesdeConsulta(_log);
                    break;
                case 7:
                    ListadoConsulta(_log);
                    break;
                case 8:
                    ListadoSolicitudesConsultaPaciente(_log);
                    break;
                case 9:
                    // Mensaje al finalizar el programa
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("                Final del Programa");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n-> ERROR - ");
                    Console.ResetColor();
                    Console.WriteLine("La opción ingresada en el menú no es correcta...");
                    Console.ReadLine();
                    break;
            }
        }
        // Método para el mantenimiento de pacientes (alta, modificación o eliminación)
        public static void MantenimientoPaciente(Logica _log)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Mantenimiento Paciente");
            Console.WriteLine("---------------------------------------------------------\n\n");

            try
            {
                // Solicitar el número de cédula del paciente
                Console.Write("Ingrese número de cedula: ");
                int _numerocedula = Convert.ToInt32(Console.ReadLine().Trim());

                // Buscar al paciente por cédula
                Paciente unP = _log.BuscarPaciente(_numerocedula);

                // Si no se encuentra el paciente, se da de alta uno nuevo
                if (unP == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n-> Paciente inexistente - ");
                    Console.ResetColor();
                    Console.Write("Complete los datos para dar de alta al paciente...\n");
                    AltaPaciente(_numerocedula, _log);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n-> Paciente Encontrado\n");
                    Console.ResetColor();

                    Console.WriteLine(unP.ToString());

                    string _opcion = "0";
                    bool _bandera = false;
                    //Se crea una bandera para que corte el ciclo del while con su menu
                    while (!_bandera)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine(" 1 - Modificar");
                        Console.WriteLine(" 2 - Eliminar");
                        Console.WriteLine(" 3 - Salir a Menu Principal");
                        Console.Write("\nSeleccione una opción: ");
                        
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
                                Console.Write("\nError - La opción ingresada no es correcta");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n-> ERROR - ");
                Console.ResetColor();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        // Método para dar de alta un nuevo paciente
        public static void AltaPaciente(int _numerocedula, Logica _log)
        {
            string _nombrepaciente = "";
            Console.Write("\nNombre y apellido del paciente: ");
            _nombrepaciente = Convert.ToString(Console.ReadLine().Trim());

            DateTime _fechanacimiento;
            Console.Write("\nFecha de nacimiento dd/mm/aaaa: ");
            _fechanacimiento = Convert.ToDateTime(Console.ReadLine());
            bool _tienesolicitud = false;

            try
            {
                // Crear una nueva entrada de Paciente y lo agrega
                Paciente unP = new Paciente(_nombrepaciente, _fechanacimiento, _numerocedula, _tienesolicitud);
                if (_log.AltaPaciente(unP))
                {
                    Console.WriteLine("Alta Correcta");
                    Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n-> ERROR - ");
                    Console.ResetColor();
                    throw new Exception("No se creó el paciente. Revise los datos ingresados...");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n-> ERROR - ");
                Console.ResetColor();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
       
        // Método para dar de alta una consulta común
        public static void AltaConsultaComun(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Agregar Consulta Comun");
                Console.WriteLine("---------------------------------------------------------\n\n");


                int _numeroconsulta = 0;
                Console.Write("Ingrese la fecha de su consulta (día/mes/año): ");
                
                DateTime FSolicitada = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Ingrese el número del consultorio (1 al 40): ");
                int CSolicitado = Convert.ToInt32(Console.ReadLine().Trim());

                // Buscar las consultas ya registradas para verificar disponibilidad
                List<Consulta> _lista = _log.ListaConsulta();

                Console.Write($"\nConsultas para la fecha: {FSolicitada.Day}/{FSolicitada.Month}/{FSolicitada.Year} Consultorio: {CSolicitado}\n");
                Console.Write($"Si existen horarios ocupados se mostrarán aquí\n");
                int _cantdidadnumero = 1;

                //Mostrar horarios ocupados si hay coincidencias

                if (_lista.Count != 0)
                {
                    List<Consulta> listaOrdenada = _log.OrdenarFechas(_lista);
                    foreach (Consulta C in listaOrdenada)
                    {
                        if (FSolicitada.Date == C.FechaHora.Date && CSolicitado == C.NumeroConsultorio)
                        {
                            Console.Write($"->  {C.FechaHora.Hour}:00   -  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"OCUPADO \n");
                            Console.ResetColor();
                            _cantdidadnumero = _cantdidadnumero + 1;
                        }
                    }
                }
                //Solicitar el horario preferido
                string _opcion = "0";
                DateTime _FechayHora = FSolicitada;
                //Asignar la hora según la opción seleccionada
                bool _bandera = false;
                while (!_bandera)
                {
                    Console.WriteLine($"\n\nIngrese el horario (1 al 9): \n 1 - 6:00 AM \n 2 - 8:00 AM \n 3 - 10:00 AM \n 4 - 12:00 PM \n 5 - 14:00 PM \n 6 - 16:00 PM \n 7 - 18:00 PM \n 8 - 20:00 PM \n 9 - 22:00 PM");
                    Console.Write("Horario preferido: ");
                    
                    _opcion = Console.ReadLine().Trim();
                    switch (_opcion)
                    {
                        case "1":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 6, 0, 0);
                            _bandera = true;
                            break;
                        case "2":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 8, 0, 0);
                            _bandera = true;
                            break;
                        case "3":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 10, 0, 0);
                            _bandera = true;
                            break;
                        case "4":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 12, 0, 0);
                            _bandera = true;
                            break;
                        case "5":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 14, 0, 0);
                            _bandera = true;
                            break;
                        case "6":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 16, 0, 0);
                            _bandera = true;
                            break;
                        case "7":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 18, 0, 0);
                            _bandera = true;
                            break;
                        case "8":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 20, 0, 0);
                            _bandera = true;
                            break;
                        case "9":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 22, 0, 0);
                            _bandera = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n-> Error");
                            Console.ResetColor();
                            Console.Write(" - Seleccione una opcion del 1 al 9");
                            break;
                    }
                }
                    // Dato de Numero de Consultorio
                    int _numeroconsultorio = CSolicitado;
                    DateTime _fechaconsulta = _FechayHora;

                    Console.Write("Ingrese el nombre del medico: ");
                    string _nombremedico = Console.ReadLine().Trim();
                
                // Valor por defecto en false
                Console.Write("¿Cuenta con enfermería? (S/N): ");
                string respuesta = Console.ReadLine().Trim().ToUpper();
                bool _tieneenfermera = false;
                if (respuesta == "S")
                {
                    _tieneenfermera = true;
                }
                else if (respuesta == "N")
                {
                    _tieneenfermera = false;
                }
                else
                {
                    Console.WriteLine("Respuesta no válida");
                    Console.ReadLine();
                    return;
                }
                    
                    // Datos que se envían para validar previo a la carga de la consulta
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
                Console.Write("Ingrese la fecha de su consulta (día/mes/año): ");

                DateTime FSolicitada = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Ingrese el número del consultorio (1 al 40): ");
                int CSolicitado = Convert.ToInt32(Console.ReadLine().Trim());

                // Buscar las consultas ya registradas para verificar disponibilidad
                List<Consulta> _lista = _log.ListaConsulta();

                Console.Write($"\nConsultas para la fecha: {FSolicitada.Day}/{FSolicitada.Month}/{FSolicitada.Year} Consultorio: {CSolicitado}\n");
                Console.Write($"Si existen horarios ocupados se mostrarán aquí\n");
                int _cantdidadnumero = 1;

                //Mostrar horarios ocupados si hay coincidencias

                if (_lista.Count != 0)
                {
                    List<Consulta> listaOrdenada = _log.OrdenarFechas(_lista);
                    foreach (Consulta C in listaOrdenada)
                    {
                        if (FSolicitada.Date == C.FechaHora.Date && CSolicitado == C.NumeroConsultorio)
                        {
                            Console.Write($"->  {C.FechaHora.Hour}:00   -  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"OCUPADO \n");
                            Console.ResetColor();
                            _cantdidadnumero = _cantdidadnumero + 1;
                        }
                    }
                }
                //Solicitar el horario preferido
                string _opcion = "0";
                DateTime _FechayHora = FSolicitada;
                //Asignar la hora según la opción seleccionada
                bool _bandera = false;
                while (!_bandera)
                {
                    Console.WriteLine($"\n\nIngrese el horario (1 al 9): \n 1 - 6:00 AM \n 2 - 8:00 AM \n 3 - 10:00 AM \n 4 - 12:00 PM \n 5 - 14:00 PM \n 6 - 16:00 PM \n 7 - 18:00 PM \n 8 - 20:00 PM \n 9 - 22:00 PM");
                    Console.Write("Horario preferido: ");

                    _opcion = Console.ReadLine().Trim();
                    switch (_opcion)
                    {
                        case "1":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 6, 0, 0);
                            _bandera = true;
                            break;
                        case "2":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 8, 0, 0);
                            _bandera = true;
                            break;
                        case "3":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 10, 0, 0);
                            _bandera = true;
                            break;
                        case "4":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 12, 0, 0);
                            _bandera = true;
                            break;
                        case "5":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 14, 0, 0);
                            _bandera = true;
                            break;
                        case "6":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 16, 0, 0);
                            _bandera = true;
                            break;
                        case "7":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 18, 0, 0);
                            _bandera = true;
                            break;
                        case "8":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 20, 0, 0);
                            _bandera = true;
                            break;
                        case "9":
                            _FechayHora = new DateTime(FSolicitada.Year, FSolicitada.Month, FSolicitada.Day, 22, 0, 0);
                            _bandera = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n-> Error");
                            Console.ResetColor();
                            Console.Write(" - Seleccione una opcion del 1 al 9");
                            break;
                    }
                }
                // Dato de Numero de Consultorio
                int _numeroconsultorio = CSolicitado;
                    DateTime _fechaconsulta = _FechayHora;
                
                    Console.Write("Ingrese el nombre del medico: ");
                    string _nombremedico = Console.ReadLine().Trim();

                string _especialidad = "";
                string _especialidadopcion = "0";
                bool _especialidadbandera = false;

                while (!_especialidadbandera)
                {
                    Console.Write("Ingrese una especialidad: ");
                    _especialidad = Console.ReadLine().Trim();

                    _especialidadopcion = Console.ReadLine().Trim();
                    switch (_especialidadopcion)
                    {
                        case "1":
                            _especialidad = "Cardiología";
                            _especialidadbandera = true;
                            break;
                        case "2":
                            _especialidad = "Dermatología";
                            _especialidadbandera = true;
                            break;
                        case "3":
                            _especialidad = "Gastroenterología";
                            _especialidadbandera = true;
                            break;
                        case "4":
                            _especialidad = "Neurología";
                            _especialidadbandera = true;
                            break;
                        case "5":
                            _especialidad = "Pediatría";
                            _especialidadbandera = true;
                            break;
                        case "6":
                            _especialidad = "Oncología";
                            _especialidadbandera = true;
                            break;
                        case "7":
                            _especialidad = "Ginecología";
                            _especialidadbandera = true;
                            break;
                        case "8":
                            _especialidad = "Psiquiatría";
                            _especialidadbandera = true;
                            break;
                        case "9":
                            _especialidad = "Oftalmología";
                            _especialidadbandera = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n-> Error");
                            Console.ResetColor();
                            Console.Write(" - Seleccione una opcion del 1 al 9");
                            break;
                    }
                }

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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n-> Paciente inexistente - ");
                    Console.ResetColor();
                    Console.Write($"enter para volver al menú... - ");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n-> Paciente Encontrado\n");
                    Console.ResetColor();
                    Console.WriteLine(unP.ToString());
                }

                Console.Write("\nIngrese numero de consulta: ");
                int numconsulta = Convert.ToInt32(Console.ReadLine());
                Consulta unaC = _log.BuscarConsulta(numconsulta);
                if (unaC == null)
                {
                    Console.WriteLine("\nEl número de consulta buscado no existe...");
                    Console.ReadLine();
                     return;  //me voy del listar
                }
                else
                {
                    Console.WriteLine(unaC.ToString());
                }
            
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
                    ModificarAsocPacienteSolicitud(unP, _log);
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
        public static void ModificarAsocPacienteSolicitud(Paciente unP, Logica _log)
        {
            try
            {
                unP.TieneSolicitud = true;
                if (_log.ModificarPaciente(unP))
                {
                    return;
                }
                else
                {
                    throw new Exception("Error al intentar marcar al paciente como inmutable");
                }
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
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
                    throw new Exception("Error al momento de modificar al paciente");
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
                if (unP.TieneSolicitud == false)
                { 
                    if (_log.EliminarPaciente(unP))
                    {
                        Console.WriteLine("Eliminacion Correcta");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("Error al momento de eliminar el paciente");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-> ERROR ");
                    Console.ResetColor();
                    throw new Exception("- No se puede borrar pacientes con solicitudes asociadas. Intente con otro paciente...");
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
            List<Consulta> listaOrdenada = _log.OrdenarFechas(_lista);
            if (_lista.Count == 0)
            {
                Console.WriteLine("No hay consultas medicas para listar - Para listar Agregue alguna");
                Console.ReadLine();
                return;
            }
                        
            foreach (Consulta C in listaOrdenada)
            {
                Console.Write("->  ");
                Console.WriteLine(C.ToString());
            }

            Console.ReadLine();
        }

        public static void ListadoSolicitudesdeConsulta(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Listado Solicitudes de Consultas");
                Console.WriteLine("---------------------------------------------------------");
                //pedir numero de consultorio

                Console.Write("Ingrese el numero de consulta: ");
                int numconsulta = Convert.ToInt32(Console.ReadLine());
                Solicitud unaS = _log.BusSolCons(numconsulta);
                if (unaS == null)
                {
                    Console.WriteLine("No hay numero de consultorio en esta solicitud - No se sigue con el listado");
                    Console.ReadLine();
                    return;  //me voy del listar
                }
                int mostrar = _log.CantidadSolicitudes(unaS);
                Console.WriteLine("Hay " + mostrar + " " + "cantidad de solicitudes: " + unaS.Paciente.NombrePaciente);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void MarcarAsistenciaSolicitudNumero(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("               Marcar Asistencia Solicitud Número");
                Console.WriteLine("---------------------------------------------------------\n\n");

                //  número de solicitud
                Console.Write("Ingrese el número de solicitud: ");
                int numeroSolicitud = Convert.ToInt32(Console.ReadLine().Trim());

                // Buscar la solicitud
                Solicitud solicitud = _log.BuscarSolicitud(numeroSolicitud);
                if (solicitud == null)
                {
                    Console.WriteLine("No se encontró una solicitud con el número proporcionado.");
                    Console.ReadLine();
                    return;
                }

                // información actual
                Console.WriteLine("Solicitud Encontrada:");
                Console.WriteLine(solicitud.ToString());
                Console.WriteLine("Estado de asistencia actual: " + (solicitud.Asistencia ? "Asistió" : "No asistió"));

                // Preguntar si asistió
                Console.Write("¿El paciente asistió? (S/N): ");
                string respuesta = Console.ReadLine().Trim().ToUpper();

                if (respuesta == "S")
                {
                    solicitud.Asistencia = true;
                }
                else if (respuesta == "N")
                {
                    solicitud.Asistencia = false;
                }
                else
                {
                    Console.WriteLine("Respuesta no válida");
                    Console.ReadLine();
                    return;
                }

                // Actualizar la solicitud
                if (_log.ActualizarSolicitud(solicitud))
                {
                    Console.WriteLine("Asistencia actualizada correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al actualizar la asistencia.");
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void ListadoSolicitudesConsultaPaciente(Logica _log)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("               Listado de Solicitudes de Consulta Paciente");
            Console.WriteLine("---------------------------------------------------------");

            try
            {
                // Número de cédula del paciente
                Console.Write("Ingrese el número de cédula del paciente: ");
                int _numerocedula = Convert.ToInt32(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine().Trim(), out _numerocedula))
                {
                    Console.WriteLine("Número de cédula inválido.");
                    Console.ReadLine();
                    return;
                }

                // Buscar paciente
                Paciente paciente = _log.BuscarPaciente(_numerocedula);
                if (paciente == null)
                {
                    Console.WriteLine("No se encontró el paciente con la cédula proporcionada.");
                    Console.ReadLine();
                    return;
                }

                // filtro de solicitudes
                Console.WriteLine("Seleccione el tipo de solicitudes a mostrar:");
                Console.WriteLine("1. Solicitudes asistidas");
                Console.WriteLine("2. Solicitudes no asistidas");
                Console.Write("Ingrese el número de opción: ");
                string opcion = Console.ReadLine().Trim();

                List<Solicitud> solicitudes = _log.ListadoSolicitudesPaciente(paciente);
                if (solicitudes.Count == 0)
                {
                    Console.WriteLine("No hay solicitudes de consulta para el paciente.");
                    Console.ReadLine();
                    return;
                }

                // según la opción elegida
                List<Solicitud> solicitudesFiltradas;
                switch (opcion)
                {
                    case "1":
                        solicitudesFiltradas = solicitudes.Where(s => s.Asistencia).ToList();
                        Console.WriteLine("Solicitudes asistidas:");
                        break;
                    case "2":
                        solicitudesFiltradas = solicitudes.Where(s => !s.Asistencia).ToList();
                        Console.WriteLine("Solicitudes no asistidas:");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. No se mostrarán resultados.");
                        Console.ReadLine();
                        return;
                }

                if (solicitudesFiltradas.Count == 0)
                {
                    Console.WriteLine("No hay solicitudes que coincidan con el criterio seleccionado.");
                }
                else
                {
                    foreach (Solicitud solicitud in solicitudesFiltradas)
                    {
                        Console.WriteLine(solicitud.ToString());
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error: " + ex.Message);
                Console.ReadLine();
            }
        }



    }
}
