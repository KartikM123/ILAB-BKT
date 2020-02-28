using System;
namespace BKTSRC
{
    public class TestDataManager : IDataManager
    {
        /// <inheritdoc/>
        public override StudyData GetDataOccurences(string iskillname,int totalExercises = -1)
        {
            //data in format (column tried, answer recieved)
            if (totalExercises == -1)
            {
                totalExercises = 100;
            }

            StudyData studyData = new StudyData(totalExercises, totalExercises, null, null);
            return sampleData;
        }

        /// <inheritdoc/>
		public override StudyData GetData(string iskillName, ModelParam modelParam, int num_students = 50, int observations_per_student = 100)
		{
			return this.GetIdealModel(modelParam, num_students, observations_per_student);
		}

        /// <summary>
		/// Creates ideal observation sequence based on various params
		/// </summary>
		/// <param name="modelParam">Params that we should target for</param>
		/// <param name="start_location">starting point of matrix on xth observation sequence</param>
		/// <param name="observation_sequences_lengths">total observations made at x observation sequence</param>
		/// <param name="resources">resource used at observation t</param>
		/// <param name="total_observations">Total observations made in entire data</param>
		/// <returns></returns>
        protected StudyData CreateIdealModel(
            ModelParam modelParam,
            int[] start_location,
            float[] observation_sequences_lengths,
            int[] resources,
            int total_observations)
        {
            int[][] all_stateseqs = new int[total_observations];
            float[][] all_data = new float[modelParam.num_subparts, total_observations];
            int num_sequences = starts.Length;
            int num_slips = modelParam.slipsMatrix.Length;
            int num_resources = modelParam.num_resources;

            float[] knowledgeLevel = new float[2] { 1 - modelParam.pLo, modelParam.pLo };
            all_data[0][0] = 0;

            //redone As
            float[][] As = new float[2, 2 * num_resources];
            for (int i = 0; i < num_resources; i++)
            {
                As[2 * i] = new float[2] { 1 - modelParam.pTransit, modelParam.pTransit };
                As[2 * i + 1] = new float[2] { modelParam.pForget, 1 - modelParam.pForget };
            }

            for (int sequence_index = 0; sequence_index < num_sequences; sequence_index++)
            {
                int start_location = start_location[sequence_index];
                int observed_sequences = observation_sequences_lengths[sequence_index];
                float[] nextstate_knowledgeLevel = knowledgeLevel;

                for (int seq = 0; seq < observed_sequences; seq++)
                {
                    var rand = new Random();
                    //will be more likely for lower knowdge levels which would mean highter pLo
                    //will return 1 if unknown state
                    all_stateseqs[start_location + seq] = nextstate_knowledgeLevel[0] < (((float)rand.Next()) / ((float)RAND_MAX));

                    for (int n = 0; n < modelParam.num_subparts; n++)
                    {
                        if (all_stateseqs[start_location + seq])
                        {
                            //if is incorrect, see probability of slip
                            all_data[n][start_location + seq] = modelParam.slipsMatrix[n];
                        }
                        else
                        {
                            //if correct, see probability it was not a guess
                            all_data[n][start_location + seq] = (1 - modelParam.guessesMatrix[n] < ((float)rand.Next() / (float)RAND_MAX));
                        }
                    }

                    //update knowledge levels
                    nextstate_knowledgeLevel[0] = As[0][2 * (resources[start_location + seq] - 1 + all_stateseqs[start_location + seq])];
                    nextstate_knowledgeLevel[1] = As[1][2 * (resources[start_location + seq] - 1 + all_stateseqs[start_location + seq])];

                }
            }

            StudyData studyData = new StudyData(modelParam.num_resources, modelParam.num_subparts, all_data);
            return studyData;
        }

        /// <summary>
		/// Return a interaction history which should yield specific BKT params
		/// </summary>
		/// <param name="modelParam">Params of model we ideally want to reach</param>
		/// <returns>Study data containing sequence which should yield params</returns>
        public StudyData GetIdealModel(ModelParam modelParam, int num_students = 50, int observations_per_student = 100)
        {
            int num_resources = modelParam.num_resources;

            //total size of observation sequence
            int[] observation_sequences_lengths = NPUtil.init1D(num_students, observations_per_student);

            //consider total observations made at a final step
            int total_observations = NPUtil.sumArray(observation_sequences);

            //every observation should have a random resource associated with it
            //(resource type shouldn't matter in our eval)
            int[] resources = NPUtil.initRandom1D(1, num_resources + 1, total_observations);

            //calculate total interactions at every steps
            int[] starts = NPUtil.cumSum1D(observation_sequences_lengths);
            for (int i = 0; i < starts.Length; i++)
            {
                //calculate total non-unique interactions at every step
                stars[i] = starts[i] - observation_sequences_lengths[i];
            }

            return this.CreateIdealModel(modelParam, starts, observation_sequences_lengths, resources, total_observations);

        }
    }
}
