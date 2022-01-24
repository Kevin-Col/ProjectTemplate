using BaseApi;
using BaseApi.Extensions;
using BaseApi.Filter;
using Common;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//�ر��Զ���֤
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.ConfigJwt(builder.Configuration);
//�����Զ��������֤������
builder.Services.AddControllers(option => option.Filters.Add<InputDtoValidFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//���ݿ������õ���������
//Microsoft.EntityFrameworkCore (5.0.1 1)
//Pomelo.EntityFrameworkCore.MySql(5.0.2)
builder.Services.AddDbContext<Context>(option => option.UseMySql("server=rm-bp1gsig2xii7jj3126o.mysql.rds.aliyuncs.com;userid=sa;password=kevin888;database=test;", MySqlServerVersion.LatestSupportedServerVersion));
builder.Services.AddAutoMapper(typeof(DtoMapProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CurrentUser, CurrentUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//��Ȩ
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
