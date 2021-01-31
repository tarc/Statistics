namespace Statistics.Domain
{
    public interface IStatistic<T>
    {
        void RecordValue(T observation);
    }
}
