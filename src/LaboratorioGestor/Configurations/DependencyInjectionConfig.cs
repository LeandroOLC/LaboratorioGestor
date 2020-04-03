using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Data.Context;
using LaboratorioGestor.Business.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using LaboratorioGestor.Data.Repository;
using LaboratorioGestor.App.Extensions;
using LaboratorioGestor.Business.Notificacoes;
using LaboratorioGestor.App.ViewModels.Identity;

namespace LaboratorioGestor.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProteticoRepository, ProteticoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IDentistaRepository, DentistaRepository>();
            services.AddScoped<IRecebimentoRepository, RecebimentosrRepository>();
            services.AddScoped<ICobrancaRepository, CobrancasRepository>();
            services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IDentistaService, DentistaService>();
            services.AddScoped<ILaboratorioService, LaboratorioService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProteticoService, ProteticoService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<ICobrancaService, CobrancaService>();
            services.AddScoped<IRecebimentoService, RecebimentosService>();

            return services;
        }
    }
}
