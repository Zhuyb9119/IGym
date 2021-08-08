﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using IGym.EFRepository.Model;
using IGym.Interface.IRepository;
using IGym.IRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IGym.EFRepository.Impl
{
    public class EfDbContext : DbContext, IDbContext
    {
        private readonly IDataRepository _context;
        
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            _context = new EFDataRepository(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }

        public IDataRepository Context => _context;
    }
}