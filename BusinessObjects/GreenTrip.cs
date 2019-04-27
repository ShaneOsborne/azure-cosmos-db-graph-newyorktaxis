using System;

namespace BusinessObjects
{
    public class GreenTrip
    {
        //,lpep_pickup_datetime,lpep_dropoff_datetime,store_and_fwd_flag,RatecodeID,PULocationID,DOLocationID,passenger_count,trip_distance,fare_amount,extra,mta_tax,tip_amount,tolls_amount,ehail_fee,improvement_surcharge,total_amount,payment_type,trip_type
        public byte VendorID { get; set; }
        public DateTime lpep_pickup_datetime { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
    }
}
