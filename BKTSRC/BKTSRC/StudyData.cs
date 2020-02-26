using System;
namespace BKTSRC
{
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

        //D: init
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
		/// 
		/// </summary>
		/// <param name="inum_resources"></param>
		/// <param name="inum_subparts"></param>
		/// <param name="iinteractionHistory"></param>
		/// <param name="iaffectiveState"></param>
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
