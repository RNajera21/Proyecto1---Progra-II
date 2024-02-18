using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks.Sources;
//Incluir estudiantes

//Objeto, permite varios tipos de datos en la matriz
object[,] infoestudiantes = new object[10, 4];

//Variables de verificacion
bool nums = false;
bool letras = false;
string text = "";
string condicion = "";
int n = 0;
double prom = 0;
var cedula = 0;
bool existe = true;
int columna = 0;
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
    var opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            for (int i = 0; i < 10; i++)
            {
                //Ciclo para recoleccion de cedulas
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**              Registro de Estudiantes             **");
                Console.WriteLine("******************************************************");
                existe = true;
                columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                for (int c = 0; c < 10; c++)
                {
                    if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)// infoestudiantes[c, 0] == null || infoestudiantes[c, 0] == ""
                    {
                        existe = true;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    Console.WriteLine("El número de cédula ya fue registrado anteriormente.");

                }
                else
                {
                    if (infoestudiantes[i, 0] == null || infoestudiantes[i, 0].Equals("")) {
                        do
                            try
                            {
                                Console.WriteLine("-Ingrese la cédula del Estudiante " + (i + 1));
                                infoestudiantes[i, 0] = int.Parse(Console.ReadLine());
                                nums = false;
                            }
                            catch
                            {
                                Console.WriteLine("------Este campo solo acepta dígitos------");
                                nums = true;
                            }
                        while (nums);

                        //Ciclo de recoleccion de nombre

                        Console.WriteLine("-Nombre del Estudiante  " + (i + 1));
                        infoestudiantes[i, 1] = (Console.ReadLine());

                        //Ingreso del promedio
                        do
                            try
                            {
                                Console.WriteLine("Promedio del estudiante: " + (i + 1));
                                infoestudiantes[i, 2] = double.Parse(Console.ReadLine());
                                nums = false;
                                prom = (double)infoestudiantes[i, 2];

                            }
                            catch
                            {
                                Console.WriteLine("------Este campo solo acepta dígitos------");
                                nums = true;
                            }
                        while (nums);

                        if (prom >= 70)
                            condicion = "Aprobado";
                        else
                            condicion = "Reprobado";

                        Console.WriteLine("La condicion del Estudiante es: " + condicion);
                        infoestudiantes[i, 3] = condicion;

                        //Menú para ingresar mas usuarios
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

            break;
        case 2:
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**        Consulta de Estudiantes Registrados       **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("-Ingrese el número de cédula del estudiante:");
                cedula = int.Parse(Console.ReadLine());

                //Recorre el arreglo en busqueda de la cédula
                existe = true;
                columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                for (int c = 0; c < 10; c++)
                {
                    if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)
                    {
                        existe = true;
                        columna = c;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    Console.WriteLine("-Nombre: {0}", infoestudiantes[columna, 1]);
                    Console.WriteLine("-Promedio: {0}", infoestudiantes[columna, 2]);
                    Console.WriteLine("-Condición: {0}", infoestudiantes[columna, 3]);

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No existe un registro para la cédula digitada.");

                }
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }

            }
            break;
        case 3:
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**         Modificar Estudiantes Registrados        **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("-Ingrese el número de cédula del estudiante:");
                cedula = int.Parse(Console.ReadLine());

                //Recorre el arreglo en busqueda de la cédula
                existe = true;
                columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                for (int c = 0; c < 10; c++)
                {
                    if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)
                    {
                        existe = true;
                        columna = c;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    Console.WriteLine("-Nombre del Estudiante:");
                    infoestudiantes[columna, 1] = (Console.ReadLine());

                    //Ingreso del promedio
                    do
                        try
                        {
                            Console.WriteLine("Promedio del estudiante: ");
                            infoestudiantes[columna, 2] = double.Parse(Console.ReadLine());
                            nums = false;
                            prom = (double)infoestudiantes[columna, 2];

                        }
                        catch
                        {
                            Console.WriteLine("------Este campo solo acepta dígitos------");
                            nums = true;
                        }
                    while (nums);

                    if (prom >= 70)
                        condicion = "Aprobado";
                    else
                        condicion = "Reprobado";

                    Console.WriteLine("La condicion del Estudiante es: " + condicion);
                    infoestudiantes[columna, 3] = condicion;

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No existe un registro para la cédula digitada.");

                }
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta para modificar? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }

            }
            break;
        case 4:
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**          Eliminar Estudiantes Registrados        **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("-Ingrese el número de cédula del estudiante:");
                cedula = int.Parse(Console.ReadLine());

                //Recorre el arreglo en busqueda de la cédula
                existe = true;
                columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                for (int c = 0; c < 10; c++)
                {
                    if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)
                    {
                        existe = true;
                        columna = c;
                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe)
                {
                    infoestudiantes[columna, 0] = "";
                    infoestudiantes[columna, 1] = "";
                    infoestudiantes[columna, 2] = "";
                    infoestudiantes[columna, 3] = "";

                    Console.WriteLine("Se eliminó correctamente el registro.");

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No existe un registro para la cédula digitada.");

                }
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("¿Desea realizar otra consulta para eliminar? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToUpper() != "S")
                {
                    break;
                }

            }
            break;
        case 5:
            while (true)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("**                Submenú de reportes               **");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1- Reporte de estudiantes por condición");
                Console.WriteLine("2- Reporte de todos los datos");
                Console.WriteLine("3- Regresar al menú principal");
                Console.WriteLine("Ingrese el número de opción:");
                var subOpcion = int.Parse(Console.ReadLine());

                switch (subOpcion)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("******************************************************");
                            Console.WriteLine("**       Reporte de Estudiantes por Condición       **");
                            Console.WriteLine("******************************************************");
                            Console.WriteLine("1- Estudiantes aprobados");
                            Console.WriteLine("2- Estudiantes reprobados");
                            Console.WriteLine("3- Regresar al menú de reportes");
                            Console.WriteLine("Ingrese el número de opción:");
                            var reportOp = int.Parse(Console.ReadLine());

                            switch (reportOp)
                            {
                                case 1:
                                    object[,] aprobados = new object[10, 4];
                                    int iAprob = 0;
                                    for (int i = 0; i < 10; i++)
                                    {
                                        if (infoestudiantes[i, 3] != null && infoestudiantes[i, 3].Equals("Aprobado"))
                                        {
                                            aprobados[iAprob, 0] = infoestudiantes[i, 0];
                                            aprobados[iAprob, 1] = infoestudiantes[i, 1];
                                            aprobados[iAprob, 2] = infoestudiantes[i, 2];
                                            aprobados[iAprob, 3] = infoestudiantes[i, 3];
                                            iAprob++;
                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine("******************************************************");
                                    Console.WriteLine("**          Reporte de Estudiantes Aprobados        **");
                                    Console.WriteLine("******************************************************");
                                    Console.WriteLine($"\t Cedula \t Nombre \t Promedio \t Condición");
                                    Console.WriteLine("======================================================");

                                    for (int i = 0; i < 10; i++)
                                    {
                                        Console.WriteLine($"{aprobados[i, 0]}\t{aprobados[i, 1]}\t{aprobados[i, 2]}\t\t{aprobados[i, 3]}");

                                    }
                                    Console.WriteLine("<Pulse cualquier tecla para abandonar>");
                                    Console.ReadKey();
                                    Environment.Exit(0);

                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("******************************************************");
                                        Console.WriteLine("**        Consulta de Estudiantes Registrados       **");
                                        Console.WriteLine("******************************************************");
                                        Console.WriteLine("-Ingrese el número de cédula del estudiante:");
                                        cedula = int.Parse(Console.ReadLine());

                                        //Recorre el arreglo en busqueda de la cédula
                                        existe = true;
                                        columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                                        for (int c = 0; c < 10; c++)
                                        {
                                            if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)
                                            {
                                                existe = true;
                                                columna = c;
                                                break;
                                            }
                                            else
                                            {
                                                existe = false;
                                            }
                                        }

                                        if (existe)
                                        {
                                            Console.WriteLine("-Nombre: {0}", infoestudiantes[columna, 1]);
                                            Console.WriteLine("-Promedio: {0}", infoestudiantes[columna, 2]);
                                            Console.WriteLine("-Condición: {0}", infoestudiantes[columna, 3]);

                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("No existe un registro para la cédula digitada.");

                                        }
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.WriteLine("¿Desea realizar otra consulta? (S/N): ");
                                        string continuar = Console.ReadLine();
                                        if (continuar.ToUpper() != "S")
                                        {
                                            break;
                                        }

                                    }
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
                                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                                    Console.Clear();
                                    break;
                            }
                        }
                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("******************************************************");
                            Console.WriteLine("**        Consulta de Estudiantes Registrados       **");
                            Console.WriteLine("******************************************************");
                            Console.WriteLine("-Ingrese el número de cédula del estudiante:");
                            cedula = int.Parse(Console.ReadLine());

                            //Recorre el arreglo en busqueda de la cédula
                            existe = true;
                            columna = 0;  //almacena el valor del indice en el momento que se encontró la coincidencia
                            for (int c = 0; c < 10; c++)
                            {
                                if (infoestudiantes[c, 0] != null && (int)infoestudiantes[c, 0] == cedula)
                                {
                                    existe = true;
                                    columna = c;
                                    break;
                                }
                                else
                                {
                                    existe = false;
                                }
                            }

                            if (existe)
                            {
                                Console.WriteLine("-Nombre: {0}", infoestudiantes[columna, 1]);
                                Console.WriteLine("-Promedio: {0}", infoestudiantes[columna, 2]);
                                Console.WriteLine("-Condición: {0}", infoestudiantes[columna, 3]);

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("No existe un registro para la cédula digitada.");

                            }
                            Console.WriteLine("------------------------------------------------------");
                            Console.WriteLine("¿Desea realizar otra consulta? (S/N): ");
                            string continuar = Console.ReadLine();
                            if (continuar.ToUpper() != "S")
                            {
                                break;
                            }

                        }
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
                        Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                        Console.Clear();
                        break;
                }
            }
            break;
        case 6:
            Console.WriteLine("Seleccionaste la Opción 6");
            break;
        default:
            Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
            {
                Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                Console.Clear();
                break;
            }
    }




    //Ciclo de recoleccion de datos

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{infoestudiantes[i, 0]}\t{infoestudiantes[i, 1]}\t{infoestudiantes[i, 2]}\t\t{infoestudiantes[i, 3]}");
    }
}


