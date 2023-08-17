using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }


// TODO WRITE SQL STRING AND METHOD IN REPO
    internal Ingredient GetIngredientById(int ingredientId)
    {
        throw new NotImplementedException();
    }
}
