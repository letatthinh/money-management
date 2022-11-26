using Common.CustomJsonConverters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Hello issuer 2",
            ValidAudience = "Hello issuer 2",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello key, this should be 128 bits for endcrypt")),
        };
    });

// Register the Swagger services
builder.Services.AddSwaggerDocument(configure =>
{
    configure.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Money management API";
        document.Info.Description = "Manage the money";
        document.Info.TermsOfService = "None";
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
    configure.AddSecurity(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
    {
        In = OpenApiSecurityApiKeyLocation.Header,
        Name = "Api key authentication",
        Description = "Bearer {token}",
        Type = OpenApiSecuritySchemeType.ApiKey,
        BearerFormat = "Jwt",
        Scheme = "Bearer"
    });
});

// Temp
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://www.contoso.com");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

// Temp
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
