using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Domain.Utils
{
    public class Paginated<T, U> : List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalItems { get; private set; }

        public int NumItemsStartPage { get; private set; }

        public int NumItemsEndPage { get; private set; }

        public Paginated(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalItems = count;
            var result = (pageIndex * pageSize);
            NumItemsStartPage = (result - pageSize) + 1;
            NumItemsEndPage = result > TotalItems ? TotalItems : result;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<Paginated<T, U>> CreateAsync(IQueryable<U> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            //var newItems = items.Select(items => (T)(dynamic)items).ToList();

            //return new Paginated<T, U>(newItems, count, pageIndex, pageSize);
            return null;
        }
        public static Paginated<T, U> Create(ICollection<U> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //var newItems = items.Select(items => (T)(dynamic)items).ToList();

            //return new Paginated<T, U>(newItems, count, pageIndex, pageSize);
            return null;
        }
    }
}
