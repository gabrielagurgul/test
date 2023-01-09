using Microsoft.AspNetCore.Mvc;

namespace RapidRevelopment.KeyVault.Abstract.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{
    private readonly ILogger<SecretController> _logger;
    private readonly IConfiguration _config;

    public SecretController(ILogger<SecretController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet]
    public IEnumerable<SecretModel> Get()
    {
        yield return new SecretModel()
        {
            Key = "ConnectionStrings:SampleConnectionString",
            Value = _config.GetValue<string>("ConnectionStrings:SampleConnectionString")
        };

        yield return new SecretModel()
        {
            Key = "AppSettings:SampleSecret",
            Value = _config.GetValue<string>("AppSettings:SampleSecret")
        };

        yield return new SecretModel()
        {
            Key = "AppSettings:SampleKey",
            Value = _config.GetValue<string>("AppSettings:SampleKey")
        };

         yield return new SecretModel()
        {
            Key = "AppSettings:SampleCertificate",
            Value = _config.GetValue<string>("AppSettings:SampleCertificate")
        };
    }

    [HttpGet("{variableName}")]
    public SecretModel Get(string variableName)
    {
        return new SecretModel()
        {
            Key = variableName,
            Value = _config.GetValue<string>(variableName)
        };
    }
}
