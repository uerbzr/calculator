using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using workshop.calculator;

namespace workshop.winui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();
        services.AddSingleton<Calculator>();
        services.AddTransient<MainWindow>();

        var provider = services.BuildServiceProvider();
        var mainWindow = provider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);

        //var services = new ServiceCollection();
        //ConfigureServices(services);
        //ServiceProvider = services.BuildServiceProvider();

        //var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        //mainWindow.Show();

        //base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<Calculator>(); // 👈 Register your service
        services.AddTransient<MainWindow>(); // 👈 Register your main window
    }
}

