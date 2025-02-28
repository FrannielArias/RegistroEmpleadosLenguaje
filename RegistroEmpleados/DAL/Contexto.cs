using Microsoft.EntityFrameworkCore;
using RegistroEmpleados.Models;

namespace RegistroEmpleados.DAL;

public class Contexto : DbContext {
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    
    public DbSet<Empleados> Empleados { get; set; }
    public DbSet<Nominas> Nominas { get; set; }
}