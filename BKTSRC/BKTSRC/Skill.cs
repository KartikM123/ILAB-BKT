using System;
using System.Collections;
namespace BKTSRC
{
    //Main source: https://github.com/CAHLR/pyBKT
    public class Skill
    {

        //standard characteristics
        public string name;
        public string userID;
        public float pLo; //probability initally known

        //Model Parameters which will be further fit
        ModelParam modelParameters;

        //Data Manager
        IDataManager dataManager;

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
        }

        /// <summary>
		/// Initializer for manual datamanager implementation
		/// </summary>
		/// <param name="iName">name of skill</param>
		/// <param name="pLo">initial knowledge level</param>
		/// <param name="idataManager"> use to query student data</param>
        public Skill(string iName, float pLo, IDataManager idataManager)
		{
            this.name = name;
            this.userID = "test";
            this.dataManager = idataManager;
            this.pLo = pLo;
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
        public void updateKnowledge(int number_of_fits = 5, int num_of_students = 50, int observations_per_student = 100)
        {

            //Get Model
            StudyData studyData = dataManager.GetDataOccurences();

            //Calculate member variables
            this.modelParameters = ModelParam(studyData.num_resources, studyData.num_subparts, this.pLo);

            //Get more comprehensive datastructure
            studyData = dataManager.GetData(this.name, this.modelParameters, num_of_students, observations_per_student);

            for (int i = 0; i < number_of_fits; i++)
			{

			}
        }

    }
}
