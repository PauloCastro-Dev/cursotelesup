using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSistemaTareas.Interfaces
{
    public interface ISistemaTareas
    {
        public void AgregarTarea(string descripcion, int prioridad);
        public void ListarTareas();
        public void CompletarTarea(int id);
        public void EditarTarea(int id, string nuevaDescripcion, int nuevaPrioridad);
        public void EliminarTarea(int id);
        public void ListarTareasCompletadas();
        public void ListarTareasPendientes();
    }
}