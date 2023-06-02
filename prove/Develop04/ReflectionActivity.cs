class ReflectionActivity : Activity
{
    private List<string> prompts; // Lista de preguntas para la reflexión

    // Constructor
    public ReflectionActivity()
    {
        prompts = new List<string>();
        prompts.Add("Think of a time when you stood up for someone else.");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");

        // Establecer la duración de la actividad
        SetDuration();
    }

    // Método para realizar la actividad de reflexión
    public void PerformActivity()
    {
        // Mostrar mensaje de inicio de la actividad
        ShowStartingMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        // Realizar la actividad de reflexión
        int count = 0;
        Random random = new Random();
        while (count < duration)
        {
            string prompt = prompts[random.Next(prompts.Count)]; // Seleccionar una pregunta aleatoria
            Console.WriteLine(prompt);
            ShowPauseAnimation();

            List<string> questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                ShowPauseAnimation();
            }

            count++;
        }

        // Mostrar mensaje de fin de la actividad
        ShowEndingMessage("Reflection Activity");
    }
}
