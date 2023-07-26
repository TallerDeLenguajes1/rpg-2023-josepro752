using EspacioPersonaje;
using InterfazVisual;

Console.Clear();
Interfaz.Presentacion();


List<Personaje>? listaDePersonajesSupervivencia = new List<Personaje>();
List<Personaje>? listaDePersonajesNiveles = new List<Personaje>();
List<Personaje>? listaDePersonajesTorneo = new List<Personaje>();
FabricaDePersonajes personaje = new FabricaDePersonajes();
PersonajesJson Json = new PersonajesJson();


var restablecer = Json.LeerPersonaje("PersonajePrueba");

if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesTorneo");
}

if (Json.Existe("PersonajesTorneo")) {
    listaDePersonajesTorneo = personaje.CrearParticipantes("PersonajesTorneo",16);
}

restablecer = Json.LeerPersonaje("PersonajeNivelesPrueba");
if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesNiveles");
}

if (Json.Existe("PersonajesNiveles")) {
    listaDePersonajesNiveles = personaje.CrearParticipantes("PersonajesNiveles",10);
}

restablecer = Json.LeerPersonaje("PersonajeSupervivenciaPrueba");
if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesSupervivencia");
}

if (Json.Existe("PersonajesSupervivencia")) {
    listaDePersonajesSupervivencia = personaje.CrearParticipantes("PersonajesSupervivencia",10);
}




if (Json != null) {
    Interfaz.Menu(Json,personaje);
} else {
    System.Console.WriteLine("Hubo un problema con los archivos Json");
}

File.Delete("EdadAPI.json"); // Borra la API, para que si esta falla por problemas de cantidad limite de ingresos. Se puedan crear edades aleatorias y no repetidas