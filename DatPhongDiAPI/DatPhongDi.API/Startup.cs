using DatPhongDi.BAL.Implement;
using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Implement;
using DatPhongDi.DAL.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DatPhongDi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            //add scope for typeOfRoom
            services.AddScoped<ITypeOfRoomService, TypeOfRoomService>();
            services.AddScoped<ITypeOfRoomRepository, TypeOfRoomRepository>();

            //add scope for Room
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            //add scope for Booking
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();


            //add scope for Customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatPhongDi API");
            });
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //end Configure swagger

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
