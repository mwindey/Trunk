using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using SimpleMembershipExample;
using WebMatrix.WebData;
using Definco.Models;


namespace Definco.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {



        public ActionResult RawSQLQuery(string query)
        {
            //LINQ to SQL context class
            DefincoDbContext dataContext = new DefincoDbContext();
            //Create gridview object - Make sure you have added reference to Syster.Web.UI.ServerControls
            GridView gv = new GridView();
            //Call Method to apply style to gridview - This is optional part and can be avoided 
            //StyleGrid(ref gv);
            //assing datasource from context class to gridview object
            System.Data.Objects.ObjectResult<UserProfile> result = ((dataContext as IObjectContextAdapter).ObjectContext).ExecuteStoreQuery<UserProfile>(query);
            gv.DataSource = result.ToList();
            //Important - bind gridview object
            gv.DataBind();
            //We have gridview object ready in memory. Follow normal "export gridview to excel" code
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=query.xls");
            Response.ContentType = "application/excel";
            //Ccreate string writer object and pass it to HtmlTextWriter object
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //Call gridiview objects RenderControl method to output gridview content to HtmlTextWriter
            gv.RenderControl(htw);
            //Pass rendered string to Response object which would be presented to user for download
            Response.Write(sw.ToString());
            Response.End();
            return null;
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                        propertyValues: new
                                                {
                                                    UserName = model.UserName,
                                                    Password = model.Password,
                                                    FirstName = model.FirstName,
                                                    LastName = model.LastName,
                                                    Address = model.Address,
                                                    Cellphone = model.Cellphone,
                                                    Email = model.Email,
                                                    CreatedDate = DateTime.Now,
                                                    UpdateDate = DateTime.Now,
                                                    SecurityLevel = 3
                                                });


                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        public ActionResult ListUsersStartingWith(string startingletter)
        {
            DefincoDbContext ctx = new DefincoDbContext();
            IQueryable<UserProfile> userProfiles = ctx.UserProfiles.Where(u => u.LastName.StartsWith(startingletter));


            return View("_ListUsersStartingWith", userProfiles);
        }

        [HttpGet]
        public ActionResult ManageByID(int userId)
        {
            DefincoDbContext ctx = new DefincoDbContext();
            UserProfile currentProfile = ctx.UserProfiles.First(x => x.UserId == userId);

            var model = CreateManageModel(currentProfile);

            return View("Manage", model);
        }

        private static ManageModel CreateManageModel(UserProfile currentProfile)
        {
            ManageModel model = new ManageModel();
            model.SecurityLevel = currentProfile.SecurityLevel;
            model.Address = currentProfile.Address;
            model.Cellphone = currentProfile.Cellphone;
            model.Email = currentProfile.Email;
            model.FirstName = currentProfile.FirstName;
            model.LastName = currentProfile.LastName;
            model.Password = currentProfile.Password;
            model.UserId = currentProfile.UserId;
            model.UserName = currentProfile.UserName;
            model.CreatedDate = currentProfile.CreatedDate;

            model.files = new FileInfo[0];
            try
            {
                string filepath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Files/"),
                                               model.UserId.ToString());
                DirectoryInfo fileDirectory = new DirectoryInfo(filepath);
                if (fileDirectory.Exists)
                {
                    model.files = fileDirectory.GetFiles();
                }
            }
            catch (DirectoryNotFoundException exp)
            {
                throw new DirectoryNotFoundException("Could not open the directory !", exp);
            }
            return model;
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {

            ViewBag.StatusMessage =

                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                  : message == ManageMessageId.ChangeProfileSuccess ? "Your profile has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            DefincoDbContext ctx = new DefincoDbContext();
            UserProfile currentProfile = ctx.UserProfiles.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (currentProfile == null)
                throw new Exception("user not found in DB");

            var model = CreateManageModel(currentProfile);

            return View(model);
        }

        public ActionResult DeleteFile(int userId, string filename)
        {
            try
            {
                string filepath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Files/"),
                                              userId.ToString());
                // Set full path to file 
                string fileToDelete = filepath + "\\" + filename;

                // Delete a file
                System.IO.File.Delete(fileToDelete);
            }
            catch (Exception exp)
            {
                throw new IOException("Could not delete file !", exp);
            }

            return RedirectToAction("ManageByID", new { userId });
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(ManageModel model)
        {

            DefincoDbContext ctx = new DefincoDbContext();
            UserProfile currentProfile = ctx.UserProfiles.First(x => x.UserId == model.UserId);

            if (ModelState.IsValid)
            {
                currentProfile.SecurityLevel = model.SecurityLevel;
                currentProfile.Password = model.Password;
                currentProfile.FirstName = model.FirstName;
                currentProfile.LastName = model.LastName;
                currentProfile.Email = model.Email;
                currentProfile.Address = model.Address;
                currentProfile.Cellphone = model.Cellphone;
                currentProfile.UpdateDate = DateTime.Now;

                bool changeAccountSucceeded = true;
                try
                {
                    ctx.SaveChanges();

                }
                catch (Exception)
                {
                    changeAccountSucceeded = false;
                }

                if (changeAccountSucceeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.ChangeProfileSuccess });
                }
                else
                {
                    ModelState.AddModelError("", "Problem with saving profile.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (DefincoDbContext db = new DefincoDbContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangeProfileSuccess,
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
