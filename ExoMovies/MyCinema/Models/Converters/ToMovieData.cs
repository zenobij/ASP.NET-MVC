using MyCinema.Data.Models;
using MyCinema.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCinema.Models.Converters
{
    public static class ToMovieData
    {
        public static Movie ToData(this MovieDTO m)
        {
            return new Movie
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Director = m.Director,
                Resume = m.Resume,
                ReleaseDate = m.ReleaseDate,
                CoverURL = m.CoverURL
            };
        }

        public static IEnumerable<Movie> ToData(this IEnumerable<MovieDTO> liste)
        {
            return liste.Select(m => m.ToData());
        }
    }
}