namespace sem_1_pra_03_battles
{
    internal class Program
    {
        static (int fighterIndex, int SumPoints) FindFighterWithMaxSumPoints(int[][] battles)
        {
            int fighterIndex = -1;
            int MaxSumPoints = 0;
            for (int i = 0; i < battles.Length; i++)
            {
                int sumPointOfFighter = 0;
                for (int j = 0; j < battles[i].Length; j++)
                {
                    sumPointOfFighter += battles[i][j];
                }
                if (MaxSumPoints < sumPointOfFighter)
                {
                    MaxSumPoints = sumPointOfFighter;
                    fighterIndex = i;
                }
            }
            return (fighterIndex+1, MaxSumPoints);
        }
        static (int fighterIndex, double middlePoints) FindFighterWithMaxMiddlePoints(int[][] battles)
        {

            int fighterIndex = -1;
            double MaxMiddlePoints = 0;
            for (int i = 0; i < battles.Length; i++)
            {
                int sumPointOfFighter = 0;
                for (int j = 0; j < battles[i].Length; j++)
                {
                    sumPointOfFighter += battles[i][j];
                }
                double middlePointOfFighter = sumPointOfFighter / battles[i].Length;
                if (MaxMiddlePoints < middlePointOfFighter)
                {
                    MaxMiddlePoints = middlePointOfFighter;
                    fighterIndex = i;
                }
            }
            return (fighterIndex+1, MaxMiddlePoints);
        }
        static (int fighterIndex, int maxPoints) FindFighterWithMostResultFight(int[][] battles)
        {
            int fighterIndex = -1;
            int pointsInFight = 0;
            for (int i = 0; i < battles.Length; i++)
            {
                for (int j = 0; j < battles[i].Length; j++)
                {
                    if(pointsInFight < battles[i][j])
                    {
                        pointsInFight = battles[i][j];
                        fighterIndex = i;
                    }
                }
            }

            return (fighterIndex+1, pointsInFight);
        }
        static void Main(string[] args)
        {
            int[][] battles =
            {
                new[] { 15, 20, 10 },
                new[] { 30, 25 },
                new[] {40},
                new[] { 20, 20, 15, 10}
            };
            Console.WriteLine($"Боец с наибольшим средним результатом: {FindFighterWithMaxMiddlePoints(battles)}");
            Console.WriteLine($"Боец с наибольшей суммой очков: {FindFighterWithMaxSumPoints(battles)}");
            Console.WriteLine($"Боец с наибольшим единичным результатом: {FindFighterWithMostResultFight(battles)}");
        }
    }
}
