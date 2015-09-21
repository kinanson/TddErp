using System.Linq;
using TddErp.Model.Models;

namespace TddErp.Service.Interface
{
    public interface IPublishService : IEntityService<Publish>
    {
        Publish Get(string publishID);
    }

    public class PublishService : EntityService<Publish>, IPublishService
    {
        public PublishService(IContext db)
            : base(db)
        {
            this.db = db;
        }

        public Publish Get(string publishID)
        {
            return db.Publish.FirstOrDefault(x => x.PublishID == publishID);
        }

        public override void Add(Publish entity)
        {
            string id = db.Publish.Max(x => x.PublishID);
            id = SeriaNumber.GetThreeID(id);
            entity.PublishID = id;
            db.Publish.Add(entity);
            db.SaveChanges();
        }
    }
}