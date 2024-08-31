using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class,IEntityBase,new()
    {
        Task AddAsync(T item);
        Task AddRangeAsync(IList<T> items);

        Task<T> UpdateAsync(T item);

        Task DestroyAsync(T item);

        Task DestroyRangeAsync(IList<T> item);
    }
}
