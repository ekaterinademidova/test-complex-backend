using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestComplex.API.Config;
using TestComplex.Database;

namespace TestComplex.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Authorization settings
        private string CorsSettings = "AllowSpecificOrigin";
        private string AllowedOrigins = "*";

        private string AuthSection => "auth";
        private AuthSettings _authSettings;
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddCors(options =>
            {
                options.AddPolicy(CorsSettings,
                    builder =>
                    {
                        builder
                            .WithOrigins(AllowedOrigins) // any origin
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            LoadSettings();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://{_authSettings.Domain}/";
                    options.Audience = _authSettings.Audience;
                });

            services.AddControllers();
        }

        /// <summary>
        /// Load settings from appsettings.json on application start.
        /// </summary>
        private void LoadSettings()
        {
            _authSettings = Configuration.GetSection(AuthSection).Get<AuthSettings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseRouting();

            app.UseCors(CorsSettings);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
