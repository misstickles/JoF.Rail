namespace JoF.Rail.Core.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.KnowledgeBase;

    public interface IKnowledgeBaseTokenService
    {
        Task<TokenModel> Get(string user, string key, string url);
    }
}