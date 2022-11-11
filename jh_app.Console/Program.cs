using jh_app.DataAccess;
using jh_app.Domain.Contracts;
using jh_app.Domain.Enums;
using jh_app.Domain.Extensions;
using jh_app.Domain.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;


Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
{
    e.Cancel = true;
    Environment.Exit(0);
});

var _services = new ServiceCollection();
ConfigureServices(_services);
using (var serviceProvider = _services.BuildServiceProvider())
{
    ILogger<Program> _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
    try
    {
        _logger.LogInformation("Program START");

        Console.WriteLine("*** Welcome to TweetStats ***");
        Console.WriteLine("0: All Stat Types");
        int index = 1;
        foreach (StatsType statsType in Enum.GetValues(typeof(StatsType)))
        {
            Console.WriteLine($"{index}: {statsType.Description()}");
            index++;
        }

        ITwitterAPIWrapper app = serviceProvider.GetRequiredService<ITwitterAPIWrapper>();
        app.ReportingTypes = GetStatsTypesInput(_logger);
        app.IncludeHistoricalReporting = GetHistoricalReportingInput(_logger);
        app.ProcessVolumeStreams();

    }
    catch (Exception ex)
    {
        _logger.LogError("Failute running ProcessVolumeStreams");
        _logger.LogError(ex.Message);
    }
    finally
    {
        _logger.LogInformation("Program END");
    }
}


void ConfigureServices(ServiceCollection services)
{
    services.AddTransient<ITwitterAPIWrapper, TwitterAPIWrapper>();
    services.AddTransient<IStatsProcessing, StatsProcessing>();

    services.AddLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
        logging.AddDebug();
        logging.AddNLog("nlog.config");
    });

    IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
    services.Configure<Program>(configuration);
    services.AddSingleton<IConfiguration>(provider => configuration);
}

List<StatsType> GetStatsTypesInput(ILogger<Program> logger)
{
    
    List<StatsType> statsTypes = new List<StatsType>();
    try
    {
        Console.WriteLine("Please choose one or more stat reports by entering a comma separated list of the above options:");
        bool isValid = false;
        while (!isValid)
        {
            //read input;
            string? input = Console.ReadLine();
            string[] inputSplit = input?.Split(',') ?? Array.Empty<string>();

            foreach (string i in inputSplit)
            {
                string iTrim = i.Trim();
                if (!string.IsNullOrEmpty(iTrim))
                {
                    int result;
                    var statTypeValues = Enum.GetValues(typeof(StatsType)).Cast<StatsType>();
                    if (int.TryParse(iTrim, out result)
                        && (result == 0
                        || (result - 1 >= (int)statTypeValues.Min()
                            && result - 1 <= (int)statTypeValues.Max())))
                    {
                        isValid = true;
                        if (result == 0)
                        {
                            statsTypes.Clear();
                            statsTypes.AddRange(statTypeValues);
                            break;
                        }
                        else
                        {
                            if (!statsTypes.Contains((StatsType)(result - 1)))
                            {
                                statsTypes.Add((StatsType)(result - 1));
                            }
                        }
                    }
                    else
                    {
                        isValid = false;
                        statsTypes = new List<StatsType>();
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError("Failute running GetStatsTypesInput");
        logger.LogError(ex.Message);
        statsTypes = new List<StatsType>();
    }
    return statsTypes.OrderBy(p => (int)p).ToList();
}

bool GetHistoricalReportingInput(ILogger<Program> logger)
{
    bool includeHistoricalReporting = false;
    try
    {
        Console.WriteLine("Would you like historical reporting? Enter Y or N;");
        bool isValid = false;
        while (!isValid)
        {
            string histInput = Console.ReadLine();
            if (histInput.Trim().ToUpper() == "Y")
            {
                isValid = true;
                includeHistoricalReporting = true;
            }
            else if (histInput.Trim().ToUpper() == "N")
            {
                isValid = true;
                includeHistoricalReporting = false;
            }
            else
            {
                isValid = false;
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError("Failute running GetHistoricalReportingInput");
        logger.LogError(ex.Message);
    }

    return includeHistoricalReporting;
}