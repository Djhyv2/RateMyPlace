using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyPlace.Classes
{
    public class Review
    {
        private int rating;

        public Review()
        {

        }

        public void SendSQLCommand( string command )
        {
            //Send the sqlCommand variable to the database here.
        }

        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }
    }
}