using System;
namespace BKTSRC
{
    public class IDataManager
    {
        /// <summary>
		/// unique id of user
		/// </summary>
        string userID;

        /// <summary>
		/// Init data manager
		/// </summary>
		/// <param name="iuserID">user id</param>
        public IDataManager(string iuserID) 
        {
            this.userID = iuserID;
        }

        /// <summary>
		/// Get specific data based on skillname
		/// </summary>
		/// <param name="iskillName">Skill which we want to see tested</param>
		/// <returns></returns>
        public virtual StudyData GetData(string iskillName);


        /// <summary>
		/// Creates ideal observation sequence based on various params
		/// </summary>
		/// <param name="modelParam">Params desired</param>
		/// <param name="starts">starting step</param>
		/// <param name="observation_sequences">different observation steps</param>
		/// <param name="resources">resources accessed</param>
		/// <param name="bigT">no clue tbh</param>
		/// <returns></returns>
        protected StudyData CreateIdealModel(
            ModelParam modelParam,
            float[] starts,
            float [] observation_sequences,
            int[] resources,
            int bigT)
		{
            int[][] all_stateseqs = new int[1, bigT];
            int[][] all_data = new int[modelParam.num_subparts, bigT];
            int num_sequences = starts.Length;
            all_data[0][0] = 0;

            for(int sequence_index = 0; sequence_index < num_sequences; sequence_index++)
			{

			}
		}

        /// <summary>
		/// Return a interaction history which should yield specific BKT params
		/// </summary>
		/// <param name="modelParam">Params of model we ideally want to reach</param>
		/// <returns>Study data containing sequence which should yield params</returns>
        public StudyData GetIdealModel(ModelParam modelParam)
		{
            int num_resources = modelParam.num_resources;

            //total size of observation
            float[] observation_sequences = Util.init1D(50.f, 100.f);
            int bigT = Util.sumArray(observation_sequences);

            int[] resources = Util.initRandom1D(1, num_resources + 1, bigT);

            //calculate interaction difference
            float[] starts = Util.cumSum1D(observation_sequences);
            for(int i = 0; i< starts.Length; i++)
			{
                stars[i] = starts[i] - observation_sequences[i];
			}


		}
    }
}
