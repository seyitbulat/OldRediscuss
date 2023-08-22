using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
    public interface IPostImageRepository : IBaseRepository<PostImage>
    {
        Task<List<PostImage>> GetImagesFromPostIdAsync(int postId, params string[] includeList);
    }
}
