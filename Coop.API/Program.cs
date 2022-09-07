using Coop.API.Base;
using Coop.API.Cliente;
using Coop.API.Cliente.Routes;
using Coop.API.Cuenta;
using Coop.API.Cuenta.Routes;
using Coop.API.Movimiento;
using Coop.API.Movimiento.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.BaseBuilder();
builder.Services.ClienteServices();
builder.Services.CuentaServices();
builder.Services.MovimientoServices();
builder.Services.BaseServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.ClienteRoutes();
app.CuentaRoutes();
app.MovimientoRoutes();
app.MovimientoReporteRoutes();

app.Run();

public partial class Program { }