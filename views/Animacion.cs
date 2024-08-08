
using System.Security.Cryptography.X509Certificates;
using ConsoleGame;

class Animacion
{
    public static void Inicio(){
        Console.CursorVisible = false;
        Console.ForegroundColor=ConsoleColor.Red;
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
        Animar(titulo);
    }

    public static void GameOver()
    {
        var titulo =@"
  ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░
░ ░   ░   ░   ▒   ░      ░      ░   
      ░       ░  ░       ░      ░  ░
                                    
 ▒█████   ██▒   █▓▓█████  ██▀███    
▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒  
▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒  
▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄    
░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒  
░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░  
  ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░  
░ ░ ░ ▒       ░░     ░     ░░   ░   
    ░ ░        ░     ░  ░   ░       
              ░                     

Tu campeón ha caído en batalla.
La arena es un lugar despiadado, y esta vez la suerte no te acompañó.

¡Sigue practicando y vuelve más fuerte para la próxima vez!";
        Animar(titulo);
    }

    public static void Victory()
    {
        var titulo = @"

╦  ╦┬┌─┐┌┬┐┌─┐┬─┐┬ ┬┬
╚╗╔╝││   │ │ │├┬┘└┬┘│
 ╚╝ ┴└─┘ ┴ └─┘┴└─ ┴ o

¡Tu campeón ha prevalecido en la batalla!
Dominaste la arena y te alzaste como el último campeón en pie.
¡Felicidades por tu habilidad y estrategia!";
        Animar(titulo);
    }

    public static void Versus(Personaje player1, Personaje player2,int enemigos)
    {
        Console.Clear();
        var vs = @"
╦  ╦╔═╗
╚╗╔╝╚═╗
 ╚╝ ╚═╝
";
        DatosDelPersonaje(player1, 2,5);
        DatosDelPersonaje(player2,80,5);
        Console.SetCursorPosition(5,28);
        Console.WriteLine($"Cantidad de enemigos restantes: {enemigos}");
        Animar(vs);

    }

    public static void Atacar(Personaje player1, Personaje player2,int sentido,double danio)
    {
        Console.Clear();
        //imprime los nombres de los peleadores
        var x =5;
        var y = 5;

        string flecha;
        if (sentido > 0)
        {
            flecha =@"
            
          \ 
 ___  ___  \
           /
          / 
            
";
        }else
        {
            flecha =@"
            
 /          
/  ___  ___ 
\           
 \          
            
";          
            var playerAux = player1;
            player1 = player2;
            player2 = playerAux;
        }
        Console.SetCursorPosition(x,y);
        Console.Write(player1.Name);
        Console.SetCursorPosition(x+25,y);
        Console.Write("VS");
        Console.SetCursorPosition(x+42,y);
        Console.Write(player2.Name);
        //imprime la salud de los peleadores
        y++;
        y++;
        Console.SetCursorPosition(x,y);
        Console.Write($"{player1.Salud:F2}");
        Console.SetCursorPosition(x+42,y);
        Console.Write($"{player2.Salud:F2}");
        y += 5;
        string[] lineas = flecha.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        foreach (var item in lineas)
        {
            Console.SetCursorPosition(x+20, y++);
            Console.WriteLine(item);
        }
        y++;
        Console.SetCursorPosition(x+25, y++);
        Console.Write($"- {danio:F2}");
        Console.SetCursorPosition(x,y);
    }

    static void Animar(string titulo)
    {
        int x = Console.WindowWidth / 2 - 20;
        int y = 5;
        int auxY = y;

        //*`StringSplitOptions.None`:** Este argumento especifica que no se deben eliminar las entradas vacías del array resultante.
        string[] lineas = titulo.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
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
            int auxX= x;
            if (mostrarTexto)
            {
                Console.SetCursorPosition(x, auxY + 2);
                Console.Write(texto);
            }
            else
            {
                Console.SetCursorPosition(x, auxY + 2);
                for (int i = 0; i < texto.Length; i++)
                {
                    Console.SetCursorPosition(auxX++,auxY + 2);
                    Console.Write(" ");
                }
            }
            mostrarTexto = !mostrarTexto;  // Invertir el estado para la próxima iteración
            Thread.Sleep(400);
        } 
            Console.ReadKey(true);
            Console.Clear();
    }
    public static void DatosDelPersonaje(Personaje personaje,int X,int y)
    {
        Console.SetCursorPosition(X, y++);
        Console.Write("Nombre: " + personaje.Name.ToUpper());
        Console.SetCursorPosition(X, y++);
        Console.Write($"Title: {personaje.Title}");
        Console.SetCursorPosition(X, y++);
        Console.Write($"Historia :");
        Console.SetCursorPosition(X, y++);
        for (int i = 0; i < personaje.Blurb.Length; i++)
        {
            if (i % 30 == 0 && i != 0)
            {
                Console.SetCursorPosition(X, y++);
            }
            Console.Write(personaje.Blurb[i]);
        }
        Console.SetCursorPosition(X, y++);
        Console.Write($"Salud: {personaje.Salud:F2}");
        Console.SetCursorPosition(X, y++);
        Console.Write($"Ataque: {personaje.Ataque:F2}");
        Console.SetCursorPosition(X, y++);
        Console.Write("Tags: ");
        foreach (var item in personaje.Tags)
        {
            Console.Write(item + " | ");
        }
        Console.SetCursorPosition(X, y++);
        Console.SetCursorPosition(X, y++);
        Console.Write($"Nivel: {personaje.Nivel}");
    }
}