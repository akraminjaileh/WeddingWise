namespace WeddingWise_Core.IDbRepos
{
    public interface IDbRepos
    {

        //DataBase Modify
        Task<int> SaveChangesAsync();
        void AddToDb(object obj);
        void UpdateOnDb(object obj);
        void DeleteFromDb(object obj);
    }
}
