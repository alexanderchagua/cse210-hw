using System;
using System.Collections.Generic;
using System.Threading;

// Clase base para las actividades
class Activity
{
    protected int duration; // Duración de la actividad en segundos

    // Constructor
    public Activity()
    {
        duration = 0;
    }

    // Método para establecer la duración de la actividad
    protected void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
    }

    // Método para mostrar el mensaje de inicio de la actividad
    protected void ShowStartingMessage(string activityName, string description)
    {
        Console.WriteLine("Activity: " + activityName);
        Console.WriteLine(description);
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pausa de 3 segundos
    }

    // Método para mostrar el mensaje de fin de la actividad
    protected void ShowEndingMessage(string activityName)
    {
        Console.WriteLine("Good job! You have completed the " + activityName + ".");
        Thread.Sleep(3000); // Pausa de 3 segundos
        Console.WriteLine("You have completed the " + activityName + " for " + duration + " seconds.");
        Thread.Sleep(3000); // Pausa de 3 segundos
    }

    // Método para mostrar una animación de pausa
    protected void ShowPauseAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("/");
            Thread.Sleep(1000); // Pausa de 1 segundo
        }
        Console.WriteLine();
    }
}