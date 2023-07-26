using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using InterfazVisual;
using EspacioCombate;
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
    public void MostrarPersonajes(int menu) {
        Console.WriteLine("            ╔═══════════════════════════════════════════╗");
        Console.WriteLine("            ║░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║");
        switch (menu) {
            case 1:
                Console.WriteLine("            ║░░░   ╔═════════════════════════════╗   ░░░║");
                Console.WriteLine("            ║░░░   ║  >>> ELEGIR PERSONAJE <<<   ║   ░░░║");
                Console.WriteLine("            ║░░░   ╚═════════════════════════════╝   ░░░║");
            break;
            case 2:
                Console.WriteLine("            ║░░░   ╔═════════════════════════════╗   ░░░║");
                Console.WriteLine("            ║░░░   ║    >>> TU PERSONAJE <<<     ║   ░░░║");
                Console.WriteLine("            ║░░░   ╚═════════════════════════════╝   ░░░║");
            break;
            case 3:
                Console.WriteLine("            ║░░░   ╔═════════════════════════════╗   ░░░║");
                Console.WriteLine("            ║░░░   ║  >>> PERSONAJE GANADOR <<<  ║   ░░░║");
                Console.WriteLine("            ║░░░   ╚═════════════════════════════╝   ░░░║");
            break;
        }
        Console.WriteLine("            ║░░░ ┌─────────────────────────────────┐ ░░░║");
        Console.WriteLine("            ║░░░ │     → DATOS DEL PERSONAJE ←     │ ░░░║");
        Console.WriteLine("            ║░░░ ├─────────────────────────────────┤ ░░░║");
        Console.WriteLine("            ║░░░ │ ♦ Nombre: "+ Interfaz.Espaciado(Nombre +", "+ Apodo,21) +" │ ░░░║"); //21 espacios
        Console.WriteLine("            ║░░░ │ ♦ LVL: "+ Interfaz.Espaciado(Nivel.ToString(),24) +" │ ░░░║"); //24 espacios
        Console.WriteLine("            ║░░░ │ ♦ TIPO: "+ Interfaz.Espaciado(Tipo,23) +" │ ░░░║"); //23 espacioes
        Console.WriteLine("            ║░░░ │ ♦ Fec. Nac.: "+ Interfaz.Espaciado(FechaDeNacimiento.ToShortDateString(),18) +" │ ░░░║"); //148espacios
        Console.WriteLine("            ║░░░ │ ♦ Edad: "+ Interfaz.Espaciado(Edad.ToString(),23) +" │ ░░░║"); //23 espacios
        Console.WriteLine("            ║░░░ ├─────────────────────────────────┤ ░░░║");
        Console.WriteLine("            ║░░░ │       ▲ CARACTERISTICAS ▲       │ ░░░║");
        Console.WriteLine("            ║░░░ ├─────────────────────────────────┤ ░░░║");
        Console.WriteLine("            ║░░░ │       ♥ SALUD ♥: "+ Interfaz.Espaciado(Salud.ToString(),15) +"│ ░░░║"); //15
        Console.WriteLine("            ║░░░ │       ↨ VELOCIDAD ↨: "+ Interfaz.Espaciado(Velocidad.ToString(),11) +"│ ░░░║"); //11
        Console.WriteLine("            ║░░░ │       ♫ DESTREZA ♫: "+ Interfaz.Espaciado(Destreza.ToString(),12) +"│ ░░░║"); //12
        Console.WriteLine("            ║░░░ │       ⚔ FUERZA ⚔: "+ Interfaz.Espaciado(Fuerza.ToString(),14) +"│ ░░░║"); //14
        Console.WriteLine("            ║░░░ │       ◘ ARMADURA ◘: "+ Interfaz.Espaciado(Armadura.ToString(),12) +"│ ░░░║"); //12
        Console.WriteLine("            ║░░░ └─────────────────────────────────┘ ░░░║");
        Console.WriteLine("            ║░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░║");
        Console.WriteLine("            ╚═══════════════════════════════════════════╝");
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
            Console.WriteLine("Limite de accesos a la API superados, se creara una edad aleatoria");
        }
    }
    public Personaje CrearPersonaje(int nivel) {
        var mecanica = new MecanicaDeCombate();
        var nuevo = new Personaje();
        var valor = new Random();
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
        if (nivel == -1) {
            nuevo.Nivel = valor.Next(1,7); // MAX nivel 6, para ser nivel 10 en la final (en el modo torneo)
        } else {
            nuevo.Nivel = nivel; // MIN nivel 3, para ser nivel 12 en la ultima pelea (en el modo supervivencia)
        }
        for (int j = 1; j < nivel; j++) {
            nuevo = mecanica.SubirNivel(nuevo);
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
        int anio;
        if (File.Exists("EdadAPI.json")) {
            string json = File.ReadAllText("EdadAPI.json");
            EdadConAPI = JsonSerializer.Deserialize<Root>(json);
            anio = 2023 - EdadConAPI.age;
        } else {
            anio = valor.Next(1723,2024);
        }
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
    public List<Personaje>? CrearParticipantes(string nombre,int cant,int nivel) {
        var listaDePersonajes = new List<Personaje> ();
        var personaje = new FabricaDePersonajes ();
        var PJson = new PersonajesJson ();
        if (!(PJson.Existe("Personajes.json"))) {
            for (int i = 0; i < cant; i++) {
                listaDePersonajes.Add(personaje.CrearPersonaje(nivel));
            }
            PJson.GuardarPersonaje(listaDePersonajes,nombre);
        } else {
            listaDePersonajes = PJson.LeerPersonaje(nombre + ".json");
        }
        return listaDePersonajes;
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
    public void GuardarPersonajeIndividual(Personaje personaje, string nombre) {
        string json;
        json = JsonSerializer.Serialize(personaje);
        File.WriteAllText(nombre+".json",json);
    }
    // Deserializacion
    public List<Personaje>? LeerPersonaje(string nombreArchivo) {
        List<Personaje>? listaPersonaje = null;
        if (Existe(nombreArchivo)) {
            string json = File.ReadAllText(nombreArchivo + ".json");
            listaPersonaje = JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        return listaPersonaje;
    }
    public Personaje? LeerPersonajeIndividual(string nombreArchivo) {
        Personaje? personaje = null;
        if (Existe(nombreArchivo)) {
            string json = File.ReadAllText(nombreArchivo + ".json");
            personaje = JsonSerializer.Deserialize<Personaje>(json);
        }
        return personaje;
    }
    public bool Existe(string nombreArchivo) {
        return (File.Exists(nombreArchivo + ".json"));
    }
}

public class Root {
    public int count { get; set; }
    public string name { get; set; }
    public int age { get; set; }
}