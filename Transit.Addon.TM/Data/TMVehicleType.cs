﻿using System;

namespace Transit.Addon.TM.Data {
	[Flags]
	public enum TMVehicleType {
		None = 0,
		PassengerCar = 1,
		Bus = 2,
		Taxi = 4,
		CargoTruck = 8,
		Service = 16,
		Emergency = 32,
		PassengerTrain = 64,
		CargoTrain = 128,
		Tram = 256,
		Bicycle = 512,
		Pedestrian = 1024,
		PassengerShip = 2048,
		CargoShip = 4096,
		PassengerPlane = 8192,
		Plane = PassengerPlane,
		Ship = PassengerShip | CargoShip,
		CargoVehicle = CargoTruck | CargoTrain | CargoShip,
		PublicTransport = Bus | Taxi | Tram | PassengerTrain,
		RoadPublicTransport = Bus | Taxi,
		RoadVehicle = PassengerCar | Bus | Taxi | CargoTruck | Service | Emergency,
		RailVehicle = PassengerTrain | CargoTrain,
		NonTransportRoadVehicle = RoadVehicle & ~PublicTransport,
        Unknown = 65536
	}
}
