namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// An interface for the models that are stored in the Redis KV-database.
    /// </summary>
    public interface IRedisModel
    {
        string ToRedisKey();
    }
}
