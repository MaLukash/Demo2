using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AndroidTests.RunnersAndData.DataBuilder;

namespace AndroidTests.RunnersAndData
{
    // 8. Use Repository
    // a) Use Static Class
    // b) All Static Methods
    // c) Use Pattern Singleton
    // 9. Use Singleton
    public class DataRepository
    {
        private volatile static DataRepository instance;
        private static object lockingObject = new object();

        private DataRepository()
        {
        }

        public static DataRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new DataRepository();
                    }
                }
            }
            return instance;
        }

        public IData Admin()
        {
            return Data.Get()
                .SetSeekBarId("SomeString")
                .SetPercentToMove(0.7)
                .Build();
                
        }

        public IData DBUser()
        {
            // Read User From DB
            // Create Class for Read
            return Data.Get()
               .SetSeekBarId("SomeString")
                .SetPercentToMove(0.7)
                .Build();
        }

        public List<IData> ExcelData()
        {
            List<IData> result = new List<IData>();
            // Read User From Excel File
            // Create Class for Read
            result.Add(
                Data.Get()
                .SetSeekBarId("SomeString")
                .SetPercentToMove(0.7)
                .Build());             
            return result;
        }
    }
}