using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Dinner
    {
        public int DinnerID { get; set; }
        [Required(ErrorMessage = "Please enter a Dinner Title")]
        [StringLength(20, ErrorMessage = "Title is too long")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Date of the Dinner")]
        public DateTime EventDate { get; set; }
        [Required(ErrorMessage ="Please enter the location of the Dinner")]
        [StringLength(30, ErrorMessage = "Address is too long")]
        public string Description { get; set; }
        public string Address { get; set; }
        public string HostedBy { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual ICollection<RSVP> RSVPs { get; set; }

        public bool IsUserRegistered(string userName)
        {
            return RSVPs.Any(r => r.AttendeeName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}