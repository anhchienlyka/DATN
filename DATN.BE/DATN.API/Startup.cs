using DANTN.ApplicationLayer.Implement;
using DANTN.ApplicationLayer.Interface;
using DATN.Data.MappingProfiles;
using DATN.DataAccessLayer.EF;
using DATN.DataAccessLayer.EF.Implementations;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.SeedData;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DATN.API
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
            services.AddDbContext<DATNDBContex>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"));
                options.LogTo(Console.WriteLine);
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DATN.API", Version = "v1" });
            });

            services.AddHttpContextAccessor();

            //Seed data
            services.AddTransient<SeeDatas>();

            //Auto mapper
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //repository
            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<ICommentRepository,CommentRepository>();
            services.AddTransient<IPaymentRepository,PaymentRepository>();
            services.AddTransient<IOrderDetailRepository,OrderDetailRepository>();
            services.AddTransient<IPictureRepository,PictureRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ISaleCodeRepository,SaleCodeRepository>();
            services.AddTransient<ISupplierRepository,SupplierRepository>();
            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient<IRoleRepository,RoleRepository>();
            //Service
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISaleCodeService, SaleCodeService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DATN.API v1"));
            }

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