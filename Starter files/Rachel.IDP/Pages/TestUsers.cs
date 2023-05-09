// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace Rachel.IDP;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = 69118,
                country = "Germany"
            };

            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Rachel",
                    Password = "alice",
                    Claims =
                    {
                        new Claim("role", "FreeUser"),
                        new Claim(JwtClaimTypes.Name, "Rachel Aumaugher"),
                        new Claim(JwtClaimTypes.GivenName, "Rachel"),
                        new Claim(JwtClaimTypes.FamilyName, "Aumauhger"),
                        new Claim(JwtClaimTypes.Email, "rachel.aumaugher@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Adam",
                    Password = "bob",
                    Claims =
                    {
                        new Claim("role", "PayingUser"),
                        new Claim(JwtClaimTypes.Name, "Adam Mizgalski"),
                        new Claim(JwtClaimTypes.GivenName, "Adam"),
                        new Claim(JwtClaimTypes.FamilyName, "Mizgalski"),
                        new Claim(JwtClaimTypes.Email, "amizg@umich.edu"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };
        }
    }
}