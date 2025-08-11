// Configurar o ASP.NET Core Identity
// Artigo - 31/05/2023
// https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-7.0#password

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosAPI.Authorization;
using UsuariosAPI.Data;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//string? connString = builder.Configuration.GetConnectionString("UsuarioConnection");
//string? connString = builder.Configuration["DevConnection"]!;
// "DevConnection": "Server=(local)\\sqlexpress;Database=BD_Login;Trusted_Connection=True;MultipleActiveResultSets=True;"
string? connString = builder.Configuration.GetConnectionString("DevConnection");



// Add services to the container.
builder.Services.AddDbContext<UsuarioDBContext>(
    opts =>
    {
        opts.UseSqlServer(connString);
    });

builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper
    (AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var securityKey = builder.Configuration["SymmetricSecurityKey"];
if (string.IsNullOrEmpty(securityKey))
    throw new InvalidOperationException("SymmetricSecurityKey is not configured.");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});


// Informa que utiliza autenticação via token JWT (.AddJwtBearer).
/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters
    = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"]!)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});
*/
//*** ATENÇÃO! POLICY! Idade Mínima 18 anos!
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy =>
    {
        policy.AddRequirements(new IdadeMinima(18));
    });
});

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

// CORS PARA LIBERAR ROTAS DE ACESSO DE DESTINO
// NECESSÁRIO SEMPRE QUE ADICIONAR UMA NOVA ROTA NO CORS
// É NECESSÁRIO ADD A PORTA DA INTEGRAÇÃO AQUI 
// GERALMENTE USA HTTPS PARA CERTIFICADO SSL  / SEM CERTIFICADO PODE USAR HTTP 
// CASO A APLICAÇÃO NECESSITE DE HTTPS MESMO NECESSÁRIO UM CERTIFICADO SSL

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(
                "http://localhost:5500",
                "http://127.0.0.1:5500",
                "https://localhost:5500",
                "https://127.0.0.1:5500",
                "http://127.0.0.1:5502",
                "http://127.0.0.1:5501",
                "http://127.0.0.1:5502/index.html"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend"); // <-- Adicione aqui

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
