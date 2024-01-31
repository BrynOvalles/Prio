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
			.AnyAsync(c => c.ClienteId == clienteID);
	}
	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await Existe(cliente.ClienteId))
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
	public async Task<bool> Eliminar(Clientes cliente)
	{
		var cantidad = await _contexto.Clientes
			.Where(c => c.ClienteId == cliente.ClienteId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}
	public async Task<Clientes?> BuscarId(int clienteId)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
	}
	public async Task<Clientes?> Buscar(int clienteId)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }
	public async Task<Clientes?> BuscarNombre(string nombre)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
	}
	public async Task<Clientes?> BuscarRNC(string RNC)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.RNC == RNC);
	}
	public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return _contexto.Clientes
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }
}
