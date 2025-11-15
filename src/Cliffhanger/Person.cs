namespace Cliffhanger
{
    public abstract class Person
    {
        // acho que esta class tem de ser abstrata (só quero criar uma pessoa quando criar por exemplo um ator)
        // (um ator tambem pode ser um escritor ou realizador, depois ver melhor esta parte)
        #region Attributes
        string name = string.Empty;
        DateOnly dateOfBirth;
        #endregion

        #region Methods

        // ver melhor estas propriedades
        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 15) name = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value.Year > 1800) dateOfBirth = value;
            }
        }
        #endregion

        #region Constructors
        // devo criar constantes para as variaveis default?
        public Person()
        {
            name = "Unknown";   // não usei a propriedades, para ter a certeza que fica assim
            dateOfBirth = new DateOnly(1950, 1, 1);
        }

        // os parametros têm de ser verificados antes de passar
        public Person(string name, DateOnly dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        #endregion

        #endregion
    }
}
