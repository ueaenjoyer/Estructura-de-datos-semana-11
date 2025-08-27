using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // English to Spanish
        {"time", "tiempo"}, {"tiempo", "time"},
        {"person", "persona"}, {"persona", "person"},
        {"year", "año"}, {"año", "year"},
        {"way", "camino"}, {"camino", "way"},
        {"day", "día"}, {"día", "day"},
        {"thing", "cosa"}, {"cosa", "thing"},
        {"man", "hombre"}, {"hombre", "man"},
        {"world", "mundo"}, {"mundo", "world"},
        {"life", "vida"}, {"vida", "life"},
        {"hand", "mano"}, {"mano", "hand"},
        {"part", "parte"}, {"parte", "part"},
        {"child", "niño"}, {"niño", "child"}, {"niña", "child"},
        {"eye", "ojo"}, {"ojo", "eye"},
        {"woman", "mujer"}, {"mujer", "woman"},
        {"place", "lugar"}, {"lugar", "place"},
        {"work", "trabajo"}, {"trabajo", "work"},
        {"week", "semana"}, {"semana", "week"},
        {"case", "caso"}, {"caso", "case"},
        {"point", "punto"}, {"punto", "point"},
        {"government", "gobierno"}, {"gobierno", "government"},
        {"company", "empresa"}, {"empresa", "company"}, {"compañía", "company"}
    };
    
    static Dictionary<string, string> translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    
    static void Main(string[] args)
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("==================== MENÚ ====================\n");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir\n");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("\n¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    break;
            }
            
            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
    
    static void TraducirFrase()
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine();
        
        // Procesar cada palabra manteniendo la puntuación
        string[] palabras = frase.Split(' ');
        
        Console.Write("\nTraducción: ");
        foreach (string palabra in palabras)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                continue;
                
            // Extraer signos de puntuación al final de la palabra
            string palabraLimpia = palabra.TrimEnd(',', '.', '!', '?', ';', ':');
            string signosPuntuacion = palabra.Substring(palabraLimpia.Length);
            
            if (dictionary.TryGetValue(palabraLimpia, out string traduccion))
            {
                Console.Write(traduccion + signosPuntuacion + " ");
            }
            else
            {
                Console.Write(palabraLimpia + signosPuntuacion + " ");
            }
        }
        Console.WriteLine();
    }
    
    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en español: ");
        string espanol = Console.ReadLine().Trim();
        
        if (string.IsNullOrWhiteSpace(espanol))
        {
            Console.WriteLine("\nLa palabra no puede estar vacía.");
            return;
        }
        
        Console.Write("Ingrese la traducción al inglés: ");
        string ingles = Console.ReadLine().Trim();
        
        if (string.IsNullOrWhiteSpace(ingles))
        {
            Console.WriteLine("\nLa traducción no puede estar vacía.");
            return;
        }
        
        // Agregar en ambos sentidos
        if (!dictionary.ContainsKey(espanol))
        {
            dictionary[espanol] = ingles;
            dictionary[ingles] = espanol;
            Console.WriteLine($"\nPalabras agregadas al diccionario: '{espanol}' <-> '{ingles}'");
        }
        else
        {
            Console.WriteLine($"\nLa palabra '{espanol}' ya existe en el diccionario.");
        }
    }
}