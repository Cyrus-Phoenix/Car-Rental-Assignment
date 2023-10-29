﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes
{
    public class Vehicle : IVehicle
    {
        #region Properties
        public int Id { get; init; }

        public string RegNo { get; init; }

        public VehiclesMake VehicleMake { get; }

        public VehiclesTypes VehicleType { get; }

        public int Odometer { get; init; }

        public int CostKm { get; init; }

        public int CostDay { get; init; }

        public VehicleStatuses VStatus { get; set; }
        #endregion

        #region Constructors

        public Vehicle(int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, int odometer, int costKm, int costDay, VehicleStatuses vStatus)
         => (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay, VStatus) = (id, regNo, vMake, vType, odometer, costKm, costDay, vStatus);

        #endregion

        #region Methods



        #endregion

    }
}
