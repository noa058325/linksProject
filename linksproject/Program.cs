using Project.Core.Repositories;
using Project.Core.services;
using Project.Core.Services;
using Project.Data;
using Project.Data.Repositories;
using Project.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(); 

builder.Services.AddControllers();
        //קטגוריה
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        //תגובות
        builder.Services.AddScoped<IRecommendRepository, RecommendRepository>();
        builder.Services.AddScoped<IRecommendService, RecommendService>();
        //משתמשים
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        //אתרים
        builder.Services.AddScoped<IWebRepository, WebRepository>();
        builder.Services.AddScoped<IWebService, WebService>();
//דאטה קונטכס
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{ 

app.UseSwagger();
app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();