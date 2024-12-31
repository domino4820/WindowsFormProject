using Microsoft.Extensions.DependencyInjection;
using LauncherGames.BLL.Services;
using LauncherGames.BLL.Services.Interface;
using LauncherGames.DAL.Repository;
using LauncherGames.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace LauncherGames
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Register DbContext with the DI container
            services.AddDbContext<LauncherGamesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddLogging(configure => configure.AddConsole());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserGameDetailsService, UserGameDetailsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddScoped<IPurchaseService, PurchaseBLL>();

            services.AddTransient<LoginForm>();
            services.AddTransient<LauncherForm>();
            services.AddTransient<AdminForm>();
            services.AddTransient<ProfileForm>();
            services.AddTransient<AdminForm>();
        }
    }
}
