using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTests.RunnersAndData
{
    public class DataBuilder
    {
        public interface ISeekBarId
        {
            IPercentToMove SetSeekBarId(string seekBarId);
        }

        public interface IPercentToMove
        {
            IDataBuilder SetPercentToMove(double perc);
        }       

       

        public interface IDataBuilder
        {
            // 5. Add Builder
            //User Build();
            // 6. Add Dependency Inversion
            IData Build();
        }

        // 6. Add Dependency Inversion
        public interface IData
        {
            string GetSeekBarId();
            double GetPercentToMove();            
        }

        public class Data : ISeekBarId, IDataBuilder, IPercentToMove, IData
        {
            // Required
            private string seekBarId;
            private double perc;

            private Data()
            { }

            public static ISeekBarId Get()
            {
                return new Data();
            }

            public IPercentToMove SetSeekBarId(string seekBarId)
            {
                this.seekBarId = seekBarId;
                return this;
            }

            public IDataBuilder SetPercentToMove(double perc)
            {
                if (perc > 1)
                {
                    this.perc = perc / 100;
                }
                else
                {
                    this.perc = perc;
                }
                return this;
            }

            public IData Build()
            {
                return this;
            }

            // Getters

            public string GetSeekBarId()            
            {
                return seekBarId;
            }

            public double GetPercentToMove()
            {
                return perc;
            }
           

        }
    }
}
