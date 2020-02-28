using System;
namespace BKTSRC
{
    /// <summary>
	/// Works as a medium for retrieval of user data
	/// </summary>
    public class IDataManager
    {
        /// <summary>
		/// unique id of user
		/// </summary>
        protected string userID;

        /// <summary>
		/// Maximum possible random Value
		/// </summary>
        public const int RAND_MAX = 2147483647;


        /// <summary>
		/// Init data manager
		/// </summary>
		/// <param name="iuserID">user id</param>
        public IDataManager(string iuserID) 
        {
            this.userID = iuserID;
        }

        /// <summary>
		/// Get num_resources and num_parts recorded for a skill
		/// </summary>
		/// <param name="iskillName">Skill which we want to see tested</param>
		/// <param name="totalExercises">total exercises we want to observe (sample size)</param>
		/// <returns></returns>
        public virtual StudyData GetDataOccurences(string iskillName, int totalExercises = -1);


		/// <summary>
		/// Get Data from DB based on student preferences
		/// </summary>
		/// <param name="iskillName">name of skill being requested</param>
		/// <param name="modelParam">parameter models to use in EM</param>
		/// <param name="num_students">number of students being analyzed (optional)</param>
		/// <param name="observations_per_student">observations per student (optional)</param>
		/// <returns></returns>
		public virtual StudyData GetData(string iskillName, ModelParam modelParam, int num_students = 50, int observations_per_student = 100);
    }
}
