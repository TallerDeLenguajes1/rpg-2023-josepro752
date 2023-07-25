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
    public static void EscribirMensajeV3000(string mensaje){
        for (int i = 0; i < mensaje.Length; i++)
        {
            Console.Write(mensaje[i]);
            Thread.Sleep(50); // Retardo de 50 milisegundos entre cada carácter
        }
        Thread.Sleep(3000); // Retardo de 3 segundos
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
    public static void Menu(PersonajesJson pjson, List<Personaje> listaDePersonajes, FabricaDePersonajes fabricaPersonaje){
        ConsoleKeyInfo key;
        int option = 1, salida=0;
        
        do{
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
            Console.WriteLine("║▒▒                               ▒▒║");
            Console.WriteLine("║▒▒          ╔════════╗           ▒▒║");
            Console.WriteLine("║▒▒          ║ INICIO ║           ▒▒║");
            Console.WriteLine("║▒▒          ╚════════╝           ▒▒║");
            Console.WriteLine("║▒▒    ┌─────────────────────┐    ▒▒║");
            if(option == 1){
                Console.WriteLine("║▒▒   »│ .      Jugar      . │«   ▒▒║");
            }else{
                Console.WriteLine("║▒▒    │ .      Jugar      . │    ▒▒║");
            }
            Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
            if(option == 2){
                Console.WriteLine("║▒▒   »│ .   Personajes    . │«   ▒▒║");
            }else{
                Console.WriteLine("║▒▒    │ .   Personajes    . │    ▒▒║");
            }
            Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
            if(option == 3){
                Console.WriteLine("║▒▒   »│ .      SALIR      . │«   ▒▒║");
            }else{
                Console.WriteLine("║▒▒    │ .      SALIR      . │    ▒▒║");
            }
            Console.WriteLine("║▒▒    └─────────────────────┘    ▒▒║");
            Console.WriteLine("║▒▒                               ▒▒║");
            Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            key = Console.ReadKey();
            Console.Clear();
            if(key.Key == ConsoleKey.Enter){
                switch (option){
                    case 1:
                        OpcionJugar(fabricaPersonaje,pjson);
                        break;
                    case 2:
                        MenuDePersonajes(listaDePersonajes, fabricaPersonaje,pjson);
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
    public static void OpcionJugar(FabricaDePersonajes fabricaPersonaje, PersonajesJson pjson){
        ConsoleKeyInfo key;
        MecanicaDeCombate Combates = new MecanicaDeCombate();
        int option = 1, salida=0;
        var listaDePersonajes = pjson.LeerPersonaje("Personajes.json");
        if(listaDePersonajes != null){
            do{
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒          ╔═══════╗            ▒▒║");
                Console.WriteLine("║▒▒          ║ JUGAR ║            ▒▒║");
                Console.WriteLine("║▒▒          ╚═══════╝            ▒▒║");
                Console.WriteLine("║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("║▒▒   »│ .  Supervivencia  . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .  Supervivencia  . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("║▒▒   »│ .   Modo Torneo   . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .   Modo Torneo   . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 3){
                    Console.WriteLine("║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    switch (option){
                        case 1:
                            ModoSupervivencia(listaDePersonajes);
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
        } else {
            EscribirMensaje("La lista de personajes está vacía, se creara una nueva");
            // hacerlo
        }
    }
    public static int ElegirPersonaje(List<Personaje>? listaDePersonajes){
        int i = 0, prim;
        ConsoleKeyInfo aux;
        int op =1, salida =0;
        if (listaDePersonajes != null) {
            prim = listaDePersonajes.Count()-1;
            do{
                Console.Clear();
                listaDePersonajes[i].MostrarPersonajeVersionPERSONAJE();
                System.Console.WriteLine("");
                System.Console.WriteLine("           ┌─────────────────────┐");
                if(op == 1){
                System.Console.WriteLine("          »│ .   SELECCIONAR   . │«");
                }else{
                System.Console.WriteLine("           │ .   SELECCIONAR   . │");
                }
                System.Console.WriteLine("           ├─────────────────────┤");
                if(op == 2){
                System.Console.WriteLine("          »│ .     VOLVER      . │«");
                }else{
                System.Console.WriteLine("           │ .     VOLVER      . │");
                }
                System.Console.WriteLine("           └─────────────────────┘");
                System.Console.WriteLine("");
                System.Console.WriteLine("Usa las flechas '←' o '→' para cambiar de personaje");
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
                    if(op == 1){
                        var seleccionado = new PersonajesJson ();// SERIALIZAR EL PERSONAJE SELECCIONADO
                        seleccionado.GuardarPersonajeIndividual(listaDePersonajes[i],"PersonajeActual");
                        return i;
                    }else if(op == 2){
                        salida = 1;
                    }
                }
            } while (aux.Key != ConsoleKey.Escape && salida !=1);
        }
        return -1;
    }
    public static void ModoSupervivencia(List<Personaje>? listaDePersonajes ) {
        if(listaDePersonajes != null) {
            EscribirMensaje("                                  --> Bienvenido al Modo Supervivencia de 'Epic Wars' <--");
            System.Console.WriteLine("");
            EscribirMensaje("- En este modo podras luchar contra disntintos personajes. Se divide en 10 niveles de dificultad, de los cuales si ganas, el siguiente nivel será mas complicado de completar -");
            System.Console.WriteLine("");
            EscribirMensaje("- Al superar un nivel, tu personaje obtendrá aleatoriamente una subida significativa en uno de sus atributos. Además, subirás de nivel, lo que mejorará ligeramente todas sus características -");
            System.Console.WriteLine("");
            EscribirMensaje("- En el campo de batalla, podrás elegir entre distintos tipos de ataques u golpes. Dependiendo de cuanta vida y energía te quedé, te convendrá o no defenderte o atacar usando tu habilidad (barra de energía) -");
            Continuar();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            List<Personaje> listaDeGanadores = new List<Personaje>();
            MecanicaDeCombate mecanica = new MecanicaDeCombate();
            do{
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒       ╔═══════════════╗       ▒▒║");
                Console.WriteLine("║▒▒       ║ SUPERVIVENCIA ║       ▒▒║");
                Console.WriteLine("║▒▒       ╚═══════════════╝       ▒▒║");
                Console.WriteLine("║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("║▒▒   »│ .     Entrar      . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .     Entrar      . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    if(option==1){
                        //CombateNiveles();
                        Continuar();
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
    public static void ModoTorneo(List<Personaje>? listaDePersonajes ){ 
        if(listaDePersonajes != null){
            EscribirMensaje("                                  --> Bienvenido al Modo Torneo de 'Epic Wars' <--");
            System.Console.WriteLine("");
            EscribirMensaje("- Este modo es un campeonato en donde podras ver luchar personajes ya creados. Son 16 participantes, de los cuales solo 1 será el vencedor -");
            System.Console.WriteLine("");
            EscribirMensaje("- En cada etapa, las luchas se organizaran por sorteo, para fomentar un equilibrio entre personajes. De esta manera ganará el mejor de todos -");
            Continuar();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            List<Personaje> listaDeGanadores = new List<Personaje>();
            MecanicaDeCombate mecanica = new MecanicaDeCombate();
            do{
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒          ╔════════╗           ▒▒║");
                Console.WriteLine("║▒▒          ║ TORNEO ║           ▒▒║");
                Console.WriteLine("║▒▒          ╚════════╝           ▒▒║");
                Console.WriteLine("║▒▒    ┌─────────────────────┐    ▒▒║");
                if(option == 1){
                    Console.WriteLine("║▒▒   »│ .     Entrar      . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .     Entrar      . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    ├─────────────────────┤    ▒▒║");
                if(option == 2){
                    Console.WriteLine("║▒▒   »│ .     VOLVER      . │«   ▒▒║");
                }else{
                    Console.WriteLine("║▒▒    │ .     VOLVER      . │    ▒▒║");
                }
                Console.WriteLine("║▒▒    └─────────────────────┘    ▒▒║");
                Console.WriteLine("║▒▒                               ▒▒║");
                Console.WriteLine("║▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒║");
                Console.WriteLine("╚═══════════════════════════════════╝");
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
    public static void MenuDePersonajes(List<Personaje>? listaDePersonajes, FabricaDePersonajes fabricaPersonaje, PersonajesJson pjson){
        ConsoleKeyInfo aux;
        int op = 1, salida = 0;
        int i = 0, prim;
        if (listaDePersonajes != null) {
            do {
                prim = listaDePersonajes.Count()-1;
                Console.Clear();
                listaDePersonajes[i].MostrarPersonajeVersionMENU();
                System.Console.WriteLine("");
                System.Console.WriteLine("   ┌─────────────────────────────────────────┐");
                if(op == 1){
                System.Console.WriteLine("  »│  . Crear Nuevos Personajes aleatorios.  │«");
                }else{
                System.Console.WriteLine("   │  . Crear Nuevos Personajes aleatorios.  │");
                }
                System.Console.WriteLine("   ├─────────────────────────────────────────┤");
                if(op == 2){
                System.Console.WriteLine("  »│ . Elegir Personaje para jugar Campaña . │«");
                }else{
                System.Console.WriteLine("   │ . Elegir Personaje para jugar Campaña . │");
                }
                System.Console.WriteLine("   ├─────────────────────────────────────────┤");
                if(op == 3){
                System.Console.WriteLine("  »│              .  VOLVER  .               │«");
                }else{
                System.Console.WriteLine("   │              .  VOLVER  .               │");
                }
                System.Console.WriteLine("   └─────────────────────────────────────────┘");
                System.Console.WriteLine("");
                System.Console.WriteLine("Usa las flechas '←' o '→' para ver los atributos de los personaje");
                aux = Console.ReadKey(intercept: true);
                if(aux.Key == ConsoleKey.UpArrow){
                    op--;
                }else if(aux.Key == ConsoleKey.DownArrow){
                    op++;
                }
                if(op<1){
                    op = 3;
                } else if (op>3) {
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
                        Console.Clear();
                        EscribirMensaje("- A continuación, seleccione el personaje que desea utilizar en el Modo Supervivencia -");
                        Continuar();
                        ElegirPersonaje(listaDePersonajes);
                        Console.Clear();
                        EscribirMensaje("- El personaje ha sido seleccionado correctamente -");
                        Continuar();
                    }
                    if (op == 3) {
                        salida = 1;
                    }
                }
            }while(aux.Key != ConsoleKey.Escape && salida !=1);
        }
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
    public static List<Personaje> OctavosDeFinal(List<Personaje> listaDePersonajes, List<Personaje> listaDeGanadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentarán en los Octavos de final -");
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
        return listaDeGanadores;
    }
    public static List<Personaje> CuartosDeFinal(List<Personaje> listaDeGanadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- La primera etapa siempre es la mas difícil, ya llegó aquí los cuartos de final -");
        Continuar();
        Console.Clear();
        EscribirMensajeV2("                 ╔════════════════════════════╗");
        EscribirMensajeV2("                 ║  --> CUARTOS DE FINAL <--  ║");
        EscribirMensajeV2("                 ╚════════════════════════════╝");
        System.Console.WriteLine("");
        listaDeGanadores = mecanica.Sorteo(listaDeGanadores);
        mecanica.Fixture(listaDeGanadores,4);
        Continuar();
        return mecanica.Ganadores(listaDeGanadores);
    }
    public static List<Personaje> Semifinales(List<Personaje> listaDeGanadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Nos encontramos ahora con los afortunados en clasificar en las semifinales -");
        Continuar();
        Console.Clear();
        EscribirMensajeV2("                   ╔═══════════════════════╗");
        EscribirMensajeV2("                   ║  --> SEMIFINALES <--  ║");
        EscribirMensajeV2("                   ╚═══════════════════════╝");
        System.Console.WriteLine("");
        listaDeGanadores = mecanica.Sorteo(listaDeGanadores);
        mecanica.Fixture(listaDeGanadores,2);
        Continuar();
        return mecanica.Ganadores(listaDeGanadores);
    }
    public static void Final(List<Personaje> listaDeGanadores, MecanicaDeCombate mecanica) {
        EscribirMensaje("- Por último, presentaremos los vencedores que lucharán en la final -");
        Continuar();
        Console.Clear();
        EscribirMensajeV2("                     ╔═══════════════════╗");
        EscribirMensajeV2("                     ║   --> FINAL <--   ║");
        EscribirMensajeV2("                     ╚═══════════════════╝");
        System.Console.WriteLine("");
        listaDeGanadores = mecanica.Sorteo(listaDeGanadores);
        mecanica.Fixture(listaDeGanadores,1);
        Continuar();
        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
        EscribirMensajeV3000("El ganador del Torneo es... ");
        System.Console.WriteLine("");
        if (listaDeGanadores != null) {
            listaDeGanadores[0].MostrarPersonajeVersionMENU();
            Continuar();
            EscribirMensaje(" - Que bien !!!. ¿Cual creíste que ganaría? - ");
            Continuar();
        }
        System.Console.WriteLine("");
    }
}