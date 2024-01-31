using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prio.DAL;
using Prio.Models;

namespace Prio.BLL;

public class PrioridadServices
{
    private readonly Contexto _contexto;
    public PrioridadServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    public bool Save(Prioridades prioridades)
    {
        if (prioridades.PrioridadId == 0)
            _contexto.Prioridades.Add(prioridades);
        else
            _contexto.Entry(prioridades).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public async Task<Prioridades?> FindAsync(int PrioridadId)
    {
        return await _contexto.Prioridades.FindAsync(PrioridadId);
    }
	public async Task<Prioridades?> SearchDescripcion(string descripcion)
	{
		return await _contexto.Prioridades
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
	}
	public bool Delete(int PrioridadId)
    {
        _contexto.Prioridades.Remove(_contexto.Prioridades.Find(PrioridadId));
        return _contexto.SaveChanges() > 0;
    }
    public List<Prioridades> GetPrioridades(Expression<Func<Prioridades, bool>> Criterio)
    {
        return _contexto.Prioridades.Where(Criterio).AsNoTracking().ToList();
    }

}
