using Microsoft.AspNetCore.Mvc;
using PlatziEntityFramework;
using PlatziEntityFramework.Model;

namespace WebApi.Service
{
    public class WorkService
    {

        WorkContext context;

        public WorkService(WorkContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Work> Get()
        {
            return context.Works;
        }

        public async Task Save(Work Work)
        {
            context.Add(Work);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Work Work)
        {
            var WorkNow = context.Works.Find(id);

            if (WorkNow == null)
            {

                WorkNow.Title = Work.Title;
                WorkNow.Description = Work.Description;
                WorkNow.Priority = Work.Priority;
                WorkNow.DateCreate = Work.DateCreate;
                WorkNow.comentary = Work.comentary;
                WorkNow.CategoryId = Work.CategoryId;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var WorksNow = context.Works.Find(id);

            if (WorksNow == null)
            {
                context.Remove(WorksNow);
                await context.SaveChangesAsync();
            }
        }

        public interface IWorkService
        {
            IEnumerable<Work> Get();

            Task Save(Work Work);

            Task Update(Guid id, Work Work);

            Task Delete(Guid id);
        }
    }
}
