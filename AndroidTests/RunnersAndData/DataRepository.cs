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
    public class DataRepository : DataBuilder
    {
        private List<string> ids = new List<string>() { "io.appium.android.apis:id/rotationX", "io.appium.android.apis:id/rotationY", "io.appium.android.apis:id/rotationZ", "io.appium.android.apis:id/scaleX", "io.appium.android.apis:id/scaleY", "io.appium.android.apis:id/translationX", "io.appium.android.apis:id/translationY" };
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

        public IData MaxMove(string seekBarId)
        {
            return Data.Get()
                .SetSeekBarId(seekBarId)
                .SetPercentToMove(1)
                .Build();
        }

        public IData ZeroMove(string seekBarId)
        {
            return Data.Get()
               .SetSeekBarId(seekBarId)
                .SetPercentToMove(0)
                .Build();
        }

        public IData ScaleYDataMax()
        {
            return MaxMove("io.appium.android.apis:id/scaleY");
        }

        public IData ScaleXDataMax()
        {
            return MaxMove("io.appium.android.apis:id/scaleX");
        }

        public IData TransXDataMax()
        {
            return MaxMove("io.appium.android.apis:id/translationX");
        }


        public List<IData> CombChangesInBars()
        {
            List<IData> barList = new List<IData>();
            barList.Add(MaxMove("io.appium.android.apis:id/translationX"));
            barList.Add(MaxMove("io.appium.android.apis:id/translationY"));
            barList.Add(MaxMove("io.appium.android.apis:id/scaleX"));
            barList.Add(MaxMove("io.appium.android.apis:id/rotationX"));
            barList.Add(MaxMove("io.appium.android.apis:id/rotationY"));
            return barList;
        }

    }
}