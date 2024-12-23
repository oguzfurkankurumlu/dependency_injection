var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// DEpendency Injection ile, nesne örnepini kullanacağımız sınıfı ve interface'i verdik!!
// Action içerisinde bu helper sınıfını kullanalım!!
builder.Services.AddScoped<IHelper,Helper>();
builder.Services.AddScoped<IPayment,Payment>();

// c# da yazılan her sınıfın bir interfacesi olması gerekmektedir. Ancak internfacesi olmasa da dependency injection olarak eklenebilir

builder.Services.AddScoped(typeof(MakeJson));



// DEpendency Injection ile, nesne örnepini kullanacağımız sınıfı ve interface'i verdik!!
// Action içerisinde bu helper sınıfını kullanalım!!
builder.Services.AddScoped<IHelper,Helper>();
builder.Services.AddScoped<IPayment,Payment>();

// c# da yazılan her sınıfın bir interfacesi olması gerekmektedir. Ancak internfacesi olmasa da dependency injection olarak eklenebilir

builder.Services.AddScoped(typeof(MakeJson));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();