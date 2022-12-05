using Common.CustomJsonConverters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
builder.Services.AddEndpointsApiExplorer();

// Add configuration to Swagger
builder.Services.AddOpenApiDocument(configure =>
{
    configure.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Money management API";
        document.Info.Description = "Manage the money";
        document.Info.TermsOfService = "https://www.facebook.com/";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Thinh Le",
            Email = "letatthinh.1997@gmail.com",
            Url = "https://www.facebook.com/letatthinh15021997/"
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Use under MIT",
            Url = "https://mit-license.org/"
        };
    };
    configure.AddSecurity("Authorization", Enumerable.Empty<string>(), new OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Name = "Authorization",
        Description = "To authorize, type: Bearer <token>",
        BearerFormat = "JWT",
        In = OpenApiSecurityApiKeyLocation.Header,
    });
});

// For authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = "acackt!x0V7^K64915VveXJo3rOk^sQ0LZCjLFcQ", // Money management front-end application (hashed MD5)
            ValidateIssuer = true,
            ValidAudience = "5vkskuA#S!OX4^wC#H3cW2mhgI48qpT3$TI1weeh", // Money management back-end application
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ld^d753GmWU86HFk")),
            ValidateIssuerSigningKey = true,
        };
    });

// To read data from JWT
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseCors("MyAllowedOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
