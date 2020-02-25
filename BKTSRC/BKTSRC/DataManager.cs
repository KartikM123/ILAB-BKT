using System;
namespace BKTSRC
{
    public class DataManager : IDataManager
    {
        public override StudyData TestData()
        { 
            return new StudyData(0, 0,new float [1,1]{ { } }, new float[1, 3] { {1,2,3} });
        }
    }
}
