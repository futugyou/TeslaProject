using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeslaApi.SDK;
using TeslaApi.Contract;
using TeslaApi.Contract.Authentication;

namespace RazorPagesMovie.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITeslaAuthentication _tesla;

    public string TeslaUrl { get; private set; } = "";

    public IndexModel(ILogger<IndexModel> logger, ITeslaAuthentication tesla)
    {
        _logger = logger;
        _tesla = tesla;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        var (verifier, challenge) = Pkce.PkceChallenge(86);
        Console.WriteLine(verifier);
        var request = new AuthorizeEndPointRequest("ownerapi", "S256", "https://auth.tesla.com/void/callback", "code", "openid email offline_access", "123", challenge);
        var url = await _tesla.GetAuthorizeEndPoint(request);
        TeslaUrl = url;
        return new RedirectResult(url, false);
    }
}
