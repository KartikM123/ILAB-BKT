using Systems;
using Systems.Collections;
using Systems.Serializable;

namespace BKT;


//D: Parameters for BKT implementation. 
public class ModelParams {

    //input variables
    protected int i_num_resources = 0; //number of total questions asked
    
    //output params
    protected float pLo;
    protected float pSlip;
    protected float pGuess;
    protected float pTransit;
    public float pKnown; //probability concept known

    //model variables
    public float [][][] As; //probability concept changed from not known to known

    //D: init Ad
    public void initAs(){
        for (int i = 0; i < i_num_resources; i++){
            for (int j = 0; j < 2; j++){
                for (int z = 0; z < 2; z++){
                    this.As[i][j][z] = 0.f;
                }
            }
        }
    }

    //D: init 
    public ModelParams(int num_resources, float pLo) {
        i_num_resources = num_resources;

        this.pLo = pLo;
        pSlip  = 0.f;
        pGuess = 0.f;
        pTransit = 0.f;
        pKnown = 0.f;

        As = new float [num_resources, 2, 2];
        initAs();

    }
}