using GlobalExceptionHandler.API.Exceptions;
using GlobalExceptionHandler.API.Models;
using GlobalExceptionHandler.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : Controller
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var resposta = await _clienteService.ObterTodos();
        return Ok(resposta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var resposta = await _clienteService.ObterPorId(id);
        return Ok(resposta);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(Cliente c)
    {
        await _clienteService.Cadastrar(c);
        return Ok();
    }
}