using StoreBL;
using StoreDL;
using StoreModel;

var builder = WebApplication.CreateBuilder(args);


// Adding CORS to allow all origins to have acess to our backend
builder.Services.AddCors(
    (options) =>
    {
        options.AddDefaultPolicy(origin =>
        {

            origin.AllowAnyOrigin(); //Allows any origin to talk to your backend
            origin.AllowAnyMethod(); //Allows any http verb request in our backend
            origin.AllowAnyHeader(); //Allows any http headers to have access to my backend
        });
    }
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddScoped<IRepository<User>, SqlUserRepository>(repo => new SqlUserRepository(builder.Configuration.GetConnectionString("Daniel Pagan")));
// builder.Services.AddScoped<IUserBL, UserBL>();
// builder.Services.AddScoped<IRepository<Products>, SqlProductsRepository>(repo => new SqlProductsRepository(builder.Configuration.GetConnectionString("Daniel Pagan")));
// builder.Services.AddScoped<IProductsBL, ProductsBL>();

builder.Services.AddScoped<IRepository<User>, SqlUserRepository>(repo => new SqlUserRepository(Environment.GetEnvironmentVariable("Daniel Pagan")));
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IRepository<Products>, SqlProductsRepository>(repo => new SqlProductsRepository(Environment.GetEnvironmentVariable("Daniel Pagan")));
builder.Services.AddScoped<IProductsBL, ProductsBL>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
