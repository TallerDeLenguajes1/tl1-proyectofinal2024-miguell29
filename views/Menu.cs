
public class Menu
{


    public static int Show(List<string> lista, int x=0, int y=0)
    {
        int opcion = 1;
        bool selected = false;
        while (!selected)        
        {
            int positionY = y;
            Console.Clear();
            Console.SetCursorPosition(x,positionY);
            for (int i = 0; i < lista.Count; i++)
            {
                if (opcion == i)
                {
                    Console.Write( lista[i] + "\t<--");
                }else
                {
                    Console.Write(lista[i]);
                }
                Console.SetCursorPosition(x,positionY++);
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
            }
        }
        return opcion;
    }
}