using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OptiMark.API.DTO;
using OptiMark.API.Services.Interfaces;
using OptiMark.DAL;
using OptiMark.DAL.Models;

namespace OptiMark.API.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly OptiMarkDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public AuthService(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        OptiMarkDbContext dbContext,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task RegisterAsync(RegisterDto dto)
    {
        // 1️⃣ Validate role
        var role = await _roleManager.FindByIdAsync(dto.RoleId)
                   ?? throw new ArgumentException("Invalid role.");

        if (role.Name == "Admin")
            throw new UnauthorizedAccessException("Admin role is restricted.");

        // 2️⃣ Validate company
        var companyExists = await _dbContext.Companies
            .AnyAsync(c => c.Id == dto.CompanyId);

        if (!companyExists)
            throw new ArgumentException("Invalid company.");

        // 3️⃣ Map DTO → AppUser
        var user = _mapper.Map<AppUser>(dto);
        user.CompanyId = dto.CompanyId;

        // 4️⃣ Create user
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException(
                string.Join(" | ", result.Errors.Select(e => e.Description))
            );

        // 5️⃣ Assign role
        await _userManager.AddToRoleAsync(user, role.Name!);
    }
}