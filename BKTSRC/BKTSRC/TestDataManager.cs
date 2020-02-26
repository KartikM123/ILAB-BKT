using System;
namespace BKTSRC
{
    public class TestDataManager : IDataManager
    {
        /// <inheritdoc/>
        public override StudyData GetDataOccurences(string iskillname)
        {
            //data in format (column tried, answer recieved)
            int totalExercises = 100;
            float[,] sampleData = new float[totalExercises][totalExercises*2];
            sampleData = Util.init2D(totalExercises, totalExercises*2, 0);
            float[,] affState = new float[totalExercises][3];
            var rand = new Random();
            for (int i = 0; i < totalExercises * 2; i++)
            {
                if (i % 2 == 0)
                {
                    affState[i / 2][0] = rand.Next(1, 15);
                    affState[i / 2][1] = rand.Next(1, 15);
                    affState[i / 2][2] = rand.Next(1, 15);

                    int correct = rand.Next(0, 2);
                    sampleData[i/2][i] = correct / 2.f;
                }
            }

            StudyData studyData = new StudyData(totalExercises, totalExercises, sampleData, affState);
            return sampleData;
        }

        /// <inheritdoc/>
		public override StudyData GetData(string iskillName, ModelParam modelParam, int num_students = 50, int observations_per_student = 100)
		{
			return base.GetIdealModel(modelParam, num_students, observations_per_student);
		}
	}
}
