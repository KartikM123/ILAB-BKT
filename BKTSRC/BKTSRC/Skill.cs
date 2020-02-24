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

        //Model Parameters which will be further fit
        ModelParam modelParameters;

        //D: init skill
        //R: new skill object
        public Skill(string iName, string iUserID)
        {
            name = iName;
            userID = iUserID;
        }

        //D: update affective state (Tom TODO)
        //R: updated aff state variable
        public void setAffectiveState(List<float> affState)
        {
            this.AffState = affState;
        }

        //D: Get knowledge state
        //R: ""
        public void getKnowledgeState()
        {
            return modelParameters.pKnown;
        }

        //D: Get user data
        private StudyData getData()
        {
            //for testing purposes
            return TestUtil.TestData();
        }
        //D: Update knowledge state using BKT based on correct Score vs. max Score
        //R: updated knowledge variables
        public void updateKnowledge(float correctScore, float maxScore)
        {
            //Get Model
            StudyData userExperience = getData();

            //Calculate member variables
            this.modelParameters = ModelParam()


        }

    }
}
