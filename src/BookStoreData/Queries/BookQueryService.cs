using BookStoreData.Data;
using BookStoreData.Interfaces;
using BookStoreData.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreData.Queries
{
    public class BookQueryService : IBookQueryService
    {
        private readonly BookStoreContext _dbContext;

        public BookQueryService(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// This method performs the sum on the database rather than in memory
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<BookDetailsModel> GetBookDetailsAsync(long bookId)
        {
            var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.GetBookDetails";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@BookId", SqlDbType.BigInt) { Value = bookId });
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            using var reader = cmd.ExecuteReader();
            var list = new List<BookDetailsModel>();
            while (reader.Read())
            {
                var id = long.Parse(reader[0].ToString());
                var title = reader.GetString(1);
                var categoryId = long.Parse(reader[2].ToString());
                var categoryName = reader.GetString(3);
                long? reviewId = string.IsNullOrEmpty(reader[4].ToString()) ? null : long.Parse(reader[4].ToString());
                var reviewText = reader[5].ToString();
                list.Add(new BookDetailsModel
                {
                    Id = id,
                    Title = title,
                    CategoryId = categoryId,
                    CategoryName = categoryName,
                    ReviewId = reviewId,
                    ReviewText = reviewText
                });
            }

            return list.FirstOrDefault();
        }
    }
}
