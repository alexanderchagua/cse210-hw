class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity()
    {
        // Establecer la duración de la actividad
        SetDuration();
    }

    // Método para realizar la actividad de respiración
    public void PerformActivity()
    {
        // Mostrar mensaje de inicio de la actividad
        ShowStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        // Realizar la actividad de respiración
        int count = 0;
        while (count < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowPauseAnimation();

            Console.WriteLine("Breathe out...");
            ShowPauseAnimation();

            count++;
        }

        // Mostrar mensaje de fin de la actividad
        ShowEndingMessage("Breathing Activity");
    }
}
