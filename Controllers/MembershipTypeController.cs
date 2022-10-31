using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clubmembership.Controllers
{
    public class MembershipTypeController : Controller
    {

        private MembershipTypeRepository membershipTypeRepository;

        public MembershipTypeController(ApplicationDbContext dbContext)
        {
            membershipTypeRepository = new MembershipTypeRepository(dbContext);
        }

        // GET: MembershipTypeController
        public ActionResult Index()
        {
            var list = membershipTypeRepository.GetAllMembershipTypes();

            return View(list);
        }

        // GET: MembershipTypeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = membershipTypeRepository.GetMembershipTypeById(id);

            return View("DetailsMembershipType", model);
        }

        // GET: MembershipTypeController/Create
        public ActionResult Create()
        {
            return View("CreateMembershipType");
        }

        // POST: MembershipTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    membershipTypeRepository.InsertMembershipType(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMembershipType");
            }
        }

        // GET: MembershipTypeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = membershipTypeRepository.GetMembershipTypeById(id);

            return View("EditMembershipType", model);
        }

        // POST: MembershipTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new MembershipTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    membershipTypeRepository.UpdateMembershipType(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: MembershipTypeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = membershipTypeRepository.GetMembershipTypeById(id);

            return View("DeleteMembershipType", model);
        }

        // POST: MembershipTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                membershipTypeRepository.DeleteMembershipType(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
