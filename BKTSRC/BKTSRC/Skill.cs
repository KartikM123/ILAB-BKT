using System;
using System.Collections;
namespace BKTSRC
{
    //Main source: https://github.com/CAHLR/pyBKT
    /// <summary>
	/// Calculates specific skill knowledge level
	/// </summary>
    public class Skill
    {

        //standard characteristics
        public string name;
        public string userID;
        public float pLo; //probability initally known

        /// <summary>
		/// Minimum possible value a float can be
		/// </summary>
        public const float MinValue = -3.402823E+38;

        /// <summary>
		/// Model parameters which can be used to find ideal fit
		/// </summary>
        protected ModelParam modelParameters;

        /// <summary>
		/// Manages Data Retrieval
		/// </summary>
        protected IDataManager dataManager;

        /// <summary>
		/// Data summarizing study info
		/// </summary>
        protected StudyData studyData;

        /// <summary>
		/// Init skill based on userid
		/// </summary>
		/// <param name="iName">name of skill</param>
		/// <param name="iUserID">userID of student being examined</param>
		/// <param name="pLo">intial knowledge of skill by student</param>
        public Skill(string iName, string iUserID, float pLo = 0.f)
        {
            this.name = iName;
            this.userID = iUserID;
            this.pLo = pLo;
            this.dataManager = new DataManager(this.userID);
            this.modelParameters = null;

            //Get Model
            this.studyData = dataManager.GetDataOccurences();

            //Calculate member variables
            this.modelParameters = new ModelParam(studyData.num_resources, studyData.num_subparts, this.pLo);
        }

        /// <summary>
		/// Initializer for manual datamanager implementation (test)
		/// </summary>
		/// <param name="iName">name of skill</param>
		/// <param name="pLo">initial knowledge level</param>
		/// <param name="idataManager"> use to query student data</param>
		/// <param name="imodelParam"> manual model Parameters</param>
        public Skill(string iName, float pLo, IDataManager idataManager, ModelParam imodelParam)
		{
            this.name = name;
            this.userID = "test";
            this.dataManager = idataManager;
            this.pLo = pLo;
            this.modelParameters = imodelParam;
		}

        /// <summary>
		/// Get most up to date knowledge probability
		/// </summary>
        public void getKnowledgeState()
        {
            return modelParameters.pKnown;
        }

        //D: Update knowledge state using BKT based on history of data. Input number of fits of model (should tune)
        //R: updated knowledge variables
        public void updateKnowledge(int number_of_fits = 5, int num_of_students = 1, int observations_per_student = 100)
        {
            //Get more comprehensive datastructure
            this.studyData = dataManager.GetData(this.name, this.modelParameters, num_of_students, observations_per_student);

            float bestlikelihood = MinValue;
            for (int i = 0; i < number_of_fits; i++)
			{
                RandomModelGenerator randomModel = new RandomModelGenerator(studyData.num_resources, studyData.num_subparts);
                //TODO EMFit
                Tuple<RandomModelGenerator, float> fitInfo = EMFit.fit(this.studyData, randomModel);
                RandomModelGenerator fitModel = fitInfo.Item1;
                float loglikelihood = fitInfo.Item2;

			}
        }

    }
}
