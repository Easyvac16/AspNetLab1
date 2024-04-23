namespace DIASP
{
	public class Program
	{
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder();

			// Add services to the container.
			builder.Services.AddRazorPages();

			var startup = new Startup(builder.Configuration);

			startup.ConfigureService(builder.Services);

			var app = builder.Build();

			if (!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
