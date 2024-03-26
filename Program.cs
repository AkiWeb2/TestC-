using System;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число 5 что бы произвести проверку программы");
            TestGetRollResult();
            TestCalculateScore();
            
            Console.WriteLine("Добро пожаловать в игру в боулинг!");
            
            int[] rolls = new int[21];
            int currentRoll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                Console.WriteLine($"Фрейм {frame + 1}");

                Console.Write("Введите количество сбитых кеглей первым броском: ");
                int roll1 = GetRollResult(null);

                if (roll1 == 10) 
                {
                    rolls[currentRoll++] = roll1;
                    Console.WriteLine("Strike!");
                }
                else
                {
                    rolls[currentRoll++] = roll1;

                    Console.Write("Введите количество сбитых кеглей вторым броском: ");
                    int roll2 = GetRollResult(null);

                    int frameScore = roll1 + roll2;
                    rolls[currentRoll++] = roll2;

                    if (frameScore == 10) 
                    {
                        Console.WriteLine("Spare!");
                    }
                    else
                    {
                        Console.WriteLine("Open frame.");
                    }
                }
            }

            int score = CalculateScore(rolls);
            Console.WriteLine($"Ваш общий счет: {score}.");
            Console.WriteLine("Игра окончена. Спасибо за игру!");
            Console.ReadLine();
        }
        static void TestGetRollResult()
        {
            string testInput = "5";
            int expectedRoll = 5;


            int actualRoll = GetRollResult(testInput);

            if (actualRoll == expectedRoll)
            {
                Console.WriteLine("Тест GetRollResult() пройден успешно.");
            }
            else { Console.WriteLine("Тест GetRollResult() провален. Ожидалось значение: " + expectedRoll + ", Актуальное значение: " + actualRoll); }
        }
        static int GetRollResult(string test)
        {
            int roll;   
            bool isValidInput = false;
            int testRoll;

            do
            {
                
                string input = Console.ReadLine();
                if (int.TryParse(test, out testRoll) && testRoll >= 0 && testRoll <= 10)
                {
                    isValidInput = true;
                }
             

                if (int.TryParse(input, out roll) && roll >= 0 && roll <= 10)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 0 до 10.");
                }
            } while (!isValidInput);

            return roll;
        }

        static int CalculateScore(int[] rolls)
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[rollIndex] == 10) 
                {
                    score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                    rollIndex++;
                }
                else if (rolls[rollIndex] + rolls[rollIndex + 1] == 10) 
                {
                    score += 10 + rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else 
                {
                    score += rolls[rollIndex] + rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }

            return score;
        }

        static void TestCalculateScore()
        {
            int[] rolls = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            int expectedScore = 133;

            int actualScore = CalculateScore(rolls);

            if (actualScore == expectedScore)
            {
                Console.WriteLine("Тест CalculateScore() пройден успешно.");
            }
            else
            {
                Console.WriteLine("Тест CalculateScore() провален. Ожидалось значение: " + expectedScore + ", Актуальное значение: " + actualScore);
            }
        }
       
    }
}