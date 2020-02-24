using System;
using System.Collections;

namespace BKTSRC
{
    public class Exercise
    {

        //exercise properties
        public string Name;
        public int Difficulty; //value 1-3

        //apply weight for main concept of exercise
        public int CONCEPT_WEIGHT = 1;

        //skill properties
        public IDictionary<string, float> SkillsTested;
        public IDictionary<string, float> SkillsCorrect;
        public int totalSteps;

        //D: init object minimum
        //R: new exercise object
        public Exercise(string Name, int Difficulty)
        {
            this.Name = Name;
            this.Difficulty = Difficulty;
            this.SkillsTested = new Dictionary<string, int>(); // GET FROM TOM
            this.SkillsCorrect = new Dictionary<string, int>();
        }

        //D: Set Skills Tested and total Substeps in question
        //R: null
        public void setSkillsTested(Dictionary<string, float> iskillsTested, int itotalSteps)
        {
            skillsTested = iskillsTested;
            totalSteps = itotalSteps;
        }

        //D: updates skillstested dictionary
        //R: N/A
        public void updateSkill(string concept, float value)
        {
            if (this.SkillsTested.ContainsKey(concept))
            {
                this.SkillsTested[concept] += value;
            }
            else
            {
                this.SkillsTested.Add(new KeyValuePair<string, int>(concept, value));
            }
        }
        //D: Calculates skillsTested based on exercise breakdown {skill, times tested}
        //R: updated skillsTested variable
        public void updateExercise(Dictionary<string, int> stepsTested, string mainConcept)
        {
            updateSkill(mainConcept, CONCEPT_WEIGHT);

            //difficulty of concept calculated by ((totalSteps/Difficulty) * conceptSteps) 
            //sum of skills = difficulty
            foreach (KeyValuePair<string, int> pair in stepsTested)
            {
                updateSkill(pair.key, pair.value * (totalSteps / this.Difficulty));
            }
        }

        //D: Calculates user results based on exercise breakdown {skill, times tested correctly}
        //R: updated skillsTested variable
        public void updateExerciseResults(Dictionary<string, int> stepsTested, string mainConcept, bool correct)
        {
            updateSkill(mainConcept, CONCEPT_WEIGHT * Math.Pow(-1, !correct)); //-1^1 if incorrect

            //difficulty of concept calculated by ((totalSteps/Difficulty) * conceptSteps) 
            //sum of skills = difficulty
            foreach (KeyValuePair<string, int> pair in stepsTested)
            {
                updateSkill(pair.key, pair.value * (totalSteps / this.Difficulty));
            }
        }

    }
}
