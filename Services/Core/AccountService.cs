using AutoMapper;
using Data.FMDbContext;
using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace Services.Core
{
    public interface IAccountService
    {
        public Task<ResultModel> Login(LoginModel model);
        public Task<ResultModel> Register(UserRegisterModel model, string role);
    }

    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, AppDbContext appDbContext, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _configuration = configuration;

            FirebaseConfig fbconfig = new FirebaseConfig();
            _configuration.Bind("Firebase", fbconfig);
          
            var json = JsonConvert.SerializeObject(fbconfig);
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(json)
            });

        }

        public object GenerateJwtToken(IdentityUser user, string role)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role),
                //new Claim(ClaimTypes.GivenName, fullname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuerOptions:Issuer"],
                _configuration["JwtIssuerOptions:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ResultModel> Login(LoginModel model)
        {
            var result = new ResultModel();
            /*try
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (signInResult.Succeeded)
                {
                    var appUser = _userManager.Users.FirstOrDefault(u => u.UserName == model.Username);
                    var rolesUser = await _userManager.GetRolesAsync(appUser);
                    //var fullname = appUser.Fullname;
                    var token = GenerateJwtToken(appUser, rolesUser[0]);
                    LoginSuccessModel successModel = new LoginSuccessModel()
                    {
                        Fullname = appUser.Fullname,
                        Role = rolesUser[0],
                        Token = token
                    };
                    result.Data = successModel;
                    result.Success = true;
                }
                else
                {
                    throw new Exception("Invalid Username or Password");
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }*/
            return result;
        }
        public async Task<ResultModel> Register(UserRegisterModel model, string role)
        {
            var result = new ResultModel();
            /* try
             {
                 FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(model.IdToken);
                 string uid = decodedToken.Uid;


                 var isExistUsername = _appDbContext.Users.Any(u => u.UserName == uid);
                 if (isExistUsername)
                 {
                     throw new Exception("User existed");
                 }
                 User user = _mapper.Map<UserRegisterModel, User>(model);
                 var createUser = await _userManager.CreateAsync(user, model.Password);


                 if (createUser.Succeeded)
                 {
                     await _userManager.AddToRoleAsync(user, role);
                     _appDbContext.SaveChanges();
                     result.Data = user.Id;
                     result.Success = true;
                 }
                 else
                 {
                     throw new Exception("Register failed");
                 }

             }
             catch (Exception e)
             {
                 result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
             }*/
            return result;
        }

        public async Task<ResultModel> SignInWithGoogle(UserRegisterModel model, string role)
        {

            var result = new ResultModel();

            try
            {
                var idToken = "";

                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);

            }
            catch { }

            return result;
        }
    
    }
}
