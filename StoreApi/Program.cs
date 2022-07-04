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

var app = builder.Build();


// builder.Services.AddScoped<IRepository<User>, SQLCustomerRepository>(repo => new SQLUserRepository(builder.Configuration.GetConnectionString("Daniel Pagan")));
// builder.Services.AddScoped<IUserBL, UserBL>();

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
