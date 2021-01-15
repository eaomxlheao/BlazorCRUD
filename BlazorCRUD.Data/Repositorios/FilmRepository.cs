using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositorios
{
    public class FilmRepository : IFilmRepository
    {
        private string ConnectionString;
        protected SqlConnection dbConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        public FilmRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
            var db = dbConnection();
            var sql = @"SELECT Id,Title,Director,ReleaseDate FROM Film";
            return await db.QueryAsync<Film>(sql.ToString(), new { });
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT Id,Title,Director,ReleaseDate FROM Film WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Film>(sql.ToString(), new { Id = id });
        }

        public async Task<bool> InsertFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Film
                (Title,Director,ReleaseDate)
                VALUES
                (@Title,@Director,@ReleaseDate)";

            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate });
            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"UPDATE Film
                SET Title=@Title,Director=@Director,ReleaseDate=@ReleaseDate 
                WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate, film.Id });
            return result > 0;
        }
    }
}
