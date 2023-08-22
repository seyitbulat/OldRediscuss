using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
    public class PostImageRepository : BaseRepository<PostImage, RediscussContext>, IPostImageRepository
    {
        public async Task<List<PostImage>> GetImagesFromPostIdAsync(int postId, params string[] includeList)
        {
            return await GetAllAsync(i => i.PostId == postId);
        }
    }
}
