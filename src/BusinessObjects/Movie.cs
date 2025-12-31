namespace BusinessObjects
{
    /// <summary>
    /// Class containing information about a movie
    /// </summary>
    public class Movie : Identifier
    {
        #region Attributes
        int year;
        int duration;
        AgeRatingType ageRating;
        #endregion

        #region Methods

        #region Properties
        public int Year
        {
            get { return year; }
            set
            {
                if (IntegrityValidator.IsMovieIntValid(value))
                    year = value;
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                if (IntegrityValidator.IsMovieIntValid(value))
                    duration = value;
            }
        }

        public AgeRatingType AgeRating
        {
            get { return ageRating; }
            set
            {
                if (IntegrityValidator.IsAgeRatingValid((int)value))
                    ageRating = value;
            }
        }
        #endregion

        #region Constructors
        public Movie() : base()
        {
            year = Config.CurrentYear;
            duration = Config.DefaultDuration;
            ageRating = Config.DefaultAgeRating;
        }

        public Movie(string name, int year, int duration, AgeRatingType ageRating)
            : base(name)
        {
            this.year = IntegrityValidator.IsMovieIntValid(year)
                ? year : Config.CurrentYear;

            this.duration = IntegrityValidator.IsMovieIntValid(duration)
                ? duration : Config.DefaultDuration;

            this.ageRating = IntegrityValidator.IsAgeRatingValid((int)ageRating)
                ? ageRating : Config.DefaultAgeRating;
        }

        // este contrutor só vai ser chamado ao ler ficheiros binarios
        public Movie(Guid id, string name, int year, int duration, AgeRatingType ageRating)
            : base(id, name)
        {
            this.year = IntegrityValidator.IsMovieIntValid(year)
                ? year : Config.CurrentYear;

            this.duration = IntegrityValidator.IsMovieIntValid(duration)
                ? duration : Config.DefaultDuration;

            this.ageRating = IntegrityValidator.IsAgeRatingValid((int)ageRating)
                ? ageRating : Config.DefaultAgeRating;
        }
        #endregion

        #endregion
    }
}
