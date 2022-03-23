using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Categories
{
    public class DeleteCategory
    {
        private readonly ICategoryManager _categoryManager;

        public DeleteCategory(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public Task<int> Do(long id)
        {
            return _categoryManager.DeleteCategory(id);
        }
    }
    
}
