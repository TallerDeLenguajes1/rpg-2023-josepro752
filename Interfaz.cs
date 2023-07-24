using EspacioPersonaje;
using EspacioCombate;
namespace InterfazVisual;
public class Interfaz{
    public static void Presentacion()
    {
        Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│ ┌───────────┐┌──────────┐ ┌───┐┌───────────┐       ┌───┐        ┌───┐  ┌──────┐  ┌────────┐  ┌──────────┐ │");
        Console.WriteLine("│ │   ┌───────┘│  ┌────┐  └┐└───┘│  ┌────────┘       │   │        │   │┌─┘      └─┐│        └─┐│   ┌──────┘ │");
        Console.WriteLine("│ │   │        │  │    └┐  │┌───┐│  │                │   │        │   ││  ┌────┐  ││  ┌───┐   ││   │        │");
        Console.WriteLine("│ │   └─────┐  │  └─────┘  ││   ││  │                │   │  ┌──┐  │   ││  │    │  ││  └───┘  ┌┘│   └──────┐ │");
        Console.WriteLine("│ │   ┌─────┘  │  ┌────────┘│   ││  │                │   │  │  │  │   ││  └────┘  ││       ┌─┘ └───────┐  │ │");
        Console.WriteLine("│ │   │        │  │         │   ││  │                │   └──┘  └──┘   ││  ┌────┐  ││  ┌─┐  └─┐ ┌──┐    │  │ │");
        Console.WriteLine("│ │   └───────┐│  │         │   ││  └────────┐       │       ┌┐       ││  │    │  ││  │ └─┐  │ │  └────┘  │ │");
        Console.WriteLine("│ └───────────┘└──┘         └───┘└───────────┘       └───────┘└───────┘└──┘    └──┘└──┘   └──┘ └──────────┘ │");
        Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
        Console.WriteLine("                                          >>Toca una tecla para empezar<<");
        Console.ReadKey();
        Console.Clear();
    }
    public static void EscribirMensaje(string mensaje){
        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(20); // Retardo de 30 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public static void EscribirMensajeV2(string mensaje){
        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(3); // Retardo de 1 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public static void EscribirMensajeV4000(string mensaje){
        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(50); // Retardo de 50 milisegundos entre cada carácter
        }
        Thread.Sleep(4000); // Retardo de 4 segundos
        Console.WriteLine();
    }
    public static void Menu(PersonajesJson pjson, List<Personaje> listaDePersonajes, FabricaDePersonajes fabricaPersonaje){
        ConsoleKeyInfo key;
        int option = 1, salida=0;
        
        do{
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║                 ╔══════╗                 ║");
            Console.WriteLine("║                 ║INICIO║                 ║");
            Console.WriteLine("║                 ╚══════╝                 ║");
            Console.WriteLine("║         ┌─────────────────────┐          ║");
            if(option == 1){
                Console.WriteLine("║        »│ .      Jugar      . │«         ║");
            }else{
                Console.WriteLine("║         │ .      Jugar      . │          ║");
            }
            Console.WriteLine("║         ├─────────────────────┤          ║");
            if(option == 2){
                Console.WriteLine("║        »│ .    Personajes   . │«         ║");
            }else{
                Console.WriteLine("║         │ .    Personajes   . │          ║");
            }
            Console.WriteLine("║         ├─────────────────────┤          ║");
            if(option == 3){
                Console.WriteLine("║        »│ .      SALIR      . │«         ║");
            }else{
                Console.WriteLine("║         │ .      SALIR      . │          ║");
            }
            Console.WriteLine("║         └─────────────────────┘          ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            key = Console.ReadKey();
            Console.Clear();
            if(key.Key == ConsoleKey.Enter){
                switch (option){
                    case 1:
                        OpJugar(fabricaPersonaje,pjson);
                        break;
                    case 2:
                        OpPersonajes(listaDePersonajes, fabricaPersonaje,pjson);
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
        }while(salida != 3 && key.Key != ConsoleKey.Escape);
    }
    public static void OpJugar(FabricaDePersonajes fabricaPersonaje, PersonajesJson pjson){
        ConsoleKeyInfo key;
        MecanicaDeCombate Combates = new MecanicaDeCombate();
        int option = 1, salida=0;
        var listaDePersonajes = pjson.LeerPersonaje("Personajes.json");
        if(listaDePersonajes != null){
            do{
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                ╔═══════╗                 ║");
                Console.WriteLine("║                ║ JUGAR ║                 ║");
                Console.WriteLine("║                ╚═══════╝                 ║");
                Console.WriteLine("║         ┌─────────────────────┐          ║");
                if(option == 1){
                    Console.WriteLine("║        »│ .  Modo Historia  . │«         ║");
                }else{
                    Console.WriteLine("║         │ .  Modo Historia  . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 2){
                    Console.WriteLine("║        »│ .   Modo Torneo   . │«         ║");
                }else{
                    Console.WriteLine("║         │ .   Modo Torneo   . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 3){
                    Console.WriteLine("║        »│ .     VOLVER      . │«         ║");
                }else{
                    Console.WriteLine("║         │ .     VOLVER      . │          ║");
                }
                Console.WriteLine("║         └─────────────────────┘          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    switch (option){
                        case 1:
                            ModoHistoria(listaDePersonajes);
                            break;
                        case 2:
                            ModoTorneo(listaDePersonajes);
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
                listaDePersonajes = pjson.LeerPersonaje("Personajes.json");
                if(listaDePersonajes == null){
                    salida = 3;
                }
            }while(salida != 3 && key.Key != ConsoleKey.Escape);
        }
    }
    public static int ElegirPersonaje(List<Personaje> listaDePersonajes){
        int i = 0, prim = listaDePersonajes.Count()-1;
        ConsoleKeyInfo aux;
        int op =1, salida =0;
        do{
            Console.Clear();
            System.Console.WriteLine("          ╔══════════════════════╗");
            System.Console.WriteLine("          ║  >>> PERSONAJES <<<  ║");
            System.Console.WriteLine("          ╚══════════════════════╝");
            listaDePersonajes[i].MostrarPersonaje();
            System.Console.WriteLine("Usa las flechas '←' o '→' para cambiar de personaje");
            System.Console.WriteLine("          ┌─────────────────────┐");
            if(op == 1){
            System.Console.WriteLine("         »│ .   SELECCIONAR   . │«");
            }else{
            System.Console.WriteLine("          │ .   SELECCIONAR   . │");
            }
            System.Console.WriteLine("          ├─────────────────────┤");
            if(op == 2){
            System.Console.WriteLine("         »│ .      SALIR      . │«");
            }else{
            System.Console.WriteLine("          │ .      SALIR      . │");
            }
            System.Console.WriteLine("          └─────────────────────┘");
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
                i = (listaDePersonajes.Count()-1);
            }else if(i>(listaDePersonajes.Count()-1)){
                i = 0;
            }
            if(aux.Key == ConsoleKey.Enter){
                if(op==1){
                    return i;
                }else if(op ==2){
                    salida = 1;
                }
            }
        }while(aux.Key != ConsoleKey.Escape && salida !=1);
        return -1;
    }
    public static void ModoTorneo(List<Personaje> listaDePersonajes ){ 
        if(listaDePersonajes != null){
            EscribirMensaje("- Bienvenido a la Arena de 'Epic Wars' -");
            Continuar();
            EscribirMensaje("- En el modo torneo podras ver luchar personajes ya creados. Son 16 participantes, de los cuales solo 1 será el vencedor -");
            Continuar();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            List<Personaje> listaDeGanadores = new List<Personaje>();
            MecanicaDeCombate mecanica = new MecanicaDeCombate();
            do{
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║               ╔════════╗                 ║");
                Console.WriteLine("║               ║ TORNEO ║                 ║");
                Console.WriteLine("║               ╚════════╝                 ║");
                Console.WriteLine("║         ┌─────────────────────┐          ║");
                if(option == 1){
                    Console.WriteLine("║        »│ .     Entrar      . │«         ║");
                }else{
                    Console.WriteLine("║         │ .     Entrar      . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 2){
                    Console.WriteLine("║        »│ .     VOLVER      . │«         ║");
                }else{
                    Console.WriteLine("║         │ .     VOLVER      . │          ║");
                }
                Console.WriteLine("║         └─────────────────────┘          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    if(option==1){
                        EscribirMensaje("- En cada etapa, las luchas se organizaran por sorteo, para fomentar un equilibrio entre personajes. De esta manera ganará el mejor de todos -");
                        Continuar();
                        // OCTAVOS DE FINAL
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en los Octavos de finales -");
                        Continuar();
                        Console.Clear();
                        EscribirMensajeV2("                 ╔════════════════════════════╗");
                        EscribirMensajeV2("                 ║  --> OCTAVOS DE FINAL <--  ║");
                        EscribirMensajeV2("                 ╚════════════════════════════╝");
                        System.Console.WriteLine("");
                        listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                        mecanica.Fixture(listaDePersonajes,8);
                        Continuar();
                        listaDeGanadores = mecanica.Ganadores(listaDePersonajes);
                        // FIN
                        // CUARTOS DE FINAL
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en los cuartos de finales -");
                        Continuar();
                        Console.Clear();
                        EscribirMensajeV2("                 ╔════════════════════════════╗");
                        EscribirMensajeV2("                 ║  --> CUARTOS DE FINAL <--  ║");
                        EscribirMensajeV2("                 ╚════════════════════════════╝");
                        System.Console.WriteLine("");
                        listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                        mecanica.Fixture(listaDeGanadores,4);
                        Continuar();
                        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
                        // FIN
                        // SEMIFINALES
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en las semifinales -");
                        Continuar();
                        Console.Clear();
                        EscribirMensajeV2("                   ╔═══════════════════════╗");
                        EscribirMensajeV2("                   ║  --> SEMIFINALES <--  ║");
                        EscribirMensajeV2("                   ╚═══════════════════════╝");
                        System.Console.WriteLine("");
                        listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                        mecanica.Fixture(listaDeGanadores,2);
                        Continuar();
                        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
                        // FIN
                        // FINAL
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en la final -");
                        Continuar();
                        Console.Clear();
                        EscribirMensajeV2("                     ╔═══════════════════╗");
                        EscribirMensajeV2("                     ║   --> FINAL <--   ║");
                        EscribirMensajeV2("                     ╚═══════════════════╝");
                        System.Console.WriteLine("");
                        listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                        mecanica.Fixture(listaDeGanadores,1);
                        Continuar();
                        EscribirMensajeV4000("El ganador del Torneo es... ");
                        System.Console.WriteLine("");
                        // FIN
                        if (listaDeGanadores != null) {
                            listaDeGanadores[0].MostrarPersonajeVersionMENU();
                            Continuar();
                            EscribirMensaje(" - Que bien !!!, ¿Cual creíste que ganaría? - ");
                            Continuar();
                        }
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
    public static void ModoHistoria(List<Personaje> listaDePersonajes ) {

    }
    public static void OpPersonajes(List<Personaje> listaDePersonajes, FabricaDePersonajes fabricaPersonaje, PersonajesJson pjson){
        int i = 0, prim = listaDePersonajes.Count()-1;
        ConsoleKeyInfo aux;
        int op = 1, salida = 0;
        do {
            Console.Clear();
            listaDePersonajes[i].MostrarPersonajeVersionMENU();
            System.Console.WriteLine("Usa las flechas '←' o '→' para cambiar de personaje");
            System.Console.WriteLine("          ┌─────────────────────────────┐");
            if(op == 1){
            System.Console.WriteLine("         »│ . Crear Nuevos Personajes . │«");
            }else{
            System.Console.WriteLine("          │ . Crear Nuevos Personajes . │");
            }
            System.Console.WriteLine("          ├─────────────────────────────┤");
            if(op == 2){
            System.Console.WriteLine("         »│ .          SALIR          . │«");
            }else{
            System.Console.WriteLine("          │ .          SALIR          . │");
            }
            System.Console.WriteLine("          └─────────────────────────────┘");
            aux = Console.ReadKey(intercept: true);
            if(aux.Key == ConsoleKey.UpArrow){
                op--;
            }else if(aux.Key == ConsoleKey.DownArrow){
                op++;
            }
            if(op<1){
                op = 2;
            } else if (op>2) {
                op = 1;
            }
            if(aux.Key == ConsoleKey.RightArrow){
                i++;
            }else if(aux.Key == ConsoleKey.LeftArrow){
                i--;
            }
            if(i<0){
                i = (listaDePersonajes.Count()-1);
            }else if(i>(listaDePersonajes.Count()-1)){
                i = 0;
            }
            if(aux.Key == ConsoleKey.Enter){
                if(op==1){
                    Console.Clear();
                    EscribirMensaje("Se estan creando los nuevos personajes...");
                    List<Personaje> listaNueva = new List<Personaje>();
                    for (int j = 0; j < 16; j++) {
                        listaNueva.Add(fabricaPersonaje.CrearPersonaje());
                    }
                    EscribirMensaje("Guardando los nuevos personajes...");
                    pjson.GuardarPersonaje(listaNueva, "Personajes");
                    listaDePersonajes = pjson.LeerPersonaje("Personajes.json");
                    EscribirMensaje("Los personajes se crearon exitosamente...");
                }
                if (op == 2) {
                    salida = 1;
                }
            }
        }while(aux.Key != ConsoleKey.Escape && salida !=1);
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
        System.Console.WriteLine("- CONTINUAR (Toca cualquier Tecla) -");
        Console.ReadKey();
        Console.Clear();
    }
}