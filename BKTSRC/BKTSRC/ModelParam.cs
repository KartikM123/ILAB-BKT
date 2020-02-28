using System;
namespace BKTSRC
{
    /// <summary>
	/// Manages all Parameters and Variables for BKT modeling
	/// </summary>
    public class ModelParam
    {

        //input variables
        public int num_resources = 0; //number of total questions asked
        public int num_subparts = 0; 

        //output variables
        public float pLo; //P concept already known
        public float pSlip; //P answer was wrong given known
        public float pGuess; //P an answer was right given not known
        public float pTransit; //P knowing given not known
        public float pForget; //P not known given knowing
        public float pKnown; //P concept known

        //model params
        public float[][][] As; //P concept changed from not known to known
        public float[] learnsMatrix; //P learned at n resource
        public float[] forgetsMatrix; //P forgotten at n resource
        public float[] priorMatrix; //P prior known
        public float[] guessesMatrix; //P guessed at m question
        public float[] slipsMatrix; // P slipped at m question


        /// <summary>
		/// Init
		/// </summary>
		/// <param name="inum_resources">number of resources</param>
		/// <param name="inum_subparts">number of subparts</param>
		/// <param name="ipLo">initial knowledge level</param>
        public ModelParam(int inum_resources, int inum_subparts, float ipLo)
        {
            this.num_resources = inum_resources;
            this.num_subparts = inum_subparts;

            this.ipLo = pLo;
            this.pSlip = 0.f;
            this.pGuess = 0.f;
            this.pTransit = 0.f;
            this.pKnown = 0.f;
            this.pForget = 0.f;

            initParams();
        }

        /// <summary>
		/// Manually set BKT variables for test
		/// </summary>
		/// <param name="pSlip">P wrong if known state</param>
		/// <param name="pGuess">P right if unknown state</param>
		/// <param name="pTransit">P of applying knowledge to the next subpart</param>
		/// <param name="pForget">P forgetting concept</param>
		/// <param name="pKnown">P is known</param>
        public void setVariables(float pSlip, float pGuess, float pTransit, float pForget, float pKnown)
		{
            this.pSlip = pSlip;
            this.pGuess = pGuess;
            this.pTransit = pTransit;
            this.pForget = pForget;
            this.pKnown = pKnown;

            initParams();
		}

        /// <summary>
		/// Init probability transition between knowning and not known & vice versa
		/// </summary>
        public void initAs() {
            this.As = new float[this.num_resources, 2, 2];
            this.As = NPUtil.init3D(this.num_resources, 2, 2, 0.f);

            for (int i = 0; i < this.num_resources; i++)
            {
                //update As per resource (resource provides checkpoint for reevaluating total knowledge levels)
                //we want to keep a consistent pTransit and pForget so keep the knowledge level at each state constant
                //2x2 each represents a permuation of transit/guess on known/not known state
                this.As[i] = NPUtil.transpose2D(new float [2,2] {{ 1 - this.pTransit, this.pTransit}, { 1 - this.pForget, pForget}});
            }
        }

        /// <summary>
		/// init BKT parameters
		/// </summary>
        public void initParams() {
            //1. Init variables that are evaluated per resource checkpoint
            //As at a point will represent knowledge level at that resource
            initAs();

            //represent prob learn or forget at each resource checkpoint at each learn and forget level
            this.learnsMatrix = NPUtil.init1D(num_resources, this.pTransit);
            this.forgetsMatrix = NPUtil.init1D(num_resources, this.pForget);

            this.priorMatrix = new float [2][1]{{ 1 - this.pLo}, { this.pLo} };

            //Init variables that are evaluated at every subpart answer
            //probability that an answer is a slip or a guess. 
            this.slipsMatrix = NPUtil.init1D(num_subparts, this.pSlip);
            this.guessesMatrix = NPUtil.init1D(num_subparts, this.pGuess);

            
        }
    }
}
