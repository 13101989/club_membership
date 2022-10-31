using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clubmembership.Controllers
{
    public class MemberController : Controller
    {

        private MemberRepository memberRepository;

        public MemberController(ApplicationDbContext dbContext)
        {
            memberRepository = new MemberRepository(dbContext);
        }

        // GET: MemberController
        public ActionResult Index()
        {
            var list = memberRepository.GetAllMembers();

            return View(list);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = memberRepository.GetMemberById(id);

            return View("DetailsMember", model);
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View("CreateMember");
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MemberModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    memberRepository.InsertMember(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMember");
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = memberRepository.GetMemberById(id);

            return View("EditMember", model);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new MemberModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    memberRepository.UpdateMember(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = memberRepository.GetMemberById(id);

            return View("DeleteMember", model);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                memberRepository.DeleteMember(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
