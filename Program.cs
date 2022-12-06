using Akhil_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

/*Identity Token Authentication using Identity Server - START*/
/*========================================================================================================*/
//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//        options.Authority = "https://localhost:5001";
//        options.Audience = "scope1";
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateAudience = false
//        };
//    });
/*========================================================================================================*/
/*Identity Token Authentication using Identity Server - END*/



/*Identity Token Authentication - START*/
/*========================================================================================================*/
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = "https://localhost:7007",
            ValidAudience = "https://localhost:7007",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my Secret Token Key")),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
        //ValidIssuer = "https://localhost:7007",
        //options.Authority = "https://localhost:7007";
        ////options.Audience = "scope1";
        //options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        //{
        //    ValidateAudience = true
        //};
    });
/*========================================================================================================*/
/*Identity Token Authentication - END*/

builder.Services.AddAuthorization();

/*API Versioning - START*/
/*========================================================================================================*/
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;

    //Custom API Version name
    //options.ApiVersionReader = new QueryStringApiVersionReader("ak-api-version");

    //Default API Version name
    options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");

});
/*========================================================================================================*/
/*API Versioning - END*/

//builder.Services.AddVersionedApiExplorer(options =>
//{
//    options.GroupNameFormat = "v'V'";
//    options.SubstituteApiVersionInUrl = true;
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseInMemoryDatabase("Shop");
});

//builder.Services.AddDbContext<CoreDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Database")));

//string connString = builder.Configuration.GetConnectionString("dukeConnectionString");
builder.Services.AddDbContext<CoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});


/*Enalbe CORS with Web Application Url - START*/
/*========================================================================================================*/
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7152")
        .AllowAnyHeader()
        .AllowAnyMethod();
        //.WithHeaders("X-API-Version");
    });
});
/*========================================================================================================*/
/*Enalbe CORS with Web Application Url - END*/


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();
