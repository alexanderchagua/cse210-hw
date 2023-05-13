using System;

class Program
{
    static void Main(string[] args)
  {
        // Defina una lista de números vacía
        List<int> numeros = new List<int>();

        // Pida al usuario una serie de números y agregue cada uno a la lista
        Console.WriteLine("Ingrese una serie de números. Ingrese 0 para terminar.");

        int numero = -1;
        while (numero != 0)
        {
            try
            {
                numero = Convert.ToInt32(Console.ReadLine());
                numeros.Add(numero);
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor ingrese un número válido.");
            }
        }

        // Calcule la suma de los números en la lista
        int suma = numeros.Sum();

        Console.WriteLine("La suma de los números en la lista es: " + suma);

        // Calcule el promedio de los números en la lista
        double promedio = numeros.Average();

        Console.WriteLine("El promedio de los números en la lista es: " + promedio);

        // Encuentre el número máximo o mayor en la lista
        int maximo = numeros.Max();

        Console.WriteLine("El número máximo en la lista es: " + maximo);

        Console.ReadKey();
    }}