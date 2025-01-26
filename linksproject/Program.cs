using links.Core.Repositories;
using links.Core.services;
using links.Core.Services;
using links.Data;
using links.Data.Repositories;
using links.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(); 

builder.Services.AddControllers();
        //�������
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        //������
        builder.Services.AddScoped<IRecommendRepository, RecommendRepository>();
        builder.Services.AddScoped<IRecommendService, RecommendService>();
        //�������
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        //�����
        builder.Services.AddScoped<IWebRepository, WebRepository>();
        builder.Services.AddScoped<IWebService, WebService>();
//���� ������
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