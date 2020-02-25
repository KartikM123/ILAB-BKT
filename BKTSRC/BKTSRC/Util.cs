using System;
namespace BKTSRC
{
    public class Util
    {
        public Util()
        {
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
