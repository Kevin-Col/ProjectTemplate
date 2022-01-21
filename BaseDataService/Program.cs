using Common;
using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//数据库连接用到的两个包
//Microsoft.EntityFrameworkCore (5.0.1 1)
//Pomelo.EntityFrameworkCore.MySql(5.0.2)
builder.Services.AddDbContext<Context>(option => option.UseMySql("server=rm-bp1gsig2xii7jj3126o.mysql.rds.aliyuncs.com;userid=sa;password=kevin888;database=test;", MySqlServerVersion.LatestSupportedServerVersion));
builder.Services.AddAutoMapper(typeof(DtoMapProfile));

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
