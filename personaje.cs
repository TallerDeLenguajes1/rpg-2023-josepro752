namespace EspacioPersonaje;
public class Personaje {
    // ATRIBUTOS
    // DATOS
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaDeNacimiento;
    private int edad;
    // CARACTERISTICAS
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    // PROPIEDADES DE DATOS
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    // PROPIEDADES DE CARACTERISTICAS
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    // CONSTRUCTOR
    // public Personaje(string tipo, string nombre, string apodo, DateTime fechaDeNacimiento, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud) {
    //     Tipo = tipo;
    //     Nombre = nombre;
    //     Apodo = apodo;
    //     FechaDeNacimiento = fechaDeNacimiento;
    //     Edad = edad;
    //     Velocidad = velocidad;
    //     Destreza = destreza;
    //     Fuerza = fuerza;
    //     Nivel = nivel;
    //     Armadura = armadura;
    //     Salud = salud;
    // }
}

public class FabricaDePersonajes {
    public string[] Nombres = {
        "Jose",
        "Ragahe",
        "Guillo",
        "Juan",
        "Marte",
        "Carlos",
        "Gero",
        "Fran",
    };
    public string[] Apodos = {
        "Culebra",
        "Buitre",
        "Rata",
        "Campero",
        "Caballero",
        "Muerte",
        "Manco",
        "ProPlayer",
    };
    public string[] Tipo = {
        "Elfo",
        "Orco",
        "Humano",
        "Zombie",
        "Esqueleto",
        "Mago",
    };
    public Personaje CrearPersonaje() {
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        // Datos
        int anio = valor.Next(1723,2024);
        int mes = valor.Next(1,13);
        int dia;
        switch (mes) {
            case 2:
                dia = valor.Next(1,29);
            break;
            case 4:
            case 6:
            case 9:
            case 11:
                dia = valor.Next(1,31);
            break;
            default:
                dia = valor.Next(1,32);
            break;
        }
        nuevo.FechaDeNacimiento = new DateTime (dia,mes,anio);
        nuevo.Apodo = Apodos[valor.Next(0,8)];
        nuevo.Nombre = Nombres[valor.Next(0,8)];
        nuevo.Tipo = Tipo[valor.Next(0,6)];
        nuevo.Edad = CalcularEdad(nuevo.FechaDeNacimiento);
        // Caracteristicas
        nuevo.Velocidad = valor.Next(1,11);
        nuevo.Destreza = valor.Next(1,6);
        nuevo.Fuerza = valor.Next(1,11);
        nuevo.Nivel = valor.Next(1,11);
        nuevo.Armadura = valor.Next(1,11);
        nuevo.Salud = 100;
        return nuevo;
    }
    public int CalcularEdad(DateTime fechaDeNacimiento) {
        DateTime FechaActual = DateTime.Now;
        int edad = FechaActual.Year - fechaDeNacimiento.Year;
        if (FechaActual.Month < fechaDeNacimiento.Month || (FechaActual.Month == fechaDeNacimiento.Month && FechaActual.Day < fechaDeNacimiento.Day)) {
            edad--;
        }
        return edad;
    }
}