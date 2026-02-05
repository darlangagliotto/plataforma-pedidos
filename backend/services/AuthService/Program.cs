using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

/*
 * ============================
 * SERVICE REGISTRATION
 * ============================
 */

// Adiciona suporte a Controllers (API REST)
builder.Services.AddControllers();

/*
 * Necessário para que o Swagger
 * consiga descobrir endpoints automaticamente
 */
builder.Services.AddEndpointsApiExplorer();

/*
 * Registra o Swagger Generator.
 * Versão simples, sem customização.
 * Customizações (JWT, versões, security)
 * entram em módulos futuros.
 */
builder.Services.AddSwaggerGen();

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey!))
        };
    });

var app = builder.Build();

/*
 * ============================
 * HTTP PIPELINE
 * ============================
 */

if (app.Environment.IsDevelopment())
{
    // Gera o swagger.json
    app.UseSwagger();

    // Interface gráfica do Swagger UI
    app.UseSwaggerUI();
}

/*
 * Redireciona HTTP → HTTPS
 */
app.UseHttpsRedirection();

/*
 * Middleware de autorização
 * (JWT será adicionado depois)
 */
app.UseAuthentication();
app.UseAuthorization();

/*
 * Mapeia os Controllers
 */
app.MapControllers();

app.Urls.Add("http://0.0.0.0:8081");

/*
 * Inicializa a aplicação
 */
app.Run();
