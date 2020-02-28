using System;
namespace BKTSRC
{
    /// <summary>
	/// Init random variables for BKT. Init per iteration 
	/// </summary>
    public class RandomModelGenerator
    {
        /// <summary>
		/// number of resources in interaction period
		/// </summary>
        protected int num_resources;

        /// <summary>
		/// number of subparts in interaction period
		/// </summary>
        protected int num_subparts;


        //Model parameters

        /// <summary>
		/// Overall learn/forgets states at every resource (learn + forget)
		/// </summary>
        public float[][][] As;

        /// <summary>
		/// Overall known/notknown summary per instance observed
		/// </summary>
        public float[][][] emissions;

        /// <summary>
		/// probability known prior to interaction
		/// </summary>
        public float prior;

        /// <summary>
		/// probability known initially prior to resource
		/// </summary>
        public float[][] pi0;

        /// <summary>
		/// Probability learned at a resource
		/// </summary>
        public float[] learns;

        /// <summary>
		/// Probability forgotten at a resource
		/// </summary>
        public float[] forgets;

        /// <summary>
		/// Predicted number of guesses per subpart based on guess probability
		/// </summary>
        public float[] guesses;

        /// <summary>
		/// Predicted number of slips per subpart based on slip probability
		/// </summary>
        public float[] slips;


        /// <summary>
		/// Initialize Random Model generator
		/// </summary>
		/// <param name="inum_resources"></param>
		/// <param name="inum_subparts"></param>
        public RandomModelGenerator(int inum_resources, int inum_subparts)
        {
            this.num_resources = inum_resources;
            this.num_subparts = inum_subparts;

            this.random_model_generator(this.num_resources, this.num_subparts);
        }

        protected void generateEmissions(float[][] given_notknown, float[][] given_known, int knowledgeSize = -1)
		{
            if (given_known.Length != given_notknown.Length)
			{
                //must represent knowledge at the same size
                throw InvalidOperationException;
			}
            if (knowledgeSize == -1)
            {
                knowledgeSize = given_known[0].Length / this.num_subparts;
            }
            int knowledgeInstances = given_known.Length; //should be 2, known and 1-known state, and same for notknown
            int knowledgeStates = 2; //not known and known are two given

            float[][][] emissions = NPUtil.init3D(this.num_subparts, knowledgeStates, knowledgeInstances * knowledgeSize, 0.f);

            for (int sb = 0; sb < this.num_subparts; sb++)
            {
                for (int i = 0; i < knowledgeSize * 2; i++)
                {
                    if (i >= knowledgeSize)
                    {
                        emissions[sb][0][i] = given_notknown[1][i];
                        emissions[sb][1][i] = given_known[1][i];
                    }
                    else
                    {
                        emissions[sb][0][i] = given_notknown[0][i - knowledgeSize];
                        emissions[sb][1][i] = given_known[0][i - knowledgeSize];
                    }
                }
            }

            return emissions;
		}



        /// <summary>
        /// Initialize random p Values before fitting the model
        /// </summary>
        /// <param name="num_resources">Number of resources in observation</param>
        /// <param name="num_subparts">Number of subparts in observation</param>
        protected void random_model_generator(int num_resources = 1, int num_subparts = 1)
        {
            //init default properties
            float[][][] tile_trans = NPUtil.duplicate2Dto3D(new float[2][2] { { 20, 4 }, { 1, 20 } }, num_resources);
            float[][] given_notknown_prior = NPUtil.tile2D(new float[2][1] { { 5 }, { 0.5 } }, 1, num_subparts);
            float[][] given_known_prior = NPUtil.tile2D(new float[2][1] { { 0.5 }, { 5 } }, 1, num_subparts);
            float[][] pi0_prior = new float[2, 1] { { 100 }, { 1 } };

            //calculate distribution of points
            float[][][] As = NPUtil.dirrnd3D(tile_trans);
            given_notknown_prior = NPUtil.dirrnd2D(given_notknown_prior);
            given_known_prior = NPUtil.dirrnd2D(given_known_prior);
            pi0_prior = NPUtil.dirrnd2D(pi0_prior);
            float[][][] emissions = generateEmissions(given_notknown_prior, given_known_prior, 1);

            var rand = new Random();
            As = NPUtil.uniform3Dchange(As, 1, 0, rand.Next(num_resources) * 0.40);
            As = NPUtil.uniform3Dchange(As, 1, 1, 1 - As[0][1][0]);
            As = NPUtil.uniform3Dchange(As, 0, 1, 0);
            As = NPUtil.uniform3Dchange(As, 0, 0, 1);

            this.prior = (float)rand.NextDouble();
            this.As = As;
            this.emissions = emissions;
            this.learns = NPUtil.init1D(As.Length, As[0][1][0]);
            this.forgets = NPUtil.init1D(As.Length, As[0][0][1]);
            this.guesses = NPUtil.init1D(given_known_prior[1].Length, rand.Next(num_subparts) * 0.4);
            this.slips = NPUtil.init1D(given_known_prior[0].Length, rand.Next(num_subparts) * 0.3);
            this.pi0 = pi0_prior;
        }
    }
}
