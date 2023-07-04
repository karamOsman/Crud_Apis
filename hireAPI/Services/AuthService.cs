using hireAPI.Helpers;
using hireAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hireAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly JWT _jWT;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager= userManager;
            _roleManager = roleManager;
            _jWT = jwt.Value;
        }
     

        public async Task<AuthModel> RegisterAsync(RegisterModel registerModel)
        {
            if (await _userManager.FindByEmailAsync(registerModel.Email) is not null) 
                return new AuthModel { Message ="Email is already registered!"};

            if (await _userManager.FindByNameAsync(registerModel.English_Name) is not null)
                return new AuthModel { Message = "Name is already registered!" };
                
            var user=new User {
                Email = registerModel.Email,
                English_Name = registerModel.English_Name ,
                Arabic_Name=registerModel.Arabic_Name,
                Mobile=registerModel.Mobile,
                UserName=registerModel.Email
            };
            var resault=await _userManager.CreateAsync(user, registerModel.Password);
            if (!resault.Succeeded)
            {
                string Errors = string.Empty;
                foreach(var error in resault.Errors)
                {
                    Errors += $"{error.Description},";
                }
                return new AuthModel { Message = Errors };

            }
            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecuritytoken = await CreateJwtToken(user);
            return new AuthModel
            {
                Email = user.Email,
                ExpireOn = jwtSecuritytoken.ValidTo,
                isAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecuritytoken),
                UsreName = user.UserName
            };
        }




        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null || !await _roleManager.RoleExistsAsync(model.Role))
            { 
                return "invalid User Id oR Role ";
            }

            if (await _userManager.IsInRoleAsync(user, model.Role)) 
            {
                return "User Already Assigned In this Role";
            }
            var resault = await _userManager.AddToRoleAsync(user, model.Role);

            //if (resault.Succeeded)
            
            //    return string.Empty;

            //return "sometind With Wrong";

            //OR 
            return resault.Succeeded ? string.Empty : "sometind With Wrong";

        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims=await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles) 
            {
                roleClaims.Add(new Claim("roles", role));
            }
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,user.English_Name),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim("uid",user.Id)
           }
            .Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.Key));
            var signingcredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWT.Issuer,
                audience: _jWT.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jWT.DurationInDays),
                signingCredentials: signingcredentials
                );
            return jwtSecurityToken;
        } 




























        public Task<bool> RevokeTokenAsync(string Token)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authmodel= new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password)) 
            {
                authmodel.Message = "Email Or Password is incorrect";
                return authmodel;
            }
             
            var jwtsecurityToken = await CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user);


            authmodel.isAuthenticated = true;
            authmodel.Token=new JwtSecurityTokenHandler().WriteToken(jwtsecurityToken);
            authmodel.Email = user.Email;
            authmodel.UsreName = user.UserName;
            authmodel.ExpireOn = jwtsecurityToken.ValidTo;

            authmodel.Roles = roleList.ToList();
            return authmodel;
        }

        public Task<AuthModel> RefreshTokenAsync(string Token)
        {
            throw new NotImplementedException();
        }

     
    }
}
