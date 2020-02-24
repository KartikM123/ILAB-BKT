using System;
namespace BKTSRC
{
    public class Util
    {
        public Util()
        {
        }

        //D: init empty 3D array
        //R: 3D array of uniform "newVal"
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

        //D: init empty 1D array
        //R: 1D array filled with uniform "newVal"
        public static float[] init1D(int x, float newVal = 0.f)
		{
            float[] ans = new float[x];
            for (int i = 0; i < x; i++)
			{
                ans[i] = newVal;
			}

            return ans;
		}

        //D: init empty 2D array
        //R: 2D array of uniform "newVal"
        public static float[][] init2D(int x, int y, float newVal = 0.f) {
            float[][] ans = new float[x, y];

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    ans[i][j] = newVal;
                }
            }

            return ans;
        }

        //D: ensures all arrays are of uniform length for matrix analysis
        //R: true if is uniform
        private static bool isUniform(float[][] input) {
            int length = input[0].Length;
            for (int i = 0; i < input.Length; i++) {
                if (input[i].Length != length) {
                    return false;
                }
            }
            return true;
        }

        //D: Transpose arrays of equal length
        //R: Transposed array
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
