using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // usado para criar o banco de dados via migrations
            //var connectionString = "Server=localhost;Port=3306;Database=CourseApi;Uid=root;Pwd=DevSysth2025@;";
            var connectionString = "Server=.\\SQLEXPRESS2022;Initial Catalog=CourseApi; MultipleActiveResultSets=True;User Id=sa;Password=DevSysth2025@;";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    
        
        
    }
}
