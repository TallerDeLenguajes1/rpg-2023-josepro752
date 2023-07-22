using EspacioPersonaje;
using InterfazVisual;

Console.Clear();
Interfaz.Presentacion();

List<Personaje>? listaDePersonajes = new List<Personaje>();
//List<Personaje>? listaDeFixture = new List<Personaje>();
var personaje = new FabricaDePersonajes();


PersonajesJson PersonajeJson = new PersonajesJson();
var restablecer = PersonajeJson.LeerPersonaje("PersonajePrueba.json");

if(restablecer!=null){
    PersonajeJson.GuardarPersonaje(restablecer,"Personajes");
}

if (!(PersonajeJson.Existe("Personajes.json"))) {
    for (int i = 0; i < 16; i++) {
        listaDePersonajes.Add(personaje.CrearPersonaje());
    }
    PersonajeJson.GuardarPersonaje(listaDePersonajes, "Personajes");
} else {
    listaDePersonajes = PersonajeJson.LeerPersonaje("Personajes.json");
}

listaDePersonajes = PersonajeJson.LeerPersonaje("Personajes.json");
if (listaDePersonajes != null) {
    Interfaz.Menu(PersonajeJson, listaDePersonajes, personaje);
} else {
    System.Console.WriteLine("No hay personajes");
}

// if (listaDePersonajes != null) {
//     foreach (var persona in listaDePersonajes) {
//         persona.MostrarPersonaje();
//     }
// } else {
//     System.Console.WriteLine("No hay personajes");
// }
