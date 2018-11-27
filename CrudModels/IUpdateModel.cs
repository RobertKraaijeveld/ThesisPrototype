namespace ThesisPrototype
{
    public interface IUpdateModel
    {
        string GetUpdateString(AbstractModel newModel);

        string[] IdentifiersToFilterOn { get; set; }
    }
}