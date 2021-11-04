using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CarInventory.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarInventory.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("manager"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "manager" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com"
            };
            IdUserResult = userMgr.Create(appUser, "passwordFAU1?");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("manager@gmail.com").Id, "manager"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("manager@gmail.com").Id, "manager");
            }

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("employee"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "employee" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            appUser = new ApplicationUser
            {
                UserName = "employee@gmail.com",
                Email = "employee@gmail.com"
            };
            IdUserResult = userMgr.Create(appUser, "passwordFAU1?");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("employee@gmail.com").Id, "employee"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("employee@gmail.com").Id, "employee");
            }
        }
    }
}