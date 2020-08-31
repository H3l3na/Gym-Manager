using GymManager3.WebAPI.Database;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GymManager3.Model;
using Administracija = GymManager3.Model.Administracija;
using Swashbuckle.AspNetCore.Swagger;
using Polaznik = GymManager3.Model.Polaznik;
using Trener = GymManager3.Model.Trener;

namespace GymManager3.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAdministracijaService _service;
        private readonly IPolaznikService _servicePolaznik;
        private readonly ITreneriService _serviceTreneri;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAdministracijaService service, 
            IPolaznikService servicePolaznik,
            ITreneriService serviceTreneri)
            : base(options, logger, encoder, clock)
        {
            _service = service;
            _servicePolaznik = servicePolaznik;
            _serviceTreneri = serviceTreneri;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            Administracija user=null;
            Polaznik p = null;
            Trener t = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                user = _service.Authenticiraj(username, password);
                p = _servicePolaznik.Authenticiraj(username, password);
                t = _serviceTreneri.Authenticiraj(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null && p==null && t== null)
                return AuthenticateResult.Fail("Invalid Username or Password");


            if (user != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme),
                new Claim(ClaimTypes.Name, user.Ime),
               };
                claims.Add(new Claim(ClaimTypes.Role, user.Uloga));

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            if (p != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, p.KorisnickoIme),
                new Claim(ClaimTypes.Name, p.Ime),
               };
                claims.Add(new Claim(ClaimTypes.Role, p.Uloga));

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            if (t != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, t.KorisnickoIme),
                new Claim(ClaimTypes.Name, t.Ime),
               };
                claims.Add(new Claim(ClaimTypes.Role, t.Uloga));

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("Invalid Username or Password");


        }
    }
}