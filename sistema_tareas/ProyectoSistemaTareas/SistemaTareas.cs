using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSistemaTareas.Enums;
using ProyectoSistemaTareas.Interfaces;
using ProyectoSistemaTareas.Models;

namespace ProyectoSistemaTareas
{
    public class SistemaTareas : ISistemaTareas
    {
        private List<Tarea> Tareas = [];
        private int contadorId = 1;

        public void AgregarTarea(string descripcion, int prioridad)
        {
            Tarea nuevaTarea = new Tarea
            {
                Id = contadorId++,
                Descripcion = descripcion,
                Prioridad = (Prioridad)prioridad,
                FechaCreacion = DateTime.Now,
                Completada = false
            };
            Tareas.Add(nuevaTarea);
            Console.WriteLine("Tarea agregada exitosamente.");
        }
        public void ListarTareas()
        {
            if (Tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas disponibles.");
                return;
            }
            foreach (Tarea item in Tareas)
            {
                Console.WriteLine($"ID: {item.Id}, Descripcion: {item.Descripcion}, Prioridad: {item.Prioridad}, Fecha de Creacion: {item.FechaCreacion}, Completada: {(item.Completada ? "Sí" : "No")}");
            }
        }
        public void CompletarTarea(int id)
        {
            Tarea? tarea = Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = true;
                Console.WriteLine("Tarea completada exitosamente.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
        public void EditarTarea(int id, string nuevaDescripcion, int nuevaPrioridad)
        {
            Tarea? tarea = Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Descripcion = nuevaDescripcion;
                tarea.Prioridad = (Prioridad)nuevaPrioridad;
                Console.WriteLine("Tarea editada exitosamente.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
        public void EliminarTarea(int id)
        {
            Tarea? tarea = Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                Tareas.Remove(tarea);
                Console.WriteLine("Tarea eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
        public void ListarTareasCompletadas()
        {
            var tareasCompletadas = Tareas.Where(t => t.Completada).ToList();
            if (tareasCompletadas.Count == 0)
            {
                Console.WriteLine("No hay tareas completadas.");
                return;
            }
            foreach (Tarea item in tareasCompletadas)
            {
                Console.WriteLine($"ID: {item.Id}, Descripcion: {item.Descripcion}, Prioridad: {item.Prioridad}, Fecha de Creacion: {item.FechaCreacion}, Completada: {(item.Completada ? "Sí" : "No")}");
            }
        }
        public void ListarTareasPendientes()
        {
            var tareasPendientes = Tareas.Where(t => !t.Completada).ToList();
            if (tareasPendientes.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes.");
                return;
            }
            foreach (Tarea item in tareasPendientes)
            {
                Console.WriteLine($"ID: {item.Id}, Descripcion: {item.Descripcion}, Prioridad: {item.Prioridad}, Fecha de Creacion: {item.FechaCreacion}, Completada: {(item.Completada ? "Sí" : "No")}");
            }
        }
    }
}