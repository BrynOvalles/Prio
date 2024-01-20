using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prio.DAL;
using Prio.Models;

namespace Prio.BLL;

public class ClientesBLL
{
    private readonly Contexto _contexto;

    public ClientesBLL (Contexto contexto)
    {
        _contexto = contexto;
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

    public async Task<bool> Existe(int ClienteID)
    {
        return await _contexto.Clientes
            .AnyAsync(c => c.ClienteID == ClienteID);
    }

    public async Task<bool> Eliminar(Clientes cliente)
    {
        var cantidad = await _contexto.Clientes
            .Where(c => c.ClienteID == cliente.ClienteID)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Clientes?> Buscar(int ClienteID)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteID == ClienteID);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}
