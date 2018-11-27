namespace ThesisPrototype
{
    public struct CrudModels<M> where M : AbstractModel, new()
    {
        public ICreateModel CreateModel;
        public ISearchModel<M> SearchModel;
        public IUpdateModel UpdateModel;
        public IDeleteModel DeleteModel;
    }
}