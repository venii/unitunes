using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Unitunes.Models.Abstratos;
using Unitunes.Models.Contratos;

namespace Unitunes.Models.ModelosApp 
{
    public class Midia : Singleton<Midia>, IRepository<Media>
    {
        public Media GetById(int id)
        {
            var ctx = new dbEntities();
            var medias = ctx.MediaSet;

            var media = from m in medias where m.Id == id select m;
            if (media.Count() > 0)
            {
                return media.First<Media>();
            }
            return null;
        }

        public IQueryable<Media> GetAll(Expression<Func<Media, bool>> filter)
        {
            var l = new List<Media>().AsQueryable();
            return l;
        }

        public bool Save(Media entity)
        {
            var ctx = new dbEntities();

            try
            {
                ctx.MediaSet.Add(entity);
                ctx.SaveChanges();

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        System.Diagnostics.Debug.WriteLine(message);
                    }
                }
                return true;
            }
          
        }

        public bool Update(Media entity)
        {
            var ctx = new dbEntities();
            var medias = ctx.MediaSet;
            try
            {
                
               ctx.SaveChanges();

               return true;
                
            }
            catch (Exception e)
            {
                return false;
            }
      
        }

        public int SaveModel(Media entity)
        {

            Save(entity);
            var ctx = new dbEntities();
            return ctx.MediaSet.Max(media => media.Id);
        }

        public bool Delete(int id)
        {

            return false;
        }

        public bool Delete(Media entity)
        {

            return false;
        }
    }
}