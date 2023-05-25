using webapi.Models;

namespace webapi.Services;

public class TareasService : ITareasService
{
    
    TareasContext context;
    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tarea.Descripcion = tarea.Descripcion;
            tarea.PrioridadTarea = tarea.PrioridadTarea;
            tarea.FechaCreacion = tarea.FechaCreacion;
            tarea.Categoria = tarea.Categoria;
            tarea.Resumen = tarea.Resumen;

            await context.SaveChangesAsync();
        }
    }
    public async Task Deelete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Deelete(Guid id);

}