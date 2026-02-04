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

var jwtSettings = builder.Configuration.GetSection("Jwt");

var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
       options.TokenValidationParameters = new()
       {
           ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],   // pegar do Docker
            ValidAudience = jwtSettings["Audience"], // pegar do Docker
            IssuerSigningKey = new SymmetricSecurityKey(key) // usa a variável de ambiente
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
