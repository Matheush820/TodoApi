using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura os serviços da API
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    // Ativa o Swagger para documentação da API (somente em ambiente de desenvolvimento)
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Força o uso de HTTPS
app.UseRouting(); // Habilita o roteamento da aplicação

// Configuração de CORS (permite requisições de qualquer origem, método e cabeçalho)
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthentication(); // Configura a autenticação da API
app.UseAuthorization();  // Configura a autorização da API

// Define as rotas dos controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();
app.Run();

/// <summary>
/// Configura os serviços da aplicação.
/// </summary>
/// <param name="services">Coleção de serviços da aplicação.</param>
/// <param name="configuration">Configurações da aplicação.</param>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Adiciona os controladores à API
    services.AddControllers();

    // Configuração do banco de dados
    services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("TodosDataBase"))
    );

    // Configuração de autenticação JWT
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = "https://securetoken.google.com/project-4199905854077769334";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/project-4199905854077769334",
                ValidateAudience = true,
                ValidAudience = "project-4199905854077769334",
                ValidateLifetime = true
            };
        });

    // Configuração de injeção de dependência
    services.AddTransient<ITodoRepository, TodoRepository>(); // Repositório de tarefas
    services.AddTransient<TodoHandler, TodoHandler>(); // Handler de tarefas

    // Configuração do Swagger para documentação da API
    services.AddEndpointsApiExplorer();
    // services.AddSwaggerGen();
}
