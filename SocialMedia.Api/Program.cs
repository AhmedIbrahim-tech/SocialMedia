

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Model State Invalid

builder.Services.AddControllers()
// To Filter ModelState Invalid
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


// Add ValidationFilter.cs 
//builder.Services.AddMvc(options => options.Filters.Add<ValidationFilter>());

#endregion

#region Add Fluent Validation

builder.Services
    .AddMvc(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

//builder.Services.AddMvc().AddFluentValidation(options => { options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())});

#endregion

#region Connection Database

builder.Services.AddDbContext<SocialMediaContext>(option =>
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(SocialMediaContext).Assembly.FullName)));

#endregion

#region Dependency Injection

builder.Services.AddTransient<IPostServices, PostServices>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Auto mapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion



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
