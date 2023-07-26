using EspacioPersonaje;
using EspacioCombate;
namespace InterfazVisual;
public class Interfaz{
    public static void Presentacion()
    {
        Console.WriteLine(" ┌───────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine(" │ ┌───────────┐┌──────────┐ ┌───┐┌───────────┐       ┌───┐        ┌───┐  ┌──────┐  ┌────────┐  ┌──────────┐ │");
        Console.WriteLine(" │ │   ┌───────┘│  ┌────┐  └┐└───┘│  ┌────────┘       │   │        │   │┌─┘      └─┐│        └─┐│   ┌──────┘ │");
        Console.WriteLine(" │ │   │        │  │    └┐  │┌───┐│  │                │   │        │   ││  ┌────┐  ││  ┌───┐   ││   │        │");
        Console.WriteLine(" │ │   └─────┐  │  └─────┘  ││   ││  │                │   │  ┌──┐  │   ││  │    │  ││  └───┘  ┌┘│   └──────┐ │");
        Console.WriteLine(" │ │   ┌─────┘  │  ┌────────┘│   ││  │                │   │  │  │  │   ││  └────┘  ││       ┌─┘ └───────┐  │ │");
        Console.WriteLine(" │ │   │        │  │         │   ││  │                │   └──┘  └──┘   ││  ┌────┐  ││  ┌─┐  └─┐ ┌──┐    │  │ │");
        Console.WriteLine(" │ │   └───────┐│  │         │   ││  └────────┐       │       ┌┐       ││  │    │  ││  │ └─┐  │ │  └────┘  │ │");
        Console.WriteLine(" │ └───────────┘└──┘         └───┘└───────────┘       └───────┘└───────┘└──┘    └──┘└──┘   └──┘ └──────────┘ │");
        Console.WriteLine(" └───────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
        System.Console.WriteLine("");
        EscribirMensaje("                                   >>Toca una tecla para empezar<<",3);
        Console.ReadKey();
        Console.Clear();
    }
    public static void EscribirMensaje(string mensaje, int x){
        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(x); // Retardo de x milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public static string Centrar(string palabra, int espacios){
        int Blanco = (espacios - palabra.Length)/2;
        string palabraCentrada = palabra.PadLeft(palabra.Length + Blanco);
        palabraCentrada = palabraCentrada.PadRight(espacios);
        return palabraCentrada;
    }
    public static string CentrarV2(string palabra, int espacios){
        int Blanco = (espacios - palabra.Length)/2;
        string palabraCentrada = palabra.PadLeft(palabra.Length + Blanco,'▒');
        palabraCentrada = palabraCentrada.PadRight(espacios,'▒');
        return palabraCentrada;
    }
    public static void Menu(PersonajesJson personajesJson, FabricaDePersonajes fabricarPersonaje){
        //Leer cada archivo json y guardarlo en una lista, 
        var Supervivencia = personajesJson.LeerPersonaje("PersonajesSupervivencia");
        var Niveles = personajesJson.LeerPersonaje("PersonajesNiveles");
        var Torneo= personajesJson.LeerPersonaje("PersonajesTorneo");
        int option = 1, salida = 0;
        ConsoleKeyInfo key;
        if (Supervivencia != null && Niveles != null && Torneo != null) {//Controlar si las listas son nulas
            do {
                Console.WriteLine("          ╔═══════════════════════════════════╗");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒          ╔════════╗           ▒▒║");
                Console.WriteLine("          ║▒▒          ║ INICIO ║           ▒▒║");
                Console.WriteLine("          ║▒▒          ╚════════╝           ▒▒║");
                Console.WriteLine("          ║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("          ║▒▒   »│ .      Jugar      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .      Jugar      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("          ║▒▒   »│ .   Personajes    . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .   Personajes    . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 3){
                    Console.WriteLine("          ║▒▒   »│ .      SALIR      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .      SALIR      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    switch (option){
                        case 1:
                            OpcionJugar(Torneo,Niveles,Supervivencia,personajesJson);
                            break;
                        case 2:
                            MenuDePersonajes(Torneo,Niveles,Supervivencia,fabricarPersonaje,personajesJson);
                            break;
                        case 3:
                            salida = 3;
                            break;
                    }
                }else if(key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 3;
                }else if(option>3){
                    option = 1;
                }
                Console.Clear();
            } while (salida != 3 && key.Key != ConsoleKey.Escape);
        }
    }
    public static void OpcionJugar(List<Personaje> Torneo, List<Personaje> Niveles, List<Personaje> Supervivencia, PersonajesJson pjson) {
        MecanicaDeCombate Combates = new MecanicaDeCombate();
        ConsoleKeyInfo key;
        var jugador = pjson.LeerPersonajeIndividual("PersonajeActual");
        int option = 1, salida=0;
        if (jugador != null) {
            do {
                Console.WriteLine("          ╔═══════════════════════════════════╗");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒          ╔═══════╗            ▒▒║");
                Console.WriteLine("          ║▒▒          ║ JUGAR ║            ▒▒║");
                Console.WriteLine("          ║▒▒          ╚═══════╝            ▒▒║");
                Console.WriteLine("          ║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("          ║▒▒   »│ .  Supervivencia  . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .  Supervivencia  . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("          ║▒▒   »│ .   Modo Torneo   . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .   Modo Torneo   . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 3){
                    Console.WriteLine("          ║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    switch (option){
                        case 1:
                            ModoSupervivencia(Niveles,jugador);
                            break;
                        case 2:
                            ModoTorneo(Torneo);
                            break;
                        case 3:
                            salida = 3;
                            break;
                    }
                }else if(key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 3;
                }else if(option>3){
                    option = 1;
                }
                Console.Clear();
            } while (salida != 3 && key.Key != ConsoleKey.Escape);
        } else {
            EscribirMensaje("Aún no se ha seleccionado un personaje, redirigiendo...",3);
            Thread.Sleep(2500);
            ElegirPersonaje(Supervivencia,pjson);
            Console.Clear();
        }
    }
    public static void ModoSupervivencia(List<Personaje>? Niveles, Personaje jugador) {
        MecanicaDeCombate mecanica = new MecanicaDeCombate();
        Personaje Ganador = new Personaje();
        if(Niveles != null) {
            EscribirMensaje("                                  --> Bienvenido al Modo Supervivencia de 'Epic Wars' <--",5);
            System.Console.WriteLine("");
            EscribirMensaje("- En este modo podras luchar contra disntintos personajes. Se divide en 10 niveles de dificultad, de los cuales si ganas, el siguiente nivel será mas complicado de completar -",1);
            System.Console.WriteLine("");
            EscribirMensaje("- Al superar un nivel, tu personaje obtendrá aleatoriamente una subida significativa en uno de sus atributos. Además, subirás de nivel, lo que mejorará ligeramente todas tus características -",1);
            System.Console.WriteLine("");
            EscribirMensaje("- En el campo de batalla, podrás elegir entre distintos tipos de ataques u golpes. Dependiendo de cuanta vida y energía te quedé, te convendrá o no defenderte o atacar usando tu habilidad (barra de energía) -",1);
            System.Console.WriteLine("");
            Continuar();
            ConsoleKeyInfo key;
            int option = 1, salida = 0, i;
            do {
                Console.WriteLine("          ╔═══════════════════════════════════╗");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");          
                Console.WriteLine("          ║▒▒       ╔═══════════════╗       ▒▒║");
                Console.WriteLine("          ║▒▒       ║ SUPERVIVENCIA ║       ▒▒║");
                Console.WriteLine("          ║▒▒       ╚═══════════════╝       ▒▒║");
                Console.WriteLine("          ║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("          ║▒▒   »│ .     Entrar      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .     Entrar      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("          ║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    if (option == 1) {
                        for (i = 0; i < 10; i++) {
                            // Ordeno los distintos personajes desde el nivel 3 al 12
                            Ganador = mecanica.CombateIAvsJugador(jugador,Niveles[0]);
                            if (Ganador.Nombre + Ganador.Apodo == jugador.Nombre + jugador.Apodo) {

                            }
                        }
                        if (i == 10) {
                            EscribirMensaje("╔════════════════════════════════════════════════╗",3);
                            Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                            Console.WriteLine("║▒▒                                            ▒▒║");
                            Console.WriteLine("║▒▒        ╔═══════════════════════════╗       ▒▒║");
                            Console.WriteLine("║▒▒        ║ FELICIDADES!!!  GANASTE ☺ ║       ▒▒║");
                            Console.WriteLine("║▒▒        ╚═══════════════════════════╝       ▒▒║");
                            Console.WriteLine("║▒▒                                            ▒▒║");
                            Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                            EscribirMensaje("╚════════════════════════════════════════════════╝,",3);
                        } else { // "+ i +"
                            EscribirMensaje(" ╔══════════════════════════════════════════════╗",3);
                            Console.WriteLine(" ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                            Console.WriteLine(" ║▒▒                                          ▒▒║");
                            Console.WriteLine(" ║▒▒       ╔══════════════════════════╗       ▒▒║");
                            Console.WriteLine(" ║▒▒       ║ ULTIMO NIVEL SUPERADO: 3 ║       ▒▒║");
                            Console.WriteLine(" ║▒▒       ╚══════════════════════════╝       ▒▒║");
                            Console.WriteLine(" ║▒▒                                          ▒▒║");
                            Console.WriteLine(" ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                            EscribirMensaje(" ╚══════════════════════════════════════════════╝",3);
                        }
                    }
                    salida = 2;
                }else if(key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option < 1){
                    option = 2;
                }else if(option > 2){
                    option = 1;
                }
                Console.Clear();
            } while (salida != 2 && key.Key != ConsoleKey.Escape);
        }
    }
    public static void ModoTorneo(List<Personaje>? listaDePersonajes ){ 
        if(listaDePersonajes != null){
            EscribirMensaje("                                  --> Bienvenido al Modo Torneo de 'Epic Wars' <--",5);
            System.Console.WriteLine("");
            EscribirMensaje("- Este modo es un campeonato en donde podras ver luchar personajes ya creados. Son 16 participantes, de los cuales solo 1 será el vencedor -",1);
            System.Console.WriteLine("");
            EscribirMensaje("- En cada etapa, las luchas se organizaran por sorteo, para fomentar un equilibrio entre personajes. De esta manera ganará el mejor de todos -",1);
            System.Console.WriteLine("");
            Continuar();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            List<Personaje> listaDeGanadores = new List<Personaje>();
            MecanicaDeCombate mecanica = new MecanicaDeCombate();
            do{
                Console.WriteLine("          ╔═══════════════════════════════════╗");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒          ╔════════╗           ▒▒║");
                Console.WriteLine("          ║▒▒          ║ TORNEO ║           ▒▒║");
                Console.WriteLine("          ║▒▒          ╚════════╝           ▒▒║");
                Console.WriteLine("          ║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("          ║▒▒   »│ .     Entrar      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .     Entrar      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("          ║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("          ║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("          ║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("          ║▒▒                               ▒▒║");
                Console.WriteLine("          ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("          ╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    if(option==1){
                        // OCTAVOS DE FINAL
                        listaDeGanadores = OctavosDeFinal(listaDePersonajes,listaDeGanadores,mecanica);
                        // FIN
                        // CUARTOS DE FINAL
                        listaDeGanadores = CuartosDeFinal(listaDeGanadores,mecanica);
                        // FIN
                        // SEMIFINALES
                        listaDeGanadores = Semifinales(listaDeGanadores,mecanica);
                        // FIN
                        // FINAL
                        Final(listaDeGanadores,mecanica);
                        // FIN
                    }
                    salida = 2;
                }else if(key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 2;
                }else if(option>2){
                    option = 1;
                }
                Console.Clear();
            }while(salida != 2 && key.Key != ConsoleKey.Escape);
        }
    }
    public static void MenuDePersonajes(List<Personaje> Torneo,List<Personaje> Niveles,List<Personaje> Supervivencia, FabricaDePersonajes fabricarPersonaje, PersonajesJson pjson){
        ConsoleKeyInfo aux;
        List<Personaje>? aux2;
        var personajeSeleccionado = new Personaje ();
        int op = 1, salida = 0;
        int i = 0, prim;
        do {
            prim = Supervivencia.Count()-1;
            Console.Clear();
            System.Console.WriteLine("   ╔═══════════════════════════════════════════════════════════════╗");
            System.Console.WriteLine("   ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
            System.Console.WriteLine("   ║▒▒                                                           ▒▒║");
            System.Console.WriteLine("   ║▒▒                 ╔═══════════════════════╗                 ▒▒║");
            System.Console.WriteLine("   ║▒▒                 ║ SELECCIONE UNA OPCION ║                 ▒▒║");
            System.Console.WriteLine("   ║▒▒                 ╚═══════════════════════╝                 ▒▒║");
            System.Console.WriteLine("   ║▒▒                                                           ▒▒║");
            System.Console.WriteLine("   ║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
            System.Console.WriteLine("   ╚═══════════════════════════════════════════════════════════════╝");
            System.Console.WriteLine("");
            System.Console.WriteLine("   ┌───────────────────────────────────────────────────────────────┐");
            if(op == 1){
            System.Console.WriteLine("  »│     . Crear Nuevos Personajes aleatorios (modo Torneo) .      │«");
            }else{
            System.Console.WriteLine("   │     . Crear Nuevos Personajes aleatorios (modo Torneo) .      │");
            }
            System.Console.WriteLine("   ├───────────────────────────────────────────────────────────────┤");
            if(op == 2){
            System.Console.WriteLine("  »│   . Crear Nuevos Enemigos aleatorios (modo Supervivencia) .   │«");
            }else{
            System.Console.WriteLine("   │   . Crear Nuevos Enemigos aleatorios (modo Supervivencia) .   │");
            }
            System.Console.WriteLine("   ├───────────────────────────────────────────────────────────────┤");
            if(op == 3){
            System.Console.WriteLine("  »│      . Crear Nuevos Personajes aleatorios para elegir .       │«");
            }else{
            System.Console.WriteLine("   │      . Crear Nuevos Personajes aleatorios para elegir .       │");
            }
            System.Console.WriteLine("   ├───────────────────────────────────────────────────────────────┤");
            if(op == 4){
            System.Console.WriteLine("  »│      . Ir a Elegir Personaje para jugar Supervivencia .       │«");
            }else{
            System.Console.WriteLine("   │      . Ir a Elegir Personaje para jugar Supervivencia .       │");
            }
            System.Console.WriteLine("   ├───────────────────────────────────────────────────────────────┤");
            if(op == 5){
            System.Console.WriteLine("  »│                         .  VOLVER  .                          │«");
            }else{
            System.Console.WriteLine("   │                         .  VOLVER  .                          │");
            }
            System.Console.WriteLine("   └───────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("");
            System.Console.WriteLine("   Usa las flechas '←' o '→' para ver los atributos de los personaje");
            aux = Console.ReadKey(intercept: true);
            if(aux.Key == ConsoleKey.UpArrow){
                op--;
            }else if(aux.Key == ConsoleKey.DownArrow){
                op++;
            }
            if(op<1){
                op = 5;
            } else if (op>5) {
                op = 1;
            }
            if(aux.Key == ConsoleKey.RightArrow){
                i++;
            }else if(aux.Key == ConsoleKey.LeftArrow){
                i--;
            }
            if(i<0){
                i = (Supervivencia.Count()-1);
            }else if(i>(Supervivencia.Count()-1)){
                i = 0;
            }
            if(aux.Key == ConsoleKey.Enter){
                if(op == 1){
                    Console.Clear();
                    EscribirMensaje("Se estan creando los nuevos personajes...",3);
                    EscribirMensaje("Guardando los nuevos personajes...",3);
                    aux2 = fabricarPersonaje.CrearParticipantes("PersonajesTorneo",16);
                    if (aux2 != null) {
                        Torneo = aux2;
                        EscribirMensaje("Los personajes se crearon exitosamente...",3);
                    } else {
                        EscribirMensaje("Los personajes no se modificaron",3);
                    }
                    Continuar();
                }
                if (op == 2) {
                    Console.Clear();
                    EscribirMensaje("Se estan creando los nuevos personajes...",3);
                    EscribirMensaje("Guardando los nuevos personajes...",3);
                    aux2 = fabricarPersonaje.CrearParticipantes("PersonajesNiveles",16);
                    if (aux2 != null) {
                        Niveles = aux2;
                        EscribirMensaje("Los personajes se crearon exitosamente...",3);
                    } else {
                        EscribirMensaje("Los personajes no se modificaron",3);
                    }
                    Continuar();
                }
                if(op == 3){
                    Console.Clear();
                    EscribirMensaje("Se estan creando los nuevos personajes...",3);
                    EscribirMensaje("Guardando los nuevos personajes...",3);
                    aux2 = fabricarPersonaje.CrearParticipantes("PersonajesSupervivencia",16);
                    if (aux2 != null) {
                        Supervivencia = aux2;
                        EscribirMensaje("Los personajes se crearon exitosamente...",3);
                    } else {
                        EscribirMensaje("Los personajes no se modificaron",3);
                    }
                    Continuar();
                }
                if (op == 4) {
                    if (Supervivencia != null) {
                        Console.Clear();
                        EscribirMensaje("- A continuación, seleccione el personaje que desea utilizar en el Modo Supervivencia -",3);
                        Continuar();
                        ElegirPersonaje(Supervivencia,pjson);
                    } else {
                        aux2 = fabricarPersonaje.CrearParticipantes("PersonajesSupervivencia",10);
                        EscribirMensaje("No hay personajes para seleccionar",3);
                        if (aux2 != null) {
                            Supervivencia = aux2;
                        }
                        Continuar();
                        salida = 1;
                    }
                }
                if (op == 5) {
                    salida = 1;
                }
            }
        }while(aux.Key != ConsoleKey.Escape && salida !=1 && Supervivencia != null);
    }
    public static void ElegirPersonaje(List<Personaje> listaP, PersonajesJson pjson) {
        int i = 0, prim;
        ConsoleKeyInfo aux;
        int op = 1, salida = 0;
        Console.Clear();
        if (listaP != null) {
            prim = listaP.Count()-1;
            do {
                Console.Clear();
                listaP[i].MostrarPersonajeVersionPERSONAJE();
                System.Console.WriteLine("");
                System.Console.WriteLine("                 ┌─────────────────────┐");
                if(op == 1){
                System.Console.WriteLine("                »│ .   SELECCIONAR   . │«");
                }else{
                System.Console.WriteLine("                 │ .   SELECCIONAR   . │");
                }
                System.Console.WriteLine("                 ├─────────────────────┤");
                if(op == 2){
                System.Console.WriteLine("                »│ .     VOLVER      . │«");
                }else{
                System.Console.WriteLine("                 │ .     VOLVER      . │");
                }
                System.Console.WriteLine("                 └─────────────────────┘");
                System.Console.WriteLine("");
                System.Console.WriteLine("    Usa las flechas '←' o '→' para cambiar de personaje",3);
                aux = Console.ReadKey(intercept: true);
                if(aux.Key == ConsoleKey.UpArrow){
                    op--;
                }else if(aux.Key == ConsoleKey.DownArrow){
                    op++;
                }
                if(op<1){
                    op = 2;
                }else if(op>2){
                    op = 1;
                }
                if(aux.Key == ConsoleKey.RightArrow){
                    i++;
                }else if(aux.Key == ConsoleKey.LeftArrow){
                    i--;
                }
                if(i<0){
                    i = (listaP.Count()-1);
                }else if(i>(listaP.Count()-1)){
                    i = 0;
                }
                if(aux.Key == ConsoleKey.Enter){
                    if(op == 1){
                        pjson.GuardarPersonajeIndividual(listaP[i],"PersonajeActual");// SERIALIZAR EL PERSONAJE SELECCIONADO
                        if (pjson.Existe("PersonajeActual")) { //Por si se borra en tiempo de ejecución el personaje actual
                            Console.Clear();
                            EscribirMensaje("- El personaje ha sido seleccionado correctamente -",3);
                            Continuar();
                        }
                    }
                    salida = 1;
                }
            } while (aux.Key != ConsoleKey.Escape && salida != 1);
        }
    }
    public static List<Personaje> OctavosDeFinal(List<Personaje> listaP, List<Personaje> Ganadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en los Octavos de final -",5);
        Continuar();
        Console.Clear();
        EscribirMensaje("                 ╔════════════════════════════╗",3);
        EscribirMensaje("                 ║  --> OCTAVOS DE FINAL <--  ║",2);
        EscribirMensaje("                 ╚════════════════════════════╝",3);
        System.Console.WriteLine("");
        listaP = mecanica.Sorteo(listaP);
        mecanica.Fixture(listaP,8);
        Continuar();
        Ganadores = mecanica.Ganadores(listaP,1);
        return Ganadores;
    }
    public static List<Personaje> CuartosDeFinal(List<Personaje> Ganadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- La primera etapa siempre es la mas difícil, ya llegó aquí los cuartos de final -",5);
        Continuar();
        Console.Clear();
        EscribirMensaje("                 ╔════════════════════════════╗",3);
        EscribirMensaje("                 ║  --> CUARTOS DE FINAL <--  ║",2);
        EscribirMensaje("                 ╚════════════════════════════╝",3);
        System.Console.WriteLine("");
        Ganadores = mecanica.Sorteo(Ganadores);
        mecanica.Fixture(Ganadores,4);
        Continuar();
        return mecanica.Ganadores(Ganadores,1);
    }
    public static List<Personaje> Semifinales(List<Personaje> Ganadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Nos encontramos ahora con los afortunados en clasificar en las semifinales -",5);
        Continuar();
        Console.Clear();
        EscribirMensaje("                   ╔═══════════════════════╗",3);
        EscribirMensaje("                   ║  --> SEMIFINALES <--  ║",2);
        EscribirMensaje("                   ╚═══════════════════════╝",3);
        System.Console.WriteLine("");
        Ganadores = mecanica.Sorteo(Ganadores);
        mecanica.Fixture(Ganadores,2);
        Continuar();
        return mecanica.Ganadores(Ganadores,1);
    }
    public static void Final(List<Personaje> Ganadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Por último, presentaremos los vencedores que lucharán en la final -",5);
        Continuar();
        Console.Clear();
        EscribirMensaje("                     ╔═══════════════════╗",3);
        EscribirMensaje("                     ║   --> FINAL <--   ║",3);
        EscribirMensaje("                     ╚═══════════════════╝",3);
        System.Console.WriteLine("");
        Ganadores = mecanica.Sorteo(Ganadores);
        mecanica.Fixture(Ganadores,1);
        Continuar();
        Ganadores = mecanica.Ganadores(Ganadores,1);
        EscribirMensaje("El ganador del Torneo es... ",5);
        Thread.Sleep(3000);
        System.Console.WriteLine("");
        if (Ganadores != null) {
            Ganadores[0].MostrarPersonajeVersionMENU();
            Continuar();
            EscribirMensaje(" - Que bien !!!. ¿Cual creíste que ganaría? - ",5);
            Continuar();
        }
        System.Console.WriteLine("");
    }
    public static string Espaciado(string palabra, int espacios){
        int aux = espacios - palabra.Count();
        for (int i = 0; i < aux; i++) {
            palabra = palabra + " ";
        }
        return palabra;
    }
    public static void Continuar() {
        System.Console.WriteLine("");
        System.Console.WriteLine("                                  --> CONTINUAR (Toca cualquier Tecla) <--");
        Console.ReadKey();
        Console.Clear();
    }
}