﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Level.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LevelTestsBase
    {
        protected abstract double DecibelsInOneDecibel { get; }
        protected abstract double NepersInOneDecibel { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelsTolerance { get { return 1e-5; } }
        protected virtual double NepersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Level((double)0.0, LevelUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Level(double.PositiveInfinity, LevelUnit.Decibel));
            Assert.Throws<ArgumentException>(() => new Level(double.NegativeInfinity, LevelUnit.Decibel));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Level(double.NaN, LevelUnit.Decibel));
        }

        [Fact]
        public void DecibelToLevelUnits()
        {
            Level decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, decibel.Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(NepersInOneDecibel, decibel.Nepers, NepersTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Level.From(1, LevelUnit.Decibel).Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(1, Level.From(1, LevelUnit.Neper).Nepers, NepersTolerance);
        }

        [Fact]
        public void FromDecibels_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Level.FromDecibels(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Level.FromDecibels(double.NegativeInfinity));
        }

        [Fact]
        public void FromDecibels_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Level.FromDecibels(double.NaN));
        }

        [Fact]
        public void As()
        {
            var decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, decibel.As(LevelUnit.Decibel), DecibelsTolerance);
            AssertEx.EqualTolerance(NepersInOneDecibel, decibel.As(LevelUnit.Neper), NepersTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var decibel = Level.FromDecibels(1);

            var decibelQuantity = decibel.ToUnit(LevelUnit.Decibel);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, (double)decibelQuantity.Value, DecibelsTolerance);
            Assert.Equal(LevelUnit.Decibel, decibelQuantity.Unit);

            var neperQuantity = decibel.ToUnit(LevelUnit.Neper);
            AssertEx.EqualTolerance(NepersInOneDecibel, (double)neperQuantity.Value, NepersTolerance);
            Assert.Equal(LevelUnit.Neper, neperQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Level decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(1, Level.FromDecibels(decibel.Decibels).Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(1, Level.FromNepers(decibel.Nepers).Decibels, NepersTolerance);
        }

        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            Level v = Level.FromDecibels(40);
            AssertEx.EqualTolerance(-40, -v.Decibels, NepersTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(50, (10*v).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(35, (v/5).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(35, v/Level.FromDecibels(5), NepersTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();


        [Fact]
        public void ComparisonOperators()
        {
            Level oneDecibel = Level.FromDecibels(1);
            Level twoDecibels = Level.FromDecibels(2);

            Assert.True(oneDecibel < twoDecibels);
            Assert.True(oneDecibel <= twoDecibels);
            Assert.True(twoDecibels > oneDecibel);
            Assert.True(twoDecibels >= oneDecibel);

            Assert.False(oneDecibel > twoDecibels);
            Assert.False(oneDecibel >= twoDecibels);
            Assert.False(twoDecibels < oneDecibel);
            Assert.False(twoDecibels <= oneDecibel);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Equal(0, decibel.CompareTo(decibel));
            Assert.True(decibel.CompareTo(Level.Zero) > 0);
            Assert.True(Level.Zero.CompareTo(decibel) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Throws<ArgumentException>(() => decibel.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Throws<ArgumentNullException>(() => decibel.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Level.FromDecibels(1);
            var b = Level.FromDecibels(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            var a = Level.FromDecibels(1);
            var b = Level.FromDecibels(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = Level.FromDecibels(1);
            Assert.True(v.Equals(Level.FromDecibels(1), DecibelsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Level.Zero, DecibelsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.False(decibel.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.False(decibel.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(LevelUnit.Undefined, Level.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(LevelUnit)).Cast<LevelUnit>();
            foreach(var unit in units)
            {
                if(unit == LevelUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Level.BaseDimensions is null);
        }
    }
}
