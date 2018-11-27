using System.Collections.Generic;

namespace ThesisPrototype
{
    public interface ISearchModel<M> where M : AbstractModel, new()
    {
        string GetSearchString();

        // Used when needing to prepare many searches at once without knowing the derived type of an ISearchModel
        ISearchModel<M> Clone();

        Dictionary<string, object> IdentifiersAndValuesToSearchFor { get; set; }
    }
}

