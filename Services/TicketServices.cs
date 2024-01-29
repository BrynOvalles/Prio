using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prio.DAL;
using Prio.Models;

namespace Prio.BLL;

public class TicketServices
{
    private readonly Contexto _contexto;

    public TicketServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int clienteID)
    {
        return await _contexto.Tickets
            .AnyAsync(c => c.ClienteID == clienteID);
    }

    public async Task<bool> Guardar(Tickets ticket)
    {
        if (!await Existe(ticket.TicketID))
            return await Insertar(ticket);
        else
            return await Modificar(ticket);
    }

    private async Task<bool> Insertar(Tickets ticket)
    {
        _contexto.Tickets.Add(ticket);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tickets tickets)
    {
        _contexto.Update(tickets);
        return await _contexto.SaveChangesAsync() > 0;
    }


    public async Task<bool> Eliminar(int ticket)
    {
        var elimiar = await _contexto.Tickets
            .Where(t => t.TicketID == ticket)
            .ExecuteDeleteAsync();
        return elimiar > 0;
    }

    public async Task<Tickets?> BuscarID(int ticketID)
    {
        return await _contexto.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TicketID == ticketID);
    }
    public async Task<Tickets?> BuscarFecha(DateTime fecha)
    {
        return await _contexto.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Fecha == fecha);
    }
    public async Task<Tickets?> BuscarCliente(int clienteID)
    {
        return await _contexto.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.ClienteID == clienteID);
    }
    public async Task<Tickets?> BuscarDescripcion(string descripcion)
    {
        return await _contexto.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Descripcion == descripcion);
    }

    public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio)
    {
        return _contexto.Tickets
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }
}
