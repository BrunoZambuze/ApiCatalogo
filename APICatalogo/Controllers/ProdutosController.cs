using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APICatalogo.Context;
using APICatalogo.Domain;
namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiCatalogoContext _context;
        public ProdutosController(ApiCatalogoContext context)
        {
            _context = context;
        }

        //Action que retorna todos os produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }
            return produtos;
        }

        //Action que retornar um produto pelo id
        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p=> p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }
    }
}
