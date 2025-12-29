using BusinessObjects;

namespace BusinessLogic
{
    public static class GlobalService
    {
        public static object? Clone(object? element)
        {
            if (element is Star auxStar)
                return StarService.Clone(auxStar);

            // vais adicionando tipos de objetos...

            return null;
        }

        public static bool Edit(object? element, object? dto)
        {
            if (element is Star auxStar && dto is StarDTO auxDTO)
                return StarService.Edit(auxStar, auxDTO);

            // vais adicionando tipos de objetos...

            return false;
        }
    }
}
