using ConsoleGame;

class Factory
{
    
    public static Character NewCharacter()
    {
        var num = new Random();
        //lista de tipos
        string[] typeList = {"Enano", "Mago","Caballero","Elfo"};
        var tipo = typeList[num.Next(typeList.Length)];
        //lista de nombres
        string[] nameList = {"Gandalf", "Legolas", "Aragorn",};
        var nombre = nameList[num.Next(nameList.Length)];
        //lista de apodos
        string[] nickList = {"El mago", "El elfo", "El caballero"};
        var apodo = nickList[num.Next(nickList.Length)];
        //fecha de nacimiento
        var fecha = new DateTime(DateTime.Now.Year - num.Next(300), 1, 1);
        var velociadad = num.Next(1,11);
        var destreza = num.Next(1,6);
        var fuerza = num.Next(1,11);
        var nivel = num.Next(1,11);
        var armadura = num.Next(1,11);
        var salud  = 100;

        Character character = new Character(tipo,nombre,apodo,fecha,velociadad,destreza,fuerza,nivel,armadura,salud);
        return character;  
    }
}