using UnityEngine;
using Systems;
using Systems.Collections;

namespace BKT;

public class KnowledgeLevels : Singleton<KnowledgeLevels>{

    //Initialize Skills to be evaluated
    public Skill EnvComfort;
    public Skill IfCondition;
    public Skill LogicExpression;

    //Interaction History (optional usage)
    public List<Exercise> InteractionHistory;

    //D: Init
    //R: New SingletonObject
    public KnowledgeLevels(){

    }

    //D: Use PFA to estimate performance on Exercise (summative) based on Skills tested
    //R: 0-1 probability student will be able to complete exercise
    float estimatePerformance(Exercise e){
        foreach(KeyValuePair<string,int> pair in e.skillsTested){
        }
    }

    //D: estimate test score based on multiple exercises
    //R: 0-1 pct expected to recieve on test
    float estimateTestScore(List<Exercise> exercises){
        float sum = 0.f;
        foreach(Exercise e in exercises) {
            sum+= estimatePerformance(e);
        }
        return (sum / exercises.Count);
    }

    //D: update skills based on execise
    //R: N/A
    void updateSkill(Execise e){

    }


}