using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Business.Models;
using X.PagedList;

namespace LaboratorioGestor.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Contatos, ContatoViewModel>().ReverseMap();
            CreateMap<Enderecos, EnderecoViewModel>().ReverseMap();
            CreateMap<Produtos, ProdutoViewModel>().ReverseMap();
            CreateMap<Enderecos, EnderecoViewModel>().ReverseMap();
            CreateMap<Recebimentos, RecebimentosViewModel>().ReverseMap();
            CreateMap<Cobrancas, CobrancaViewModel>().ReverseMap();
            CreateMap<Proteticos, ProteticoViewModel>().ReverseMap();
            CreateMap<Laboratorios, LaboratorioViewModel>().ReverseMap();
            CreateMap<Servicos, ServicoViewModel>().ReverseMap();
            CreateMap<Dentistas, DentistaViewModel>().ReverseMap();

            CreateMap<IEnumerable<DentistaViewModel>, IEnumerable<Dentistas>>();
            CreateMap<IEnumerable<ProdutoViewModel>, IEnumerable<Produtos>>();
            CreateMap<IEnumerable<ServicoViewModel>, IEnumerable<Servicos>>();


            CreateMap<StaticPagedList<Produtos>, StaticPagedList<ProdutoViewModel>>()
                .ConstructUsing((source, context) => new StaticPagedList<ProdutoViewModel>(
                    context.Mapper.Map<List<Produtos>, List<ProdutoViewModel>>(source.ToList()),
                    source.PageNumber,
                    source.PageSize,
                    source.TotalItemCount)).ReverseMap();

            CreateMap<StaticPagedList<Servicos>, StaticPagedList<ServicoViewModel>>()
               .ConstructUsing((source, context) => new StaticPagedList<ServicoViewModel>(
                   context.Mapper.Map<List<Servicos>, List<ServicoViewModel>>(source.ToList()),
                   source.PageNumber,
                   source.PageSize,
                   source.TotalItemCount)).ReverseMap();

            CreateMap<StaticPagedList<Recebimentos>, StaticPagedList<RecebimentosViewModel>>()
            .ConstructUsing((source, context) => new StaticPagedList<RecebimentosViewModel>(
                context.Mapper.Map<List<Recebimentos>, List<RecebimentosViewModel>>(source.ToList()),
                source.PageNumber,
                source.PageSize,
                source.TotalItemCount)).ReverseMap();
        }
    }

 

}
