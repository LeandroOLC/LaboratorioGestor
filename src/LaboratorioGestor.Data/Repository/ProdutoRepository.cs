using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Data.Repository
{
    public class ProdutoRepository : Repository<Produtos>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

    }
}
