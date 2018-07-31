namespace JoF.Rail.Standard.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.KnowledgeBase;

    public interface IKnowledgeBaseTokenService
    {
        Task<TokenModel> Get(string user, string key, string url);
    }
}