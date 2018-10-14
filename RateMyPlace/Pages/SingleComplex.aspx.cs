using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace RateMyPlace.Pages
{
    public partial class SingleComplex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //whenever you click button it will load page and then call this function

        public void DetermineStatistics()
        {
            //set complexName to an empty string just to clear errors. need to figure out how to get that data
            string complexName = "";
            string maxOverall;
            string minOverall;
            string averageOverall;

            string minNoise;
            string maxNoise;
            string averageNoise;

            string minSafety;
            string maxSafety;
            string averageSafety;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@HousingComplex", complexName));
            DataTable credentials = Connection.RunSQL("SELECT HousingComplex, average(overallRating) AS overallAverageAlias," +
                                                      " min(overallRating) AS overallMinAlias, max(overallRating) AS overallMaxAlias, " +
                                                      "average(noise) AS avgNoiseAlias, max(noise) AS maxNoiseAlias, min(noise) AS minNoiseAlias, " +
                                                      "average(safety) AS avgSafetyAlias, min(safety) AS minSafetyAlias, max(safety) AS maxSafetyAlias, " +
                                                      "average(maintenance) AS avgMaintenanceAlias, min(maintenance) AS minMaintenanceAlias," +
                                                      " max(maintenance) AS maxMaintenanceAlias, average(utilities) AS avgUtilitiesAlias" +
                                                      "min(utilities) AS minUtilitiesAlias, max(utilities) AS maxUtilitiesAlias," +
                                                      " average(rent) AS avgRentAlias, " +
                                                      "min(rent) AS minRentAlias, max(rent) AS maxRentAlias " +
                                                      "FROM Reviews where HousingComplex = @ComplexName", parameters);
            complexName = credentials.Rows[0]["HousingComplex"].ToString();

            //getting data from the dataTable rows and columns that were just retrieved
            averageOverall = credentials.Rows[0]["overallAverageAlias"].ToString();
            minOverall = credentials.Rows[0]["overallMinAlias"].ToString();
            maxOverall = credentials.Rows[0]["overallMaxAlias"].ToString();

            //process of converting from strings to floats or ints
            float overallAverageRating = float.Parse("averageOverall");
            int overallMinRating = int.Parse("minOverall");
            int overallMaxRating = int.Parse("maxOverall");

            averageNoise = credentials.Rows[0]["avgNoiseAlias"].ToString();
            maxNoise = credentials.Rows[0]["overallMaxAlias"].ToString();
            minNoise = credentials.Rows[0]["overallMinAlias"].ToString();

            float noiseAverageRating = float.Parse("averageNoise");
            int noiseMinRating = int.Parse("minNoise");
            int noiseMaxRating = int.Parse("maxNoise");

            averageSafety = credentials.Rows[0]["avgSafetyAlias"].ToString();
            minSafety = credentials.Rows[0]["minSafetyAlias"].ToString();
            maxSafety = credentials.Rows[0]["maxSafetyAlias"].ToString();

            float safetyAverageRating = float.Parse("averageSafety");
            int minSafetyRating = int.Parse("minSafety");
            int maxSafetyRating = int.Parse("maxSafety");

            string minMaintenance = credentials.Rows[0]["minMaintenanceAlias"].ToString();
            string maxMaintenance = credentials.Rows[0]["maxMaintenanceAlias"].ToString();
            string averageMainenance = credentials.Rows[0]["avgMaintenanceAlias"].ToString();

            int minMaintenanceRating = int.Parse("minMaintenance");
            int maxMaintenanceRating = int.Parse("maxMaitenance");
            float averageMaintenanceRating = float.Parse("averageMaintenace");

            string minUtilities = credentials.Rows[0]["minUtilitiesAlias"].ToString();
            string maxUtilities = credentials.Rows[0]["maxUtilitiesAlias"].ToString();
            string averageUtilities = credentials.Rows[0]["avgUtilitiesAlias"].ToString();

            int minUtilitiesRating = int.Parse("minUtilities");
            int maxUtilitiesRating = int.Parse("maxUtilities");
            float averageUtilitiesRating = float.Parse("averageUtilities");

            string minRent = credentials.Rows[0]["minRentAlias"].ToString();
            string maxRent = credentials.Rows[0]["maxRentAlias"].ToString();
            string averageRent = credentials.Rows[0]["avgRentAlias"].ToString();

            int minRentRating = int.Parse("minRent");
            int maxRentRating = int.Parse("maxRent");
            float averageRentRating = float.Parse("averageRent");
        }
    }
}
