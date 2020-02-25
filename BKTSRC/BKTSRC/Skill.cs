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

        //D: init skill main code flow
        //R: new skill object
        public Skill(string iName, string iUserID, float pLo = 0.f)
        {
            this.name = iName;
            this.userID = iUserID;
            this.pLo = pLo;
            this.dataManager = new DataManager(this.userID);
        }

        public Skill(string iName, float pLo, IDataManager idataManager)
		{
            this.name = name;
            this.userID = "test";
            this.dataManager = idataManager;
            this.pLo = pLo;
		}

        //D: Get knowledge state
        //R: ""
        public void getKnowledgeState()
        {
            return modelParameters.pKnown;
        }

        //D: Update knowledge state using BKT based on correct Score vs. max Score
        //R: updated knowledge variables
        public void updateKnowledge(float correctScore, float maxScore)
        {
            //Get Model
            StudyData studyData = dataManager.GetData();

            //Calculate member variables
            this.modelParameters = ModelParam(studyData.num_resources, studyData.num_subparts, this.pLo);

            //Tune this
            int number_of_fits = 5;

            for(int i = 0; i < number_of_fits; i++)
			{

			}
        }

    }
}
