using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.Models;
using SistemaDeCompras.DAL;
using SistemaDeCompras.Services.Adm.Pedidos;
using SistemaDeCompras.Services.Adm.Perfis;
using SistemaDeCompras.Services.Adm.Produtos;
using SistemaDeCompras.Services.ClienteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IClienteServices, ClienteServices>();//
builder.Services.AddScoped<IAdmProdutosServices, AdmProdutosServices>();//
builder.Services.AddScoped<IAdmPedidosServices, AdmPedidosServices>();//
builder.Services.AddScoped<IAdmPerfisServices, AdmPerfisServices>();//

builder.Services.AddDbContext<SistemaDeComprasDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();