using Systems;
using Systems.Collections;

namespace BKT;

public class Exercise{

    //exercise properties
    public string Name;
    public int Difficulty; //value 1-3
    
    //apply weight for main concept of exercise
    public int CONCEPT_WEIGHT = 1;

    //skill properties
    public Dictionary<string, float> SkillsTested;

    //D: init object minimum
    //R: new exercise object
    public Exercise(string Name, int Difficulty){
        this.Name = Name;
        this.Difficulty = Difficulty;
        this.SkillsTested = new Dictionary<string, int>();
    }

    //D: updates skillstested dictionary
    //R: N/A
    void updateSkill(string concept, float value){
        if (this.SkillsTested.ContainsKey(concept)){
            this.SkillsTested[concept]+=value;
        } else {
            this.SkillsTested.Add(new KeyValuePair<string,int>(concept, value))
        }
    }
    //D: Calculates skillsTested based on exercise breakdown {skill, times tested}
    //R: updated skillsTested variable
    void updateExercise(Dictionary<string, int> stepsTested, string mainConcept, int totalSteps){
        updateSkill(mainConcept,CONCEPT_WEIGHT);

        //difficulty of concept calculated by ((totalSteps/Difficulty) * conceptSteps) 
        //sum of skills = difficulty
        foreach(KeyValuePair<string,int> pair in stepsTested){
            updateSkill(pair.key, pair.value * (totalSteps/this.Difficulty));
        }
    }

}