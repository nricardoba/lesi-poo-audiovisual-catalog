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
        /// <summary>
        /// Property of attribute year.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public int Year
        {
            get { return year; }
            set
            {
                if (IntegrityValidator.IsMovieIntValid(value))
                    year = value;
            }
        }

        /// <summary>
        /// Property of attribute duration.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public int Duration
        {
            get { return duration; }
            set
            {
                if (IntegrityValidator.IsMovieIntValid(value))
                    duration = value;
            }
        }

        /// <summary>
        /// Property of attribute ageRating.
        /// If the variable value is valid, it's assigned.
        /// </summary>
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
        /// <summary>
        /// Default constructor.
        /// Assigns the default values.
        /// </summary>
        public Movie() : base()
        {
            year = Config.CurrentYear;
            duration = Config.DefaultDuration;
            ageRating = Config.DefaultAgeRating;
        }

        /// <summary>
        /// Constructor with all the parameters.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="duration"></param>
        /// <param name="ageRating"></param>
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

        /// <summary>
        /// This constructor will only be called when manipulating binary files.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="duration"></param>
        /// <param name="ageRating"></param>
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
