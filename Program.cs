using Dashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Dashboard.Areas.Identity.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		{
			//info 1: it uses UseSqlServer
			//info 2: it uses DefaultConnection connection line
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		});

		builder.Services.AddDbContext<DashboardDbContext>(options =>
		{
			//info 1: it uses UseSqlServer
			//info 2: it uses DefaultConnection connection line
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		});

		builder.Services.AddDefaultIdentity<DashboardUser>(options => options.SignIn.RequireConfirmedAccount = true)
	    .AddEntityFrameworkStores<DashboardDbContext>();
		builder.Services.AddRazorPages();
<<<<<<< HEAD

		//must be added to use session
		builder.Services.AddSession();
=======
>>>>>>> 054a4bacd529ccc22a35d039283f75f5f735bba5
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
<<<<<<< HEAD
        //must be added to use session
        app.UseSession();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Shopping}/{action=Index}/{id?}");

        app.MapRazorPages();
        //used to trace the problem if there is one when excuting
        app.UseDeveloperExceptionPage();
=======
       
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();
>>>>>>> 054a4bacd529ccc22a35d039283f75f5f735bba5
        app.Run();
    }
}
