namespace ThesisPrototype
{
    public interface ICreateCollectionModel<M> where M : AbstractModel, new()
    {
        string GetCreateCollectionText();
    }
}