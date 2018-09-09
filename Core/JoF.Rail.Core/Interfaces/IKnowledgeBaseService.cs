namespace JoF.Rail.Core.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.KnowledgeBase;

    public interface IKnowledgeBaseService<T>
        where T : class
    {
        Task<T> Get(KnowledgeBaseQuery query);
    }
}
