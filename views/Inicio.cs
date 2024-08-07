
using System.Dynamic;
using System.Runtime.InteropServices;

class Inicio
{
    public static void Start(){
        Console.CursorVisible = false;
        Animacion();
    }

    static void Animacion()
    {
        int x = Console.WindowWidth / 2 - 20;
        int y = 5;
        int auxY = y;

        var titulo = @"__________         __    __  .__            
\______   \_____ _/  |__/  |_|  |   ____    
 |    |  _/\__  \\   __\   __\  | _/ __ \   
 |    |   \ / __ \|  |  |  | |  |_\  ___/   
 |______  /(____  /__|  |__| |____/\___  >  
        \/      \/                     \/   
__________                     .__          
\______   \ ____ ___.__._____  |  |   ____  
 |       _//  _ <   |  |\__  \ |  | _/ __ \ 
 |    |   (  <_> )___  | / __ \|  |_\  ___/ 
 |____|_  /\____// ____|(____  /____/\___  >
        \/       \/          \/          \/ 
";
        //*`StringSplitOptions.None`:** Este argumento especifica que no se deben eliminar las entradas vacías del array resultante.
        string[] lineas = titulo.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var item in lineas)
        {
            Console.SetCursorPosition(x, auxY++);
            Console.WriteLine(item);
            Thread.Sleep(100);
        }
        var texto = "Presione una tecla...";
        PresioneUnaTecla(x, auxY,texto);
    }

    public static void PresioneUnaTecla(int x, int auxY,string texto)
    {
        bool mostrarTexto = true;

        while (!Console.KeyAvailable)  // Mientras no se presione una tecla
        {
            if (mostrarTexto)
            {
                Console.SetCursorPosition(x, auxY + 2);
                Console.Write(texto);
            }
            else
            {
                //* se escribe una línea vacía (utilizando \r para volver al principio de la línea y espacios para sobrescribir el texto anterior)
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            }
            mostrarTexto = !mostrarTexto;  // Invertir el estado para la próxima iteración
            Thread.Sleep(400);
        }
    }
}