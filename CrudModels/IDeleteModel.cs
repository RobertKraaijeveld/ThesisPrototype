namespace ThesisPrototype
{
    public interface IDeleteModel
    {
        string[] IdentifiersToDeleteOn { get; set; }

        string GetDeleteString(AbstractModel model);
    }
}