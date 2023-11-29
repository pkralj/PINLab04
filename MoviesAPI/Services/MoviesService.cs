using System;
using MoviesAPI.Data;

namespace MoviesAPI.Services
{
	public class MoviesService
	{
		private readonly MovieContext _dbContext;

        public MoviesService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

		public List<Movie> getAllMovies()
		{
			return _dbContext.Movies.ToList();
		}

		public Movie? getmovieByID(int id)
		{
			return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
		}

		public Movie? updateMovie(int id, MovieVM movieVM)
		{
			var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
			if (movie != null) {
				movie.Name = movieVM.Name;
				movie.Year = movieVM.Year;
				movie.Genre = movieVM.Genre;

				_dbContext.Movies.Update(movie);
				_dbContext.SaveChanges();
			}
			return movie;
        }

		public void deleteMovie(int id)
		{
			var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
			if (movie == null)
			{
				return;
			}
			_dbContext.Remove(movie);
			_dbContext.SaveChanges();
		}

		public void addMovie(MovieVM movieVM)
		{
			Movie movie = new Movie() { Name = movieVM.Name, Year = movieVM.Year, Genre = movieVM.Genre };
			_dbContext.Add(movie);
			_dbContext.SaveChanges();
		}

	}
}

