using AutoMapper;
using DamianTrans.Entities;
using DamianTrans.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DamianTrans.Services
{
    public interface IAccountService
    {
        void addUser(RegisterClientDto dto);
        Task<string> loginUser(LoginClientWorkerDto dto);
        void logoutClient();
    }

    public class AccountService : IAccountService
    {
        private readonly DamianTransDbContext _dbContext;
        private readonly IPasswordHasher<Client> _passwordHasherClient;
        private readonly IPasswordHasher<Worker> _passwordHasherWorker;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(DamianTransDbContext dbContext, IPasswordHasher<Client> passwordHasherClient, IPasswordHasher<Worker> passwordHasherWorker, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _passwordHasherClient = passwordHasherClient;
            _passwordHasherWorker = passwordHasherWorker;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> loginUser(LoginClientWorkerDto dto)
        {
            var user = _dbContext.Clients.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);
            var worker = _dbContext.Workers.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);
            string errorMessage = "";

            if (worker is null)
            {
                if (user is null)
                {
                    errorMessage = "Invalid username or password!";
                    return errorMessage;
                }
            }

            if (user != null)
            {
                var resultUser = _passwordHasherClient.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

                if (resultUser == PasswordVerificationResult.Failed)
                {
                    errorMessage = "Invalid username or password!";
                    return errorMessage;
                }
            }

            if (worker != null)
            {
                var resultUser = _passwordHasherWorker.VerifyHashedPassword(worker, worker.PasswordHash, dto.Password);

                if (resultUser == PasswordVerificationResult.Failed)
                {
                    errorMessage = "Invalid username or password!";
                    return errorMessage;
                }
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, worker is null ? user.Id.ToString() : worker.Id.ToString()),
                new Claim(ClaimTypes.Name,  worker is null ? $"{user.Name} {user.Surname}" : $"{worker.Name} {worker.Surname}"),
                new Claim(ClaimTypes.Role, worker is null ? $"{user.Role.Name}" : $"{user.Role.Name}")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);

            return errorMessage;
        }

        public async void logoutClient()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
        public void addUser(RegisterClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);

            var hashedPassword = _passwordHasherClient.HashPassword(client, dto.PasswordHash);

            client.PasswordHash = hashedPassword;

            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }
    }
}
