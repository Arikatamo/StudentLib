using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VRatings
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Rating { get; set; }
        public int RatingId { get; set; }
        public int SubjectId { get; set; }
        public static implicit operator VRatings(ERatings s)
        {
            return new VRatings
            {
                Id = s.Id,
                Subject = s.Subject.Name,
                Rating = s.Rating.Rating,
                RatingId = s.RatingId,
                SubjectId = s.SubjectId
            };
        }
    }
}
