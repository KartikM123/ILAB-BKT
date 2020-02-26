using System;
namespace BKTSRC
{
    public class DataManager : IDataManager
    {
        ///<inheritdoc/>
        public override StudyData GetDataOccurences(string iskillname)
        { 
            return new StudyData(0, 0,new float [1,1]{ { } }, new float[1, 3] { {1,2,3} });
        }

        /// <inheritdoc/>
		public override StudyData GetData(string iskillName, ModelParam modelParam, int num_students = 50, int observations_per_student = 100)
		{
            //TODO
            return new StudyData(0, 0, new float[1, 1] { { } }, new float[1, 3] { { 1, 2, 3 } });
        }

    }
}
