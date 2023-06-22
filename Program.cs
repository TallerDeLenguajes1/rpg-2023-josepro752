using EspacioPersonaje;

Personaje personaje;
personaje = new FabricaDePersonajes().CrearPersonaje();
System.Console.WriteLine("Nombre del personaje: "+personaje.Nombre);
List<Personaje>? listaDePersonajes = new List<Personaje>();
float salud1, salud2;
int ronda = 1;

var fp = new FabricaDePersonajes();

PersonajesJson PersonajeJson = new PersonajesJson();
if (!(PersonajeJson.Existe("Personajes.json"))) {
    for (int i = 0; i < 16; i++) {
        listaDePersonajes.Add(fp.CrearPersonaje());
    }
    PersonajeJson.GuardarPersonaje(listaDePersonajes, "Personajes");
} else {
    listaDePersonajes = PersonajeJson.LeerPersonaje("Personajes.json");
}

if (listaDePersonajes != null) {
    foreach (var persona in listaDePersonajes) {
        persona.MostrarPersonaje(persona);
    }
}

MecanicaDeCombate mecanica = new MecanicaDeCombate();

for (int i = 0;i < 8; i++) {
    System.Console.WriteLine("--- Octavos de Final ---");
    System.Console.WriteLine(listaDePersonajes[i*2].Nombre + ", " + listaDePersonajes[i*2].Apodo + " vs " +listaDePersonajes[(i*2)+1].Nombre + ", " + listaDePersonajes[(i*2)+1].Apodo);
    salud1 = listaDePersonajes[i*2].Salud;
    salud2 = listaDePersonajes[(i*2)+1].Salud;
    while ((salud1 > 0) && (salud2 > 0)) {
        System.Console.WriteLine("--> RONDA N"+ronda);
        salud1 = salud1 - mecanica.Combate(listaDePersonajes[i*2],listaDePersonajes[(i*2)+1]);
        salud2 = salud2 - mecanica.Combate(listaDePersonajes[(i*2)+1],listaDePersonajes[i*2]);
        System.Console.WriteLine("--- Resultados del combate ---");
        System.Console.WriteLine("Personaje: "+ listaDePersonajes[i*2].Nombre + ", " + listaDePersonajes[i*2].Apodo);
        System.Console.WriteLine("Salud: "+ salud1);
        System.Console.WriteLine("--- Resultados del combate ---");
        System.Console.WriteLine("Personaje: "+ listaDePersonajes[(i*2)+1].Nombre + ", " + listaDePersonajes[(i*2)+1].Apodo);
        System.Console.WriteLine("Salud: "+ salud2);
        ronda++;
    }
    if (salud1 > 0) {
        System.Console.WriteLine("El ganador es: "+ listaDePersonajes[i*2].Nombre + ", " + listaDePersonajes[i*2].Apodo);
    } else {
        System.Console.WriteLine("El ganador es: "+ listaDePersonajes[(i*2)+1].Nombre + ", " + listaDePersonajes[(i*2)+1].Apodo);
    }
    ronda = 1;
}
