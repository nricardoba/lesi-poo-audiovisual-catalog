namespace BusinessObjects
{
    public class MovieDTO : IdentifierDTO
    {
        #region Attributes
        readonly int year;
        readonly int duration;
        readonly AgeRatingType ageRating;
        #endregion

        #region Methods

        #region Properties
        public int Year
        {
            get { return year; }
        }

        public int Duration
        {
            get { return duration; }
        }

        public AgeRatingType AgeRating
        {
            get { return ageRating; }
        }
        #endregion

        #region Constructors
        public MovieDTO(Guid id, string name, int year, int duration, AgeRatingType ageRating)
            : base(id, name)
        {
            this.year = year;
            this.duration = duration;
            this.ageRating = ageRating;
        }

        public MovieDTO(string name, int year, int duration, AgeRatingType ageRating)
            : base(name)
        {
            this.year = year;
            this.duration = duration;
            this.ageRating = ageRating;
        }
        #endregion

        #endregion
    }
}
