﻿using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using System.Security.Claims;

namespace Rediscuss.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserBs _userBs;
        private readonly IConfiguration _configuration;

        public UsersController(IUserBs userBs, IConfiguration configuration)
        {
            _userBs = userBs;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userBs.GetAllUsers();
            return await SendResponse(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _userBs.GetByIdAsync(id);
            return await SendResponse(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var response = await _userBs.LoginAsync(dto.UserName, dto.Password);

            var claims = new List<Claim>();
            claims.Add(new Claim("userName", response.Data.Username));
            claims.Add(new Claim("userId", response.Data.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, UserRoles.User));

            var accessToken = new JwtGenerator(_configuration).CreateAccessToken(claims);
            response.Data.Token = accessToken.Token;

            return await SendResponse(response);
        }

        [HttpPost("adminLogin")]
        public async Task<IActionResult> AdminLogin([FromBody] UserLoginDto dto)
        {
            var response = await _userBs.AdminLoginAsync(dto.UserName, dto.Password);

            var claims = new List<Claim>();
			claims.Add(new Claim("userName", response.Data.Username));
			claims.Add(new Claim("userId", response.Data.UserId.ToString()));
			claims.Add(new Claim(ClaimTypes.Role, UserRoles.Admin));

			var accessToken = new JwtGenerator(_configuration).CreateAccessToken(claims);
			response.Data.Token = accessToken.Token;

			return await SendResponse(response);
		}

        [HttpPost("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] UserSignupDto dto)
        {
            var response = await _userBs.SignUpAsync(dto);

            var claims = new List<Claim>();
            claims.Add(new Claim("userName", response.Data.Username));
            claims.Add(new Claim("userId", response.Data.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, UserRoles.User));

            var accessToken = new JwtGenerator(_configuration).CreateAccessToken(claims);
            response.Data.Token = accessToken.Token;
            return await SendResponse(response);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] int id)
        {
            var response = await _userBs.DeleteUserAsync(id);
            return await SendResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UserPutDto dto)
        {
            var response = await _userBs.UpdateUserAsync(dto);
            return await SendResponse(response);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchAsync([FromForm] UserPutDto dto)
        {

            var response = await _userBs.PatchUserAsync(dto);

            return await SendResponse(response);
        }

        [HttpPatch("profileSetup")]
        public async Task<IActionResult> ProfileSetupAsync([FromForm] UserSetUpDto dto)
        {
            var respnse = await _userBs.ProfileSetupAsync(dto);
            return await SendResponse(respnse);
        }
    }
}
