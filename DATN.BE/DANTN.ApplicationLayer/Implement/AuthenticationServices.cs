using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data.Dtos;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Configs;
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
            //var claims = new List<Claim>()
            //{
            //   new Claim("userId", userDto.Id.ToString()),
            //   new Claim("username", userDto.UserName),
            //   new Claim("fullname", userDto.FullName),
            //   new Claim("address",userDto.Address),
            //   new Claim("phone",userDto.Phone),
            //   new Claim("email",userDto.Email),
            //   new Claim("role", userDto.Roles.ToString())
            //   };

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //rsA

            //var token = new JwtSecurityToken(
            //   issuer: _configuration["Jwt:Issuer"],
            //   audience: _configuration["Jwt:Audience"],
            //   claims: claims,
            //    expires: DateTime.Now.AddHours(1),
            //    signingCredentials: creds);

            //return new SuccessResult(new JwtSecurityTokenHandler().WriteToken(token)).Token;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
         {
                   new Claim("userId", userDto.Id.ToString()),
                   new Claim("username", userDto.UserName),
                   new Claim("fullname", userDto.FullName),
                   new Claim("address",userDto.Address),
                   new Claim("phone",userDto.Phone),
                  new Claim("email",userDto.Email),
                  new Claim("role", userDto.Roles.ToString())
               });

            var tokenHandler = new JwtSecurityTokenHandler();
            var issuedAt = DateTime.Now;
            var sec = AppKeys.JWTSecretKey;
            var issuer = AppKeys.JWTIssuer;
            var audience = AppKeys.JWTAudience;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token = tokenHandler.CreateJwtSecurityToken(issuer: issuer, audience: audience, subject: claimsIdentity, notBefore: issuedAt,
                expires: DateTime.Now.AddMinutes(AppKeys.JWTTimeout), signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}