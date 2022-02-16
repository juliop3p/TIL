using Microsoft.AspNetCore.Mvc;

namespace CustomResponses.Controllers;


public class ProductController : MainController
{
  private static List<string> products = new List<string> { "Pc Gamer", "Redmi 9", "Notebook" };

  [HttpGet]
  public ActionResult<string[]> GetProducts()
  {
    return CustomResponse(200, products);
  }

  [HttpGet("{index}")]
  public ActionResult<string> GetProduct(int index)
  {
    if (index > products.Count())
      return CustomResponse(400, null, "Index Inválido");

    return CustomResponse(200, products[index]);
  }

  [HttpPost]
  public ActionResult CreateProduct(string product)
  {
    products.Add(product);

    return CustomResponse(201, product);
  }

  [HttpPut]
  public ActionResult UpdateProduct(int index, string product)
  {
    string[] errors = { "Index Inválido", "Teste" };

    if (index >= products.Count())
      return CustomResponse(400, null, errors);

    products[index] = product;

    return CustomResponse(204);
  }

  [HttpDelete]
  public ActionResult DeleteProduct(string product)
  {
    products.Remove(product);

    return CustomResponse(204);
  }
}
