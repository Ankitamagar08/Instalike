using API.Entities;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using API.Interfaces;
using System.Security.Claims;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Cryptography;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens; 
//using System.IdentityModel.Tokens;

using Microsoft.AspNetCore.Authentication.JwtBearer; 
//using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey key1;
        public TokenService(IConfiguration config)
        {
             key1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                 new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };

            var creds = new SigningCredentials(key1,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
             };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}