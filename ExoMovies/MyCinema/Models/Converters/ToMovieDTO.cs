using MyCinema.Data.Models;
using MyCinema.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCinema.Models.Converters
{
    public static class ToMovieDTO
    {
        public static MovieDTO ToDTO(this Movie m)
        {
            return new MovieDTO
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Director = m.Director,
                Resume = m.Resume,
                ReleaseDate = m.ReleaseDate,
                CoverURL = m.CoverURL
            }; 
        }

        public static IEnumerable<MovieDTO> ToDTO(this IEnumerable<Movie> liste)
        {
            return liste.Select(m => m.ToDTO());
        }
    }
}