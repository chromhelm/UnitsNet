﻿using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class LengthTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void MetersToDistanceUnits()
        {
            Length meter = Length.FromMeters(1);

            Assert.AreEqual(1E-3, meter.Kilometers);
            Assert.AreEqual(1, meter.Meters);
            Assert.AreEqual(1E1, meter.Decimeters);
            Assert.AreEqual(1E2, meter.Centimeters);
            Assert.AreEqual(1E3, meter.Millimeters);
            Assert.AreEqual(1E6, meter.Micrometers);
            Assert.AreEqual(1E9, meter.Nanometers);

            Assert.AreEqual(0.000621371, meter.Miles, Delta);
            Assert.AreEqual(1.09361, meter.Yards, Delta);
            Assert.AreEqual(3.28084, meter.Feet, Delta);
            Assert.AreEqual(39.3701, meter.Inches, Delta);
        }

        [Test]
        public void DistanceUnitsRoundTrip()
        {
            Length meter = Length.FromMeters(1);

            Assert.AreEqual(1, Length.FromKilometers(meter.Kilometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromMeters(meter.Meters).Meters, Delta);
            Assert.AreEqual(1, Length.FromDecimeters(meter.Decimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromCentimeters(meter.Centimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromMillimeters(meter.Millimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromMicrometers(meter.Micrometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromNanometers(meter.Nanometers).Meters, Delta);

            Assert.AreEqual(1, Length.FromMiles(meter.Miles).Meters, Delta);
            Assert.AreEqual(1, Length.FromYards(meter.Yards).Meters, Delta);
            Assert.AreEqual(1, Length.FromFeet(meter.Feet).Meters, Delta);
            Assert.AreEqual(1, Length.FromInches(meter.Inches).Meters, Delta);
        }

        [Test]
        public void DynamicConversion()
        {
            Assert.AreEqual(1E-3, UnitsHelper.Convert(1, Unit.Meter, Unit.Kilometer));
            Assert.AreEqual(1, UnitsHelper.Convert(1, Unit.Meter, Unit.Meter));
            Assert.AreEqual(1E1, UnitsHelper.Convert(1, Unit.Meter, Unit.Decimeter));
            Assert.AreEqual(1E2, UnitsHelper.Convert(1, Unit.Meter, Unit.Centimeter));
            Assert.AreEqual(1E3, UnitsHelper.Convert(1, Unit.Meter, Unit.Millimeter));
            Assert.AreEqual(1E6, UnitsHelper.Convert(1, Unit.Meter, Unit.Micrometer));
            Assert.AreEqual(1E9, UnitsHelper.Convert(1, Unit.Meter, Unit.Nanometer));

            Assert.AreEqual(0.000621371, UnitsHelper.Convert(1, Unit.Meter, Unit.Mile), Delta);
            Assert.AreEqual(1.09361, UnitsHelper.Convert(1, Unit.Meter, Unit.Yard), Delta);
            Assert.AreEqual(3.28084, UnitsHelper.Convert(1, Unit.Meter, Unit.Foot), Delta);
            Assert.AreEqual(39.3701, UnitsHelper.Convert(1, Unit.Meter, Unit.Inch), Delta);
        }

    }
}