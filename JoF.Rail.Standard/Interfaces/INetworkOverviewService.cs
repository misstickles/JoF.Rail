namespace JoF.Rail.Standard.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.KnowledgeBase;

    public interface IKnowledgeBase<T>
        where T : class
    {
        Task<T> Get(KnowledgeBaseQuery query);
    }
}
