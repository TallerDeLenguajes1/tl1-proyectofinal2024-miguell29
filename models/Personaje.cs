
namespace ConsoleGame;


public class Personaje
{
    //*Variables que me sirven para el desarrollo del juego
    int nivel = 1;
    double salud = 0;
    double ataque = 0;



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
    public double Ataque { get => ataque; set => ataque = value; }

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
        Ataque = stats.AttackDamage;
    }

    

}
