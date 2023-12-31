namespace Allspice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService)
    {
        _accountService = accountService;
        _auth0Provider = auth0Provider;
        _favoritesService = favoritesService;
    }

    [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpGet("favorites")]
  public async Task<ActionResult<List<RecipeFavorite>>> GetAccountFavorites()
  {
    try 
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<RecipeFavorite> favorites = _favoritesService.GetAccountFavorites(userInfo.Id);
      return Ok(favorites);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut]
  public async Task<ActionResult<Account>> Edit([FromBody] Account editData)
  {
    try 
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      
      Account account = _accountService.Edit(editData, userInfo.Email);
      return Ok(account);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
