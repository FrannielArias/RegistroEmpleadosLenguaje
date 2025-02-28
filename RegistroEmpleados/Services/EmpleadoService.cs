using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.DAL;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.Service;

public class EmpleadoService(Contexto contexto){
    
    public async Task<bool> Guardar(Empleados empleado){

        empleado.Nomina?.CalcularSalarioNeto();

        if(! await Existe(empleado.EmpleadoId))
            return await Insertar(empleado);
        
        else
            return await Modificar(empleado);
    }

    private async Task<bool> Existe(int id)
    {
        return await contexto.Empleados
            .AnyAsync(e => e.EmpleadoId == id);
    }

    private async Task<bool> Insertar(Empleados empleado)
    {
        contexto.Empleados.Add(empleado);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Empleados empleado)
    {
        contexto.Update(empleado);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Empleados empleado){
        return await contexto.Empleados
            .AsNoTracking()
            .Where(e => e.EmpleadoId == empleado.EmpleadoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Empleados?> Buscar(int empleadoId){
        return await contexto.Empleados
            .AsNoTracking()
            .Include(n => n.Nomina)
            .FirstOrDefaultAsync(e => e.EmpleadoId == empleadoId); 
    }

    public async Task<List<Empleados>> Listar(Expression<Func<Empleados, bool>> criterio){
        return await contexto.Empleados
            .AsNoTracking()
            .Include(n => n.Nomina)
            .Where(criterio)
            .ToListAsync();
    }
}