using CatalcaliWebAppV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Areas.Admin.Models
{
    public class InstanceResult<T>
    {
        public Result<List<T>> resultList { get; set; }
        public Result<int> resultint { get; set; }
        public Result<T> resultT { get; set; }
    }
}