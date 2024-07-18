namespace ConsoleGame;


public class Personaje
{
    //*Datos
    string tipo;
    string nombre;
    string apodo;
    DateTime fechaNacimiento;


    //*Características
    int velocidad;
    int destreza;
    int fuerza;
    int nivel;
    int armadura;
    int salud;
    int edad;
    public Personaje(string tipo, string nombre, string apodo, DateTime fechaNacimiento, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.tipo = tipo;
        this.nombre = nombre;
        this.apodo = apodo;
        this.fechaNacimiento = fechaNacimiento;
        this.velocidad = velocidad;
        this.destreza = destreza;
        this.fuerza = fuerza;
        this.nivel = nivel;
        this.armadura = armadura;
        this.salud = salud;
        Edad = DateTime.Now.Year - fechaNacimiento.Year;
    }

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Edad { get => edad; set => edad = value; }
}