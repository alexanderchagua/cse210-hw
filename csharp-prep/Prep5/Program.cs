using System;

class Program
{
    static void Main(string[] args)
      {
        // Llame a cada función y guarde los valores de retorno según sea necesario
        DisplayWelcome();
        string nombre = PromptUserName();
        int numero = PromptUserNumber();
        int cuadrado = SquareNumber(numero);
        DisplayResult(nombre, cuadrado);

        Console.ReadKey();
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string nombre = Console.ReadLine();
        return nombre;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int numero = Convert.ToInt32(Console.ReadLine());
        return numero;
    }

    static int SquareNumber(int numero)
    {
        int cuadrado = numero * numero;
        return cuadrado;
    }

    static void DisplayResult(string nombre, int cuadrado)
    {
        Console.WriteLine(nombre + ", your favorite number squared is " + cuadrado + "!");
    }
}