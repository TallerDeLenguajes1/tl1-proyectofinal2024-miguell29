using System.Runtime.CompilerServices;

namespace ConsoleGame;


public class Personaje
{
    //*Variables que me sirven para el desarrollo del juego
    int nivel = 1;
    double salud = 0;



    public string Id { get; set; }
    public string Name { get; set; } //*nombre
    public string Title { get; set; }//*Apodo
    public string Blurb { get; set; }//*Descripcion Breve
    public Info Info { get; set; }
    public Image Image { get; set; }
    public List<string> Tags { get; set; }
    public string Partype { get; set; }
    public Stats Stats { get; set; }
    public int Nivel { get => nivel; set => nivel = value; }
    public double Salud { get => salud; set => salud = value; }

    public Personaje(string id, string name, string title, string blurb, Info info, Image image, List<string> tags, string partype, Stats stats)
    {
        Id = id;
        Name = name;
        Title = title;
        Blurb = blurb;
        Info = info;
        Image = image;
        Tags = tags;
        Partype = partype;
        Stats = stats;
        Salud = stats.Hp;
    }

    public void MostrarDatos()
    {
        Console.WriteLine("----------> Datos del personaje:");
        Console.WriteLine($"nombre: {Name}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Daño de Ataque: {Stats.AttackDamage}");
        Console.WriteLine($"velocidad: {Stats.MoveSpeed}");
        Console.WriteLine($"nivel: {Nivel}");
        Console.WriteLine($"armadura: {Stats.Armor}");
        Console.WriteLine($"salud: {Stats.Hp}\n");
    }
    public void Atacar(Personaje enemy)
    {
        var ataque = Stats.AttackDamage;
        var efectividadDeAtaqueMin = Math.Min((Nivel-1)*10, 100);
        var efectividadDeAtaque = new Random().Next(efectividadDeAtaqueMin, 101) / 100.0;
        var efectividadDeDeefensaMin = Math.Min((enemy.Nivel-1)*10, 100);
        var efectividadDeDefensa = new Random().Next(efectividadDeDeefensaMin, 50) / 100.0;;
        var defensa = enemy.Stats.Armor + (enemy.Stats.MoveSpeed * 0.1);
        var daño = (ataque * efectividadDeAtaque) - (defensa * efectividadDeDefensa);

        // Asegurarse de que el daño no sea negativo
        daño = Math.Max(daño, 0);
        enemy.Salud -= daño;
        var saludRestante = (enemy.Salud > 0) ? enemy.Salud : 0;
        Console.WriteLine($"{enemy.Name} recibe {daño:F2} de daño");
        Console.WriteLine($"Salud restante: {saludRestante:F2}");
    }

}
