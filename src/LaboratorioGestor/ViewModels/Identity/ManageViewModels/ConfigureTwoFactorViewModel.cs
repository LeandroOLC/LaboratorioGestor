using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaboratorioGestor.App.ViewModels.Identity.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
