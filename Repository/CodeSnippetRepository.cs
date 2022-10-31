using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class CodeSnippetRepository
    {
        private ApplicationDbContext _DBContext;
        public CodeSnippetRepository()
        {
            _DBContext = new ApplicationDbContext();
        }
        public CodeSnippetRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private CodeSnippetModel MapDBObjectToModel(CodeSnippet dbobject)
        {
            var model = new CodeSnippetModel();
            if (dbobject != null)
            {
                model.IdcodeSnippet = dbobject.IdcodeSnippet;
                model.Title = dbobject.Title;
                model.ContentCode = dbobject.ContentCode;
                model.Idmember = dbobject.Idmember;
                model.Revision = dbobject.Revision;
                model.IdsnippetPreviousVersion = dbobject.IdsnippetPreviousVersion;
                model.DateTimeAdded = dbobject.DateTimeAdded;
                model.IsPublished = dbobject.IsPublished;
            }
            return model;
        }

        private CodeSnippet MapModelToDBObject (CodeSnippetModel model)
        {
            var dbobject = new CodeSnippet();
            if (model != null)
            {
                dbobject.IdcodeSnippet = model.IdcodeSnippet;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.Idmember = model.Idmember;
                dbobject.Revision = model.Revision;
                dbobject.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
                dbobject.IsPublished = model.IsPublished;
            }
            return dbobject;
        }

        public List<CodeSnippetModel> GetAllCodeSnippets()
        {
            var list = new List<CodeSnippetModel>();
            foreach(var dbobject in _DBContext.CodeSnippets)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            list.Sort((x, y) => y.DateTimeAdded.CompareTo(x.DateTimeAdded));

            return list;
        }

        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == id));
        }

        public void InsertCodeSnippet(CodeSnippetModel model)
        {
            model.IdcodeSnippet = Guid.NewGuid();   
            _DBContext.CodeSnippets.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel model)
        {
            var dbobject = _DBContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == model.IdcodeSnippet);
            if (dbobject != null)
            {
                dbobject.IdcodeSnippet = model.IdcodeSnippet;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.Idmember = model.Idmember;
                dbobject.Revision = model.Revision;
                dbobject.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
                dbobject.IsPublished = model.IsPublished;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteCodeSnippet(Guid id)
        {
            var dbobject = _DBContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == id);

            if (dbobject != null)
            {
                _DBContext.CodeSnippets.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
