public class Usuario 
{
    public string? Nombre { get; set;}
    public string? Edad { get; set;}
    public List<string>? Hobbies { get; set;}

    public Usuario(string? Nombre, string Edad, List<string> Hobbies)
    {
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.Hobbies = Hobbies;
    }
} 