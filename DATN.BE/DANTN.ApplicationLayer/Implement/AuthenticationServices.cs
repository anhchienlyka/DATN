using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data.Dtos;
using DATN.Data.Viewmodel.AccountViewModel;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationServices(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;

        }
        public async Task<string> GenerateNewToken(UserDto userDto)
        {
            var roles = new List<string>();
            foreach (var role in userDto.Roles)
            {
                roles.Add(role.ToString());
            }

            var claims = new List<Claim>()
            {
                new Claim("userId", userDto.Id.ToString()),
                new Claim("username", userDto.UserName),
                new Claim("fullname", userDto.FullName),
                new Claim("address",userDto.Address),
                new Claim("phone",userDto.Phone),
               new Claim("email",userDto.Email)
               };

            foreach (var roleItem in roles)
            {
                claims.Add(new Claim("role", roleItem));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //rsA

            var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new SuccessResult(new JwtSecurityTokenHandler().WriteToken(token)).Token;
        }
    }
}