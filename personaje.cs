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
    public void MostrarPersonaje(Personaje personaje) {
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
}

public class FabricaDePersonajes {
    string[] nombresElficos = {
        "Legolas",
        "Arwen",
        "Galadriel",
        "Thranduil",
        "Elrond",
        "Eärendil",
        "Celebrían",
        "Finrod",
        "Lúthien",
        "Glorfindel"
    };
    string[] nombresOrcos = {
        "Gorbag",
        "Uglúk",
        "Azog",
        "Lurtz",
        "Gothmog",
        "Shagrat",
        "Grishnákh",
        "Mauhúr",
        "Guritz",
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
    string[] nombresZombies = {
        "Rotten",
        "Ghoul",
        "Lurker",
        "Zed",
        "Mort",
        "Cadaver",
        "Flesh-Eater",
        "Rotter",
        "Zombie",
        "Decay"
    };
    string[] apodosZombies = {
        "Caminante",
        "Comecerebros",
        "Muerto Viviente",
        "Podrido",
        "Carroñero",
        "Putrefacto",
        "Despojo",
        "Errante",
        "No-Muerto",
        "Pálido"
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
        "Susurrante",
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
        "Zombie",
    };
    string[] roles = {
        "Arquero",
        "Mago",
        "Curador",
        "Caballero",
        "Cazador",
        "Saboteador"
    };
    public Personaje CrearPersonaje() {
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        string rol;
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
        nuevo.FechaDeNacimiento = new DateTime (anio,mes,dia);
        nuevo.Tipo = Tipo[valor.Next(0,4)];
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
            case "Zombie":
                nuevo.Nombre = nombresZombies[valor.Next(0,9)];
                nuevo.Apodo = apodosZombies[valor.Next(0,9)];
                nuevo.Velocidad = valor.Next(1,11);
                nuevo.Fuerza = valor.Next(4,11);
                nuevo.Armadura = valor.Next(5,11);
                nuevo.Salud = valor.Next(130,200);
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

public class MecanicaDeCombate {
    public Personaje SubirNivel(Personaje personaje) {
        Random valor = new Random(); 
        personaje.Nivel = personaje.Nivel + 1;
        personaje.Salud = personaje.Salud + 5;
        personaje.Fuerza = personaje.Fuerza + 0.25f;
        personaje.Armadura = personaje.Armadura + 0.25f;
        personaje.Velocidad = personaje.Velocidad + 0.25f;
        switch (valor.Next(1,5)) {
            case 1:
                personaje.Armadura = personaje.Armadura + 1;
            break;
            case 2:
                personaje.Fuerza = personaje.Fuerza + 1;
            break;
            case 3:
                personaje.Velocidad = personaje.Velocidad + 1;
            break;
            case 4:
                personaje.Salud = personaje.Salud + 25;
            break;
        }
        return personaje;
    }
    public float DanoDeCombate(Personaje atacante, Personaje defensor,int habilidadAtacante, int habilidadDefensor) {
        float dano, ataque, defensa;
        Random valor = new Random();
        if (habilidadAtacante == 0) {
            habilidadAtacante = 1;
        }
        if (habilidadDefensor == 0) {
            habilidadDefensor = 1;
        }
        ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel * habilidadAtacante;
        defensa = defensor.Armadura * defensor.Velocidad * habilidadDefensor;
        dano = (((ataque * valor.Next(1,100)) - defensa)/200);
        return dano;
    }
    public Personaje Combate(Personaje personaje1, Personaje personaje2) {
        Random valor = new Random();
        float salud1, salud2;
        int turno = valor.Next(1,3);
        int ronda = 1;
        int habilidadAtacante;
        int habilidadDefensor;
        salud1 = personaje1.Salud;
        salud2 = personaje2.Salud;
        while ((salud1 > 0) && (salud2 > 0)) {
            habilidadAtacante = 0;
            habilidadDefensor = 0;
            System.Console.WriteLine("--> RONDA N"+ronda);
            if (turno == 1) {
                turno = 2;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario
                if (personaje1.Energia == 5 && (salud1 > (personaje1.Salud/2))) {
                    habilidadAtacante = 5;
                    personaje1.Energia = 0;
                } else {
                    if (personaje1.Energia == 5 && (salud2 < (personaje2.Salud/3))) {
                        habilidadAtacante = 5;
                        personaje1.Energia = 0;
                    }
                }
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                if (personaje2.Energia == 3 && (salud2 < (personaje2.Salud/3))) {
                    habilidadDefensor = 3;
                    personaje2.Energia -= 3;
                }
                salud2 = salud2 - DanoDeCombate(personaje1,personaje2,habilidadAtacante,habilidadDefensor);
                personaje2.Energia += 1;
                System.Console.WriteLine("--- Resultados del combate ---");
                System.Console.WriteLine("Personaje: "+ personaje2.Nombre + ", " + personaje2.Apodo);
                System.Console.WriteLine("Salud: "+ salud2);
            } else {
                turno = 1;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario
                if (personaje2.Energia == 5 && (salud2 > (personaje2.Salud/2))) {
                    habilidadAtacante = 5;
                    personaje2.Energia = 0;
                } else {
                    if (personaje2.Energia == 5 && (salud1 < (personaje1.Salud/3))) {
                        habilidadAtacante = 5;
                        personaje2.Energia = 0;
                    }
                }
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                if (personaje1.Energia == 3 && (salud1 < (personaje1.Salud/3))) {
                    habilidadDefensor = 3;
                    personaje1.Energia -= 3;
                }
                salud1 = salud1 - DanoDeCombate(personaje1,personaje2,habilidadAtacante,habilidadDefensor);
                personaje1.Energia += 1;
                System.Console.WriteLine("--- Resultados del combate ---");
                System.Console.WriteLine("Personaje: "+ personaje1.Nombre + ", " + personaje1.Apodo);
                System.Console.WriteLine("Salud: "+ salud1);
            }
            ronda++;
        }
        if (salud1 > 0) {
            return personaje1;
        } else {
            return personaje2;
        }
    }
    public List<Personaje> Sorteo(List<Personaje> listaPersonajes){
        var Combate = new List<Personaje>();
        var random = new Random();
        Personaje p;
        while(listaPersonajes.Count()!=0){
            p = listaPersonajes[random.Next(0,listaPersonajes.Count())];
            Combate.Add(p);
            listaPersonajes.Remove(p);
        }
        return Combate;
    }
    public List<Personaje> Ganadores(List<Personaje> Competidores){
        var resultados = new List<Personaje>();
        int batalla = 1;
        Personaje ganador;
        while(Competidores.Count()>0){
            System.Console.WriteLine("--- BATALLA NUMERO "+batalla);
            if(Competidores.Count()>1){
                System.Console.WriteLine(Competidores[0].Nombre + ", " + Competidores[0].Apodo + " vs " +Competidores[1].Nombre + ", " + Competidores[1].Apodo);
                ganador = Combate(Competidores[0],Competidores[1]);
                resultados.Add(ganador);
                System.Console.WriteLine("EL GANADOR ES: "+ganador.Nombre+ ", "+ganador.Apodo);
                Competidores.Remove(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }else{
                resultados.Add(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }
            batalla++;
        }
        return resultados;
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
    // Deserialicacion
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