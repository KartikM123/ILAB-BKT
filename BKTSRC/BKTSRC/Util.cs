using System;
namespace BKTSRC
{
    /// <summary>
	/// Utility class used for misc. mathematical operations based on numpy
	/// </summary>
    public class NPUtil
    {
        public NPUtil()
        {
        }

        /// <summary>
		/// Summ all elements on y (2nd) dim and clamp to a singular dim on y
		/// </summary>
		/// <param name="arr">arr to sum</param>
		/// <returns></returns>
        public static float[][] sumxAxis2D(float[][] arr)
        {
            float[][] summedx = init3D(1, arr[0].Length, 0.f);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    summedx[0][j] += arr[i][j];
                }
            }
            return summedx;
        }
        /// <summary>
		/// Summ all elements on y (2nd) dim and clamp to a singular dim on y
		/// </summary>
		/// <param name="arr">arr to sum</param>
		/// <returns></returns>
        public static float[][][] sumyAxis3D(float[][][] arr)
        {
            float[][][] summedy = init3D(arr.Length, 1, arr[0][0].Length, 0.f);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    for (int k = 0; k < arr[0][0].Length; k++)
                    {
                        summedy[i][0][k] += arr[i][j][k];
                    }
                }
            }
            return summedy;
        }
        /// <summary>
		/// Divide sum of array column with each array value
		/// </summary>
		/// <param name="arrFull">Fully populated array (x by y)</param>
		/// <param name="arrClamped">stores sum of array at each column (1 by y)</param>
		/// <returns></returns>
        public static float[][] diviseAxis2D(float[][] arrFull, float[][] arrClamped)
        {
            for (int i = 0; i < arrFull.Length; i++)
            {
                for (int j = 0; j < arrFull[0].Length; j++)
                {
                    arrFull[i][j] = arrFull[i][j] / arrClamped[0][k];
                }
            }
            return arrFull;
        }
        /// <summary>
		/// Divide sum of array column with each array value
		/// </summary>
		/// <param name="arrFull">Fully populated array (x by y by z)</param>
		/// <param name="arrClamped">stores sum of array at each column (x by 1 by z)</param>
		/// <returns></returns>
        public static float [][][] diviseAxis3D (float [][][] arrFull, float [][][] arrClamped)
		{
            for(int i = 0; i < arrFull.Length; i++)
			{
                for(int j = 0; j < arrFull[0].Length; j++)
				{
                    for(int k = 0; k < arrFull[0][0].Length; k++)
					{
                        arrFull[i][j][k] = arrFull[i][j][k] / arrClamped[i][0][k];
					}
				}
			}
            return arrFull;
		}
        /// <summary>
		/// rand distribution over 3D array
		/// </summary>
		/// <param name="alphavec">vector to be distributed</param>
		/// <returns></returns>
        public static float[][][] dirrnd3D (float [][][] alphavec)
		{
            Random rand = new Random();
            float[][][] a = GammaDist.RandomGamma3D(alphavec, 1, rand);
            float[][][] suma = sumxAxis3D(a);
            return diviseAxis3D(a, suma);
        }

        /// <summary>
		/// Random distribution over 2D array
		/// </summary>
		/// <param name="alphavec"></param>
		/// <returns></returns>
        public static float[][] dirrnd2D (float [][] alphavec)
		{
            Random rand = new Random();
            float [][] a = GammaDist.RandomGamma2D(alphavec, 1, rand);
            float[][] suma = sumxAxis2D(a);
            return diviseAxis2D(a, suma);

		}


        /// <summary>
		/// Duplicated 2D array x times
		/// </summary>
		/// <param name="arr">original array to duplicate</param>
		/// <param name="numDuplications">x duplications for array</param>
		/// <returns></returns>
        public static float [][][] duplicate2Dto3D(float[][] arr, int numDuplications)
		{
            float[][][] duplicatedArr = new float[numDuplications, arr.Length, arr[0].Length];
            for(int i = 0; i < numDuplications; i++)
			{
                duplicatedArr[i] = arr;
			}

            return duplicatedArr;
		}

        /// <summary>
		/// Tile 2D array based on dimensions provided
		/// </summary>
		/// <param name="arr">initial array to be expanded</param>
		/// <param name="xtimesRepeated">time array values must be tiled</param>
		/// <returns></returns>
        public static float[][] tile2D(float[][] arr, int xtimesRepeated = 1, int ytimesRepeated = 1)
		{
            if (!isUniform(arr))
			{
                throw FormatException;
			}

            float[][] tiledArr = new float[arr.Length * xtimesRepeated, arr[0].Length * ytimesRepeated];
            //first repeat each y direction
            for(int yrepeat = 0; yrepeat < ytimesRepeated; yrepeat++)
			{
               for(int i = 0; i < arr.Length; i++)
                {
                    for(int j = 0; j < arr[i].Length; j++)
                    {
                        tiledArr[i][yrepeat * arr[i].Length + j] = arr[i][j];
                    }
                }
			}
            //then repeat in x dimension
            for(int xdims = 0; xdims < xtimesRepeated; xdims++)
			{
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < tiledArr[i].Length; j++)
                    {
                        tiledArr[arr.Length * xdims + i][j] = tiledArr[i][j];
                    }
                }
			}

            return tiledArr;
            
		}

        /// <summary>
		/// returns the sum of all values in array
		/// </summary>
		/// <param name="arr">array to sum values of</param>
		/// <returns>sum of array values</returns>
        public static int sumArray(float[] arr) {
            int count = 0;
            for (int i =0; i < arr.Length; i++)
			{
                count += arr[i];
			}
            return count;
        }

        /// <summary>
		/// init 3D array with fill some new value
		/// </summary>
		/// <param name="x">x dim size</param>
		/// <param name="y">y dim size</param>
		/// <param name="z">z dim size</param>
		/// <param name="newVal">value to populate array</param>
		/// <returns>uniformly init 3D array</returns>
        public static float[][][] init3D(int x, int y, int z, float newVal = 0.f) {
            float[][][] ans = new float[x, y, z];

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    for (int k = 0; k < z; k++) {
                        ans[x][y][z] = newVal;
                    }
                }
            }

            return ans;
        }

        /// <summary>
		/// init 1D array with random values
		/// </summary>
		/// <param name="low"> lowest value </param>
		/// <param name="high"> highest random value</param>
		/// <param name="size"> size of array</param>
		/// <returns>randomly fill 1D array</returns>
        public static float[] initRandom1D(int low, int high, int size)
		{
            float[] arr = new float[size];
            var rand = new Random();

            for(int i = 0; i< size; i++)
			{
                arr[i] = rand.Next(low, high);
			}

            return arr;
		}

        /// <summary>
		/// Cumulative sum at every point at array
		/// (sum[2] = arr[1] + arr[0]+ arr[2])
		/// </summary>
		/// <param name="arr">array to cumsum</param>
		/// <returns>cumsum 1D array</returns>
        public static float[] cumSum1D(int [] arr)
		{
            int cumulcount = 0;

            for(int i = 0; i < arr.Length; i++)
			{
                cumulcount += arr[i];
                arr[i] = cumulcount;
			}

            return arr;
		}

        /// <summary>
		/// init 1D array with some standard value
		/// </summary>
		/// <param name="x">x-dim size</param>
		/// <param name="newVal">value to fill</param>
		/// <returns>filled 1D array</returns>
        public static float[] init1D(int x, float newVal = 0.f)
		{
            float[] ans = new float[x];
            for (int i = 0; i < x; i++)
			{
                ans[i] = newVal;
			}

            return ans;
		}

        /// <summary>
		/// Init 2D array
		/// </summary>
		/// <param name="x"> x-dim size</param>
		/// <param name="y"> y-dim size</param>
		/// <param name="newVal"> new value</param>
		/// <returns>filled 2D matrix</returns>
        public static float[][] init2D(int x, int y, float newVal = 0.f) {
            float[][] ans = new float[x, y];

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    ans[i][j] = newVal;
                }
            }

            return ans;
        }

        /// <summary>
		/// sees if all array values have same length (to treat like matrix
		/// </summary>
		/// <param name="input">array to check (2D)</param>
		/// <returns>true if matrix is uniform</returns>
        private static bool isUniform(float[][] input) {
            int length = input[0].Length;
            for (int i = 0; i < input.Length; i++) {
                if (input[i].Length != length) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
		/// Transpose 2D matrix
		/// </summary>
		/// <param name="input">matrix</param>
		/// <returns>transposed matrix</returns>
        public static float [][] transpose2D(float[][] input) {
            if (!isUniform(input)) {
                return;
            }
            int totalRows = input.Length;
            int totalCols = input[0].Length;
            float[][] mask = new float[totalCols, totalRows];

            for (int i = 0; i < totalRows; i++) {
                for (int j = 0; j < totalCols; j++) {
                    mask[j][i] = input[i][j];
                }
            }

            return mask;
        }

    }
}
