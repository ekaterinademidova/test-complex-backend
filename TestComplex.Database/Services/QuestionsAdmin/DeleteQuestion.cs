using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.QuestionsAdmin
{
    [Service]
    public class DeleteQuestion
    {
        private readonly IQuestionManager _questionManager;

        public DeleteQuestion(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public Task<int> Do(long id)
        {
            return _questionManager.DeleteQuestion(id);
        }
    }
    
}
