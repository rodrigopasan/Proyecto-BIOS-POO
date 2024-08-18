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

            Console.WriteLine("--------------------------------------------------------");
            Alertas("|*||*||*|   Sistema de Gestión - Policlínica   |*||*||*|", 0, "DarkCyan");
            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("1 - Gestionar Pacientes");
            Console.WriteLine("2 - Registrar Consulta Común");
            Console.WriteLine("3 - Registrar Consulta con Especialista");
            Console.WriteLine("4 - Crear Nueva Solicitud");
            Console.WriteLine("5 - Marcar Asistencia en Solicitud");
            Console.WriteLine("6 - Ver Solicitudes por Número de Consulta");
            Console.WriteLine("7 - Ver Consultas Registradas");
            Console.WriteLine("8 - Buscar Solicitudes por Paciente");
            Console.WriteLine("9 - Salir del Sistema");

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
                    Alertas("La opción ingresada en el menú no es correcta...", 1,"");
                    Console.ReadLine();
                    break;
            }
        }
        // Método para el mantenimiento de pacientes (alta, modificación o eliminación)
        public static void MantenimientoPaciente(Logica _log)
        {
            Console.Clear();
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
            Alertas("                Mantenimiento Paciente", 0, "Magenta");
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

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
                    Alertas("-> Paciente inexistente - ", 2, "Yellow");
                    Console.Write("Complete los datos para dar de alta al paciente...\n");
                    AltaPaciente(_numerocedula, _log);
                }
                else
                {
                    Alertas("-> Paciente Encontrado\n", 0, "Green");

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
                                Alertas("La opción ingresada no es correcta", 1, "");
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
                    Alertas("\n-> ERROR - ", 0, "Red");
                    throw new Exception("No se creó el paciente. Revise los datos ingresados...");
                }
            }
            catch (Exception ex)
            {
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
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
                Alertas("               Registrar Consulta Común", 0, "Blue");
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

                

                DateTime FSolicitada = SolicitarFechaConsulta();

                int _numeroconsultorio = SolicitarNumeroConsultorio();

                List<Consulta> _lista = _log.ListaConsulta();

                MostrarHorariosOcupados(FSolicitada, _numeroconsultorio, _lista, _log);

                DateTime _fechaconsulta = SolicitarHorarioPreferido(FSolicitada);

                string _nombremedico = SolicitarNombreMedico();

                bool _tieneenfermera = SolicitarEnfermeria();

                int _cantidadnumeros = SolicitarMaxNumeros();


                Comun unaC = new Comun(0, _numeroconsultorio, _fechaconsulta, _nombremedico, _cantidadnumeros, _tieneenfermera);
                if (_log.AltaConsultaComun(unaC))
                    {
                        Console.WriteLine("Alta Correcta");
                        Console.ReadLine();
                    }
                    else
                    {
                        Alertas("\n-> ERROR - ", 0, "Red");
                        throw new Exception("En Alta Consulta Comun");
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
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
                Alertas("               Registrar Consulta con Especialista", 0, "Yellow");
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

                DateTime FSolicitada = SolicitarFechaConsulta();

                int _numeroconsultorio = SolicitarNumeroConsultorio();

                List<Consulta> _lista = _log.ListaConsulta();

                MostrarHorariosOcupados(FSolicitada, _numeroconsultorio, _lista, _log);

                DateTime _fechaconsulta = SolicitarHorarioPreferido(FSolicitada);

                string _nombremedico = SolicitarNombreMedico();

                string _especialidad = SolicitarEspecialidad();

                int _cantidadnumeros = SolicitarMaxNumeros();


                Especialista unaE = new Especialista(0, _numeroconsultorio, _fechaconsulta, _nombremedico, _cantidadnumeros, _especialidad);
                if (_log.AltaConsultaEspecialista(unaE))
                    {
                        Console.WriteLine("Alta Correcta");
                        Console.ReadLine();
                    }
                    else
                    {
                        Alertas("\n-> ERROR - ", 0, "Red");
                        throw new Exception("En Alta Consulta Especialista");
                    }   
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }
        }
        private static DateTime SolicitarFechaConsulta()
        {
            Console.Write("Ingrese la fecha de su consulta (día/mes/año): ");
            return Convert.ToDateTime(Console.ReadLine());
        }
        private static int SolicitarNumeroConsultorio()
        {
            Console.Write("Ingrese el número del consultorio (1 al 40): ");
            return Convert.ToInt32(Console.ReadLine().Trim());
        }
        private static void MostrarHorariosOcupados(DateTime FSolicitada, int CSolicitado, List<Consulta> _lista, Logica _log)
        {
            Alertas($"\nConsultas para la fecha: {FSolicitada.Day}/{FSolicitada.Month}/{FSolicitada.Year} Consultorio: {CSolicitado}", 0, "Green");
            Console.WriteLine("Si existen horarios ocupados se mostrarán aquí:");

            if (_lista.Count != 0)
            {
                List<Consulta> listaOrdenada = _log.OrdenarFechas(_lista);
                foreach (Consulta C in listaOrdenada)
                {
                    if (FSolicitada.Date == C.FechaHora.Date && CSolicitado == C.NumeroConsultorio)
                    {
                        Console.Write($"->  {C.FechaHora.Hour}:00   -  ");
                        Alertas("OCUPADO", 0, "Red");
                    }
                }
            }
        }
        private static DateTime SolicitarHorarioPreferido(DateTime fecha)
        {
            string _opcion = "0";
            DateTime _FechayHora = fecha;
            bool _bandera = false;

            while (!_bandera)
            {
                Console.WriteLine($"\n\nIngrese el horario (1 al 9): \n 1 - 6:00 AM \n 2 - 8:00 AM \n 3 - 10:00 AM \n 4 - 12:00 PM \n 5 - 14:00 PM \n 6 - 16:00 PM \n 7 - 18:00 PM \n 8 - 20:00 PM \n 9 - 22:00 PM");
                Console.Write("Horario preferido: ");
                _opcion = Console.ReadLine().Trim();

                switch (_opcion)
                {
                    case "1":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 6, 0, 0);
                        _bandera = true;
                        break;
                    case "2":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 8, 0, 0);
                        _bandera = true;
                        break;
                    case "3":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0);
                        _bandera = true;
                        break;
                    case "4":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0);
                        _bandera = true;
                        break;
                    case "5":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 0, 0);
                        _bandera = true;
                        break;
                    case "6":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 0, 0);
                        _bandera = true;
                        break;
                    case "7":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 18, 0, 0);
                        _bandera = true;
                        break;
                    case "8":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 20, 0, 0);
                        _bandera = true;
                        break;
                    case "9":
                        _FechayHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 22, 0, 0);
                        _bandera = true;
                        break;

                    default:
                        Alertas("Seleccione una opcion del 1 al 9", 1, "");
                        break;
                }
             }
            return _FechayHora;
        }
        private static string SolicitarEspecialidad()
        {
            string especialidad = "";
            bool especialidadBandera = false;

            while (!especialidadBandera)
            {
                Console.WriteLine("Ingrese el número de la especialidad: \n 1 - Cardiología \n 2 - Dermatología \n 3 - Gastroenterología \n 4 - Neurología \n 5 - Pediatría \n 6 - Oncología \n 7 - Ginecología \n 8 - Psiquiatría \n 9 - Oftalmología");
                Console.Write("Especialidad: ");
                string especialidadOpcion = Console.ReadLine().Trim();

                switch (especialidadOpcion)
                {
                    case "1":
                        especialidad = "Cardiología";
                        especialidadBandera = true;
                        break;
                    case "2":
                        especialidad = "Dermatología";
                        especialidadBandera = true;
                        break;
                    case "3":
                        especialidad = "Gastroenterología";
                        especialidadBandera = true;
                        break;
                    case "4":
                        especialidad = "Neurología";
                        especialidadBandera = true;
                        break;
                    case "5":
                        especialidad = "Pediatría";
                        especialidadBandera = true;
                        break;
                    case "6":
                        especialidad = "Oncología";
                        especialidadBandera = true;
                        break;
                    case "7":
                        especialidad = "Ginecología";
                        especialidadBandera = true;
                        break;
                    case "8":
                        especialidad = "Psiquiatría";
                        especialidadBandera = true;
                        break;
                    case "9":
                        especialidad = "Oftalmología";
                        especialidadBandera = true;
                        break;
                    default:
                        Alertas("Seleccione una opcion del 1 al 9", 1, "");
                        break;
                }
            }

            return especialidad;
        }
        private static string SolicitarNombreMedico()
        {
            Console.Write("Ingrese el nombre del médico: ");
            string medico = Console.ReadLine().Trim();

            if (medico == "")
                {
                    medico = "Médico de Guardia";
                }

            return medico;
        }

        private static bool SolicitarEnfermeria()
        {
            
            bool enfermeria = false;
            bool enfermeriaBandera = false;

            while (!enfermeriaBandera)
            {
                Console.Write("¿Cuenta con enfermería? (S/N): ");
                string respuesta = Console.ReadLine().Trim().ToUpper();
                switch (respuesta)
                {
                    case "S":
                        enfermeria = true;
                        enfermeriaBandera = true;
                        break;
                    case "N":
                        enfermeria = false;
                        enfermeriaBandera = true;
                        break;

                    default:
                        Alertas("Respuesta no válida\n", 1, "");
                        break;
                }
             }

            return enfermeria;
        }
        private static int SolicitarMaxNumeros()
        {
            Console.Write("Ingrese la cantidad de números habilitados: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void AltaSolicitud(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
                Alertas("               Crear Nueva Solicitud", 0, "DarkMagenta");
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

                //numero de cedula
                Console.Write("Ingrese el número de cédula del paciente: ");
                int _numerocedula = Convert.ToInt32(Console.ReadLine().Trim());

                //busco por cedula
                Paciente unP = _log.BuscarPaciente(_numerocedula);

                if (unP == null)
                {
                    Alertas("\n-> Paciente inexistente", 0, "Yellow");
                    Console.Write($"Precione enter para volver al menú...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Alertas("\n-> Paciente Encontrado", 0, "Green");
                    Console.WriteLine(unP.ToString());
                }

                Console.Write("\nIngrese número de consulta (ID): ");
                int numconsulta = Convert.ToInt32(Console.ReadLine());
                Consulta unaC = _log.BuscarConsulta(numconsulta);
                if (unaC == null)
                {
                    Alertas("\n-> Número de consulta ID inexistente", 0, "Yellow");
                    Console.Write("\nPuede encontrar los ID de consultas desde el menú...");
                    Console.ReadLine();
                     return;  //me voy del listar
                }
                else
                {
                    Alertas("\n-> Consulta Encontrada", 0, "Green");
                    Console.WriteLine(unaC.ToString());
                    Console.Write("\nSeleccione una opción:\n1 - Confirmar \n2 - Salir");
                    Console.Write("\nOpción: ");
                    string _continuar = Console.ReadLine().Trim();
                    switch (_continuar)
                    {
                        case "1":
                            break;
                        case "2":
                            return;
                        default:
                            Alertas("\n-> ERROR ", 0, "Red");
                            Console.WriteLine("Opción inválida, presione enter para salir...");
                            Console.ReadLine();
                            return;
                    }
                }
            
                //bool _asistencia = false;

                Solicitud UnaS = new Solicitud(0, DateTime.Now, false, 0, unP, unaC);
                if (_log.AgregarSolicitud(UnaS))
                {
                    ModificarAsocPacienteSolicitud(unP, _log);
                    Console.WriteLine("Alta Correcta");
                    Console.ReadLine();
                }
                else
                {
                    Alertas("\n-> Error", 0, "Red");
                    throw new Exception(" - No se realizó el alta de la solicitud - Revise los datos ingresados...");
                }
                
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
                if (unP.TieneSolicitud == true)
                {
                    return;
                }
                else
                {
                    unP.TieneSolicitud = false;
                    Alertas("\n-> Error", 0, "Red");
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
                    Alertas("\n-> Error", 0, "Red");
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
                    Alertas("\n-> Error", 0, "Red");
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
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
            Alertas("               Ver Consultas Registradas", 0, "Green");
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

            //busco la informacion
            List<Consulta> _lista = _log.ListaConsulta();
            List<Consulta> listaOrdenada = _log.OrdenarFechas(_lista);
            if (_lista.Count == 0)
            {
                Alertas("No hay consultas medicas para listar - Para listar Agregue alguna", 2, "");
                Console.ReadLine();
                return;
            }
                        
            foreach (Consulta C in listaOrdenada)
            {
                Console.Write("->  ");
                Console.WriteLine(C.ToString());
            }
            Console.WriteLine("\n---------------------------------------------------------\nPrecione enter para volver al menú...");
            Console.ReadLine();
        }

        public static void ListadoSolicitudesdeConsulta(Logica _log)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
                Alertas("               Ver Solicitudes por Número de Consulta", 0, "Cyan");
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");

                Console.Write("Ingrese el número de consulta (ID): ");
                int numconsulta = Convert.ToInt32(Console.ReadLine());

                List<Solicitud> _listaS = _log.BuscarSolicitudesPorConsulta(numconsulta);
                if (_listaS == null || _listaS.Count == 0)
                {
                    Console.WriteLine("No hay solicitudes asociadas a esta consulta.");
                    Console.ReadLine();
                    return;  // Salir del listado
                }
                // Le paso [0] para tener la primera solicitud como ejemplo para buscar las otras.
                int mostrar = _log.CantidadSolicitudes(_listaS[0]);
                Alertas("-> Hay " + mostrar + " de " + _listaS[0].Consulta.CantidadNumeros + " " + "solicitud/es asociada/s a la consulta ID " + numconsulta, 0, "Green");
                foreach (Solicitud L in _listaS)
                {
                    Console.Write($"\nIdentificador Solicitud: {L.NumeroInterno}\n\nPaciente: {L.Paciente.NombrePaciente}\n\nFecha Solicitud: {L.FechaSolicitud}\n\nFecha Consulta: {L.Consulta.FechaHora}\n\nPrioridad de atención (lugar): {L.Lugar}\n----------------------------------------\n\n");
                }

                Console.WriteLine("\nPrecione enter para salir...");
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
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
                Alertas("               Marcar Asistencia en Solicitud", 0, "DarkBlue");
                Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n\n");

                //  número de solicitud
                Console.Write("Ingrese el número interno de solicitud: ");
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
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");
            Alertas("               Buscar Solicitudes por Paciente", 0, "Gray");
            Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/");

            try
            {
                // Número de cédula del paciente
                Console.Write("Ingrese el número de cédula del paciente: ");
                int _numerocedula;
                if (!int.TryParse(Console.ReadLine().Trim(), out _numerocedula))
                {
                    Alertas("Número de cédula inválido...",2,"");
                    Console.ReadLine();
                    return;
                }

                // Buscar paciente
                Paciente paciente = _log.BuscarPaciente(_numerocedula);
                if (paciente == null)
                {
                    Alertas("No se encontró el paciente con la cédula proporcionada...", 2, "");
                    Console.ReadLine();
                    return;
                }

                // filtro de solicitudes
                Console.WriteLine("Seleccione el tipo de solicitudes a mostrar:\n\n");
                Console.WriteLine(" 1. Solicitudes con Asistencia");
                Console.WriteLine(" 2. Solicitudes sin Asistencia");
                Console.Write("\nOpción: ");
                string opcion = Console.ReadLine().Trim();

                List<Solicitud> solicitudes = _log.ListadoSolicitudesPaciente(paciente);
                if (solicitudes.Count == 0)
                {
                    Alertas("No hay solicitudes de consulta para el paciente...", 2, "");
                    Console.ReadLine();
                    return;
                }

                // según la opción elegida
                List<Solicitud> solicitudesFiltradas;
                Alertas("-> Se encontraron solicitudes\n", 0, "Green");
                switch (opcion)
                {
                    case "1":
                        solicitudesFiltradas = solicitudes.Where(s => s.Asistencia).ToList();
                        Console.WriteLine("Solicitudes con Asistencia:\n");
                        break;
                    case "2":
                        solicitudesFiltradas = solicitudes.Where(s => !s.Asistencia).ToList();
                        Console.WriteLine("Solicitudes sin Asistencia:\n");
                        break;
                    default:
                        Alertas("Opción no válida. No se mostrarán resultados...", 2, "");
                        Console.ReadLine();
                        return;
                }

                if (solicitudesFiltradas.Count == 0)
                {
                    Alertas("No hay solicitudes que coincidan con el criterio seleccionado...", 2, "");
                }
                else
                {
                    foreach (Solicitud solicitud in solicitudesFiltradas)
                    {
                        Console.WriteLine(solicitud.ToString());
                    }
                }
                Console.WriteLine("\n------------------------------------------------------\nPrecione enter para volver al menu");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Alertas("Se produjo un error: " + ex.Message, 1, "");
                Console.ReadLine();
            }
        }
        private static void Alertas(string texto, int alerta, string color)
        {
            if (alerta == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n-> ERROR ");
                Console.ResetColor();
                Console.Write($"{texto}");
            }
            if (alerta == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n-> Advertencia - ");
                Console.ResetColor();
                Console.Write($"{texto}");
            }
            if (alerta == 0)
            {
                ConsoleColor cambiarColor = ConsoleColor.White;
                cambiarColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                Console.ForegroundColor = cambiarColor;
                Console.WriteLine($"{texto}");
                Console.ResetColor();
            }
        }


    }
}
