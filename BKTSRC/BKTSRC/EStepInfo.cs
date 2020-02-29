using System;
namespace BKTSRC
{
    /// <summary>
	/// Wrapper for relevant information at a single EM step
	/// </summary>
    public struct EStepInfo
    {
        public EStepInfo()
        {
        }

        public float[][][] transSoftCount;
        public float[][][] emissionSoftCount;
        public float[][] initsoftCounts;
        public float[][] loglikelihood;

    }
}
