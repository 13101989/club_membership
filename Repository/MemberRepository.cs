using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class MemberRepository
    {
        private ApplicationDbContext _DBContext;

        public MemberRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public MemberRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }   

        private MemberModel MapDBObjectToModel(Member dbobject)
        {
            var model = new MemberModel();
            if (dbobject != null)
            {
                model.IdMember = dbobject.IdMember;
                model.Name = dbobject.Name;
                model.Title = dbobject.Title;
                model.Position = dbobject.Position;
                model.Description = dbobject.Description;
                model.Resume = dbobject.Resume;
            }
            return model;
        }

        private Member MapModelToDBObject (MemberModel model)
        {
            var dbobject = new Member();
            if (model != null)
            {
                dbobject.IdMember = model.IdMember;
                dbobject.Name = model.Name;
                dbobject.Title = model.Title;
                dbobject.Position = model.Position;
                dbobject.Description = model.Description;
                dbobject.Resume = model.Resume;
            }
            return dbobject;
        }

        public List<MemberModel> GetAllMembers()
        {
            var list = new List<MemberModel>();
            foreach(var dbobject in _DBContext.Members)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MemberModel GetMemberById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Members.FirstOrDefault(x => x.IdMember == id));
        }

        public void InsertMember (MemberModel model)
        {
            model.IdMember = Guid.NewGuid();
            _DBContext.Members.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateMember(MemberModel model)
        {
            var dbobject = _DBContext.Members.FirstOrDefault(x => x.IdMember == model.IdMember);
            if (dbobject != null)
            {
                dbobject.IdMember = model.IdMember;
                dbobject.Name = model.Name;
                dbobject.Title = model.Title;
                dbobject.Position = model.Position;
                dbobject.Description = model.Description;
                dbobject.Resume = model.Resume;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteMember(Guid id)
        {
            var dbobject = _DBContext.Members.FirstOrDefault(x => x.IdMember == id);
            if (dbobject != null)
            {
                var memberships = _DBContext.Memberships.Where(x => x.Idmember == dbobject.IdMember);

                foreach (var membership in memberships)
                {
                    _DBContext.Memberships.Remove(membership);
                }

                var codesnippets = _DBContext.CodeSnippets.Where(x => x.Idmember == dbobject.IdMember);

                foreach (var codesnippet in codesnippets)
                {
                    _DBContext.CodeSnippets.Remove(codesnippet);
                }

                _DBContext.Members.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
