
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

//Ciclo de recoleccion de datos

for (int i = 0; i < 10; i++)
{
    //Ciclo para recoleccion de cedulas

    do
        try
        {
            Console.WriteLine("Ingrese la cédula del Estudiante " + (i + 1));
            infoestudiantes[i, 0] = int.Parse(Console.ReadLine());
            nums = false;
        }
        catch
        {
            Console.WriteLine("Este campo solo acepta dígitos");
            nums = true;
        }
    while (nums);

    //Ciclo de recoleccion de nombre

    Console.WriteLine("Nombre del Estudiante  " + (i + 1));
    infoestudiantes[i, 1] = (Console.ReadLine());

    //Ingreso del promedio

    do

        try
        {
            Console.WriteLine("Promedio del estudiante: " + (i + 1));
            infoestudiantes[i, 2] = (Console.ReadLine());
            nums = false;
        }
        catch
        {
            Console.WriteLine("Este campo solo acepta dígitos");
            nums = true;
            prom = (double)infoestudiantes[i, 2];
        }
    while (nums);

    if (prom < 70)
        condicion = "Aprobado";
    else
        condicion = "Reprobado";

    Console.WriteLine("La condicion del Estudiante es: " + condicion);
    infoestudiantes[i, 3] = condicion;

    //Menú para ingresar mas usuarios
    Console.WriteLine("¿Desea ingresar información de otro estudiante? (S/N): ");
    string continuar = Console.ReadLine();
    if (continuar.ToUpper() != "S")
    {
        break;
    }

}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{infoestudiantes[i, 0]}\t{infoestudiantes[i, 1]}\t{infoestudiantes[i, 2]}\t\t{infoestudiantes[i, 3]}");
}



