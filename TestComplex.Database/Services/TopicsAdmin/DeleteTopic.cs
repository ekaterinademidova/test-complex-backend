using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.TopicsAdmin
{
    [Service]
    public class DeleteTopic
    {
        private readonly ITopicManager _topicManager;

        public DeleteTopic(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public Task<int> Do(long id)
        {
            return _topicManager.DeleteTopic(id);
        }
    }
    
}
