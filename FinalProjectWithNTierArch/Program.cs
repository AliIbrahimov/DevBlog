using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Extentions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entity.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
});
builder.Services.AddAutoMapper(typeof(Business.Utilities.Profiles.Mapper));
builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<IStatisticService, StatisticManager>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IChooseUsRepository, ChooseUsRepository>();
builder.Services.AddScoped<IChooseUsService, ChooseUsManager>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServicesService, ServicesManager>();
builder.Services.AddScoped<IDeveloperService, DeveloperManager>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IQuoteService, QuoteManager>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ISettingService, SettingManager>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
    options.User.RequireUniqueEmail = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.ImplicitlyValidateChildProperties = true;
    opt.ImplicitlyValidateRootCollectionElements = true;
    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.CustomExceptionHandler();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
