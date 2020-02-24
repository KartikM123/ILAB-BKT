using System;
namespace BKTSRC
{
    public class TestUtil
    {
        public TestUtil()
        {
        }
        public static float[][] TestData()
        {
            //data in format (column tried, answer recieved)
            int totalExercises = 100;
            float[,] sampleData = new float[totalExercises][totalExercises];
            var rand = new Random();

            for (int i = 0; i < totalExercises; i++)
            {
                int correct = rand.Next(0, 2);
                sampleData[i][i] = correct / 2.f;
            }
            return sampleData;
        }
    }
}
