using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.App.ViewModels.Identity;

namespace LaboratorioGestor.Data
{
    public class ApplicationDbContext :   IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LaboratorioGestor.App.ViewModels.RecebimentosViewModel> RecebimentosViewModel { get; set; }
        public DbSet<LaboratorioGestor.App.ViewModels.CobrancaViewModel> CobrancaViewModel { get; set; }
     
    }
}
