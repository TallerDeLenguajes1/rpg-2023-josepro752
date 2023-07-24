using EspacioPersonaje;
using InterfazVisual;
namespace EspacioCombate;

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
        ConsoleKeyInfo decision;
        decision = new ConsoleKeyInfo('\r',ConsoleKey.Enter,false,false,false);
        float salud1, salud2;
        int turno = valor.Next(1,3);
        int ronda = 1;
        int habilidadAtacante;
        int habilidadDefensor;
        int energia1, energia2;
        salud1 = personaje1.Salud;
        salud2 = personaje2.Salud;
        energia1 = personaje1.Energia;
        energia2 = personaje2.Energia;
        while ((salud1 > 0) && (salud2 > 0) && (ronda < 21) && (decision.KeyChar == '\r')) {
            habilidadAtacante = 0;
            habilidadDefensor = 0;
            System.Console.WriteLine("        ╔═══════════════════════════════════════╗");
            System.Console.WriteLine("        ║ "+ Interfaz.CentrarV2(" RONDA N"+ronda/2+" ",37) +" ║"); // 37 espacios
            System.Console.WriteLine("        ╚═══════════════════════════════════════╝");
            System.Console.WriteLine("");
            if (turno == 1) {
                turno = 2;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario
                if (personaje1.Energia == 5 && (salud1 > (personaje1.Salud/2))) {
                    habilidadAtacante = 5;
                    energia1 = 0;
                } else {
                    if (personaje1.Energia == 5 && (salud2 < (personaje2.Salud/3))) {
                        habilidadAtacante = 5;
                        energia1 = 0;
                    }
                }
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                if (personaje2.Energia == 3 && (salud2 < (personaje2.Salud/3))) {
                    habilidadDefensor = 3;
                    energia2 -= 3;
                }
                salud2 = salud2 - DanoDeCombate(personaje1,personaje2,habilidadAtacante,habilidadDefensor);
                energia2 += 1;
                ResultadoCombate(personaje2, salud2);
                decision = Opciones(decision);
            } else {
                turno = 1;
                //El personaje que ataca utilizara su habilidad especial, si tiene una clara ventaja sobre su adversario
                if (personaje2.Energia == 5 && (salud2 > (personaje2.Salud/2))) {
                    habilidadAtacante = 7;
                    energia2 = 0;
                } else {
                    if (personaje2.Energia == 5 && (salud1 < (personaje1.Salud/3))) {
                        habilidadAtacante = 7;
                        energia2 = 0;
                    }
                }
                //El personaje que defiende utilizara su habilidad especial para defenderse si esta cerca de morir 
                if (personaje1.Energia == 3 && (salud1 < (personaje1.Salud/3))) {
                    habilidadDefensor = 3;
                    energia1 -= 3;
                }
                salud1 = salud1 - DanoDeCombate(personaje1,personaje2,habilidadAtacante,habilidadDefensor);
                energia1 += 1;
                ResultadoCombate(personaje1, salud1);
                decision = Opciones(decision);
            }
            Console.Clear();
            ronda++;
        }
        if (salud1 > 0 && salud2 < 0) {
                System.Console.WriteLine("");
                GanadorPorKO(personaje1);
                Interfaz.Continuar();
            return personaje1;
        } else {
            if (salud2 > 0 && salud1 < 0) {
                System.Console.WriteLine("");
                GanadorPorKO(personaje1);
                Interfaz.Continuar();
                return personaje2;
            } else {
                salud1 = (salud1/personaje1.Salud)*100;
                salud2 = (salud2/personaje2.Salud)*100;
                if (salud1 > salud2) {
                    System.Console.WriteLine("");
                    GanadorPorVida(personaje2);
                    Interfaz.Continuar();;
                    return personaje1;
                } else {
                    System.Console.WriteLine("");
                    GanadorPorVida(personaje2);
                    Interfaz.Continuar();
                    return personaje2;
                }
            }
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
            System.Console.WriteLine("        ╔═════════════════════════════════════════════════════════╗");
            System.Console.WriteLine("        ║ ░░░░░░░░░░░░░░░░░░░░ BATALLA N"+ batalla +" ░░░░░░░░░░░░░░░░░░░░░░░ ║");
            System.Console.WriteLine("        ╚═════════════════════════════════════════════════════════╝");
            System.Console.WriteLine("");
            System.Console.WriteLine("        ┌─────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("        │   . "+ Interfaz.Centrar(Competidores[0].Nombre +", "+ Competidores[0].Apodo +"   vs.  "+Competidores[1].Nombre +", "+ Competidores[1].Apodo,47) +" .   │");
            System.Console.WriteLine("        └─────────────────────────────────────────────────────────┘");
            if(Competidores.Count()>1){
                Interfaz.Continuar();
                ganador = Combate(Competidores[0],Competidores[1]);
                ganador = SubirNivel(ganador);
                resultados.Add(ganador);
                Competidores.Remove(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            } else {
                resultados.Add(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }
            batalla++;
        }
        Console.Clear();
        return resultados;
    }
    public void Fixture(List<Personaje> listaDePersonajes, int cant) {
          Interfaz.EscribirMensajeV2(" ╔═══════════════════════════════════════════════════════════╗");
        for (int i = 0; i < cant; i++) {
            System.Console.WriteLine(" ║ ░░░░░░░░░░░░░░░░░░░░░░░ COMBATE N"+ (i+1) +" ░░░░░░░░░░░░░░░░░░░░░░ ║");
            System.Console.WriteLine(" ╟───────────────────────────────────────────────────────────╢");
            System.Console.WriteLine(" ║"+ Interfaz.Centrar("--> "+ listaDePersonajes[i*2].Nombre +", "+ listaDePersonajes[i*2].Apodo +"   vs.   "+ listaDePersonajes[(i*2)+1].Nombre +", "+ listaDePersonajes[(i*2)+1].Apodo +" <--",59) +"║"); // 59 espacios totales
            if (i != cant - 1) {
            System.Console.WriteLine(" ╠═══════════════════════════════════════════════════════════╣");
            }
        }
            Interfaz.EscribirMensajeV2(" ╚═══════════════════════════════════════════════════════════╝");
    }
    public void GanadorPorVida(Personaje personaje) {
        System.Console.WriteLine("            ╔═══════════════════════════════════════════════╗");
        System.Console.WriteLine("            ║ "+ Interfaz.CentrarV2(" EL GANADOR ES: "+ personaje.Nombre +", "+ personaje.Apodo +" ",45) +" ║"); //44 espacios
        System.Console.WriteLine("            ╟───────────────────────────────────────────────╢");
        System.Console.WriteLine("            ║        Ganó por mayor cantidad de vida        ║");
        System.Console.WriteLine("            ╚═══════════════════════════════════════════════╝");
    }
    public void GanadorPorKO(Personaje personaje) {
        System.Console.WriteLine("            ╔═══════════════════════════════════════════════╗");
        System.Console.WriteLine("            ║ "+ Interfaz.CentrarV2(" EL GANADOR ES: "+ personaje.Nombre +", "+ personaje.Apodo +" ",45) +" ║"); //44 espacios
        System.Console.WriteLine("            ╟───────────────────────────────────────────────╢");
        System.Console.WriteLine("            ║                 Ganó por K.O                  ║");
        System.Console.WriteLine("            ╚═══════════════════════════════════════════════╝");
    }
    public void ResultadoCombate(Personaje personaje, float salud) {
        System.Console.WriteLine("        ╔═══════════════════════════════════════╗");
        System.Console.WriteLine("        ║"+ Interfaz.Centrar("Personaje: "+ personaje.Nombre +", "+ personaje.Apodo,38) +" ║"); //38 espacios
        System.Console.WriteLine("        ║"+ Interfaz.Centrar("Salud restante: "+ salud.ToString(),38) +" ║"); //38 espacios
        System.Console.WriteLine("        ╚═══════════════════════════════════════╝");
    }
    public ConsoleKeyInfo Opciones(ConsoleKeyInfo decision) {
        if (decision.KeyChar == '\r') {
            System.Console.WriteLine("");
            System.Console.WriteLine("        ┌────────────────────────────────────────┐");
            System.Console.WriteLine("        │      . Siguiente turno (Enter) .       │");
            System.Console.WriteLine("        ├────────────────────────────────────────┤");
            System.Console.WriteLine("        │      . Omitir batalla (Espacio) .      │");
            System.Console.WriteLine("        └────────────────────────────────────────┘");
            decision = Console.ReadKey();
        }
        return decision;
    }
}