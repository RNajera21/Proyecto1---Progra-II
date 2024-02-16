using System.Threading;
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

            break;
        case 2:
            Console.WriteLine("Seleccionaste la Opción 2");
            break;
        case 3:
            Console.WriteLine("Seleccionaste la Opción 3");
            break;
        case 4:
            Console.WriteLine("Seleccionaste la Opción 4");
            break;
        case 5:
            Console.WriteLine("Seleccionaste la Opción 5");
            break;
        case 6:
            Console.WriteLine("Seleccionaste la Opción 6");
            break;
        default:
            Console.WriteLine("Opción no válida, por favor inténtelo de nuevo.");
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



