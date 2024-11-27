using GlobalExceptionHandler.API.Exceptions;
using GlobalExceptionHandler.API.Models;
using GlobalExceptionHandler.API.Services.Interfaces;

namespace GlobalExceptionHandler.API.Services;

public class ClienteService : IClienteService
{
    public Task<List<Cliente>> ObterTodos()
    {
        throw new Exception("erro ao conectar na base de dados");
    }

    public Task Cadastrar(Cliente c)
    {
        //regras de negócios , validações
        throw new DomainException("Já existe esse CPF cadastrado em nossa base de dados");
        //repository
    }

    public Task<Cliente> ObterPorId(int id)
    {
        throw new NotFoundException("Registro não encontrado");
    }
}