using civil.Web.Data.Entities;
using civil.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace civil.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Form> ToFormAsync(FormViewModel model, string path, bool isNew);

        FormViewModel ToFormViewModel(Form form);
    }
}
