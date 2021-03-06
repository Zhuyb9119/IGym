using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using IGym.EFRepository.Model;
using IGym.Interface.IRepository;
using IGym.IRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IGym.EFRepository.Impl
{
    public class EfDbContext : DbContext, IDbContext
    {
        private readonly IDataRepository _context;
        private readonly IAddDbService _service;

        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            _context = new EFDataRepository(this);
            _service = new AddDbService();
        }

        //OpenSSL SSL_read: Connection was reset, errno 10054
        //git config lfs.https://github.com/Zhuyb9119/IGym.git/info/lfs.locksverify false
        //https://github.com/Zhuyb9119/IGym.git
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void AddService(IServiceCollection services, string connection)
        {
            _service.AddService(services, connection);
        }

        public DbSet<User> Users { get; set; }

        public IDataRepository Context => _context;
    }
}
