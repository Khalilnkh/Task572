using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public  class Admin_Repository:Irepository<Admin>
    {
        private static int Id;
        public Admin Create(Admin entity)
        {
            Id++;
            entity.Id = Id;
            Dbcontext.Admin.Add(entity);
            return entity;
        }

        public void Delete(Admin entity)
        {
            Dbcontext.Admin.Remove(entity);
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return Dbcontext.Admin[0];
            }
            else
            {
                return Dbcontext.Admin.Find(filter);
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return Dbcontext.Admin;

            }
            else
            {
                return Dbcontext.Admin.FindAll(filter);
            }
        }

        public void Update(Admin entity)
        {
            var admin = Dbcontext.Groups.Find(g => g.Id == entity.Id);
            if (admin != null)
            {
                admin.User = entity.User;
                admin.Password = entity.Password;

            }
        }
    }
}
