using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0Provider;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
      try
      {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.CreateRecipe(recipeData);
      return Ok(recipe);
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes()
    {
      try
      {
      List<Recipe> recipes = _recipesService.GetRecipes();
      return Ok(recipes);
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
      try
      {
      Recipe recipe = _recipesService.GetRecipeById(recipeId);
      return recipe;
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{recipeId}")]

    public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe recipeData, int recipeId)
    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.UpdateRecipe(recipeId, recipeData);
      return Ok(recipe);
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{recipeId}")]

    public async Task<ActionResult<string>> RemoveRecipe(int recipeId)
    {
      try
      {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      _recipesService.RemoveRecipe(recipeId, userInfo.Id);
      return Ok("This recipe has been deleted!");
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
    }
}
