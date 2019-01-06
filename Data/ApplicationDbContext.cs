using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Customer.Models;


namespace Customer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Burada veri tabanı ile nasıl iletişime geçileceği, okunacağı veya yazılacağı belirlenir.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         /* Migration(Göç) Oluşturma:

            1. [ dotnet ef migrations add tCust ]
            * Program.cs klasöründe olduğunuzdan emin olunuz.

            2. [ dotnet ef migrations list ] : Göç listesini 

            3. [ dotnet ef database update ]

            4. [ dotnet ef database update CreateIdentitySchema ] 
            Bu komut CreateIdentitySchema dan sonra oluşturulmuş 
            tüm *göçlerin Down metodunu çalıştıracaktır.

            5. veri tabanını tamamen silmek istiyorsanız. 
                [ dotnet ef database drop ] kullanabilirsiniz. 
                Ardından [ dotnet ef database update ]
                yazdığınızda son Göç e kadar tüm göçler çalıştırılır.
        */
        public DbSet<Cust> tCust { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
