//using AutoMapper;
//using EmployeeManagment.BL.DTOs.AppUserDto;
//using EmployeeManagment.BL.Services.Abstractions;
//using EmployeeManagment.Core.Entities;
//using EmployeeManagment.Data.DAL;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Internal;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace EmployeeManagment.BL.Services.Implementations;

//public class AccountService : IAccountService
//{
//    private readonly UserManager<AppUser> _userManager;
//    private readonly IMapper _mapper;
//    private readonly AppDbContext _context;
//    private readonly SignInManager<AppUser> _signInManager;

//    public AccountService(UserManager<AppUser> userManager, IMapper mapper, AppDbContext context, SignInManager<AppUser> signInManager)
//    {
//        _userManager = userManager;
//        _mapper = mapper;
//        _context = context;
//        _signInManager = signInManager;
//    }
//    //public async Task<bool> LoginAsync(AppUserLoginDto appUserLoginDto)
//    //{
//    //    AppUser? user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
//    //    if (user == null)
//    //    {
//    //        throw new Exception("Not Found");
//    //    }
//    //    var result = await _signInManager.CheckPasswordSignInAsync(user,appUserLoginDto.Password,true);
//    //    if (!result.Succeeded)
//    //    {
//    //        return false;
//    //    }
//    //    string issuer = "https://localhost:7295";
//    //    string audience = "https://localhost:7295";
//    //    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1e520b6a-2b24-4eea-821f-58c5e771287a"));
//    //    SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.Sha256);

//    //    List<Claim> claims = new List<Claim>();
//    //    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
//    //    claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
//    //    claims.Add(new Claim(ClaimTypes.Name, user.UserName));

//    //    //JwtSer            24:58 
         
//    //}
//    public async Task<ICollection<AppUser>> GetAllUserAsync()
//    {
//        ICollection<AppUser> user = await _context.Set<AppUser>().ToListAsync();
//        return user;
//    }

//    public async Task<AppUser> GetUserByName(string name)
//    {
//        return await _context.Set<AppUser>()
//        .FirstOrDefaultAsync(x => x.FirstName == name);
//    }

    

//    public async Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto)
//    {
//        AppUser user = _mapper.Map<AppUser>(appUserCreateDto);
//        var result =  await _userManager.CreateAsync(user, appUserCreateDto.Password);
//        if (!result.Succeeded)
//        {
//            throw new Exception("Could not created");
//        }
//        return true;
//    }
//}
