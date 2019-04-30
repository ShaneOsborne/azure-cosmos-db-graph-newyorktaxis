using BusinessObjects;
using Microsoft.Azure.CosmosDB.BulkExecutor.Graph.Element;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBulkExecutor
{
    public static class ConvertBusinessObjects
    {
        //Keys for import
        private static int GreenTripVertexIndex = 1;

        public static IEnumerable<GremlinVertex> ConvertGreenTripsToVertices(IEnumerable<GreenTrip> greenTrips, List<GremlinVertex> Veritices, List<GremlinEdge> edges)
        {
            foreach (GreenTrip trip in greenTrips)
            {
                string thisIndex = GreenTripVertexIndex++.ToString();
                string greenTripKey = "greentrip." + thisIndex;
                String greenTripPK = String.Format("{0}:{1}", trip.VendorID, thisIndex);

                GremlinVertex v = new GremlinVertex(greenTripKey, "greentrip");
                v.AddProperty(ConfigurationManager.AppSettings["CollectionPartitionKey"], greenTripPK);
                v.AddProperty("vendorid", trip.VendorID);
                v.AddProperty("lpep_pickup_datetime", trip.lpep_pickup_datetime);
                v.AddProperty("PULocationID", trip.PULocationID);
                v.AddProperty("DOLocationID", trip.DOLocationID);
                //yield return v;
                Veritices.Add(v);
                //Add the edges here as will need a reference to the original objects

                //pickup start
                GremlinEdge e = new GremlinEdge(
                    "e.pickup." + thisIndex,
                    "has_pickup",
                    greenTripKey, //green trip
                    "location." + trip.PULocationID.ToString(), //location ID
                    "greentrip",
                    "location",
                    greenTripPK,
                    "locations");
                edges.Add(e);
                //now reverse -- not sure if needed (Dont think so unless want to reverse query)
                //e = new GremlinEdge(
                //    "e.pickup_greentrip." + thisIndex,
                //    "pickup_greentrip",
                //    "location." + trip.PULocationID.ToString(), //location ID
                //    greenTripKey, //green trip
                //    "location",
                //    "greentrip",
                //     "locations",
                //    greenTripPK);
                //edges.Add(e);

                //dropoff
                e = new GremlinEdge(
                    "e.dropoff." + thisIndex,
                    "has_dropoff",
                    greenTripKey, //green trip
                    "location." + trip.DOLocationID.ToString(), //location ID
                    "greentrip",
                    "location",
                    greenTripPK,
                    "locations");
                edges.Add(e);
                //now reverse -- not sure if needed (Dont think so unless want to reverse query)
                //e = new GremlinEdge(
                //    "e.dropoff_greentrip." + thisIndex,
                //    "dropoff_greentrip",
                //    "location." + trip.DOLocationID.ToString(), //location ID
                //    greenTripKey, //green trip
                //    "location",
                //    "greentrip",
                //     "locations",
                //    greenTripPK);
                //if (GreenTripVertexIndex == 2) break; //force just 10k records
            }
            return null;
        }

        public static IEnumerable<GremlinVertex> ConvertLocationsToVertices(IEnumerable<Location> locations)
        {
            foreach (Location location in locations)
            {
                string thisIndex = location.LocationID.ToString();
                string locTripKey = "location." + thisIndex;
                String locTripPK = "locations";

                GremlinVertex v = new GremlinVertex(locTripKey, "location");
                v.AddProperty(ConfigurationManager.AppSettings["CollectionPartitionKey"], locTripPK);//<10k docs so putting in 1 partition
                v.AddProperty("LocationID", location.LocationID);
                v.AddProperty("Borough", location.Borough);
                v.AddProperty("Zone", location.Zone);
                v.AddProperty("service_zone", location.service_zone);
                yield return v;
            }
        }

    }
}
