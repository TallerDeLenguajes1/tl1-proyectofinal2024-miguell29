namespace ConsoleGame;


public class Personaje
{
    int nivel = 1;

   

    public string Id { get; set; }
    public string Name { get; set; } //*nombre
    public string Title { get; set; }//*Apodo
    public string Blurb { get; set; }//*Descripcion Breve
    public Info Info { get; set; }
    public Image Image { get; set; }
    public List<string> Tags { get; set; }
    public string Partype { get; set; }
    public Stats Stats { get; set; }

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
    }

    public void MostrarDatos()
    {
        Console.WriteLine("----------> Datos del personaje:");
        Console.WriteLine($"nombre: {Name}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Daño de Ataque: {Stats.AttackDamage}");
        Console.WriteLine($"velocidad: {Stats.MoveSpeed}");
        Console.WriteLine($"nivel: {nivel}");
        Console.WriteLine($"armadura: {Stats.Armor}");
        Console.WriteLine($"salud: {Stats.Hp}\n");
    }
    public void Atacar(Personaje enemy)
    {
        var ataque =Stats.AttackDamage * nivel;
        var efectividad = new Random().Next(1,101);
        var defensa = Stats.Armor * Stats.MoveSpeed * 0.3;
        var constanteAjuste = 500;
        var daño = ((ataque * efectividad) - defensa)/constanteAjuste;
        enemy.Stats.Hp -= daño;
        var saludRestante = (enemy.Stats.Hp > 0) ? enemy.Stats.Hp : 0;
        Console.WriteLine($"{enemy.Name} recibe {daño} de daño");
        Console.WriteLine($"Salud restante {saludRestante}");
    }
}