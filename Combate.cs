using EspacioPersonaje;
using InterfazVisual;
namespace EspacioCombate;

public class MecanicaDeCombate {
    public Personaje SubirNivel(Personaje personaje) {
        Random valor = new Random(); 
        // personaje.Nivel += 1;
        personaje.Salud += 5;
        personaje.Fuerza += 0.25f;
        personaje.Armadura += 0.25f;
        personaje.Velocidad += 0.25f;
        switch (valor.Next(1,5)) {
            case 1:
                personaje.Armadura += 1;
            break;
            case 2:
                personaje.Fuerza += 1;
            break;
            case 3:
                personaje.Velocidad += 1;
            break;
            case 4:
                personaje.Salud += 25;
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
    public Personaje CombateIAvsIA(Personaje personaje1, Personaje personaje2)
    {
        Random valor = new Random();
        ConsoleKeyInfo decision;
        decision = new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false);
        float salud1, salud2, dano;
        int habilidadAtacante, habilidadDefensor, energia1, energia2;
        int turno = valor.Next(1, 3);
        int ronda = 1;
        salud1 = personaje1.Salud;
        salud2 = personaje2.Salud;
        energia1 = personaje1.Energia;
        energia2 = personaje2.Energia;
        while ((salud1 > 0) && (salud2 > 0) && (ronda < 21))
        {
            habilidadAtacante = 0;
            habilidadDefensor = 0;
            System.Console.WriteLine("                                ╔═══════════════════════════════════════╗");
            System.Console.WriteLine("                                ║ " + Interfaz.CentrarV2(" RONDA N" + (ronda + 1) / 2 + " ", 37) + " ║"); // 37 espacios
            System.Console.WriteLine("                                ╚═══════════════════════════════════════╝");
            System.Console.WriteLine("");
            if (turno == 1)
            {
                turno = 2;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario o si esta llena
                CombateAutomaticoAtacar(personaje1, personaje2, salud1, salud2, ref habilidadAtacante, ref energia1);
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                CombateAutomaticoDefender(personaje2, salud2, ref habilidadAtacante, ref energia2);
                if (energia2 >= 5 && (salud2 < (personaje2.Salud / 3)))
                {
                    habilidadDefensor = 3;
                    energia2 -= 5;
                }
                dano = DanoDeCombate(personaje1, personaje2, habilidadAtacante, habilidadDefensor);
                salud2 = salud2 - dano;
                energia1 += 1;
                energia2 += 1;
                if (decision.KeyChar == '\r')
                {
                    if (dano > 0)
                    {
                        ResultadoCombate(personaje1, personaje2, energia2, salud2, dano, "TURNO de:");
                    }
                    else
                    {
                        ResultadoCombate(personaje1, personaje2, energia2, salud2, valor.Next(1, 5), "TURNO de:");
                    }
                    decision = Opciones(decision);
                }
            }
            else
            {
                turno = 1;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario o si esta llena
                CombateAutomaticoAtacar(personaje2, personaje1, salud2, salud1, ref habilidadAtacante, ref energia2);
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                CombateAutomaticoDefender(personaje1, salud1, ref habilidadDefensor, ref energia1);
                dano = DanoDeCombate(personaje1, personaje2, habilidadAtacante, habilidadDefensor);
                salud1 = salud1 - dano;
                energia1 += 1;
                energia2 += 1;
                if (decision.KeyChar == '\r')
                {
                    if (dano > 0)
                    {
                        ResultadoCombate(personaje2, personaje1, energia1, salud1, dano, "TURNO de:");
                    }
                    else
                    {
                        ResultadoCombate(personaje2, personaje1, energia1, salud1, valor.Next(1, 5), "TURNO de:");
                    }
                    decision = Opciones(decision);
                }
            }
            Console.Clear();
            ronda++;
        }
        return QuienGano(personaje1, personaje2, ref salud1, ref salud2);
    }
    public Personaje CombateIAvsJugador(Personaje jugador, Personaje personajeIA, Personaje auxiliarIA, float danoAnterior) {
        Random valor = new Random();
        ConsoleKeyInfo decision;
        decision = new ConsoleKeyInfo('\r',ConsoleKey.Enter,false,false,false);
        float saludJugador, saludIA, auxiliarIASalud;
        int habilidadAtacante, habilidadDefensor, energiaJugador, energiaIA, auxiliarIAEnergia, bandera;
        int turno = valor.Next(1,3);
        int ronda = 1;
        // Guardo Valores anteriores de personajeIA para poder mostrarlos y saber mejor como atacar
        auxiliarIASalud = personajeIA.Salud;
        auxiliarIAEnergia = personajeIA.Energia;
        // Fin
        energiaJugador = jugador.Energia;
        energiaIA = personajeIA.Energia;
        saludJugador = jugador.Salud;
        saludIA = personajeIA.Salud;
        while ((saludJugador > 0) && (saludIA > 0) && (ronda < 21)) {
            bandera = 0;
            habilidadAtacante = 0;
            habilidadDefensor = 0;
            System.Console.WriteLine("                                ╔══════════════════════════════════════╗");
            System.Console.WriteLine("                                ║ "+ Interfaz.CentrarV2(" RONDA N"+(ronda+1)/2+" ",36) +" ║"); // 36 espacios
            System.Console.WriteLine("                                ╚══════════════════════════════════════╝");
            System.Console.WriteLine("");
            if (turno == 1) { // TURNO DEL JUGADOR
                turno = 2;
                //El jugador decide como atacar
                ResultadoCombate(jugador,personajeIA,auxiliarIAEnergia,auxiliarIASalud,danoAnterior,"TU TURNO:");
                System.Console.WriteLine("                                ╔═══════════════════════════════════════╗");
                System.Console.WriteLine("                                ╟──────┬────────────────────────┬───────╢");
                System.Console.WriteLine("                                ╟──────┤   ELIGE COMO ATACAR    ├───────╢");
                System.Console.WriteLine("                                ╟──────┴────────────────────────┴───────╢");
                System.Console.WriteLine("                                ╚═══════════════════════════════════════╝");
                decision = OpcionesAtaque(decision,energiaJugador);
                if (decision.KeyChar == ' ' && energiaJugador >= 7) {
                    habilidadAtacante = 2;
                    energiaJugador -= 7;
                } else {
                    if (decision.KeyChar == ' ' && energiaJugador <= 7) {
                        System.Console.WriteLine("");
                        Interfaz.EscribirMensaje("- No puedes utilizar tu habilidad especial para defenderte, no tienes suficiente energía -",3);
                        System.Console.WriteLine("");
                        Interfaz.EscribirMensaje("- Defenderás normal automaticamente -",5);
                        Thread.Sleep(1500);
                    }
                }
                //El enemigo que se defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                CombateAutomaticoDefender(personajeIA, saludIA, ref habilidadDefensor, ref energiaIA);
                danoAnterior = DanoDeCombate(jugador,personajeIA,habilidadAtacante,habilidadDefensor);
                saludIA = saludIA - danoAnterior;
                energiaJugador += 1;
                energiaIA += 1;
                Console.Clear();
                System.Console.WriteLine("");
                ResultadoCombate(jugador,personajeIA,energiaIA,saludIA,danoAnterior,"TU TURNO:");
                if (bandera == 1) {
                    auxiliarIAEnergia = energiaIA;
                }
                // VALORES ANTERIORES
                auxiliarIASalud = saludIA;
                auxiliarIAEnergia = energiaIA;
                Interfaz.Continuar();
            } else { // TURNO DE LA IA
                turno = 1;
                //El enemigo que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario o si esta llena
                CombateAutomaticoAtacar(personajeIA, jugador, saludIA, saludJugador, ref habilidadAtacante, ref energiaIA);
                //El jugador decide como defenderse
                ResultadoCombate(personajeIA,jugador,energiaJugador,saludJugador,danoAnterior,"TURNO DE:");
                System.Console.WriteLine("");
                System.Console.WriteLine("                                ╔═══════════════════════════════════════╗");
                System.Console.WriteLine("                                ╟──────┬────────────────────────┬───────╢");
                System.Console.WriteLine("                                ╟──────┤ ELIGE COMO DEFENDERTE  ├───────╢");
                System.Console.WriteLine("                                ╟──────┴────────────────────────┴───────╢");
                System.Console.WriteLine("                                ╚═══════════════════════════════════════╝");
                decision = OpcionesDefensa(decision,energiaJugador);
                if (decision.KeyChar == ' ' && energiaJugador >= 5) {
                    habilidadAtacante = 3;
                    energiaJugador -= 5;
                } else {
                    if (decision.KeyChar == ' ' && energiaJugador <= 5) {
                        System.Console.WriteLine("");
                        Interfaz.EscribirMensaje("- No puedes utilizar tu habilidad especial para defenderte, no tienes suficiente energía -",3);
                        System.Console.WriteLine("");
                        Interfaz.EscribirMensaje("- Defenderás normal automaticamente -",5);
                        Thread.Sleep(1500);
                    }
                }
                danoAnterior =  DanoDeCombate(personajeIA,jugador,habilidadAtacante,habilidadDefensor);
                saludJugador = saludJugador - danoAnterior;
                energiaJugador += 1;
                energiaIA += 1;
                Console.Clear();
                System.Console.WriteLine("");
                ResultadoCombate(personajeIA,jugador,energiaJugador,saludJugador,danoAnterior,"TURNO DE:");
                if (bandera == 1) {
                    auxiliarIAEnergia = energiaIA;
                }
                // VALORES ANTERIORES
                auxiliarIASalud = saludIA;
                auxiliarIAEnergia = energiaIA;
                Interfaz.Continuar();
            }
            Console.Clear();
            ronda++;
        }
        return QuienGano(jugador, personajeIA, ref saludJugador, ref saludIA);
    }

    private Personaje QuienGano(Personaje personaje1, Personaje personaje2, ref float salud1, ref float salud2)
    {
        if (salud1 > 0 && salud2 < 0)
        {
            System.Console.WriteLine("");
            GanadorPorKO(personaje1);
            Interfaz.Continuar();
            return personaje1;
        }
        else
        {
            if (salud2 > 0 && salud1 < 0)
            {
                System.Console.WriteLine("");
                GanadorPorKO(personaje2);
                Interfaz.Continuar();
                return personaje2;
            }
            else
            {
                salud1 = (salud1 / personaje1.Salud) * 100;
                salud2 = (salud2 / personaje2.Salud) * 100;
                if (salud1 > salud2)
                {
                    System.Console.WriteLine("");
                    GanadorPorVida(personaje1);
                    Interfaz.Continuar(); ;
                    return personaje1;
                }
                else
                {
                    System.Console.WriteLine("");
                    GanadorPorVida(personaje2);
                    Interfaz.Continuar();
                    return personaje2;
                }
            }
        }
    }

    private static void CombateAutomaticoAtacar(Personaje personaje1, Personaje personaje2, float salud1, float salud2, ref int habilidadAtacante, ref int energia1)
    {
        if (energia1 >= 5 && (salud1 > (personaje1.Salud / 2)))
        {
            habilidadAtacante = 2;
            energia1 -= 5;
        }
        else
        {
            if (energia1 >= 5 && (salud2 < (personaje2.Salud / 3)))
            {
                habilidadAtacante = 2;
                energia1 -= 5;
            }
            else
            {
                if (energia1 == 10)
                {
                    habilidadAtacante = 2;
                    energia1 -= 5;
                }
            }
        }
    }
    private static void CombateAutomaticoDefender(Personaje personaje1, float salud1, ref int habilidadDefensor, ref int energia1)
    {
        if (energia1 >= 5 && (salud1 < (personaje1.Salud / 3)))
        {
            habilidadDefensor = 3;
            energia1 -= 5;
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
    public List<Personaje> Ganadores(List<Personaje> Competidores,Personaje auxiliarIA,float danoAnterior,int modo){
        var resultados = new List<Personaje>();
        int batalla = 1;
        Personaje ganador;
        while(Competidores.Count()>0){
            Interfaz.EscribirMensaje("                     ╔═════════════════════════════════════════════════════════════╗",1);
            System.Console.WriteLine("                     ║ ░░░░░░░░░░░░░░░░░░░░░░ BATALLA N"+ batalla +" ░░░░░░░░░░░░░░░░░░░░░░░░░ ║");
            Interfaz.EscribirMensaje("                     ╚═════════════════════════════════════════════════════════════╝",1);
            System.Console.WriteLine("");
            System.Console.WriteLine("                     ┌─────────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("                     │   . "+ Interfaz.Centrar(Competidores[0].Nombre +", "+ Competidores[0].Apodo +"   vs.  "+ Competidores[1].Nombre +", "+ Competidores[1].Apodo,51) +" .   │");
            System.Console.WriteLine("                     └─────────────────────────────────────────────────────────────┘");
            if (modo == 1) {
                if(Competidores.Count()>1){
                    Interfaz.Continuar();
                    ganador = CombateIAvsIA(Competidores[0],Competidores[1]);
                    ganador.Nivel++; // Subo nivel
                    ganador = SubirNivel(ganador);
                    resultados.Add(ganador);
                    Competidores.Remove(Competidores[0]);
                    Competidores.Remove(Competidores[0]);
                } else {
                    resultados.Add(Competidores[0]);
                    Competidores.Remove(Competidores[0]);
                }
            } else {
                if (Competidores.Count() == 2) {
                    Interfaz.Continuar();
                    ganador = CombateIAvsJugador(Competidores[0],Competidores[1],auxiliarIA,danoAnterior);
                    ganador.Nivel++; // Subo nivel
                    ganador = SubirNivel(ganador);
                    resultados.Add(ganador);
                    Competidores.Remove(Competidores[0]);
                    Competidores.Remove(Competidores[0]);
                } else {
                    resultados.Add(Competidores[0]);
                    Competidores.Remove(Competidores[0]);
                }
            }
            batalla++;
        }
        Console.Clear();
        return resultados;
    }
    public void Fixture(List<Personaje> listaDePersonajes, int cant) {
        Interfaz.EscribirMensaje("                      ╔═══════════════════════════════════════════════════════════╗",3);
        for (int i = 0; i < cant; i++) {
            System.Console.WriteLine("                      ║ ░░░░░░░░░░░░░░░░░░░░░░░ COMBATE N"+ (i+1) +" ░░░░░░░░░░░░░░░░░░░░░░ ║");
            System.Console.WriteLine("                      ╟───────────────────────────────────────────────────────────╢");
            System.Console.WriteLine("                      ║"+ Interfaz.Centrar("--> "+ listaDePersonajes[i*2].Nombre +", "+ listaDePersonajes[i*2].Apodo +"   vs.   "+ listaDePersonajes[(i*2)+1].Nombre +", "+ listaDePersonajes[(i*2)+1].Apodo +" <--",59) +"║"); // 59 espacios totales
            if (i != cant - 1) {
                System.Console.WriteLine("                      ╠═══════════════════════════════════════════════════════════╣");
            }
        }
        Interfaz.EscribirMensaje("                      ╚═══════════════════════════════════════════════════════════╝",3);
    }
    public void GanadorPorVida(Personaje personaje) {
        System.Console.WriteLine("                            ╔═══════════════════════════════════════════════╗");
        System.Console.WriteLine("                            ║ "+ Interfaz.CentrarV2(" EL GANADOR ES: "+ personaje.Nombre +", "+ personaje.Apodo +" ",45) +" ║"); //44 espacios
        System.Console.WriteLine("                            ╟───────────────────────────────────────────────╢");
        System.Console.WriteLine("                            ║        Ganó por mayor cantidad de vida        ║");
        System.Console.WriteLine("                            ╚═══════════════════════════════════════════════╝");
    }
    public void GanadorPorKO(Personaje personaje) {
        System.Console.WriteLine("                            ╔═══════════════════════════════════════════════╗");
        System.Console.WriteLine("                            ║ "+ Interfaz.CentrarV2(" EL GANADOR ES: "+ personaje.Nombre +", "+ personaje.Apodo +" ",45) +" ║"); //44 espacios
        System.Console.WriteLine("                            ╟───────────────────────────────────────────────╢");
        System.Console.WriteLine("                            ║                 Ganó por K.O                  ║");
        System.Console.WriteLine("                            ╚═══════════════════════════════════════════════╝");
    }
    public void ResultadoCombate(Personaje personajeTurno, Personaje personajeGolpeado, int energiaGolpeado ,float saludGolpeado, float danoGolpeado, string texto) {
        if (danoGolpeado != 0) {
            System.Console.WriteLine("                             ╔═════════════════════════════════════════════╗");
            System.Console.WriteLine("                             ║ "+ Interfaz.CentrarV2(" "+ texto +" "+ personajeTurno.Nombre +", "+ personajeTurno.Apodo +" ",43) +" ║"); //43 espacios
            System.Console.WriteLine("                             ╟─────────┬────────────────────────┬──────────╢");
            System.Console.WriteLine("                             ╟─────────┤ RESULTADOS DEL COMBATE ├──────────╢");
            System.Console.WriteLine("                             ╟─────────┴────────────────────────┴──────────╢");
            System.Console.WriteLine("                             ║"+ Interfaz.Centrar("Personaje golpeado: "+ personajeGolpeado.Nombre +", "+ personajeGolpeado.Apodo,45) +"║"); //45 espacios
            System.Console.WriteLine("                             ║"+ Interfaz.Centrar("Daño ocasionado: "+ danoGolpeado.ToString(),45) +"║"); //45 espacios
            System.Console.WriteLine("                             ║"+ Interfaz.Centrar("Salud restante: "+ saludGolpeado.ToString(),45) +"║"); //45 espacios
            System.Console.WriteLine("                             ║"+ Interfaz.Centrar("Energia restante: "+ energiaGolpeado,45) +"║"); //45 espacios
            System.Console.WriteLine("                             ╚═════════════════════════════════════════════╝");
            System.Console.WriteLine("");
        } else {
            System.Console.WriteLine("                               ╔═════════════════════════════════════════╗");
            System.Console.WriteLine("                               ║ "+ Interfaz.CentrarV2(" "+ texto +" "+ personajeTurno.Nombre +", "+ personajeTurno.Apodo +" ",39) +" ║"); //39 espacios
            System.Console.WriteLine("                               ╟──┬───────────────────────────────────┬──╢");
            System.Console.WriteLine("                               ╟──┤ AUN NO SE REALIZÓ EL PRIMER GOLPE ├──╢");
            System.Console.WriteLine("                               ╟──┴───────────────────────────────────┴──╢");
            System.Console.WriteLine("                               ╚═════════════════════════════════════════╝");

        }
    }
    public ConsoleKeyInfo Opciones(ConsoleKeyInfo decision) {
        if (decision.KeyChar == '\r') {
            System.Console.WriteLine("                                ┌───────────────────────────────────────┐");
            System.Console.WriteLine("                                │      . Siguiente turno (Enter) .      │");
            System.Console.WriteLine("                                ├───────────────────────────────────────┤");
            System.Console.WriteLine("                                │      . Omitir batalla (Espacio) .     │");
            System.Console.WriteLine("                                └───────────────────────────────────────┘");
            decision = Console.ReadKey();
        }
        return decision;
    }
    public ConsoleKeyInfo OpcionesAtaque(ConsoleKeyInfo decision, int energia) {
        System.Console.WriteLine("");
        System.Console.WriteLine("                                ┌───────────────────────────────────────┐");
        System.Console.WriteLine("                                │       . Ataque normal (Enter) .       │");
        if (energia >= 7) {
            System.Console.WriteLine("                                ├───────────────────────────────────────┤");
            System.Console.WriteLine("                                │      . Ataque fuerte (Espacio) .      │");
            System.Console.WriteLine("                                └───────────────────────────────────────┘");
        } else {
            System.Console.WriteLine("                                └───────────────────────────────────────┘");
        }
        decision = Console.ReadKey();
        return decision;
    }
    public ConsoleKeyInfo OpcionesDefensa(ConsoleKeyInfo decision,int energia) {
        System.Console.WriteLine("");
        System.Console.WriteLine("                                ┌───────────────────────────────────────┐");
        System.Console.WriteLine("                                │      . Defensa normal (Enter) .       │");
        if (energia >= 5) {
            System.Console.WriteLine("                                ├───────────────────────────────────────┤");
            System.Console.WriteLine("                                │      . Defensa fuerte (Espacio) .     │");
            System.Console.WriteLine("                                └───────────────────────────────────────┘");
        } else {
        System.Console.WriteLine("                                └───────────────────────────────────────┘");
        }
        decision = Console.ReadKey();
        return decision;
    }
}