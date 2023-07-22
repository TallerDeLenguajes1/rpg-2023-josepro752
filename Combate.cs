using EspacioPersonaje;
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
        string? decision = "1";
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
        while ((salud1 > 0) && (salud2 > 0) && (ronda < 20)) {
            habilidadAtacante = 0;
            habilidadDefensor = 0;
            System.Console.WriteLine("--> TURNO N"+ronda);
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
                System.Console.WriteLine("--- Resultados del combate ---");
                System.Console.WriteLine("Personaje: "+ personaje2.Nombre + ", " + personaje2.Apodo);
                System.Console.WriteLine("Salud: "+ salud2);
                if (decision == "1") {
                    System.Console.WriteLine("Continuar al siguiente turno? Ingrese 1");
                    System.Console.WriteLine("Continuar a la siguiente batalla(omitir batalla)? Ingrese 0");
                    decision = System.Console.ReadLine();
                }
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
                System.Console.WriteLine("--- Resultados del combate ---");
                System.Console.WriteLine("Personaje: "+ personaje1.Nombre + ", " + personaje1.Apodo);
                System.Console.WriteLine("Salud: "+ salud1);
                System.Console.WriteLine("----------");
                if (decision == "1") {
                    System.Console.WriteLine("Continuar al siguiente turno? Ingrese 1");
                    System.Console.WriteLine("Continuar a la siguiente batalla(omitir batalla)? Ingrese 0");
                    decision = System.Console.ReadLine();
                }
            }
            ronda++;
        }
        if (salud1 > 0) {
            return personaje1;
        } else {
            if (salud2 > 0) {
                return personaje2;
            } else {
                salud1 = (salud1/personaje1.Salud)*100;
                salud2 = (salud2/personaje2.Salud)*100;
                if (salud1 > salud2) {
                    return personaje1;
                } else {
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
            System.Console.WriteLine("--- BATALLA NUMERO "+batalla);
            if(Competidores.Count()>1){
                System.Console.WriteLine(Competidores[0].Nombre + ", " + Competidores[0].Apodo + " vs " +Competidores[1].Nombre + ", " + Competidores[1].Apodo);
                ganador = Combate(Competidores[0],Competidores[1]);
                ganador = SubirNivel(ganador);
                resultados.Add(ganador);
                System.Console.WriteLine("*****EL GANADOR ES: "+ganador.Nombre+ ", "+ganador.Apodo+"*****");
                System.Console.WriteLine("");
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
    public void Competencia(List<Personaje> listaDePersonajes) {
        List<Personaje> listaDeGanadores = new List<Personaje>();
        MecanicaDeCombate mecanica = new MecanicaDeCombate();
        System.Console.WriteLine("----- OCTAVOS DE FINAL ---- -");
        listaDePersonajes = mecanica.Sorteo(listaDePersonajes); 
        listaDeGanadores = mecanica.Ganadores(listaDePersonajes);
        System.Console.WriteLine("----- CUARTOS DE FINAL -----");
        listaDeGanadores = mecanica.Sorteo(listaDeGanadores);
        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
        System.Console.WriteLine("----- SEMIFINALES -----");
        listaDeGanadores = mecanica.Sorteo(listaDeGanadores);
        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);
        System.Console.WriteLine("----- FINAL -----");
        listaDeGanadores = mecanica.Ganadores(listaDeGanadores);   
    }
}