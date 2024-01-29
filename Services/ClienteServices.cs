using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prio.DAL;
using Prio.Models;

namespace Prio.BLL;

public class ClienteServices
{
    private readonly Contexto _contexto;

    public ClienteServices (Contexto contexto)
    {
        _contexto = contexto;
    }

	public async Task<bool> Existe(int clienteID)
	{
		return await _contexto.Clientes
			.AnyAsync(c => c.ClienteID == clienteID);
	}

	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await Existe(cliente.ClienteID))
			return await Insertar(cliente);
		else
			return await Modificar(cliente);
	}

	private async Task<bool> Insertar(Clientes cliente)
    {
        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes cliente)
    {
        _contexto.Update(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }


	public async Task<bool> Eliminar(int CLienteID)
	{
		var cliente = _contexto.Clientes.Find(CLienteID);

		_contexto.Clientes.Remove(cliente);
		var deleted = await _contexto.SaveChangesAsync() > 0;
		return deleted;
	}

	public async Task<Clientes?> Buscar(int ClienteID)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteID == ClienteID);
    }

    public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return _contexto.Clientes
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }
}
