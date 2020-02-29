using System;
namespace BKTSRC
{
    /// <summary>
	/// Fit parameters using EMfit maximization
	/// </summary>
    public class EMFit
    {
        public EMFit()
        {
        }

        /// <summary>
		/// See expected emission and transition of skill values at a certain model state
		/// </summary>
		/// <param name="studyData">data from study</param>
		/// <param name="fitmodel">current state of the model being fitted</param>
		/// <param name="num_outputs">number of outputs we need</param>
		/// <returns></returns>
        public static EStepInfo expectedStepResults (
            StudyData studyData,
            RandomModelGenerator fitmodel,
            int num_outputs)
		{

		}

        /// <summary>
		/// Fit data based on model init paramters and studyData
		/// </summary>
		/// <param name="fitModel">Model fit with default params</param>
		/// <param name="studyData">Study data</param>
		/// <param name="knowledgeLevelsRecorded">Number of skills we are tracking per fit</param>
		/// <returns></returns>
        public static Tuple<RandomModelGenerator, float> fit(
            RandomModelGenerator fitModel,
            StudyData studyData,
            int knowledgeLevelsRecorded = 1)
		{
            float tol = 1E-3;
            float maxiter = 100;

            int num_subparts = studyData.num_subparts;
            int num_resources = studyData.num_resources;

            //TODO: Document Estepinfo
            EStepInfo result;
            result.transSoftCount = NPUtil.init3D(num_resources, 2, 2);
            result.emissionSoftCount = NPUtil.init3D(num_subparts, 2, 2);
            result.initsoftCounts = NPUtil.init2D(2, 1);
            result.loglikelihood = NPUtil.init2D(maxiter, 1);
            RandomModelGenerator newFitModel;
            float log_likelihood;

            for (int i = 0; i < maxiter; i++)
			{
                //E step here (calculated expected values)
                result = EMFit.expectedStepResults(studyData, fitModel, 1);

                for(int resource = 0; resource < num_resources; resource++)
				{
                    result.transSoftCount[resource] = NPUtil.transpose2D(result.transSoftCount[resource]);
				}
                for (int subpart = 0; subpart < num_subparts; subpart++)
				{
                    result.emissionSoftCount[subpart] = NPUtil.transpose2D(result.emissionSoftCount[subpart]);
				}

                log_likelihood = result.loglikelihood[i][0];

                if (i > 1 && Math.Abs(result.loglikelihood[i][0] - result.loglikelihood[i-1][0]) < tol)
				{
                    break;
				}

                //M step here (maximize the model)
			}


            return Tuple.Create<RandomModelGenerator, float>(newFitModel, log_likelihood);
		}
    }
}
