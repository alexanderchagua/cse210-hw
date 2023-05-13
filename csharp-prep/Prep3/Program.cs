using System;

class Program
{
    static void Main(string[] args)
    {   
       Random ran = new Random();
       int number = ran.Next(1,101);
       int guess = -1;

       while(guess != number){
         Console.WriteLine("guees the number");
         guess = int.Parse(Console.ReadLine());
         if(guess>number){
            Console.WriteLine("IT IS LOWER");

         }else if(guess<number){
            Console.WriteLine("it is higther");
         }else{
            Console.WriteLine("that is the number");
         }


       }
        }
       }



    
    
