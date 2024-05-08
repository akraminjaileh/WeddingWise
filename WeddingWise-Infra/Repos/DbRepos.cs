using WeddingWise_Core.Context;
using WeddingWise_Core.IDbRepos;

namespace WeddingWise_Infra.DbRepos
{
    public class DbRepos : IDbRepos
    {
        private readonly WeddingWiseDbContext context;

        public DbRepos(WeddingWiseDbContext context) => this.context = context;


        public void AddToDb(object obj)
        {
            context.Add(obj);
        }
        public void UpdateOnDb(object obj)
        {
            context.Update(obj);
        }
        public void DeleteFromDb(object obj)
        {
            context.Remove(obj);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }



    }
}
