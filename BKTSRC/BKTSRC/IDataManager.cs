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




		}
    }
}
