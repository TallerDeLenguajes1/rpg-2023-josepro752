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
        Console.WriteLine("                                          >>Click ENTER para empezar<<");
        Console.ReadKey();
        Console.Clear();
    }
    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(50); // Retardo de 50 milisegundos entre cada carácter
        }
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
                option = 1;
            }else if(option>3){
                option = 3;
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
                    option = 1;
                }else if(option>3){
                    option = 3;
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
            System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
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
            if(op<0){
                op = 1;
            }else if(op>2){
                op = 2;
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
            EscribirMensaje("- Bienvenido a la Arena de 'Epic War'...");
            Console.ReadKey();
            Console.Clear();
            EscribirMensaje("- El modo torneo sirve para ver luchar personajes ya creados, de dos en dos, de manera que solo ganara el mejor...");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            List<Personaje> listaDeGanadores = new List<Personaje>();
            MecanicaDeCombate mecanica = new MecanicaDeCombate();
            do{
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                ╔════════╗                ║");
                Console.WriteLine("║                ║ TORNEO ║                ║");
                Console.WriteLine("║                ╚════════╝                ║");
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
                        EscribirMensaje("- En cada etapa, las luchas se organizaran por sorteo, para fomentar un equilibrio entre personajes. De esta manera ganara solo el mejor.");
                        Console.ReadKey();
                        Console.Clear();
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentaran en los Octavos de finales...");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("- Click Enter -");
                        key = Console.ReadKey();
                        Console.Clear();
                        if(key.Key == ConsoleKey.Enter) {
                            System.Console.WriteLine("----- OCTAVOS DE FINAL -----");
                            listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                            mecanica.Fixture(listaDePersonajes,8);
                            listaDeGanadores = mecanica.Ganadores(listaDePersonajes);
                        }

                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentaran en los cuartos de finales...");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("- Click Enter -");
                        key = Console.ReadKey();
                        Console.Clear();

                        if(key.Key == ConsoleKey.Enter) {
                            System.Console.WriteLine("----- CUARTOS DE FINAL -----");
                            listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                            mecanica.Fixture(listaDeGanadores,4);
                            listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
                        }

                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentaran en las semifinales...");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("- Click Enter -");
                        key = Console.ReadKey();
                        Console.Clear();

                        if(key.Key == ConsoleKey.Enter) {
                            System.Console.WriteLine("----- SEMIFINALES -----");
                            listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                            mecanica.Fixture(listaDeGanadores,2);
                            listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
                        }
                        
                        EscribirMensaje("- Ahora presentaremos los participantes que se enfrentaran en la final...");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("- Click Enter -");
                        key = Console.ReadKey();
                        Console.Clear();
                        
                        if(key.Key == ConsoleKey.Enter) {
                            System.Console.WriteLine("----- FINAL -----");
                            listaDePersonajes = mecanica.Sorteo(listaDePersonajes);
                            mecanica.Fixture(listaDeGanadores,1);
                            listaDeGanadores = mecanica.Ganadores(listaDeGanadores); 
                        }

                        if (listaDeGanadores != null) {
                            EscribirMensaje("El ganador del Torneo es... ");
                            Console.ReadKey();
                            Console.Clear();
                            listaDeGanadores[0].MostrarPersonaje();
                            System.Console.WriteLine("");
                            System.Console.WriteLine("- Click Enter -");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    salida = 2;
                }else if(key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 1;
                }else if(option>2){
                    option = 2;
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
            System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
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
                op = 1;
            } else if (op>2) {
                op = 2;
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
}