using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class RoleViewModels
    {
        public RoleViewModels() { }
        public RoleViewModels(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}