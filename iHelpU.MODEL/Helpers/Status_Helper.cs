using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHelpU.MODEL.Models;

namespace iHelpU.MODEL.Helpers
{
    public static class Status_Helper
    {
        public static List<Status> ObterTodosStatus(Banco_TCCContext context)
        {
            return context.Statuses.ToList();
        }
    }
}
