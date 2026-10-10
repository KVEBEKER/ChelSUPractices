namespace sem_1_pra_03_dungeon
{
    internal class Program
    {
        static bool TryParseDungeon(string[] rawDungeonLines, out int[,] dungeon)
        {
            int MaxElementInLine = 0;
            for (int i = 0; i < rawDungeonLines.Length; i++)
            {
                int CountElementInLine = rawDungeonLines[i].Split(' ').Length;
                if (MaxElementInLine < CountElementInLine)
                {
                    MaxElementInLine = CountElementInLine;
                }
            }
            dungeon = new int[rawDungeonLines.Length, MaxElementInLine];
            for (int i = 0; i < rawDungeonLines.Length; i++)
            {
                string[] rawElements = rawDungeonLines[i].Split(' ');
                for (int y = 0; y < MaxElementInLine; y++)
                {
                    if (rawElements.Length - 1 < y)
                    {
                        dungeon[i, y] = 0;
                    }
                    else
                    {
                        if (!int.TryParse(rawElements[y], out dungeon[i, y]))
                        {
                            return false;
                        }

                    }
                }
            }
            return true;
        }

        static void WriteDungeon(int[,] dungeon)
        {
            for (int i = 0; i < dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < dungeon.GetLength(1); j++)
                {
                    Console.Write(dungeon[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int CountTreasuresInDungeon(int[,] dungeon)
        {
            int count = 0;
            //2 = treasure
            for (int i = 0; i < dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < dungeon.GetLength(1); j++)
                {
                    if (dungeon[i, j] == 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static int CountTrapsInDungeon(int[,] dungeon)
        {
            int count = 0;
            //-1 = traps
            for (int i = 0; i < dungeon.GetLength(0); i++)
            {
                for (int j = 0; j < dungeon.GetLength(1); j++)
                {
                    if (dungeon[i, j] == -1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static int FindMostTreasureLineInDungeon(int[,] dungeon)
        {
            int index = -1;
            int count = 0;
            //2 = treasure
            for (int i = 0; i < dungeon.GetLength(0); i++)
            {
                int lineCount = 0;
                for (int j = 0; j < dungeon.GetLength(1); j++)
                {
                    if (dungeon[i, j] == 2)
                    {
                        lineCount++;
                    }
                }
                if (lineCount > count)
                {
                    index = i + 1;
                    count = lineCount;
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            if (File.Exists("dungeon.kvdung"))
            {
                int[,] dungeon = new int[,] { };
                string[] rawDungeon = File.ReadAllLines("dungeon.kvdung");
                if (TryParseDungeon(rawDungeon, out dungeon))
                {
                    WriteDungeon(dungeon);
                    Console.WriteLine($"Количество сокровищ: {CountTreasuresInDungeon(dungeon)}");
                    Console.WriteLine($"Количество ловушек: {CountTrapsInDungeon(dungeon)}");
                    Console.WriteLine($"Строка с наибольшим количество сокровищ: {FindMostTreasureLineInDungeon(dungeon)}");
                }
                else
                {
                    Console.WriteLine("Ошибка перевода. Проверьте файл");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
    }
}
