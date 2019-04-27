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
        public static IEnumerable<GremlinVertex> ConvertGreenTripsToVertices(IEnumerable<GreenTrip> greenTrips)
        {
            int idLoop = 0;
            foreach (GreenTrip trip in greenTrips)
            {
                idLoop++;
                GremlinVertex v = new GremlinVertex(idLoop.ToString(), "greentrip");
                v.AddProperty(ConfigurationManager.AppSettings["CollectionPartitionKey"], String.Format("{0}:{1}",trip.VendorID, idLoop));
                v.AddProperty("vendorid", trip.VendorID);
                v.AddProperty("lpep_pickup_datetime", trip.lpep_pickup_datetime);
                yield return v;
                if (idLoop == 10000) break; //force just 10k records
            }
        }

        public static IEnumerable<GremlinVertex> ConvertLocationsToVertices(IEnumerable<Location> locations)
        {
            foreach (Location location in locations)
            {
                GremlinVertex v = new GremlinVertex(location.LocationID.ToString(), "location");
                v.AddProperty(ConfigurationManager.AppSettings["CollectionPartitionKey"], "locations");//<10k docs so putting in 1 partition
                v.AddProperty("LocationID", location.LocationID);
                v.AddProperty("Borough", location.Borough);
                v.AddProperty("Zone", location.Zone);
                v.AddProperty("service_zone", location.service_zone);
                yield return v;
            }
        }

        public static IEnumerable<GremlinEdge> CreateEdgesBetweenGreenTripsAndLocations(IEnumerable<GreenTrip> greenTrips)
        {
            int idLoop = 0;
            foreach (GreenTrip trip in greenTrips)
            {
                idLoop++;

                //pickup start
                GremlinEdge e = new GremlinEdge(
                    "e:pickup:" + idLoop,
                    "pickup",
                    idLoop.ToString(), //green trip
                    trip.PULocationID.ToString(), //location ID
                    "vertex",
                    "vertex",
                    idLoop,
                    idLoop + 1);
                //dropoff
                yield return e;
                e = new GremlinEdge(
                    "e:dropoff:" + idLoop,
                    "dropoff",
                    idLoop.ToString(), //green trip
                    trip.PULocationID.ToString(), //location ID
                    "vertex",
                    "vertex",
                    idLoop,
                    idLoop + 1);
                //e.AddProperty("duration", i);
                yield return e;
                if (idLoop == 10000) break; //force just 10k records
            }
        }
    }
}
