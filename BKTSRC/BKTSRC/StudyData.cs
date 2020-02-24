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

        //number of resources/checkpoints reached throughout interaction
        public int num_resources;

        //number of subparts ocmpleted throughout interaction
        public int num_subparts;

        public StudyData(int inum_resources, int inum_subparts, float[][] iinteractionHistory)
        {
            this.interactionHistory = iinteractionHistory;
            this.num_resources = inum_resources;
            this.num_subparts = inum_subparts;
        }
    }
}
