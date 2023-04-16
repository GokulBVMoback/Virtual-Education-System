using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace Rudra.Web
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
		{
			app.MapHubs();
			// Configure the db context, user manager and signin manager to use a single instance per request

			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			//app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

			// Enable the application to use a cookie to store information for the signed in user
			// and to use a cookie to temporarily store information about a user logging in with a third party login provider
			// Configure the sign in cookie
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
				Provider = new CookieAuthenticationProvider
				{
					// Enables the application to validate the security stamp when the user logs in.
					// This is a security feature which is used when you change a password or add an external login to your account.  

					//OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
					//    validateInterval: TimeSpan.FromMinutes(30),
					//    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))

				}
			});
			//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			//app.UseFacebookAuthentication(
			//appId: "1676442252375883",
			//appSecret: "307fb84249d2eaccba6a8c718f320c6b");

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//    ClientId = "656925394654-fas6dpoakmiskvrjvbi4jh5hjbock0gv.apps.googleusercontent.com",
			//    ClientSecret = "vo11vXVpOkRn08niTlv1enmq"
			//});


		}
	}
}