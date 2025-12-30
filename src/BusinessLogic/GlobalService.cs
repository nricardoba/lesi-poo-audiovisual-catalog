using BusinessObjects;

namespace BusinessLogic
{
    public static class GlobalService
    {
        public static object? Clone(object? element)
        {
            if (element is Star auxStar)
                return StarService.Clone(auxStar);

            if (element is Movie auxMovie)
                return MovieService.Clone(auxMovie);

            // vais adicionando tipos de objetos...

            return null;
        }

        public static bool Edit(object? element, object? dto)
        {
            if (element is Star auxStar && dto is StarDTO auxStarDTO)
                return StarService.Edit(auxStar, auxStarDTO);

            if (element is Movie auxMovie && dto is MovieDTO auxMovieDTO)
                return MovieService.Edit(auxMovie, auxMovieDTO);

            // vais adicionando tipos de objetos...

            return false;
        }
    }
}
