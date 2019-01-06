using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JensenEngineers.Repository;

namespace JensenEngineers
{
    public static class Helper
    {
        public static void GenerateStateItems(this DropDownList list)
        {
            List<ListItem> items = new List<ListItem>();
            ;
            foreach (var state in new StateRepository().GetAll())
            {
                items.Add(new ListItem(state, state));
            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }

        public static void GenerateClientItems(this DropDownList list)
        {
            List<ListItem> items = new List<ListItem>();
            ;
            
            foreach (var client in new ClientRepository().GetAll())
            {
                items.Add(new ListItem(client.Title, client.Id.ToString()));

            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }

        public static void GenerateProjectStatus(this DropDownList list)
        {
            List<ListItem> items = new List<ListItem>();
            foreach (var item in new ProjectRepository().GetProjectStatusList())
            {
                items.Add(new ListItem(item.StatusTitle, item.Id.ToString()));
            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }
        public static void GenerateProjectPriority(this DropDownList list)
        {
            List<ListItem> items = new List<ListItem>();
            foreach (var item in new ProjectRepository().GetProjectPriorityList())
            {
                items.Add(new ListItem(item.PriorityTitle, item.Id.ToString()));
            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }
        public static void GenerateProjectType(this DropDownList list)
        {
            List<ListItem> items = new List<ListItem>();
            foreach (var item in new ProjectRepository().GetProjectType())
            {
                items.Add(new ListItem(item.ProjectTypeTitle, item.Id.ToString()));
            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }

        public static void GenerateApplicationUserRole(this DropDownList list)
        {
            List<ListItem> items =  new List<ListItem>();
            foreach (var itemUserRole in new ApplicationUserRepository().GetUserRoles())
            {
                items.Add(new ListItem(itemUserRole.RoleName, itemUserRole.Id.ToString()));
            }
            list.Items.Add(new ListItem("Select", "-1"));
            list.Items.AddRange(items.ToArray());
        }

    }
}