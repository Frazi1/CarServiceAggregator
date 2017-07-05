namespace DataAccess
{
    public interface IRepositorySettingCreator<T>
        where T : RepositorySettings
    {
        T Create();
    }
}
