using SGE.UI.Components;

//agregamos estas directivas using
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

var builder = WebApplication.CreateBuilder(args);

EntidadesSqlite.Inicializar();

//agregamos estos servicios al contenedor DI
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();

builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorExpediente>();

builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificarPermisos>();


builder.Services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddSingleton<ITramiteRepositorio, TramiteRepositorio>();
builder.Services.AddSingleton<IExpedienteRepositorio, ExpedienteRepositorio>();


builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddTransient<IEspecificacionCambioEstado, EspecificacionCambioEstado>();
builder.Services.AddTransient<ServicioActualizacionEstado>();
builder.Services.AddTransient<IUsuarioValidador, UsuarioValidador>();
builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddSingleton<IServicioSesion, ServicioSesion>();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
