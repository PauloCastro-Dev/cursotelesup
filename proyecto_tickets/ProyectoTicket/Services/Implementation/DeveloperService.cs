using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models;
using ProyectoTicket.Services.Interface;

namespace ProyectoTicket.Services.Implementation
{
    public class DeveloperService : IDeveloperService
    {
        private List<Developer> Developers { get; set; } = [];
        public void Add(Developer developer)
        {
            Developers.Add(developer);
        }

        public bool Delete(int id)
        {
            int removedCount = Developers.RemoveAll(d => d.Id == id);
            return removedCount > 0;
        }

        public List<Developer> GetAll()
        {
            return Developers;
        }
        public bool Update(int id, Developer entity)
        {
            Developer? developer = Developers.FirstOrDefault(d => d.Id == id);
            if (developer != null)
            {
                developer. = entity.Name;
                developer.Email = entity.Email;
                developer.Role = entity.Role;
                return true;
            }
            return false;
        }
        public Developer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}