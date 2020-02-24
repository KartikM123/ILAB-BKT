using System;
namespace BKTSRC
{
    public class ModelParam
    {

        //input variables
        protected int num_resources = 0; //number of total questions asked
        protected int num_subparts = 0; 

        //output params
        protected float pLo; //P concept already known
        protected float pSlip; //P answer was wrong given known
        protected float pGuess; //P an answer was right given not known
        protected float pTransit; //P knowing given not known
        protected float pForget; //P not known given knowing
        public float pKnown; //P concept known

        //model variables
        public float[][][] As; //P concept changed from not known to known
        public float[] learnsMatrix; //P learned at n resource
        public float[] forgetsMatrix; //P forgotten at n resource
        public float[] priorMatrix; //P prior known
        public float[] guessesMatrix; //P guessed at m question
        public float[] slipsMatrix; // P slipped at m question


        //D: init 
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

        //D: init probability of retained knowledge ("As")
        public void initAs() {
            this.As = new float[this.num_resources, 2, 2];
            this.As = Util.init3D(this.num_resources, 2, 2, 0.f);

            for (int i = 0; i < this.num_resources; i++)
            {
                this.As[i] = Util.transpose2D(new float [2,2] {{ 1 - this.pTransit, this.pTransit}, { 1 - this.pForget, pForget}});
            }
        }

        //D: Wrapper which initializes all parameters
        public void initParams() {
            //1. Init variables that are evaluated per resource checkpoint
            //As at a point will represent knowledge level at that resource
            initAs();

            //represent how much knowledge at each learn and forget level
            this.learnsMatrix = Util.init1D(num_resources, this.pTransit);
            this.forgetsMatrix = Util.init1D(num_resources, this.pForget);

            this.priorMatrix = new float [2][1]{{ 1 - this.pLo}, { this.pLo} };

            //2. Init variables that are evaluated at every subpart answer
            this.slipsMatrix = Util.init1D(num_subparts, this.pSlip);
            this.guessesMatrix = Util.init1D(num_subparts, this.pGuess);
        }
    }
}
