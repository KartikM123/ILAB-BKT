using System;
namespace BKTSRC
{
    public class GammaDist
    {
        public GammaDist()
        {
        }
        /// <summary>
        ///   Generates a random value from a standard Normal 
        ///   distribution (zero mean and unit standard deviation).
        /// </summary>
        /// 
        public static double RandomNormalDistribution(Random source)
        {
            // check if we can use second value
            if (useSecond)
            {
                // return the second number
                useSecond = false;
                return secondValue;
            }

            double x1, x2, w, firstValue;

            // generate new numbers
            do
            {
                x1 = source.NextDouble() * 2.0 - 1.0;
                x2 = source.NextDouble() * 2.0 - 1.0;
                w = x1 * x1 + x2 * x2;
            }
            while (w >= 1.0);

            w = Math.Sqrt((-2.0 * Math.Log(w)) / w);

            // get two standard random numbers
            firstValue = x1 * w;
            secondValue = x2 * w;

            useSecond = true;

            // return the first number
            return firstValue;
        }
        /// <summary>
        ///   Random Gamma-distribution number generation 
        ///   based on Marsaglia's Simple Method (2000).
        /// </summary>
        /// 
        public static double Marsaglia(double d, double c, Random source)
        {
            // References:
            //
            // - Marsaglia, G. A Simple Method for Generating Gamma Variables, 2000
            //

            while (true)
            {
                // 2. Generate v = (1+cx)^3 with x normal
                double x, t, v;

                do
                {
                    x = GammaDist.RandomNormalDistribution(source);
                    t = (1.0 + c * x);
                    v = t * t * t;
                } while (v <= 0);


                // 3. Generate uniform U
                double U = source.NextDouble();

                // 4. If U < 1-0.0331*x^4 return d*v.
                double x2 = x * x;
                if (U < 1 - 0.0331 * x2 * x2)
                    return d * v;

                // 5. If log(U) < 0.5*x^2 + d*(1-v+log(v)) return d*v.
                if (Math.Log(U) < 0.5 * x2 + d * (1.0 - v + Math.Log(v)))
                    return d * v;

                // 6. Goto step 2
            }
        }

        /// <summary>
        ///   Generates a random observation from the 
        ///   Gamma distribution with the given parameters.
        /// </summary>
        /// 
        /// <param name="scale">The scale parameter theta (or inverse beta).</param>
        /// <param name="shape">The shape parameter k (or alpha).</param>
        /// <param name="source">The random number generator to use as a source of randomness. 
        ///   Default is to use <see cref="Accord.Math.Random.Generator.Random"/>.</param>
        /// 
        /// <returns>A random double value sampled from the specified Gamma distribution.</returns>
        /// 
        public static float[][] RandomGamma2D(float[][] shape, double scale, Random source)
        {
            float[][] newshape = new float[shape.Length, shape[0].Length];
            for (int i = 0; i < newshape.Length; i++)
            {
                for (int j = 0; j < newshape[0].Length; j++)
                {
                    double shape = newshape[i][j];
                    if (shape < 1)
                    {
                        double d = shape + 1.0 - 1.0 / 3.0;
                        double c = (1.0 / 3.0) / Math.Sqrt(d);

                        double u = source.NextDouble();
                        newshape[i] = scale * GammaDist.Marsaglia(d, c) * Math.Pow(u, 1.0 / shape);
                    }
                    else
                    {
                        double d = shape - 1.0 / 3.0;
                        double c = (1.0 / 3.0) / Math.Sqrt(d);

                        newshape[i] = scale * GammaDist.Marsaglia(d, c);
                    }
                }
            }

            return newshape;
        }

        /// <summary>
        ///   Generates a random observation from the 
        ///   Gamma distribution with the given parameters.
        /// </summary>
        /// 
        /// <param name="scale">The scale parameter theta (or inverse beta).</param>
        /// <param name="shape">The shape parameter k (or alpha).</param>
        /// <param name="source">The random number generator to use as a source of randomness. 
        ///   Default is to use <see cref="Accord.Math.Random.Generator.Random"/>.</param>
        /// 
        /// <returns>A random double value sampled from the specified Gamma distribution.</returns>
        /// 
        public static float[][][] RandomGamma3D(float[][] shape, double scale, Random source)
        {
            float[][][] newshape = new float[shape.Length, shape[0].Length, shape[0][0].Length];
            for (int i = 0; i < newshape.Length; i++)
            {
                newshape[i] = GammaDist.RandomGamma2D(newshape[i], scale, source);
            }

            return newshape;
        }
    }
}
