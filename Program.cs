using EspacioPersonaje;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Personaje personaje;
personaje = new FabricaDePersonajes().CrearPersonaje();
System.Console.WriteLine("Nombre del personaje: "+personaje.Nombre);

var fp = new FabricaDePersonajes();

List<Personaje> listaDePersonajes = new List<Personaje>();
for (int i = 0; i < 10; i++) {
    listaDePersonajes.Add(fp.CrearPersonaje());
}
