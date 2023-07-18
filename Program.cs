using EspacioPersonaje;

Personaje personaje;
personaje = new FabricaDePersonajes().CrearPersonaje();
List<Personaje>? listaDePersonajes = new List<Personaje>();
List<Personaje>? listaDeGanadores = new List<Personaje>();
//List<Personaje>? listaDeFixture = new List<Personaje>();

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

// for (int i = 0;i < 8; i++) {
//     System.Console.WriteLine("--- OCTAVOS DE FINAL ---");
//     System.Console.WriteLine(listaDePersonajes[i*2].Nombre + ", " + listaDePersonajes[i*2].Apodo + " vs " +listaDePersonajes[(i*2)+1].Nombre + ", " + listaDePersonajes[(i*2)+1].Apodo);
//     ganador = mecanica.Combate(listaDePersonajes[i*2],listaDePersonajes[(i*2)+1]);
//     System.Console.WriteLine("El ganador es: "+ganador.Nombre+ ", "+ganador.Apodo);
//     ganador = mecanica.SubirNivel(ganador);
//     listaDeGanadores.Add(ganador);
// }
//listaDeFixture = listaDePersonajes;
System.Console.WriteLine("----- OCTAVOS DE FINAL -----");
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

listaDeGanadores[0].MostrarPersonaje(listaDeGanadores[0]);