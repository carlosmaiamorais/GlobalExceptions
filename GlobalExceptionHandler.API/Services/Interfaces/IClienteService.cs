using GlobalExceptionHandler.API.Models;

namespace GlobalExceptionHandler.API.Services.Interfaces;

public interface IClienteService
{
    Task<List<Cliente>> ObterTodos();
    Task Cadastrar(Cliente c);
    Task<Cliente> ObterPorId(int id);
}