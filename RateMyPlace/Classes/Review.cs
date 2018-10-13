﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyPlace.Classes
{
    public class Review
    {
        private int overallRating;
        private int noiseRating;
        private int safetyRating;
        private int maintenanceRating;
        private string leaseStart;
        private string leaseEnd;
        private float rent;
        private float utility;
        private float distance;
        private string pros;
        private string cons;
        private bool studySpace;
        private bool shuttle;
        private bool wifi;
        private bool furnished;
        private bool tv;
        private bool pet;
        private bool trash;
        private bool gym;
        private bool parking;
        private float parkingCost;

        public Review()
        {

        }

        public void SendToDatabase() //Sends everything to the database.
        {

        }

        public int OverallRating { get => overallRating; set => overallRating = value; }
        public int NoiseRating { get => noiseRating; set => noiseRating = value; }
        public int SafetyRating { get => safetyRating; set => safetyRating = value; }
        public int MaintenanceRating { get => maintenanceRating; set => maintenanceRating = value; }
        public string LeaseStart { get => leaseStart; set => leaseStart = value; }
        public string LeaseEnd { get => leaseEnd; set => leaseEnd = value; }
        public float Rent { get => rent; set => rent = value; }
        public float Utility { get => utility; set => utility = value; }
        public float Distance { get => distance; set => distance = value; }
        public string Cons { get => cons; set => cons = value; }
        public string Pros { get => pros; set => pros = value; }
        public bool Shuttle { get => shuttle; set => shuttle = value; }
        public bool StudySpace { get => studySpace; set => studySpace = value; }
        public bool Wifi { get => wifi; set => wifi = value; }
        public bool Furnished { get => furnished; set => furnished = value; }
        public bool Tv { get => tv; set => tv = value; }
        public bool Pet { get => pet; set => pet = value; }
        public bool Trash { get => trash; set => trash = value; }
        public bool Gym { get => gym; set => gym = value; }
        public float ParkingCost { get => parkingCost; set => parkingCost = value; }
        public bool Parking { get => parking; set => parking = value; }
    }
}