using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Swing
    {        
        public double RemainingDistance { get; set; }
        public double SwingDistance { get; set; }
        public double CurrentDistance { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }

        public Swing(double angle, double velocity)
        {
            this.Angle = angle;
            this.Velocity = velocity;
        }

        //Calculates the distance every time the player hits the ball. 
        public void CalculateSwingDistance()
        {
            double angleInRadians = (Math.PI / 180) * Angle;

            // Gravitational Acceleration Constant.
            double gravity = 9.8;
            double swngDist = Math.Pow(Velocity, 2) / (gravity * Math.Sin(2 * angleInRadians));
            SwingDistance = Math.Truncate(swngDist);
        }


        //Calculates the remaining distance between the ball and the cup.
        public void CalculateRemainingDistance(double remainingDistance)
        {
            RemainingDistance = remainingDistance - SwingDistance;
            if (RemainingDistance < 0)
                RemainingDistance = RemainingDistance * (-1);
            
        }


        //Calculates the current position of the ball every time it moves.
        public void CalculateCurrentDistance(double previousDistance)
        {
            CurrentDistance = previousDistance + SwingDistance;

        }

    }

}
