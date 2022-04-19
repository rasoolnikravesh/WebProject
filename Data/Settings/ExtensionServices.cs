using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Settings
{
    public static class ExtensionServices
    {
		public static void AddConfigContext(this IServiceCollection services, string connectionString)
        {
			services.AddDbContext<Data.DatabaseContext>(opts =>
			{
				opts.UseSqlServer(connectionString);
			});
		}

        public static void AddConfigIdentity(this IServiceCollection services)
		{
			IdentityBuilder builder =
				services.AddIdentity<Models.ApplicationUser, Models.ApplicationRole>(option =>
				{
					option.Password.RequireDigit = false;
					option.Password.RequireLowercase = false;
					option.Password.RequireUppercase = false;
					option.Password.RequireNonAlphanumeric = false;
					option.Password.RequiredLength = 5;
					option.User.RequireUniqueEmail = true;

					option.SignIn.RequireConfirmedAccount = true;
				}).AddRoles<Models.ApplicationRole>();
					
			builder =
				new IdentityBuilder
				(builder.UserType, typeof(Models.ApplicationRole), builder.Services);

			builder.AddEntityFrameworkStores<Data.DatabaseContext>()
				.AddDefaultTokenProviders();
		}
	}
}
