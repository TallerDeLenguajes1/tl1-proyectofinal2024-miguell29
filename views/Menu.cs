
using System.Runtime.CompilerServices;

public class Menu
{


    public static int Show(List<string> lista, int x=0, int y=0)
    {
        int opcion = 1;
        bool selected = false;
        while (!selected)        
        {
            LimpiarMenu(x,y,lista.Count);
            int positionY = y;
            int positionX = x;
            Console.SetCursorPosition(positionX,positionY);
            for (int i = 0; i < lista.Count; i++)
            {
                if (opcion == i)
                {
                    Console.Write( lista[i] + "\t<--");
                }else
                {
                    Console.Write(lista[i]);
                }
                if (i%20 == 0 && i != 0) 
                {
                    positionY = y;
                    positionX += 22;
                }
                
                Console.SetCursorPosition(positionX,positionY++);
            }
            var tecla = Console.ReadKey(true);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                if (opcion <= 1) continue;
                opcion--;
                break;

                case ConsoleKey.DownArrow:
                if (opcion >= lista.Count - 1) continue;
                opcion++;
                break;
                case ConsoleKey.Enter:
                selected = true;
                break;
                case ConsoleKey.Escape:
                selected = true;
                opcion = -1;
                break;
            }
        }

        if(opcion == -1)LimpiarMenu(x,y,lista.Count);
        return opcion;
    }
    public static void LimpiarMenu(int x , int y, int cantidadDeOpciones)
    {
        for (int i = 0; i < Math.Min(cantidadDeOpciones,20); i++)
        {
            for (int j = 0; j < 22 + 22 *cantidadDeOpciones/20; j++)
            {
                Console.SetCursorPosition(x+j,y);
                Console.Write(" ");
            }
            y++;
        }
    }
}