using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace PictureManager
{
    class PictureRepository : IPictureRepository
    {
        public void Save(Picture picture)
        {
            using (ISession session = DataConfig.GetSession())
            {
                session.BeginTransaction();
                session.SaveOrUpdate(picture);
                session.Transaction.Commit();
            }
        }
    }
}
