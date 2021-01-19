using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    // Throws an exception if the ball goes too far away.
    class BallOutOfCourse : Exception
    {
        public override string Message
        {
            get
            {
                return "You lost as your Ball is out of golf course";
            }
        }
    }


    // Throws an exception if the player takes too many swings.
    class TooManySwings : Exception
    {
        public override string Message
        {
            get
            {
                return "Sorry! You Lost the game. More than 10 swings not allowed";
            }
        }
    }
}
