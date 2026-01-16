/// <file>MovieDTO.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

namespace BusinessObjects
{
    /// <summary>
    /// Data Transfer Object of Movie class
    /// </summary>
    public class MovieDTO : IdentifierDTO
    {
        #region Attributes
        readonly int year;
        readonly int duration;
        readonly AgeRatingType ageRating;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute year.
        /// Just returns the value of the attribute.
        /// </summary>
        public int Year
        {
            get { return year; }
        }

        /// <summary>
        /// Property of attribute duration.
        /// Just returns the value of the attribute.
        /// </summary>
        public int Duration
        {
            get { return duration; }
        }

        /// <summary>
        /// Property of attribute ageRating.
        /// Just returns the value of the attribute.
        /// </summary>
        public AgeRatingType AgeRating
        {
            get { return ageRating; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to be used for clones.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="duration"></param>
        /// <param name="ageRating"></param>
        public MovieDTO(Guid id, string name, int year, int duration, AgeRatingType ageRating)
            : base(id, name)
        {
            this.year = year;
            this.duration = duration;
            this.ageRating = ageRating;
        }

        /// <summary>
        /// Constructor to be used to edit attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="duration"></param>
        /// <param name="ageRating"></param>
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
