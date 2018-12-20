using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class RatingFeedback
    {
        public int RatingFeedbackId { get; set; }

        public double RatingScore { get; set; }
        public string FeedbackText { get; set; }

        public bool IsDriverFeedback { get; set; }
        public int SentByPassengerId { get; set; }
        public int SentToDriverId { get; set; }
        public DateTime SentByPassengerDateTime { get; set; }

        public bool IsPassengerFeedback { get; set; }
        public int SentByDriverId { get; set; }
        public int SentToPassengerId { get; set; }
        public DateTime SentByDriverDateTime { get; set; }

        public bool IsCarpoolFeedback { get; set; }
        public int FeedbackCarpoolId { get; set; }

        public bool IsCabRequestFeedback { get; set; }
        public int FeedbackCabRequestId { get; set; }

    }
}
