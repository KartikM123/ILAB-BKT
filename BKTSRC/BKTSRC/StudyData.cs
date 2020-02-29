using System;
namespace BKTSRC
{
    /// <summary>
	/// Contains all study data which will be analyzed
	/// </summary>
    public class StudyData
    {
        /*
         * sequence of participant interaction (interactions x possible subparts)
         * (includes order of answers [right (2)/wrong (1)] and checkpoints (1))
         * NOTE: interactions = num_resources + num_subparts
         */
        public float[][] interactionHistory;

        /*
         * Returns affective state at every interaction. Dimensions (interactions x 3)
         * Each interaction stores 3 state attributes
         */ 
        public float[][] affectiveState;

        //number of resources/checkpoints reached throughout interaction
        public int num_resources;

        //number of subparts ocmpleted throughout interaction
        public int num_subparts;


        //total size of observation sequence
        public int[] observation_sequences_lengths;

        //consider total observations made at a final step
        public int total_observations;

        //every observation should have a random resource associated with it
        //(resource type shouldn't matter in our eval)
        public int[] resources;

        //calculate total interactions at every steps
        public int[] starts;

        /// <summary>
		/// Init studydata no affective state
		/// </summary>
		/// <param name="inum_resources">number of resources possible</param>
		/// <param name="inum_subparts">number of subparts to question</param>
		/// <param name="iinteractionHistory">interaction history</param>
        public StudyData(
            int inum_resources,
            int inum_subparts,
            float[][] iinteractionHistory)
        {
            this.interactionHistory = iinteractionHistory;
            this.num_resources = inum_resources;
            this.num_subparts = inum_subparts;
            this.affectiveState = null;
        }
        /// <summary>
		/// Intialize studydata with affective state
		/// </summary>
		/// <param name="inum_resources">number of resources possible</param>
		/// <param name="inum_subparts">number of subparts to question</param>
		/// <param name="iinteractionHistory">interaction history</param>
		/// <param name="iaffectiveState">additional parameters detailing affective state</param>
        public StudyData(
            int inum_resources,
            int inum_subparts,
            float[][] iinteractionHistory,
            float [][] iaffectiveState)
        {
            this.interactionHistory = iinteractionHistory;
            this.num_resources = inum_resources;
            this.num_subparts = inum_subparts;
            this.affectiveState = iaffectiveState;
        }
    }
}
