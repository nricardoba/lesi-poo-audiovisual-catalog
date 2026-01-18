/// <file>GlobalService.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace BusinessLogic
{
    /// <summary>
    /// BL class to provide generic service methods to the project classes
    /// </summary>
    public class GlobalService
    {
        /// <summary>
        /// Generic clone method.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static object? Clone(object? element)
        {
            if (element is Star auxStar)
                return StarService.Clone(auxStar);

            if (element is Movie auxMovie)
                return MovieService.Clone(auxMovie);

            // vais adicionando tipos de objetos...

            return null;
        }

        /// <summary>
        /// Generic edit method.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
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
