using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clubmembership.Controllers
{
    public class CodeSnippetController : Controller
    {
        private CodeSnippetRepository codeSnippetRepository;
        private MemberRepository memberRepository;

        public CodeSnippetController(ApplicationDbContext dbContext)
        {
            codeSnippetRepository = new CodeSnippetRepository(dbContext);
            memberRepository = new MemberRepository(dbContext);
        }

        // GET: CodeSnippetController
        public ActionResult Index()
        {
            var list = codeSnippetRepository.GetAllCodeSnippets();

            return View(list);
        }

        // GET: CodeSnippetController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = codeSnippetRepository.GetCodeSnippetById(id);

            return View("DetailsCodeSnippet", model);
        }

        // GET: CodeSnippetController/Create
        public ActionResult Create()
        {
            var members = memberRepository.GetAllMembers();
            var memberList = members.Select(x => new SelectListItem(x.Name, x.IdMember.ToString() ));
            ViewBag.MemberList = memberList;

            var codeSnippet = codeSnippetRepository.GetAllCodeSnippets();
            var codeSnippetList = codeSnippet.Select(x => new SelectListItem(x.Title, x.IdcodeSnippet.ToString()));
            ViewBag.CodeSnippetList = codeSnippetList;

            return View("CreateCodeSnippet");
        }

        // POST: CodeSnippetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new CodeSnippetModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    codeSnippetRepository.InsertCodeSnippet(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCodeSnippet");
            }
        }

        // GET: CodeSnippetController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = codeSnippetRepository.GetCodeSnippetById(id);

            return View("EditCodeSnippet", model);
        }

        // POST: CodeSnippetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CodeSnippetModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    codeSnippetRepository.UpdateCodeSnippet(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: CodeSnippetController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = codeSnippetRepository.GetCodeSnippetById(id);

            return View("DeleteCodeSnippet", model);
        }

        // POST: CodeSnippetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                codeSnippetRepository.DeleteCodeSnippet(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
