using WebApi.Model;

namespace WebApi.Service
{
    public class CategoryService : ICategoryService
    {

        WorkContext context;

        public CategoryService(WorkContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }

        public async Task Save(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id,Category category)
        {
            var CategoryNow = context.Categories.Find(id);

            if(CategoryNow == null)
            {
                CategoryNow.Name = category.Name;
                CategoryNow.Description = category.Description;
                CategoryNow.Weigth = category.Weigth;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var CategoryNow = context.Categories.Find(id);

            if (CategoryNow == null)
            {
                context.Remove(CategoryNow);
                await context.SaveChangesAsync();
            }
        }
 
    }
    public interface ICategoryService
    {
        IEnumerable<Category> Get();

        Task Save(Category category);

        Task Update(Guid id, Category category);

        Task Delete(Guid id);

    }
}
