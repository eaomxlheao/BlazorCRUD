﻿using BlazorCRUD.Data.Dapper.Repositorios;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interfaces
{
    public class FilmService : IFilmService
    {
        private IFilmRepository _filmRepository;
        private SqlConfiguration _config;

        public FilmService(SqlConfiguration configuration)
        {
            this._config = configuration;
            this._filmRepository = new FilmRepository(this._config.ConnectionString);
        }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Film>> GetAllFilms()
        {
            throw new NotImplementedException();
        }

        public Task<Film> GetFilmDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.Id == 0)
            {
                return this._filmRepository.InsertFilm(film);
            }
            else
            {
                return null;
            }
        }
    }
}
