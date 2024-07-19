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

    public void MostrarDatos()
    {
        Console.WriteLine("----------> Datos del personaje:");
        Console.WriteLine($"nombre: {nombre}");
        Console.WriteLine($"apodo: {apodo}");
        Console.WriteLine($"tipo: {tipo}");
        Console.WriteLine($"fecha de nacimiento: {fechaNacimiento}");
        Console.WriteLine($"edad: {edad}");
        Console.WriteLine($"velocidad: {velocidad}");
        Console.WriteLine($"destreza: {destreza}");
        Console.WriteLine($"fuerza: {fuerza}");
        Console.WriteLine($"nivel: {nivel}");
        Console.WriteLine($"armadura: {armadura}");
        Console.WriteLine($"salud: {salud}\n");
    }
    public void Atacar(Personaje enemy)
    {
        var ataque = Destreza * Fuerza * Nivel;
        var efectividad = new Random().Next(1,101);
        var defensa = Armadura * Velocidad;
        var constanteAjuste = 500;
        var daño = ((ataque * efectividad) - defensa)/constanteAjuste;
        enemy.Salud -= daño;
        var saludRestante = (enemy.Salud > 0) ? enemy.Salud : 0;
        Console.WriteLine($"{enemy.Nombre} recibe {daño} de daño");
        Console.WriteLine($"Salud restante {saludRestante}");
    }
}