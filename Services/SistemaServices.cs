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

    public async Task<bool> Existe(int sistemaId)
    {
        return await _contexto.Sistema
            .AnyAsync(s => s.SistemaId == sistemaId);
    }

    public async Task<bool> Guardar(Sistema sistema)
    {
        if (!await Existe(sistema.SistemaId))
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
            .Where(s => s.SistemaId == sistema.SistemaId)
            .ExecuteDeleteAsync();
        return Eliminar > 0;
    }
    public async Task<Sistema?> BuscarId(int sistemaId)
    {
        return await _contexto.Sistema
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.SistemaId == sistemaId);
    }
    public async Task<Sistema?> BuscarNombre(string nombre)
    {
        return await _contexto.Sistema
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Nombre == nombre);
    }
    public List<Sistema> Listar(Expression<Func<Sistema, bool>> Criterio)
    {
        return _contexto.Sistema
            .Where(Criterio)
            .AsNoTracking()
            .ToList();
    }
}
