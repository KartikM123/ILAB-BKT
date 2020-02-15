using Systems;
using Systems.Collections;

namespace BKT;

public class Skill {

    //standard characteristics
    public string Name;
    
    //BKT params
    protected float pLo;
    protected float pSlip;
    protected float pGuess;
    protected float pTransit;
    protected float pKnown; //probability concept known

    //Affective state params -- TODO
    protected List<float> AffState;

    //D: init skill
    //R: new skill object
    public Skill (string Name){
        this.Name = name;

        this.pLo = 0;
        this.pSlip = 0;
        this.pGuess = 0;
        this.pTransit = 0;
        this.pKnown = 0;

        AffState = new List<float>();
    }

    //D: update affective state (Tom TODO)
    //R: updated aff state variable
    public void setAffectiveState(List<float> affState){
        this.AffState = affState;
    }

    //D: Get knowledge state
    //R: ""
    public void getKnowledgeState(){
        return this.pKnown;
    }

    //D: Update knowledge state using BKT based on correct Score vs. max Score
    //R: updated knowledge variables
    public void updateKnowledge(float correctScore, float maxScore){
        //TODO
    }
    
}