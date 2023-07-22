using EspacioPersonaje;
using EspacioCombate;
namespace InterfazVisual;
public class Interfaz{
    public static void Presentacion()
    {
        Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│ ┌───────┐┌───────┐┌──────────┐┌────────┐     ┌───┐        ┌───┐┌──────────┐┌────────┐   │");
        Console.WriteLine("│ │       └┘       ││          ││        └─┐   │   │        │   ││          ││        └─┐ │");
        Console.WriteLine("│ │   ┌──┐  ┌──┐   ││  ┌────┐  ││  ┌───┐   └┐  │   │        │   ││  ┌────┐  ││  ┌───┐   │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │   └─┐  │  │   │        │   ││  │    │  ││  │   └┐  │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │     │  │  │   │        │   ││  │    │  ││  │   ┌┘  │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  └────┘  ││  │     │  │  │   │  ┌──┐  │   ││  └────┘  ││  └───┘  ┌┘ │");
        Console.WriteLine("│ │   │  └──┘  │   ││  ┌────┐  ││  │     │  │  │   │  │  │  │   ││  ┌────┐  ││       ┌─┘  │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││  │   ┌─┘  │  │   │  │  │  │   ││  │    │  ││  ┌─┐  └─┐  │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││  └───┘   ┌┘  │   └──┘  └──┘   ││  │    │  ││  │ └─┐  └┐ │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││        ┌─┘   │       ┌┐       ││  │    │  ││  │   └┐  │ │");
        Console.WriteLine("│ └───┘        └───┘└──┘    └──┘└────────┘     └───────┘└───────┘└──┘    └──┘└──┘    └──┘ │");
        Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────┘");
        Console.WriteLine("                                 >>press ENTER to start<<");
        Console.ReadKey();
        Console.Clear();
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
                    Console.WriteLine("║        »│ .     Torneo      . │«         ║");
                }else{
                    Console.WriteLine("║         │ .     Torneo      . │          ║");
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
                    switch (option){
                        case 1:
                            ModoTorneo(listaDePersonajes);
                            break;
                        case 2:
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
                }else if(option>2){
                    option = 2;
                }
                Console.Clear();
                listaDePersonajes = pjson.LeerPersonaje("Personajes.json");
                if(listaDePersonajes ==null){
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
            System.Console.WriteLine("- Bienvenido a la Arena de 'Epic War'...");
            Console.ReadKey();
            Console.Clear();
            System.Console.WriteLine("- El modo torneo sirve para ver, en condiciones azarosas, quien es mejor...");
            Console.ReadKey();
            Console.Clear();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            MecanicaDeCombate Combates = new MecanicaDeCombate();
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
                        Combates.Competencia(listaDePersonajes); 
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

    public static void OpPersonajes(List<Personaje> listaDePersonajes, FabricaDePersonajes fabricaPersonaje, PersonajesJson pjson){
        int i = 0, prim = listaDePersonajes.Count()-1;
        ConsoleKeyInfo aux;
        int op = 1, salida = 0;
        do{
            Console.Clear();
            System.Console.WriteLine("          ╔══════════════════════╗");
            System.Console.WriteLine("          ║  >>> PERSONAJES <<<  ║");
            System.Console.WriteLine("          ╚══════════════════════╝");
            listaDePersonajes[i].MostrarPersonaje();
            System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
            System.Console.WriteLine("          ┌─────────────────────┐");
            if(op == 1){
            System.Console.WriteLine("         »│ . Crear Nuevos Personajes . │«");
            }else{
            System.Console.WriteLine("          │ . Crear Nuevos Personajes . │");
            }
            System.Console.WriteLine("          ├─────────────────────┤");
            if(i>prim){
                if(op == 2){
                System.Console.WriteLine("         »│ .      SALIR      . │«");
                }else{
                System.Console.WriteLine("          │ .      SALIR      . │");
                }
                System.Console.WriteLine("          ├─────────────────────┤");
                if(op == 3){
                System.Console.WriteLine("         »│ .      BORRAR     . │«");
                }else{
                System.Console.WriteLine("          │ .      BORRAR     . │");
                }
                System.Console.WriteLine("          └─────────────────────┘");
                aux = Console.ReadKey(intercept: true);
                if(aux.Key == ConsoleKey.UpArrow){
                    op--;
                }else if(aux.Key == ConsoleKey.DownArrow){
                    op++;
                }
                if(op<1){
                    op = 1;
                }else if(op>3){
                    op = 3;
                }
            }else{
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
                    var nuevo = fabricaPersonaje.CrearPersonaje();
                    string? name;
                    do{
                        Console.Clear();
                        System.Console.WriteLine("          ╔═══════════════════════╗");
                        System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                        System.Console.WriteLine("          ╚═══════════════════════╝");
                        System.Console.WriteLine("Ingrese el NOMBRE del Personaje: ");
                        name = Console.ReadLine();
                    }while(name == null || name =="");
                    nuevo.Nombre = name;
                    do{
                        Console.Clear();
                        System.Console.WriteLine("          ╔═══════════════════════╗");
                        System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                        System.Console.WriteLine("          ╚═══════════════════════╝");
                        System.Console.WriteLine(">>NOMBRE: "+ nuevo.Nombre);
                        System.Console.WriteLine("Ingrese el APODO del Personaje: ");
                        name = Console.ReadLine();
                    }while(name ==null || name =="");
                    nuevo.Apodo = name;
                    listaDePersonajes.Add(nuevo);
                    Console.Clear();
                }else if(op ==2){
                    salida = 1;
                }else if(op==3){
                    listaDePersonajes.Remove(listaDePersonajes[i]);
                    op=1;
                    i--;
                }
                pjson.GuardarPersonaje(listaDePersonajes,"Personajes");
            }
        }while(aux.Key != ConsoleKey.Escape && salida !=1);
    }

}