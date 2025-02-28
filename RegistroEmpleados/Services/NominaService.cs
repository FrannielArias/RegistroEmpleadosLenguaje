using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.DAL;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.Service;

public class NominaService(Contexto contexto){
    
    public async Task<bool> Guardar(Nominas nomina){

        nomina.CalcularSalarioNeto();

        if(! await Existe(nomina.NominaId))
            return await Insertar(nomina);
        
        else
            return await Modificar(nomina);
    }

    private async Task<bool> Existe(int id)
    {
        return await contexto.Nominas
            .AnyAsync(e => e.NominaId == id);
    }

    private async Task<bool> Insertar(Nominas nomina)
    {
        contexto.Nominas.Add(nomina);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Nominas nomina)
    {
        contexto.Update(nomina);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Nominas nomina){
        return await contexto.Nominas
            .AsNoTracking()
            .Where(e => e.NominaId == nomina.NominaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Nominas?> Buscar(int nominaId){
        return await contexto.Nominas
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.NominaId == nominaId); 
    }

    public async Task<List<Nominas>> Listar(Expression<Func<Nominas, bool>> criterio){
        return await contexto.Nominas
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}