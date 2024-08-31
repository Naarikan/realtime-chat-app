using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Application.Interfaces.Repositories;
using RealTimeChatApp.Domain.Common;
using RealTimeChatApp.Persistence.Context;

namespace RealTimeChatApp.Persistence.Repositories
{
    public class WriteRepository<T>:IWriteRepository<T> where T : class,IEntityBase,new()
    {
        private readonly AppDbContext _db;

        public WriteRepository(AppDbContext db)
        {
            _db = db;
        }
        private DbSet<T> Table { get => _db.Set<T>(); }

        public async Task AddAsync(T item)
        {
            await Table.AddAsync(item);
        }

        public async Task AddRangeAsync(IList<T> items)
        {
            await Table.AddRangeAsync(items);
        }


        public async Task DestroyAsync(T item)
        {

            await Task.Run(() => Table.Remove(item));
        }

        public async Task DestroyRangeAsync(IList<T> item)
        {
            await Task.Run(() => Table.RemoveRange(item));
        }

        public async Task<T> UpdateAsync(T item)
        {
            await Task.Run(() => Table.Update(item));
            return item;
        }
    }
}
