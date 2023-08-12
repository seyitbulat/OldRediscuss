using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Interfaces
{
	public interface ICommentBs
	{
		Task<ApiResponse<CommentGetDto>> GetByIdAsync(int id, params string[] includeList);
		Task<ApiResponse<List<CommentGetDto>>> GetByPostIdAsync(int postId, params string[] includeList);

		Task<ApiResponse<Comment>> AddCommentAsync(CommentPostDto dto);
		Task<ApiResponse<NoData>> DeleteCommentAsync(int id);
	}
}
