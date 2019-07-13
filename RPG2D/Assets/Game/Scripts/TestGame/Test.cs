using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * This code automatically collects game data in an infinite loop.
 * It uses the standard input to place data into the game variables such as x and y.
 * YOU DO NOT NEED TO MODIFY THE INITIALIZATION OF THE GAME VARIABLES.
 **/

class Point
{
    public int x;
    public int y;
    public Point(int x_, int y_)
    {
        this.x = x_;
        this.x = y_;
    }
}
class Player
{
    static double Angle(Point p1, Point p2)
    {
        return Math.Atan2(p2.y - p1.y, p2.x - p1.x) * 180.0 / Math.PI;
    }
    static void Main(string[] args)
    {
        // double angleToBot = 0;
        // double distancetoBot = 0;
        // game loop
        while (true)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int x = int.Parse(inputs[0]); // x position of your pod
            int y = int.Parse(inputs[1]); // y position of your pod
            int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
            int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
            int nextCheckpointDist = int.Parse(inputs[4]);
            int nextCheckpointAngle = int.Parse(inputs[5]);
            string[] input2 = Console.ReadLine().Split(' ');
            int opponentX = int.Parse(input2[0]);
            int opponentY = int.Parse(input2[1]);

            Point opponentPoint = new Point(int.Parse(input2[0]), int.Parse(input2[1]));
            Point playerPoint = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
            Point nextCheckPoint = new Point(int.Parse(inputs[2]), int.Parse(inputs[3]));
            

            double thrust = 0;

            double angleToBot = Math.Atan2(opponentY - y, opponentX - x) * 180.0 / Math.PI;
            double distancetoBot = Math.Sqrt(Math.Pow((opponentX - x), 2) + Math.Pow((opponentY - y), 2));
            Console.Error.WriteLine(angleToBot + " " + distancetoBot);
            Console.Error.WriteLine(nextCheckpointDist);


            if(nextCheckpointAngle < 18 && nextCheckpointAngle > -18)
            {
                if(nextCheckpointDist > 600)
                {
                    Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + "BOOST");
                }
            }

            //1. estimate next point player will be
            //2. check distanceToBot and AngleToBot
            //3. 

            // if (distancetoBot < 400 && (angleToBot < 90 && angleToBot > -90))
            // {
            //     Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + distancetoBot / 600 * 100);
            // }
            // else if (nextCheckpointAngle < -90 || nextCheckpointAngle > 90)
            // {
            //     Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + thrust);
            // }
            // else
            // {
            //     if (nextCheckpointDist < 2000)
            //     {
            //         thrust = 4000 / nextCheckpointDist * 100;
            //         if (thrust > 100) thrust = 100;
            //         Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + thrust);
            //     }
            //     else
            //     {
            //         Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + "BOOST");
            //     }

            // }
        }
    }
}