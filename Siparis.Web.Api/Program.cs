using Siparis.BussinessLayer.Abstract;
using Siparis.BussinessLayer.Concrete;
using Siparis.DataAccessLayer.Abstract;
using Siparis.DataAccessLayer.Concrete;
using Siparis.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();



builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("SiparisApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("SiparisApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
