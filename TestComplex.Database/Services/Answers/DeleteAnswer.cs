using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Answers
{
    public class DeleteAnswer
    {
        private readonly IAnswerManager _answerManager;

        public DeleteAnswer(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public Task<int> Do(long id)
        {
            return _answerManager.DeleteAnswer(id);
        }
    }
    
}
