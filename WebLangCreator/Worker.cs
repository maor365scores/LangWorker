using Microsoft.EntityFrameworkCore;

namespace WebLangCreator;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private SportifierDB _context;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker Started at: {Time}", DateTimeOffset.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<SportifierDB>();
                _context = scopedProcessingService;

                await Task.WhenAll(CreateAthletesInWebLang(),
                                   CreateCompetitorsInWebLang(),
                                   CreateCompetitionInWebLang(),
                                   CreateCountriesInWebLang());
            }

            await Task.Delay(10000, stoppingToken);
        }
    }

    public async Task CreateAthletesInWebLang()
    {
        var webLang = await _context.Languages.FirstOrDefaultAsync(x => x.Iso3LettersCode.Equals("WEB"));
        if (webLang is null)
        {
            return;
        }

        var athletesNameId = await _context.Athletes
                                           .Where(a => !_context.DictValues.Any(x => x.TermId == a.NameId &&
                                                                                     x.LangId == webLang.LanguageId))
                                           .Select(x => x.NameId)
                                           .ToListAsync();

        foreach (var nameId in athletesNameId)
        {
            var englishValue = _context.DictValues.FirstOrDefault(x => x.TermId == nameId && x.LangId == 1)?.Value;
            if (string.IsNullOrWhiteSpace(englishValue))
            {
                continue;
            }

            await
                _context.Database
                        .ExecuteSqlInterpolatedAsync($"EXECUTE [Dict].[AddValue] {nameId} , {webLang.LanguageId} , {englishValue} ,{1},{0} ,{null}");
            _logger.LogInformation("Added athlete {Name} to web lang", englishValue);
        }
    }

    public async Task CreateCompetitorsInWebLang()
    {
        var webLang = await _context.Languages.FirstOrDefaultAsync(x => x.Iso3LettersCode.Equals("WEB"));
        if (webLang is null)
        {
            return;
        }

        var nameIds = await _context.Competitors
                                    .Where(competitor => !_context.DictValues.Any(x => x.TermId == competitor.NameId &&
                                                                                       x.LangId == webLang.LanguageId))
                                    .Select(x => x.NameId)
                                    .ToListAsync();

        foreach (var nameId in nameIds)
        {
            var englishValue = _context.DictValues.FirstOrDefault(x => x.TermId == nameId && x.LangId == 1)?.Value;
            if (string.IsNullOrWhiteSpace(englishValue))
            {
                continue;
            }

            await
                _context.Database
                        .ExecuteSqlInterpolatedAsync($"EXECUTE [Dict].[AddValue] {nameId} , {webLang.LanguageId} , {englishValue} ,{1},{0} ,{null}");
            _logger.LogInformation("Added athlete {Name} to web lang", englishValue);
        }
    }

    public async Task CreateCompetitionInWebLang()
    {
        var webLang = await _context.Languages.FirstOrDefaultAsync(x => x.Iso3LettersCode.Equals("WEB"));
        if (webLang is null)
        {
            return;
        }

        var nameIds = await _context.Competitions
                                    .Where(competition => !_context.DictValues.Any(x => x.TermId == competition.NameId &&
                                                                                        x.LangId == webLang.LanguageId))
                                    .Select(x => x.NameId)
                                    .ToListAsync();

        foreach (var nameId in nameIds)
        {
            var englishValue = _context.DictValues.FirstOrDefault(x => x.TermId == nameId && x.LangId == 1)?.Value;
            if (string.IsNullOrWhiteSpace(englishValue))
            {
                continue;
            }

            await
                _context.Database
                        .ExecuteSqlInterpolatedAsync($"EXECUTE [Dict].[AddValue] {nameId} , {webLang.LanguageId} , {englishValue} ,{1},{0} ,{null}");
            _logger.LogInformation("Added athlete {Name} to web lang", englishValue);
        }
    }

    public async Task CreateCountriesInWebLang()
    {
        var webLang = await _context.Languages.FirstOrDefaultAsync(x => x.Iso3LettersCode.Equals("WEB"));
        if (webLang is null)
        {
            return;
        }

        var nameIds = await _context.Countries
                                    .Where(country => !_context.DictValues.Any(x => x.TermId == country.NameId &&
                                                                                    x.LangId == webLang.LanguageId))
                                    .Select(x => x.NameId)
                                    .ToListAsync();

        foreach (var nameId in nameIds)
        {
            var englishValue = _context.DictValues.FirstOrDefault(x => x.TermId == nameId && x.LangId == 1)?.Value;
            if (string.IsNullOrWhiteSpace(englishValue))
            {
                continue;
            }

            await
                _context.Database
                        .ExecuteSqlInterpolatedAsync($"EXECUTE [Dict].[AddValue] {nameId} , {webLang.LanguageId} , {englishValue} ,{1},{0} ,{null}");
            _logger.LogInformation("Added athlete {Name} to web lang", englishValue);
        }
    }
}