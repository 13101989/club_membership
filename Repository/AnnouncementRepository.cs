using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class AnnouncementRepository
    {
        private ApplicationDbContext _DBContext;
        public AnnouncementRepository()
        {
            _DBContext = new ApplicationDbContext();
        }
        public AnnouncementRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private AnnouncementModel MapDBObjectToModel(Announcement dbobject)
        {
            var model = new AnnouncementModel();
            if (dbobject != null)
            {
                model.Idannouncemment = dbobject.Idannouncemment;
                model.ValidFrom = dbobject.ValidFrom;
                model.ValidTo = dbobject.ValidTo;
                model.Title = dbobject.Title;
                model.Text = dbobject.Text;
                model.EventDateTime = dbobject.EventDateTime;
                model.Tags = dbobject.Tags;
            }
            return model;
        }

        private Announcement MapModelToDBObject(AnnouncementModel model)
        {
            var dbobject = new Announcement();
            if (model != null)
            {
                dbobject.Idannouncemment = model.Idannouncemment;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime = model.EventDateTime;
                dbobject.Tags = model.Tags;
            }
            return dbobject;
        }

        public List<AnnouncementModel> GetAllAnnouncements()
        {
            var list = new List<AnnouncementModel>();
            foreach(var dbobject in _DBContext.Announcements)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Announcements.FirstOrDefault(x => x.Idannouncemment == id));
        }

        public void InsertAnnouncement(AnnouncementModel model)
        {
            model.Idannouncemment = Guid.NewGuid();
            _DBContext.Announcements.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateAnnouncement(AnnouncementModel model)
        {
            var dbobject = _DBContext.Announcements.FirstOrDefault(x => x.Idannouncemment == model.Idannouncemment);
            if (dbobject != null)
            {
                dbobject.Idannouncemment = model.Idannouncemment;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime = model.EventDateTime;
                dbobject.Tags = model.Tags;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteAnnouncement(Guid id)
        {
            var dbobject = _DBContext.Announcements.FirstOrDefault(x => x.Idannouncemment == id);
            if (dbobject != null)
            {
                _DBContext.Announcements.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
