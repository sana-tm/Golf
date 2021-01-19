using System;
using System.Collections.Generic;

namespace Golf
{   
    /* In this GOLF game the user controls the ball till it reaches the cup.
      The user inputs the angle and the velocity at which he hits the ball.
      It runs in a loop till the ball reaches the cup or if he has taken more than 10 swings or 
      if the ball went too far.
      Displays the progress after every hit.
      The cup distance from the initial piont is 550 meters and the Golf course radius is 550 meters.
      Swing calculations are Truncated to make it easier for the user.
     */
    class Program
    {
        static string name;
        static List<Swing> swingList = new List<Swing>();
        static void Main(string[] args)
        {
            double finalDestination = 550;
            double remainingDistance = finalDestination;
            double previousDistance = 0;
            int maxSwingsAllowed = 10;
            Console.WriteLine("Welcome to the Golf Game");
            Console.WriteLine("*****************************************************");
            Console.WriteLine($"Game rules\n Total course distance {finalDestination} " +
                $"\n {maxSwingsAllowed} number of swings allowed");
            Console.WriteLine("*****************************************************");
            Console.Write("Enter name for your Player: ");
            name = Console.ReadLine();            
            
            try
            {
                while (true)
                {
                    Console.WriteLine("*****************************************************");
                    Console.Write("Enter the angle for the ball swing between 1 to 90 degree : ");
                    double angle = Convert.ToDouble(Console.ReadLine());                    

                    Console.Write("Enter positive value for the Velocity : ");
                    double velocity = Convert.ToDouble(Console.ReadLine());

                    
                    if (velocity <= 0 || angle <= 0 || angle >= 90)
                    {
                        Console.WriteLine("Invalid Angle or Velocity. Try again");
                        continue;
                    }

                    Console.WriteLine("*****************************************************");
                    Swing swing = new Swing(angle, velocity);
                    swing.CalculateSwingDistance();
                    Console.WriteLine($"You have hit the ball {swing.SwingDistance} meters");                    

                    swing.CalculateCurrentDistance(previousDistance);
                    previousDistance = swing.CurrentDistance;
                    Console.WriteLine($"Your ball is at distance {previousDistance} meters from the initial point. ");

                    swing.CalculateRemainingDistance(remainingDistance);
                    remainingDistance = swing.RemainingDistance;
                    Console.WriteLine($"Your ball is {swing.RemainingDistance} meters away from the Cup");

                    swingList.Add(swing);

                    Console.WriteLine($"{name} has {maxSwingsAllowed - swingList.Count} swings left");
                    
                    if (swing.RemainingDistance == 0)
                    {
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("CONGRATULATIONS!!! \n Your Ball reached the Cup");
                        DisplaySummary();
                        break;
                    }                   

                    else if (swing.RemainingDistance > finalDestination)
                        throw new BallOutOfCourse();                    

                    else if (swingList.Count >= maxSwingsAllowed)
                        throw new TooManySwings();

                    else if (swing.RemainingDistance > 0)
                        continue;
                }
            }

            catch(BallOutOfCourse ex )
            {
                Console.WriteLine(ex.Message);
            }

            catch(TooManySwings ex)
            {
                Console.WriteLine(ex.Message);

            }            
            Console.ReadLine();
        }

        //Displays the position of your ball after every hit,distance covered, distance remaining to the cup
        //Also displays the number of swings you took to reach the cup.
        public static void DisplaySummary()
        {
            int count = 1;
            Console.WriteLine($"{name} took {swingList.Count} number of Swings");
            Console.WriteLine("--------------------------------------------------------");
            foreach (Swing hit in swingList)
            {
                Console.WriteLine($"Swing {count} summary");
                Console.WriteLine($"You have hit the ball {hit.SwingDistance} meters");
                Console.WriteLine($"Your current distance from initial location is {hit.CurrentDistance} meters");
                Console.WriteLine($"Your remaining distance from cup is {hit.RemainingDistance} meters");
                count++;
            }
        }
       
    }
}
