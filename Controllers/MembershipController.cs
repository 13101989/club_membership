using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clubmembership.Controllers
{
    public class MembershipController : Controller
    {

        private MembershipRepository membershipRepository;
        private MemberRepository memberRepository;
        private MembershipTypeRepository membershipTypeRepository;

        public MembershipController(ApplicationDbContext dbContext)
        {
            membershipRepository = new MembershipRepository(dbContext);
            memberRepository = new MemberRepository(dbContext);
            membershipTypeRepository = new MembershipTypeRepository(dbContext);
        }

        // GET: MembershipController
        public ActionResult Index()
        {
            var list = membershipRepository.GetAllMemberships();

            return View(list);
        }

        // GET: MembershipController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = membershipRepository.GetMembershipById(id);

            return View("DetailsMembership", model);
        }

        // GET: MembershipController/Create
        public ActionResult Create()
        {
            var members = memberRepository.GetAllMembers();
            var memberList = members.Select(x => new SelectListItem(x.Name, x.IdMember.ToString()));
            ViewBag.MemberList = memberList;

            var membershipType = membershipTypeRepository.GetAllMembershipTypes();
            var membershipTypeList = membershipType.Select(x => new SelectListItem(x.Name, x.IdMembershipType.ToString()));
            ViewBag.MembershipTypeList = membershipTypeList;

            return View("CreateMembership");
        }

        // POST: MembershipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    membershipRepository.InsertMembership(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMembership");
            }
        }

        // GET: MembershipController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = membershipRepository.GetMembershipById(id);

            return View("EditMembership", model);
        }

        // POST: MembershipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    membershipRepository.UpdateMembership(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: MembershipController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = membershipRepository.GetMembershipById(id);

            return View("DeleteMembership", model);
        }

        // POST: MembershipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                membershipRepository.DeleteMembership(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
