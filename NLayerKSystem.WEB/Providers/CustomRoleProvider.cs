using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace NLayerKSystem.WEB.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        IService<UserDTO> userService;
        IService<RoleDTO> roleService;

        public CustomRoleProvider()
        {
            this.userService = DependencyResolver.Current.GetService<IService<UserDTO>>();
            this.roleService = DependencyResolver.Current.GetService<IService<RoleDTO>>();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };

            var userDTO = new UserDTO
            {
                Email = username.Trim()
            };
            
            var user = userService.CheckToExistUserEmail(userDTO);

            if (user != null)
            {
                var u = new UserDTO
                {
                    RoleId = user.RoleId
                };

                var userRole = roleService.GetUserByRoleId(u.RoleId);

                if (userRole != null)
                {
                    roles = new string[] { userRole.Name.Trim() };
                }
            }

            return roles;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;

            var userDTO = new UserDTO
            {
                Email = username.Trim()
            };

            var user = userService.CheckToExistUserEmail(userDTO);

            if (user != null)
            {
                var u = new UserDTO
                {
                    RoleId = user.RoleId
                };

                var userRole = roleService.GetUserByRoleId(u.RoleId);

                if (userRole != null && userRole.Name.Trim() == roleName.Trim())
                {
                    outputResult = true;
                }
            }

            return outputResult;
        }
        

        ///////////////////////////////////////////////////////////////////////////////////

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}