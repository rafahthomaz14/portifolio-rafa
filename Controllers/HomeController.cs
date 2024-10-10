using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using portifolio_rafa.Models;

namespace portifolio_rafa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MeuDbContext _context; // Adicione o contexto do banco de dados

        public HomeController(ILogger<HomeController> logger, MeuDbContext context)
        {
            _logger = logger;
            _context = context; // Inicializa o contexto do banco de dados
        }


        // Método para exibir a página inicial com a lista de projetos
        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projetos.ToListAsync(); // Busca os projetos
            return View(projetos); // Passa a lista de projetos para a view
        }

        // Método para exibir a página de criação
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, Descricao")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redireciona para o Index após salvar
            }
            return View(projeto); // Retorna para a mesma view se houver erros de validação
        }


    }

}