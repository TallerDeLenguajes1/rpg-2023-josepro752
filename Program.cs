using EspacioPersonaje;
using InterfazVisual;

Console.Clear();
Interfaz.Presentacion();


List<Personaje>? Supervivencia = new List<Personaje>();
List<Personaje>? Niveles = new List<Personaje>();
List<Personaje>? Torneo = new List<Personaje>();
FabricaDePersonajes personaje = new FabricaDePersonajes();
PersonajesJson Json = new PersonajesJson();



var restablecer = Json.LeerPersonaje("PersonajeTorneoPrueba");
if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesTorneo");
}

if (!Json.Existe("PersonajesTorneo")) {
    Torneo = personaje.CrearParticipantes("PersonajesTorneo",16,-1);
}

restablecer = Json.LeerPersonaje("PersonajeNivelesPrueba");
if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesNiveles");
}

if (!Json.Existe("PersonajesNiveles")) {
    Niveles = personaje.CrearParticipantes("PersonajesNiveles",10,3);
}

restablecer = Json.LeerPersonaje("PersonajeSupervivenciaPrueba");
if (restablecer != null) {
    Json.GuardarPersonaje(restablecer,"PersonajesSupervivencia");
}

if (!Json.Existe("PersonajesSupervivencia")) {
    Supervivencia = personaje.CrearParticipantes("PersonajesSupervivencia",10,-1);
}

if (Json != null) {
    Interfaz.Menu(Json,personaje);
} else {
    System.Console.WriteLine("Hubo un problema con los archivos Json");
}

File.Delete("EdadAPI.json"); // Borra la API, para que si esta falla por problemas de cantidad limite de ingresos. Se puedan crear edades aleatorias y no repetidas