using IDoContent.Data;
using IDoContent.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<APIContext>(opt => opt.UseInMemoryDatabase("ContentDB"));
builder.Services.AddDbContext<APIContext>(options =>
{
    options.UseSqlServer("Server=104.247.167.130\\MSSQLSERVER2022;Database=sezerala_api;User Id=sezerala_api;Password=Bzs2p582@;TrustServerCertificate=True");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

builder.Services.AddScoped<JwtService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>

{

    c.SwaggerDoc("v1", new OpenApiInfo

    {

        Version = "v1",

        Title = "JWT Api",

        Description = "Secures API using JWT",

        Contact = new OpenApiContact

        {

            Name = "Simuzeche Kaluwa",

            Email = "simuzechek@gmail.com",

            Url = new Uri("https://www.google.mw/")



        }

    });

    // To Enable authorization using Swagger (JWT)  

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()

    {

        Name = "Authorization",

        Type = SecuritySchemeType.ApiKey,

        Scheme = "Bearer",

        BearerFormat = "JWT",

        In = ParameterLocation.Header,

        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",

    });



    c.AddSecurityRequirement(new OpenApiSecurityRequirement

                {

                    {

                          new OpenApiSecurityScheme

                            {

                                Reference = new OpenApiReference

                                {

                                    Type = ReferenceType.SecurityScheme,

                                    Id = "Bearer"

                                }

                            },

                            new string[] {}



                    }

                });

});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
});
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
