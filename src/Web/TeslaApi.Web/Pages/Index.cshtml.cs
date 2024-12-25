namespace RazorPagesMovie.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITeslaAuthentication _tesla;

    public IndexModel(ILogger<IndexModel> logger, ITeslaAuthentication tesla)
    {
        _logger = logger;
        _tesla = tesla;
    }

    public void OnGet()
    {
    }

    public async Task<JsonResult> OnPostAsync()
    {
        var (verifier, challenge) = Pkce.PkceChallenge(86);
        Console.WriteLine(verifier);

        var request = new AuthorizeEndPointRequest("ownerapi", "S256", "https://auth.tesla.com/void/callback", "code", "openid email offline_access", "123", challenge);
        var url = await _tesla.GetAuthorizeEndPoint(request);

        var result = new { verifier = verifier, url = url };
        return new JsonResult(result);
    }
}
