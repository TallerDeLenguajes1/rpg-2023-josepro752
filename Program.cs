using EspacioPersonaje;

Personaje personaje;
personaje = new FabricaDePersonajes().CrearPersonaje();
System.Console.WriteLine("Nombre del personaje: "+personaje.Nombre);
List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonajes();

PersonajesJson PersonajeJson = new PersonajesJson();
if (!(PersonajeJson.Existe("Personajes.json"))) {
    for (int i = 0; i < 15; i++) {
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