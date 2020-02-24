using System;
namespace BKTSRC
{
    public class TestUtil
    {
        public TestUtil()
        {
        }
        public static StudyData TestData()
        {
            //data in format (column tried, answer recieved)
            int totalExercises = 100;
            float[,] sampleData = new float[totalExercises][totalExercises];
            sampleData = Util.init2D(totalExercises * 2, totalExercises, 0);
            var rand = new Random();

            for (int i = 0; i < totalExercises*2; i++)
            {
                if (i % 2 == 0)
                {
                    int correct = rand.Next(0, 2);
                    sampleData[i][i] = correct / 2.f;
                }
            }

            StudyData studyData = new StudyData(totalExercises,100, sampleData);
            return sampleData;
        }
    }
}
