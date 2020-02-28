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
		/// Fit data based on model init paramters and studyData
		/// </summary>
		/// <param name="fitModel">Model fit with default params</param>
		/// <param name="studyData"></param>
		/// <returns></returns>
        public static Tuple<RandomModelGenerator, float> fit(RandomModelGenerator fitModel, StudyData studyData)
		{
            //TODO
            throw NotImplementedException;

            RandomModelGenerator newFitModel;
            float log_likelihood;

            return Tuple.Create<RandomModelGenerator, float>(newFitModel, log_likelihood);
		}
    }
}
