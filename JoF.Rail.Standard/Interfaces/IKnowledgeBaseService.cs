namespace JoF.Rail.Standard.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.KnowledgeBase;

    public interface IKnowledgeBaseService<T>
        where T : class
    {
        Task<T> Get(KnowledgeBaseQuery query);
    }
}
