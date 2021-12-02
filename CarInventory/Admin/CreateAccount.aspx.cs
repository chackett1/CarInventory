using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CarInventory.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace CarInventory.Admin
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("1");
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            System.Diagnostics.Debug.WriteLine("1");
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            System.Diagnostics.Debug.WriteLine("1");
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                System.Diagnostics.Debug.WriteLine("2");
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                System.Diagnostics.Debug.WriteLine("3");
                System.Diagnostics.Debug.WriteLine("3");
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                System.Diagnostics.Debug.WriteLine("4");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                System.Diagnostics.Debug.WriteLine("5");
            }

            // ----------------------- Add role -----------------------
            
            System.Diagnostics.Debug.WriteLine("1");
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;
            System.Diagnostics.Debug.WriteLine("2");

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            System.Diagnostics.Debug.WriteLine("3");
            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("manager"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = AccessRadio.SelectedValue });
            }
            System.Diagnostics.Debug.WriteLine("4");

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = Email.Text,//"test11@gmail.com",
                Email = Email.Text//"test11@gmail.com"
            };
            IdUserResult = userMgr.Create(appUser, Password.Text);
            System.Diagnostics.Debug.WriteLine("5");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail(Email.Text).Id, AccessRadio.SelectedValue))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(Email.Text).Id, AccessRadio.SelectedValue);
            }
            System.Diagnostics.Debug.WriteLine("6");

            //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["~/Default.aspx"], Response);


            //FormsAuthentication.SignOut();
            System.Diagnostics.Debug.WriteLine("7");
            //Response.Redirect("~/Default.aspx", false);



            //Context.ApplicationInstance.CompleteRequest();

            System.Diagnostics.Debug.WriteLine("8");
            //FormsAuthentication.SignOut();
            //System.Diagnostics.Debug.WriteLine("9");
            //Response.Redirect("~/Default.aspx", false);
            //Context.ApplicationInstance.CompleteRequest();
            //System.Diagnostics.Debug.WriteLine("10");

        }
    }
}