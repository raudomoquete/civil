using civil.Web.Data;
using civil.Web.Data.Entities;
using civil.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace civil.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Form> ToFormAsync(FormViewModel model, string path, bool isNew)
        {
            var form = new Form
            {
                Date = model.Date,
                Incident = model.Incident,
                Province = model.Province,
                Id = isNew ? 0 : model.Id,
                Description = model.Description,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                ImageUrl = path,
                AffectedPeople = model.AffectedPeople,
                AffectedHomes = model.AffectedHomes,
                Deceased = model.Deceased,
                Observation = model.Observation,
                Informant = model.Informant,
                Operator = model.Operator
            };

            return form;
        }

        public FormViewModel ToFormViewModel(Form form)
        {
            return new FormViewModel
            {
                Date = form.Date,
                Incident = form.Incident,
                Province = form.Province,
                Id = form.Id,
                Description = form.Description,
                Longitude = form.Longitude,
                Latitude = form.Latitude,
                ImageUrl = form.ImageUrl,
                AffectedPeople = form.AffectedPeople,
                AffectedHomes = form.AffectedHomes,
                Deceased = form.Deceased,
                Observation = form.Observation,
                Informant = form.Informant,
                Operator = form.Operator
            };
        }
    }
}
