class ListingActivity : Activity
{
    private List<string> prompts; // Lista de preguntas para la enumeración

    // Constructor
    public ListingActivity()
    {
        prompts = new List<string>();
        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");

        // Establecer la duración de la actividad
        SetDuration();
    }

    // Método para realizar la actividad de enumeración
    public void PerformActivity()
    {
        // Mostrar mensaje de inicio de la actividad
        ShowStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        // Realizar la actividad de enumeración
        int count = 0;
        Random random = new Random();
        while (count < duration)
        {
            string prompt = prompts[random.Next(prompts.Count)]; // Seleccionar un prompt aleatorio
            Console.WriteLine(prompt);
            Thread.Sleep(5000); // Pausa de 5 segundos para pensar

            Console.WriteLine("Keep listing items...");
            // Lógica para que el usuario ingrese los elementos de la lista (no implementada en este ejemplo)

            count++;
        }

        // Mostrar el número de elementos ingresados
        Console.WriteLine("You listed " + count + " items.");

        // Mostrar mensaje de fin de la actividad
        ShowEndingMessage("Listing Activity");
    }
}