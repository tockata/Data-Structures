namespace _03_RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class RideTheHorse
    {
        private static int[,] matrix;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            matrix = new int[cols, rows];
            Point startPoint = new Point { X = startRow, Y = startCol, Value = 1 };
            BFS(startPoint);

            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[col, row] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BFS(Point point)
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point);

            while (queue.Count > 0)
            {
                Point currentPoint = queue.Dequeue();
                int currentCell = matrix[currentPoint.Y, currentPoint.X];

                if (currentCell == 0)
                {
                    matrix[currentPoint.Y, currentPoint.X] = currentPoint.Value;
                    TryDirection(queue, currentPoint, +1, -2);
                    TryDirection(queue, currentPoint, +2, -1);
                    TryDirection(queue, currentPoint, +2, +1);
                    TryDirection(queue, currentPoint, +1, +2);
                    TryDirection(queue, currentPoint, -1, +2);
                    TryDirection(queue, currentPoint, -2, +1);
                    TryDirection(queue, currentPoint, -2, -1);
                    TryDirection(queue, currentPoint, -1, -2);
                }
            }
        }

        private static void TryDirection(Queue<Point> queue, Point currentPoint, int deltaX, int deltaY)
        {
            int newX = currentPoint.X + deltaX;
            int newY = currentPoint.Y + deltaY;
            if (newX >= 0 && newX < matrix.GetLength(1) &&
                newY >= 0 && newY < matrix.GetLength(0) &&
                matrix[newY, newX] == 0)
            {
                var nextPoint = new Point { X = newX, Y = newY, Value = currentPoint.Value + 1 };
                queue.Enqueue(nextPoint);
            }
        }
    }
}