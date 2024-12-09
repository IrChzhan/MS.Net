using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BL.Auth.Entities;
using BookStore.BL.Users.Entity;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using IdentityModel.Client;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.BL.Auth;

public class AuthProvider (SignInManager<User> signInManager, UserManager<User> userManager, IHttpClientFactory httpClientFactory, string identityServerUri, string clientId, string clientSecret, IMapper mapper) : IAuthProvider
{
    public async Task<TokensResponce> AuthorizeUser(string login, string password)
    {
        var user = await userManager.FindByNameAsync(login);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var verificationResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!verificationResult.Succeeded)
        {
            throw new Exception("Password is incorrect");
        }
        
        var client = httpClientFactory.CreateClient();
        var discoveryDoc = await client.GetDiscoveryDocumentAsync(identityServerUri);
        if (discoveryDoc.IsError)
        {
            throw new Exception("Identity servor error");
        }
        
        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDoc.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = clientId,
            ClientSecret = clientSecret,
            UserName = user.Name!,
            Password = password,
            Scope = "api offline_access"
        });
        if (tokenResponse.IsError)
        {
            throw new Exception();
        }
        return new TokensResponce
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken,
        };
    }

    public async Task<UserModel> RegisterUser(string login, string password)
    {
        var existUser = await userManager.FindByNameAsync(login);
        if (existUser != null)
        {
            throw new Exception("User exists");
        }

        var user = new User
        {
            Login = login
        };

        var result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new Exception("User creation fail");
        }

        var createdUser = await userManager.FindByNameAsync(login);
        return mapper.Map<UserModel>(createdUser);
    }
}