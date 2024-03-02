using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MenuPrincipal
    {
        public List<Estudiante> ListaEstudiantes { get; set; }

        public MenuPrincipal()
        {
            ListaEstudiantes = new List<Estudiante>();
        }
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**           Menú Principal de Estudiantes          **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1- Ingresar estudiantes");
                Console.WriteLine("2- Consultar estudiantes");
                Console.WriteLine("3- Modificar estudiantes");
                Console.WriteLine("4- Eliminar estudiantes");
                Console.WriteLine("5- Submenú de reportes");
                Console.WriteLine("6- Salir");
                Console.WriteLine("Ingrese el número de opción:");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarEstudiante();
                        break;
                    case "2":
                        ConsultarEstudiante();
                        break;
                    case "3":
                        ModificarEstudiante();
                        break;
                    case "4":
                        EliminarEstudiante();
                        break;
                    case "5":
                        //Se valida si hay estudiantes en la lista con los cuales generar reportes
                        if (ListaEstudiantes.Count() > 0)
                        {
                            MenuReportes.Menu(ListaEstudiantes);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No hay datos para generar reportes");
                            Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        }
                        break;
                    case "6":
                        Console.WriteLine("Saliendo...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        Console.Clear();
                        break;
                }
            }
        }

        #region "Métodos para las opciones del menú"
        public void InsertarEstudiante()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**              Registro de Estudiantes             **");
                Console.WriteLine("******************************************************");

                //Se utiliza el método para que se ingrese una cédula
                var cedula = InsertarCedula();

                //Se llama el método "Existe" para que no ingresar duplicados
                if (Existe(cedula))
                {
                    Console.WriteLine("El número de cédula ya fue registrado anteriormente."); //Mensaje de error
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar

                }
                else
                {
                    //Se crea el nuevo estudiante para agregarlo a la lista
                    Estudiante estudiante = new Estudiante();

                    //Se llenan los datos utilizando los métodos de ingreso
                    estudiante.Cedula = cedula;
                    estudiante.Nombre = InsertarNombre();
                    estudiante.Promedio = InsertarPromedio();
                    estudiante.Condicion = AsignarCondicion(estudiante.Promedio);

                    ListaEstudiantes.Add(estudiante);

                    //Se muestra la condició que se le asignó al estudiante
                    Console.WriteLine("La condicion del Estudiante es: " + estudiante.Condicion);

                    //Se consulta si se quiere seguir en esta opción
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("¿Desea ingresar información de otro estudiante? (S/N): ");
                    string continuar = Console.ReadLine();
                    if (continuar.ToUpper() != "S")
                    {
                        break;
                    }

                }
            }
        }
        public void ConsultarEstudiante()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**        Consulta de Estudiantes Registrados       **");
                Console.WriteLine("******************************************************");

                //Se utiliza el método para que se ingrese una cédula válida
                var cedula = InsertarCedula();

                //Se llama el método "Existe" para validar si hay datos a consultar
                if (Existe(cedula))
                {
                    //Se busca al estudiante con la cédula ingresada
                    Estudiante estudiante = ListaEstudiantes.FirstOrDefault(estudiante => estudiante.Cedula == cedula);

                    //Se muestran los datos de ese estudiante
                    Console.WriteLine("-Nombre: {0}", estudiante.Nombre);
                    Console.WriteLine("-Promedio: {0}", estudiante.Promedio);
                    Console.WriteLine("-Condición: {0}", estudiante.Condicion);

                }
                else //en caso de que no exista estudiante con esa cédula
                {
                    Console.WriteLine("El número de cédula no ha sido registrado."); //Mensaje de error
                }

                //Consulta si desea iniciar de nuevo en esta opción
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }
            }
        }
        public void ModificarEstudiante()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**         Modificar Estudiantes Registrados        **");
                Console.WriteLine("******************************************************");
                var cedula = InsertarCedula();

                
                //Se valida si hay un estudiante con esa cédula
                if (Existe(cedula))
                {
                    //Obtiene la información del estudiante
                    Estudiante estudianteModificar = ListaEstudiantes.Find(estudiante => estudiante.Cedula == cedula);

                    //Vuelven a pedir los datos del estudiante para que sean modificados
                    estudianteModificar.Nombre = InsertarNombre();
                    estudianteModificar.Promedio = InsertarPromedio();
                    estudianteModificar.Condicion = AsignarCondicion(estudianteModificar.Promedio);

                    //Muestra la condición que se le asignó al estudiante
                    Console.WriteLine("La condicion del Estudiante es: " + estudianteModificar.Condicion);
                    Console.WriteLine("Cambios realizados con éxito.");//Se confirma que todo salió bien

                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }

                //Consulta si desea iniciar de nuevo en esta opción
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta para modificar? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }

            }
        }
        public void EliminarEstudiante()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**          Eliminar Estudiantes Registrados        **");
                Console.WriteLine("******************************************************");
                var cedula = InsertarCedula();

                //Se valida si existe estudiante con esa cédula
                if (Existe(cedula))
                {
                    //Se elimina el registro con esa cédula
                    ListaEstudiantes.RemoveAll(estudiante => estudiante.Cedula == cedula);
                    Console.WriteLine("El estudiante se eliminó correctamente");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta para eliminar? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }
            }

        }
        #endregion

        #region "Metodos de ingreso y validación"
        public int InsertarCedula()
        {
            int cedIngreso;
            while (true)
            {
                try
                {
                    Console.WriteLine("-Ingrese el número de cédula del Estudiante: ");
                    cedIngreso = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Error: Solo se permite el ingreso de números");
                }

            }
            return cedIngreso;
        }

        public string InsertarNombre()
        {
            string nombre;
            while (true)
            {
                try
                {
                    Console.WriteLine("-Ingrese el nombre del estudiante:");
                    nombre = Console.ReadLine();


                    // Validar que no sea nulo o solo espacios
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        throw new Exception("El nombre no puede estar vacío ni consistir solo de espacios.");
                    }


                    // Validar que el nombre solo contenga letras o los espacios de en medio
                    foreach (char caracter in nombre)
                    {
                        if (!char.IsLetter(caracter) && caracter != ' ' && caracter != 'ñ' && caracter != 'Ñ' /*&& !char.IsWhiteSpace(caracter)*/)
                        {
                            throw new Exception("El nombre debe contener solo letras.");
                        }
                    }

                    break; // Salir del bucle si no hay excepciones
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return nombre;
        }

        public float InsertarPromedio()
        {
            float promedio;
            while (true)
            {
                try
                {
                    Console.WriteLine("-Ingrese el promedio del Estudiante: ");
                    //Se cambian los puntos por comas
                    var valor = Console.ReadLine().Replace(".", ",");

                    promedio = float.Parse(valor);

                    // se verifica si el promedio está dentro del rango válido
                    if (promedio < 0 || promedio > 100)
                    {
                        throw new Exception("El promedio debe ser máximo 100 y mínimo 0"); //Mensaje que tendrá la excepción
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Debe ingresar un número (se aceptan decimales)."); //Excepción en caso de no ser float
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message); //Excepción en caso de no estar en el entre 0 y 100
                }
            }

            return (float)Math.Round(promedio, 2); //Se usa para redondear el número a dos decimales
        }

        public string AsignarCondicion(float promedio)
        {
            //Devuelve condición según el parametro promedio
            if (promedio >= 70)
            {
                return "Aprobado";
            }
            else
            {
                return "Reprobado";
            }
        }

        public bool Existe(int cedula)        
        {
            //Expresión lambda que devuelve true si encuentra que alguno de los estudiantes tiene la cédula que vino como parámetro
            return ListaEstudiantes.Any(estudiante => estudiante.Cedula == cedula);
        }
        #endregion
    }


}
