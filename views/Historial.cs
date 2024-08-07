using System.Security.Cryptography.X509Certificates;
using ConsoleGame;

class Historial
{
    public static void Show(List<Personaje> lista)
    {
        Console.Clear();
        int x = Console.WindowWidth/2-10;
        int y = 3;
        int auxY = y;
        Console.SetCursorPosition(x,auxY++);
        Console.Write("Historial de Ganadores");
        auxY++;
        auxY++;
        foreach (Personaje personaje in lista)
        {
            Console.SetCursorPosition(x-20,auxY++);
            Console.Write($"{personaje.Name} - {personaje.Title} - Salud: {personaje.Stats.Hp} - Nivel: {personaje.Nivel}");
        }
        auxY++;
        auxY++;
        Inicio.PresioneUnaTecla(x,auxY++,"Presione una tecla para volver al menu...");
        
    }
}