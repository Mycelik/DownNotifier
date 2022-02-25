using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class AppBs:IAppBs
    {
        DataContext _ctx;
        public AppBs()
        {
            _ctx = new DataContext();
        }

        public void Delete(App app)
        {
            EntityEntry<App> deletedApp = _ctx.Entry(app);
            deletedApp.State = EntityState.Deleted;

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public List<App> GetAll()
        {
            return _ctx.Apps.ToList();
        }

        public App GetById(int id)
        {
            return _ctx.Apps.SingleOrDefault(x => x.Id == id);
        }
        public App GetByUrl(string name)
        {
            return _ctx.Apps.SingleOrDefault(x => x.Url == name);
        }
        public App Insert(App app)
        {
            EntityEntry<App> insertedApp = _ctx.Entry(app);
            insertedApp.State = EntityState.Added;
            _ctx.SaveChanges();
            return app;
        }

        public App Update(App app)
        {
            EntityEntry<App> updatedApp = _ctx.Entry(app);
            updatedApp.State = EntityState.Modified;
            _ctx.SaveChanges();
            return app;
        }
    }
}
