using EspacioPersonaje;
using InterfazVisual;

Console.Clear();
Interfaz.Presentacion();

List<Personaje>? listaDePersonajes = new List<Personaje>();
FabricaDePersonajes personaje = new FabricaDePersonajes();


PersonajesJson PersonajeJson = new PersonajesJson();
var restablecer = PersonajeJson.LeerPersonaje("PersonajePrueba.json");

if(restablecer!=null){
    PersonajeJson.GuardarPersonaje(restablecer,"Personajes");
}

listaDePersonajes = personaje.CrearParticipantes();

listaDePersonajes = PersonajeJson.LeerPersonaje("Personajes.json");
if (listaDePersonajes != null) {
    Interfaz.Menu(PersonajeJson, listaDePersonajes, personaje);
} else {
    System.Console.WriteLine("No hay personajes");
}

File.Delete("EdadAPI.json"); // Borra la API, para que si esta falla por problemas de cantidad limite de ingresos. Se puedan crear edades aleatorias