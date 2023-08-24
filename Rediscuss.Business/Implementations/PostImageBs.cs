using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Hosting;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Implementations
{
    public class PostImageBs : IPostImageBs
    {
        private readonly IPostImageRepository _repo;
        private readonly IWebHostEnvironment _webhost;
        private readonly IMapper _mapper;

        public PostImageBs(IPostImageRepository repo, IWebHostEnvironment webhost, IMapper mapper)
        {
            _repo = repo;
            _webhost = webhost;
            _mapper = mapper;
        }


        public async Task<ApiResponse<List<PostImageGetDto>>> AddPostImageAsync(IFormFileCollection files, int postId)
        {
            ApiResponse<List<PostImageGetDto>> response = new();
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (!file.ContentType.StartsWith("image/"))
                        throw new BadRequestException("File must be an image");

                    var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                    var imagePath = $@"/PostImages/{randomFileName}";
                    var uploadPath = $@"{_webhost.ContentRootPath}/wwwroot{imagePath}";

                    using var fs = new FileStream(uploadPath, FileMode.Create);
                    file.CopyTo(fs);

                    var dto = new PostImagePostDto()
                    {
                        PostId = postId,
                        Base64Picture = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath)),
                        ImageRoute = imagePath
                    };

                    var image = _mapper.Map<PostImage>(dto);

                    var inserted = await _repo.InsertAsync(image);

                    var result = _mapper.Map<PostImageGetDto>(inserted);

                    response.Data.Add(result);
                    response.StatusCode = StatusCodes.Status201Created;
                    
                }

                return response;
            }
            throw new BadRequestException("You must upload a file");
        }
        public async Task<ApiResponse<PostImageGetDto>> AddPostImageAsync(PostImageUploadDto uploadDto, int postId)
        {
            var file = uploadDto.File;
            if (file != null)
            {
                   // if (!file.ContentType.StartsWith("image/"))
                    //    throw new BadRequestException("File must be an image");

                    var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                    var imagePath = $@"/PostImages/{randomFileName}";
                    var uploadPath = $@"{_webhost.ContentRootPath}/wwwroot{imagePath}";

                    using var fs = new FileStream(uploadPath, FileMode.Create);
                    file.CopyTo(fs);
                    fs.Dispose();
                    var dto = new PostImagePostDto()
                    {
                        PostId = postId,
                        Base64Picture = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath)),
                        ImageRoute = imagePath,
                        ContentType = uploadDto.ContentType
                    };

                    var image = _mapper.Map<PostImage>(dto);

                    var inserted = await _repo.InsertAsync(image);
                    inserted.ContentType = file.ContentType;
                    var result = _mapper.Map<PostImageGetDto>(inserted);
               


                return  ApiResponse<PostImageGetDto>.Success(StatusCodes.Status201Created, result);
            }
            throw new BadRequestException("You must upload a file");
        }

		public async Task<ApiResponse<NoData>> DeleteImages(int postId)
		{
			var patchDoc = new JsonPatchDocument<PostImage>();
			if (postId < 0)
				throw new BadRequestException("Id cannot be negative");

			var postImage = await _repo.GetImagesFromPostIdAsync(postId);
			if (postImage != null)
			{
				foreach(var image in postImage)
                {
                    patchDoc.Replace(p => p.IsActive, false);
					patchDoc.ApplyTo(image);
					await _repo.PatchAsync(image);
				}
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("Post images not found");
		}

		public async Task<ApiResponse<List<PostImageGetDto>>> GetImagesFromPostIdAsync(int postId, params string[] includeList)
        {
            if (postId < 0)
                throw new BadRequestException("Id cannot be negative");

            var posts = await _repo.GetImagesFromPostIdAsync(postId, includeList);
            var filtered = posts.Where(e => e.IsActive == true);
            if(filtered != null)
            {
				var dtoList = _mapper.Map<List<PostImageGetDto>>(posts);

				return ApiResponse<List<PostImageGetDto>>.Success(StatusCodes.Status200OK, dtoList);
			}
			throw new NotFoundException("Post images not found");
		}

	}
}
