using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    private float velocidad;
    private int destreza;
    private float fuerza;
    private int nivel;
    private float armadura;
    private int energia;
    private float salud;
    // PROPIEDADES DE DATOS
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    // PROPIEDADES DE CARACTERISTICAS
    public float Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public float Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public float Armadura { get => armadura; set => armadura = value; }
    public int Energia { get => energia; set => energia = value; }
    public float Salud { get => salud; set => salud = value; }
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
    private string Espaciado(string palabra, int espacios){
        int aux = espacios - palabra.Count();
        for (int i = 0; i < aux; i++) {
            palabra = palabra + " ";
        }
        return palabra;
    }
    public void MostrarPersonaje() {
        System.Console.WriteLine("~~~ PERSONAJE ~~~");
        System.Console.WriteLine(" - "+ Nombre +", "+ Apodo);
        System.Console.WriteLine(" - LVL: "+ Nivel + "| TIPO: "+ Tipo);
        System.Console.WriteLine(" - FECHA DE NACIMIENTO: "+ FechaDeNacimiento.ToShortDateString());
        System.Console.WriteLine(" - EDAD: "+ Edad);
        System.Console.WriteLine(" - CARACTERISTICAS:");
        System.Console.WriteLine("    -> SALUD: "+ Salud);
        System.Console.WriteLine("    -> VELOCIDAD: "+ Velocidad);
        System.Console.WriteLine("    -> DESTREZA: "+ Destreza);
        System.Console.WriteLine("    -> FUERZA: "+ Fuerza);
        System.Console.WriteLine("    -> ARMADURA: "+ Armadura);
    }
    public void MostrarPersonajeVersionMENU() {
        Console.WriteLine("╔═════════════════════════════════════════════╗");
        Console.WriteLine("║                                             ║");
        Console.WriteLine("║                ╔═══════════╗                ║");
        Console.WriteLine("║                ║ PERSONAJE ║                ║");
        Console.WriteLine("║                ╚═══════════╝                ║");
        Console.WriteLine("║     ┌─────────────────────────────────┐     ║");
        Console.WriteLine("║     │     → DATOS DEL PERSONAJE ←     │     ║");
        Console.WriteLine("║     ├─────────────────────────────────┤     ║");
        Console.WriteLine("║     │ ♦ Nombre: "+ Espaciado(Nombre +", "+ Apodo,21) +" │     ║"); //21 espacios
        Console.WriteLine("║     │ ♦ LVL: "+ Espaciado(Nivel.ToString(),24) +" │     ║"); //24 espacios
        Console.WriteLine("║     │ ♦ TIPO: "+ Espaciado(Tipo,23) +" │     ║"); //23 espacioes
        Console.WriteLine("║     │ ♦ Fec. Nac.: "+ Espaciado(FechaDeNacimiento.ToShortDateString(),18) +" │     ║"); //148espacios
        Console.WriteLine("║     │ ♦ Edad: "+ Espaciado(Edad.ToString(),23) +" │     ║"); //23 espacios
        Console.WriteLine("║     ├─────────────────────────────────┤     ║");
        Console.WriteLine("║     │       ▲ CARACTERISTICAS ▲       │     ║");
        Console.WriteLine("║     ├─────────────────────────────────┤     ║");
        Console.WriteLine("║     │      ♥ SALUD ♥: "+ Espaciado(Salud.ToString(),15) +" │     ║"); //15
        Console.WriteLine("║     │      ↨ VELOCIDAD ↨: "+ Espaciado(Velocidad.ToString(),11) +" │     ║"); //11
        Console.WriteLine("║     │      ♫ DESTREZA ♫: "+ Espaciado(Destreza.ToString(),12) +" │     ║"); //12
        Console.WriteLine("║     │      ♠ FUERZA ♠: "+ Espaciado(Fuerza.ToString(),14) +" │     ║"); //14
        Console.WriteLine("║     │      ◘ ARMADURA ◘: "+ Espaciado(Armadura.ToString(),12) +" │     ║"); //12
        Console.WriteLine("║     └─────────────────────────────────┘     ║");
        Console.WriteLine("║                                             ║");
        Console.WriteLine("╚═════════════════════════════════════════════╝");
        
    }
    public void MostrarPersonajeVersionCorta() {
        System.Console.WriteLine(Nombre +", "+ Apodo);
    }
}

