namespace Initial_Activities
{
    public class StudentAverageCalculation
    {
        public void Calculation()
        {
            string[] nameGrade = { "1º", "2º", "3º", "4º" };
            double[] grade = new double[4];
            bool inputValid;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.WriteLine($"\nPlease, Enter your |{nameGrade[i]}| grade!!! (Between 0 and 100)");
                    inputValid = double.TryParse(Console.ReadLine(), out grade[i]);

                    if (inputValid && grade[i] >= 0 && grade[i] <= 100)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nERROR: Value must be an integer between 0 and 100. Please try again.");
                    }
                } while (true);
            }
            var average = grade.Average();

            if (average >= 70)
            {
                Console.WriteLine($"\nCongratulations! You are approved. Your average is {average}.");
            }
            else if (average < 70 & average >= 50)
            {
                Console.WriteLine($"\nBe careful! You are recovering. Your average is {average}.");
            }
            else
            {
                Console.WriteLine($"\nI'm sorry! You Failed. Your average is {average}.");
            }
        }
    }
}
