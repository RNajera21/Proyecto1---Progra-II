using ConsoleApp1;
using System;
using System.Collections.ObjectModel;
using System.Collections;

public class MenuReportes
{
    public static void Menu(List<Estudiante> estudiantes)
    {
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
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ReportesPorCondicion(estudiantes);
                    break;
                case "2":
                    ReporteGeneral(estudiantes);
                    break;
                case "3":
                    break;
                default:
                Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
                Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                Console.Clear();
                break;

            }

        }
    }

    public static void ReportesPorCondicion(List<Estudiante> estudiantes)
    {
        {
            Console.Clear();
            Console.WriteLine("******************************************************");
            Console.WriteLine("**       Reporte de Estudiantes por Condición       **");
            Console.WriteLine("******************************************************");
            Console.WriteLine("1- Estudiantes aprobados");
            Console.WriteLine("2- Estudiantes reprobados");
            Console.WriteLine("3- Regresar al submenú de reportes");
            Console.WriteLine("Ingrese el número de opción:");
            var reportOp = Console.ReadLine();

            switch (reportOp)
            {
                case "1":

                    List<Estudiante> aprobados = estudiantes.Where(estudiante => estudiante.Condicion == "Aprobado").ToList();

                    Console.Clear();
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**                Reporte de Estudiantes Aprobados               **");
                    Console.WriteLine("*******************************************************************");
                    if (aprobados.Count() > 0)
                    {
                        Console.WriteLine($"{"Cedula",-10}{"Nombre",-30}{"Promedio",-10}{"Condición",-15}");
                        Console.WriteLine("===================================================================");

                        foreach (var estudiante in aprobados)
                        {
                            Console.WriteLine($"{estudiante.Cedula,-10}{estudiante.Nombre,-30}{estudiante.Promedio,-10}{estudiante.Condicion,-15}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay estudiantes aprobados");
                    }
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("            << Pulse cualquier tecla para abandonar >>            ");
                    Console.ReadKey();
                    //Environment.Exit(0);

                    break;
                case "2":

                    List<Estudiante> reprobados = estudiantes.Where(estudiante => estudiante.Condicion == "Reprobado").ToList();

                    Console.Clear();
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("**               Reporte de Estudiantes Reprobados               **");
                    Console.WriteLine("*******************************************************************");
                    if (reprobados.Count() > 0)
                    {
                        Console.WriteLine($"{"Cedula",-10}{"Nombre",-30}{"Promedio",-10}{"Condición",-15}");
                        Console.WriteLine("===================================================================");

                        foreach (var estudiante in reprobados)
                        {
                            Console.WriteLine($"{estudiante.Cedula,-10}{estudiante.Nombre,-30}{estudiante.Promedio,-10}{estudiante.Condicion,-15}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay estudiantes reprobados");
                    }
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("            << Pulse cualquier tecla para abandonar >>            ");
                    Console.ReadKey();
                    //Environment.Exit(0);

                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
                    Thread.Sleep(3000); // Espera 3 segundos antes de continuar
                    Console.Clear();
                    break;


            }

        }
    }

    public static void ReporteGeneral(List<Estudiante> estudiantes)
    {
        //Se obtiene el promedio más alto
        float maxPromedio = estudiantes.Max(estudiante => estudiante.Promedio);
        //Se llena una lista con los estudiantes que tengan ese promedio
        List<Estudiante> mejoresPromedios = estudiantes.Where(estudiante => estudiante.Promedio == maxPromedio).ToList();

        //Se obtiene el promedio más alto
        float minPromedio = estudiantes.Min(estudiante => estudiante.Promedio);
        //Se llena una lista con los estudiantes que tengan ese promedio
        List<Estudiante> peoresPromedios = estudiantes.Where(estudiante => estudiante.Promedio == minPromedio).ToList();


        //Se imprime el reporte
        Console.Clear();
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("**               Reporte de General de Estudiantes               **");
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("-Total de Estudiantes: {0}", estudiantes.Count());                   
        Console.WriteLine("===================================================================");

        //Se imprimen los mejores promedios
        Console.WriteLine("-Mejores promedios:");
        foreach (var estudiante in mejoresPromedios)
        {
            Console.WriteLine($"{estudiante.Nombre,-30}{estudiante.Promedio,-6}");
        }

        //Se imprimen los peores promedios
        Console.WriteLine("-Peores promedios:");
        foreach (var estudiante in peoresPromedios)
        {
            Console.WriteLine($"{estudiante.Nombre,-30}{estudiante.Promedio,-6}");
        }
        //Se define el espacio para cada "columna"
        Console.WriteLine("===================================================================");
        Console.WriteLine($"{"Cedula",-10}{"Nombre",-30}{"Promedio",-10}{"Condición",-15}");       
        Console.WriteLine("===================================================================");
        
        //Se crea una nueva lista con los estudiantes ordenados alfabéticamente
        List<Estudiante> listaOrdenada = estudiantes.OrderBy(estudiante => estudiante.Nombre).ToList();

        //Se imprime cada uno de los estudiantes en la lista, respetando el espacio de las "columnas".
        foreach (var estudiante in listaOrdenada)
        {
            Console.WriteLine($"{estudiante.Cedula,-10}{estudiante.Nombre,-30}{estudiante.Promedio,-10}{estudiante.Condicion,-15}");
        }

        Console.WriteLine("            << Pulse cualquier tecla para abandonar >>            ");
        Console.WriteLine("===================================================================");

        Console.ReadKey();

    }
}