var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add the TicketService to the DI container
//builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddSingleton<ITicketService, TicketService>();


builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
    // Other logging providers as needed
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();