public class FabricaDePersonajes {
    string[] nombresElficos = {
        "Legolas",
        "Arwen",
        "Galadriel",
        "Thranduil",
        "Elrond",
        "Earendil",
        "Celebrian",
        "Finrod",
        "Luthien",
        "Glorfindel"
    };
    string[] nombresOrcos = {
        "Rotten",
        "Ghoul",
        "Lurker",
        "Zed",
        "Ugluk",
        "Azog",
        "Lurtz",
        "Gothmog",
        "Shagrat",
        "Bolg"
    };
    string[] nombresHumanos = {
        "Aragorn",
        "Gandalf",
        "Frodo",
        "Boromir",
        "Samwise",
        "Gimli",
        "Pippin",
        "Merry",
        "Eowyn",
        "Faramir"
    };
    string[] apodosHumanos = {
        "Valiente",
        "Sabio",
        "Intrépido",
        "Heroico",
        "Audaz",
        "Leal",
        "Astuto",
        "Noble",
        "Errante",
        "Firme"
    };
    string[] apodosElfos = {
        "Luminoso",
        "Eterno",
        "Gélido",
        "Danzante",
        "Esmeralda",
        "Radiante",
        "Caminante",
        "Sombra",
        "Ardiente",
        "Celestial"
    };
    string[] apodosOrcos = {
        "Sanguinario",
        "Feroz",
        "Salvaje",
        "Despiadado",
        "Infernal",
        "Colmillo",
        "Atronador",
        "Devastador",
        "Gruñidor",
        "Desgarrador"
    };
    public string[] Tipo = {
        "Elfo",
        "Orco",
        "Humano",
    };
    string[] roles = {
        "Arquero",
        "Mago",
        "Curador",
        "Caballero",
        "Cazador",
        "Saboteador"
    };
    public void EdadconAPI(string nombre){
        var url = $"https://api.agify.io?name="+nombre;
        var request = (HttpWebRequest)WebRequest.Create(url);
        Random valor = new Random();
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        try{
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return ;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        File.WriteAllText("EdadAPI.json",responseBody);
                    }
                }
            }
        }
        catch (WebException ex){
            Console.WriteLine("Problemas de acceso a la API");
        }
    }
    public Personaje CrearPersonaje() {
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        string rol;
        // Datos
        nuevo.Tipo = Tipo[valor.Next(0,3)];
        switch (nuevo.Tipo) {
            case "Elfo":
                nuevo.Nombre = nombresElficos[valor.Next(0,9)];
                nuevo.Apodo = apodosElfos[valor.Next(0,9)];
                nuevo.Velocidad = valor.Next(5,11);
                nuevo.Fuerza = valor.Next(2,11);
                nuevo.Armadura = valor.Next(4,11);
                nuevo.Salud = valor.Next(100,150);
            break;
            case "Orco":
                nuevo.Nombre = nombresOrcos[valor.Next(0,9)];
                nuevo.Apodo = apodosOrcos[valor.Next(0,9)];
                nuevo.Velocidad = valor.Next(1,11);
                nuevo.Fuerza = valor.Next(5,11);
                nuevo.Armadura = valor.Next(4,11);
                nuevo.Salud = valor.Next(150,200);
            break;
            case "Humano":
                nuevo.Nombre = nombresHumanos[valor.Next(0,9)];
                nuevo.Apodo = apodosHumanos[valor.Next(0,9)];
                nuevo.Velocidad = valor.Next(3,11);
                nuevo.Fuerza = valor.Next(3,11);
                nuevo.Armadura = valor.Next(3,11);
                nuevo.Salud = valor.Next(120,150);
            break;
        }
        nuevo.Nivel = valor.Next(1,7);
        switch (nuevo.Nivel) {
            case 1:
                nuevo.Salud = nuevo.Salud + 5;
                nuevo.Fuerza = nuevo.Fuerza + 0.25f;
                nuevo.Armadura = nuevo.Armadura + 0.25f;
                nuevo.Velocidad = nuevo.Velocidad + 0.25f;
            break;
            case 2:
                nuevo.Salud = nuevo.Salud + 10;
                nuevo.Fuerza = nuevo.Fuerza + 0.5f;
                nuevo.Armadura = nuevo.Armadura + 0.5f;
                nuevo.Velocidad = nuevo.Velocidad + 0.5f;
            break;
            case 3:
                nuevo.Salud = nuevo.Salud + 15;
                nuevo.Fuerza = nuevo.Fuerza + 0.75f;
                nuevo.Armadura = nuevo.Armadura + 0.75f;
                nuevo.Velocidad = nuevo.Velocidad + 0.75f;
            break;
            case 4:
                nuevo.Salud = nuevo.Salud + 20;
                nuevo.Fuerza = nuevo.Fuerza + 1;
                nuevo.Armadura = nuevo.Armadura + 1;
                nuevo.Velocidad = nuevo.Velocidad + 1;
            break;
            case 5:
                nuevo.Salud = nuevo.Salud + 25;
                nuevo.Fuerza = nuevo.Fuerza + 1.25f;
                nuevo.Armadura = nuevo.Armadura + 1.25f;
                nuevo.Velocidad = nuevo.Velocidad + 1.25f;
            break;
            case 6:
                nuevo.Salud = nuevo.Salud + 30;
                nuevo.Fuerza = nuevo.Fuerza + 1.5f;
                nuevo.Armadura = nuevo.Armadura + 1.5f;
                nuevo.Velocidad = nuevo.Velocidad + 1.5f;
            break;
            // case 7:
            //     nuevo.Salud = nuevo.Salud + 35;
            //     nuevo.Fuerza = nuevo.Fuerza + 1.75f;
            //     nuevo.Armadura = nuevo.Armadura + 1.75f;
            //     nuevo.Velocidad = nuevo.Velocidad + 1.75f;
            // break;
            // case 8:
            //     nuevo.Salud = nuevo.Salud + 40;
            //     nuevo.Fuerza = nuevo.Fuerza + 2;
            //     nuevo.Armadura = nuevo.Armadura + 2;
            //     nuevo.Velocidad = nuevo.Velocidad + 2;
            // break;
            // case 9:
            //     nuevo.Salud = nuevo.Salud + 45;
            //     nuevo.Fuerza = nuevo.Fuerza + 2.25f;
            //     nuevo.Armadura = nuevo.Armadura + 2.25f;
            //     nuevo.Velocidad = nuevo.Velocidad + 2.25f;
            // break;
            // case 10:
            //     nuevo.Salud = nuevo.Salud + 50;
            //     nuevo.Fuerza = nuevo.Fuerza + 2.5f;
            //     nuevo.Armadura = nuevo.Armadura + 2.5f;
            //     nuevo.Velocidad = nuevo.Velocidad + 2.5f;
            // break;
        }
        rol = roles[valor.Next(0,5)];
        switch (rol) {
            case "Arquero":
                nuevo.Salud = nuevo.Salud - 15;
                nuevo.Fuerza = nuevo.Fuerza + 1;
                nuevo.Armadura = nuevo.Armadura + 0.25f;
                nuevo.Velocidad = nuevo.Velocidad + 2;
            break;
            case "Mago":
                nuevo.Salud = nuevo.Salud - 10;
                nuevo.Fuerza = nuevo.Fuerza + 1;
                nuevo.Armadura = nuevo.Armadura - 1;
                nuevo.Velocidad = nuevo.Velocidad + 4;
            break;
            case "Curador":
                nuevo.Salud = nuevo.Salud + 15;
                nuevo.Fuerza = nuevo.Fuerza + 0.5f;
                nuevo.Armadura = nuevo.Armadura - 0.5f;
                nuevo.Velocidad = nuevo.Velocidad + 1;
            break;
            case "Caballero":
                nuevo.Salud = nuevo.Salud + 30;
                nuevo.Fuerza = nuevo.Fuerza + 1.5f;
                nuevo.Armadura = nuevo.Armadura + 1;
                nuevo.Velocidad = nuevo.Velocidad - 1;
            break;
            case "Cazador":
                nuevo.Salud = nuevo.Salud + 15;
                nuevo.Fuerza = nuevo.Fuerza + 1;
                nuevo.Armadura = nuevo.Armadura - 1;
                nuevo.Velocidad = nuevo.Velocidad + 2;
            break;
            case "Saboteador":
                nuevo.Salud = nuevo.Salud + 15;
                nuevo.Fuerza = nuevo.Fuerza - 0.5f;
                nuevo.Armadura = nuevo.Armadura - 1;
                nuevo.Velocidad = nuevo.Velocidad + 3;
            break;
        }
        nuevo.Destreza = valor.Next(1,6);
        nuevo.Tipo = nuevo.Tipo + ", " + rol;
        nuevo.Energia = 2;
        // Edad con API
        EdadconAPI(nuevo.Nombre);
        Root EdadConAPI = new Root();
        if (File.Exists("EdadAPI.json")) {
            string json = File.ReadAllText("EdadAPI.json");
            EdadConAPI = JsonSerializer.Deserialize<Root>(json);
        }
        int anio = 2023 - EdadConAPI.age;
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
        nuevo.FechaDeNacimiento = new DateTime (anio,mes,dia);
        nuevo.Edad = CalcularEdad(nuevo.FechaDeNacimiento);
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

public class PersonajesJson {
    // Serializacion
    public void GuardarPersonaje(List<Personaje> lista, string nombre) {
        string json;
        //var json = new JsonSerializerOptions {WriteIndented = true};
        // foreach (var personaje in lista) {
        //     json = json + "\n\r"+ JsonSerializer.Serialize(personaje/*, config*/);
        // }
        json = JsonSerializer.Serialize(lista);
        File.WriteAllText(nombre+".json",json);
    }
    // Deserializacion
    public List<Personaje>? LeerPersonaje(string nombreArchivo) {
        List<Personaje>? listaPersonaje = null;
        if (Existe(nombreArchivo)) {
            string json = File.ReadAllText(nombreArchivo);
            listaPersonaje = JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        return listaPersonaje;
    }
    public bool Existe(string nombreArchivo) {
        return (File.Exists(nombreArchivo));
    }
}

public class Root {
    public int count { get; set; }
    public string name { get; set; }
    public int age { get; set; }
}