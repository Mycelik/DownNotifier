using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IAppBs
    {
        List<App> GetAll();
        App GetById(int id);
        App GetByUrl(string name);
        App Insert(App app);
        void Delete(App app);
        void Delete(int id);
        App Update(App app);
    }
}
