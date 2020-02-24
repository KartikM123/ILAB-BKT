using Systems;
using Systems.Collections;
using Systems.Serializable;

namespace BKT;

public class TestUtil {
    public static float[][] TestData()
    {
        //data in format (column tried, answer recieved)
        int totalExercises = 100;
        float [,] sampleData = new float [totalExercises][totalExercises];
        var rand = new Random();

        for (int i = 0; i < totalExercises; i++){
            int correct = rand.Next(0,2);
            sampleData[i][i] = correct/ 2.f;
        }
        return sampleData;
    }
}



//Ideal Data
// 0 = we provide answer , 1 = answer incorrect, 2 = answer correct
/* FORMAT [item (data recorded)]:
    Main question 1 (SKILL TESTED : DIFFICUTY){
        substep (SKILL TESTED)
        substep (SKILL TESTED)
        ...
    }
    Main question 2 (SKILL TESTED : DIFFICUTY){
        substep (SKILL TESTED)
        substep (SKILL TESTED)
        ...
    }
    ...
 */

