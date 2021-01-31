using System.Collections.Generic;

namespace Statistics.Domain
{
    public class Sample<T>
    {
        List<IStatistic<T>> _statistics = new List<IStatistic<T>>();

        public Sample<T> SetStatistic(IStatistic<T> statistic)
        {
            _statistics.Add(statistic);

            return this;
        }

        public Sample<T> Add(T observation)
        {
            foreach(var statistic in _statistics)
            {
                statistic.RecordValue(observation);
            }

            return this;
        }
    }
}
