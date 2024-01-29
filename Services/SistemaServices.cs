using Microsoft.EntityFrameworkCore;
using Prio.DAL;
using Prio.Models;
using System.Linq;
using System.Linq.Expressions;
namespace Prio.Services;

public class SistemaServices
{
    private readonly Contexto _contexto;

    public SistemaServices (Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int sistemaID)
    {
        return await _contexto.Sistema
            .AnyAsync(s => s.SistemaID == sistemaID);
    }

    public async Task<bool> Guardar(Sistema sistema)
    {
        if (!await Existe(sistema.SistemaID))
            return await Insertar(sistema);
        else
            return await Modificar(sistema);
    }

    private async Task<bool> Insertar(Sistema sistema)
    {
        _contexto.Sistema.Add(sistema);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Sistema sistema)
    {
        _contexto.Update(sistema);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminar(Sistema sistema)
    {
        var Eliminar = await _contexto.Sistema
            .Where(s => s.SistemaID == sistema.SistemaID)
            .ExecuteDeleteAsync();
        return Eliminar > 0;
    }
    public async Task<Sistema?> BuscarID(int sistemaID)
    {
        return await _contexto.Sistema
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.SistemaID == sistemaID);
    }
    public async Task<Sistema?> BuscarNombre(string nombre)
    {
        return await _contexto.Sistema
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Nombre == nombre);
    }
    public async Task<List<Sistema>> Listar(Expression<Func<Sistema, bool>> Criterio)
    {
        return await _contexto.Sistema
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
