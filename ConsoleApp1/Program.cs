
//Incluir estudiantes

int[] infoestudiantes = new int[3];
string cedulaest = "";
string nombreest = "";
int ced = 0;
string let = "";
bool verifnum = false;
bool veriflet = false;

for (int i = 0; i < infoestudiantes.Length;)
{
    Console.WriteLine("Ingrese la cédula del Estudiante " + (i + 1));
        cedulaest = (Console.ReadLine());
        while (!verifnum)
    {
        Console.WriteLine("Este campo únicamente acepta dígitos");
        verifnum = int.TryParse(Console.ReadLine(), out ced);
    }
    Console.WriteLine("Nombre del Estudiante  " + (i+1));
        nombreest = (Console.ReadLine());
    Console.WriteLine("Estudiante ingresado correctamente");
        i++;
}

Console.WriteLine("Lainformación guardada es: ");
for (int i = 0; i < infoestudiantes.Length; i++)
{
    Console.WriteLine("Los Estudiantes en memoria son:");
    Console.WriteLine("Estudiante 1: \nCédula: " + cedulaest, "\nNombre: " + nombreest);
}
