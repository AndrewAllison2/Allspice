
namespace Allspice.Models;

public class Favorite
{
    public int Id { get; set; }
    public string AccountId { get; set; }
    public int RecipeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class RecipeFavorite : Favorite
{
  public int FavoriteId { get; set; }
}

public class AccountFavorite : Account
{
  public int FavoriteId { get; set; }
}
