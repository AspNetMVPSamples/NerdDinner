using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace NerdDinner.Web.Models
{
    public class Dinner
    {
        [HiddenInput(DisplayValue = false)]
        public int DinnerID { get; set; }

        public string Title { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }
        public string HostedBy { get; set; }

        public string ContactPhone { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        //public DbGeography Location { get; set; }

        public virtual ICollection<RSVP> RSVPs { get; set; }

        public bool IsHostedBy(string userName)
        {
            return String.Equals(HostedBy, userName, StringComparison.Ordinal);
        }

        public bool IsUserRegistered(string userName)
        {
            return RSVPs.Any(r => r.AttendeeName == userName);
        }

        public LocationDetail LocationDetail
        {
            get
            {
                return new LocationDetail() { /*Location = this.Location,*/ Id = this.DinnerID, Title = this.Title, Address = this.Address };
            }
            set
            {
                //this.Location = value.Location;
                this.DinnerID = value.Id;
                this.Title = value.Title;
                this.Address = value.Address;
            }
        }
    }
    public class LocationDetail
    {
        //public DbGeography Location;
        public int Id;
        public string Title;
        public string Address;
    }
}