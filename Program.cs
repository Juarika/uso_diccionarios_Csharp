// Ejercicio: Sistema de registro de Usuarios

// Crea un programa en C# que permita registrar información de usuarios de una página de hobbies. El programa debe utilizar un diccionario donde la clave sea el número de identificación del usuario (que debe ser único) y el valor sea un objeto que contenga el nombre del usuario, su edad y una lista de hobbies a los que está inscrito.

// El programa debe proporcionar un menú con las siguientes opciones:

// 1. Agregar usuario: Permite agregar un nuevo usuario al diccionario, ingresando su número de identificación, nombre, edad y los hobbies de preferencia.
// 2. Mostrar usuario: Muestra la información de un usuario específico, ingresando su número de identificación.
// 3. Mostrar todos los usuarios: Muestra la información de todos los usuarios registrados en el diccionario.
// 4. Eliminar usuario: Permite eliminar un usuario del diccionario, ingresando su número de identificación.
// 5. Salir: Termina el programa.


// Declaración e inicialización de un diccionario:
using System;
using System.Collections.Generic;

class Program {
    static readonly Dictionary<long, Usuario> usuarios = new();
    static void Main() {
        int opcion;

        do {
            MostrarMenu();
            opcion = PedirOpcion();

            switch (opcion) {
                case 1:
                    Agregar();
                    break;
                case 2:
                    Buscar();
                    break;
                case 3:
                    ImprimirLista();
                    break;
                case 4:
                    Eliminar();
                    break;
                case 5:
                    Console.WriteLine("Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 5);
    }

    static void MostrarMenu() {
        Reset();
        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Agregar usuario");
        Console.WriteLine("2. Mostrar usuario");
        Console.WriteLine("3. Mostrar todos los usuarios");
        Console.WriteLine("4. Eliminar usuario");
        Console.WriteLine("5. Salir");
    }

    static int PedirOpcion() {
        Console.Write("Elige una opción: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void Agregar()
    // 1. Agregar usuario: Permite agregar un nuevo usuario al diccionario, ingresando su número de identificación, nombre, edad y los hobbies de preferencia.
    {
        Console.Write("Ingresa el nombre: ");
        string ? nombre = Console.ReadLine();

        Console.Write("Ingresa el numero de identificacion: ");
        if (long.TryParse(Console.ReadLine(), out long identificacion))
        {
            Console.Write("Ingresa la edad: ");
            string ? edad = Console.ReadLine();

            List<string> hobbies = new();
            bool seguir = true;
            while (seguir) 
            {
                Console.Write("¿Desea agregar algun hobbie? S/N ");
                string input = Console.ReadLine().ToLower();

                if (input == "n")
                {
                    seguir = false;
                }
                else if (input == "s")
                {
                    Console.WriteLine("Ingrese el hobbie:");
                    hobbies.Add(Console.ReadLine());
                }
                else if (input != "s" || input != "n")
                {
                    Console.WriteLine("Entrada inválida. Debes ingresar 's' o 'n'.");
                }
            }
            var usuario = new Usuario(Nombre: nombre, Edad: edad, Hobbies: hobbies);
            usuarios.Add(key: identificacion, value: usuario);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Usuario agregado con éxito!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Número inválido. Debes ingresar un valor numérico.");
        }
    }

    static void Eliminar()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;        
        Console.WriteLine("Ingrese la identificacion");
        Console.ResetColor();      
        if (long.TryParse(Console.ReadLine(), out long eliminar))
        {
            if (usuarios.ContainsKey(eliminar))
            {   
                usuarios.Remove(eliminar);
                Console.ForegroundColor = ConsoleColor.Red;  
                Console.WriteLine("¡Usuario eliminado con éxito!");
                Console.ResetColor();      
            }
            else 
            {
                Console.WriteLine("El usuario no esta en nuestra base de datos");
            }
        }
        else
        {
            Console.WriteLine("Documento inválido. Debes ingresar un valor adecuado.");
        }
    }

    static void ImprimirLista() {
        Console.ForegroundColor = ConsoleColor.DarkBlue;        
        Console.WriteLine($"Id\tEdad\tNombre\tHobbies");
        foreach (var usuario in usuarios)
        {
            var hobbiesList = string.Join(" - ", usuario.Value.Hobbies);
            Console.ResetColor();
            Console.WriteLine($"{usuario.Key}\t{usuario.Value.Edad}\t{usuario.Value.Nombre}\t{hobbiesList}");
        }
        Thread.Sleep(3000);
    }
    static void Reset() {
        Thread.Sleep(2000);
        Console.Clear();    
    }

    static void Buscar() {
        Console.ForegroundColor = ConsoleColor.DarkBlue;        
        Console.WriteLine("Ingrese la identificacion");
        if (long.TryParse(Console.ReadLine(), out long buscar))
        {
            if (usuarios.ContainsKey(buscar))
            {   
                var usuario = usuarios[buscar];
                Console.WriteLine($"Edad\tNombre\tHobbies");
                var hobbiesList = string.Join(" - ", usuario.Hobbies);
                Console.ResetColor();
                Console.WriteLine($"{usuario.Edad}\t{usuario.Nombre}\t{hobbiesList}");
            }
            else 
            {
                Console.WriteLine("El usuario no esta en nuestra base de datos");
            }
        }
        else
        {
            Console.WriteLine("Documento inválido. Debes ingresar un valor adecuado.");
        }
    }
}
