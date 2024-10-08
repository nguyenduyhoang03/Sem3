using ExamAzure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm Razor Pages và DbContext cho API
builder.Services.AddControllers(); // Thêm Web API support

// Thêm DbContext với SQL Server
builder.Services.AddDbContext<ProjectManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Thêm middleware Swagger
app.UseSwagger(); // Kích hoạt Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty; // Đặt Swagger UI ở gốc
});

// Ánh xạ API controllers và Razor Pages
app.MapControllers();  // Thêm dòng này để ánh xạ các API controller

app.Run();
