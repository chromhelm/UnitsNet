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
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Specific entropy is an amount of energy required to raise temperature of a substance by 1 Kelvin per unit mass.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart

    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class SpecificEntropy : IQuantity
#else
    public partial struct SpecificEntropy : IQuantity, IComparable, IComparable<SpecificEntropy>
#endif
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly SpecificEntropyUnit? _unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref="BaseUnit" /> if default ctor was used.
        /// </summary>
        public SpecificEntropyUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        static SpecificEntropy()
        {
            BaseDimensions = new BaseDimensions(2, 0, -2, 0, -1, 0, 0);
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="numericValue">The numeric value  to contruct this quantity with.</param>
        /// <param name="unit">The unit representation to contruct this quantity with.</param>
        /// <remarks>Value parameter cannot be named 'value' due to constraint when targeting Windows Runtime Component.</remarks>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        private
#else
        public
#endif
        SpecificEntropy(double numericValue, SpecificEntropyUnit unit)
        {
            if(unit == SpecificEntropyUnit.Undefined)
              throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = Guard.EnsureValidNumber(numericValue, nameof(numericValue));
            _unit = unit;
        }

        #region Properties

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public static QuantityType QuantityType => QuantityType.SpecificEntropy;

        /// <summary>
        ///     The base unit of SpecificEntropy, which is JoulePerKilogramKelvin. All conversions go via this value.
        /// </summary>
        public static SpecificEntropyUnit BaseUnit => SpecificEntropyUnit.JoulePerKilogramKelvin;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions
        {
            get;
        }

        /// <summary>
        ///     All units of measurement for the SpecificEntropy quantity.
        /// </summary>
        public static SpecificEntropyUnit[] Units { get; } = Enum.GetValues(typeof(SpecificEntropyUnit)).Cast<SpecificEntropyUnit>().Except(new SpecificEntropyUnit[]{ SpecificEntropyUnit.Undefined }).ToArray();

        /// <summary>
        ///     Get SpecificEntropy in CaloriesPerGramKelvin.
        /// </summary>
        public double CaloriesPerGramKelvin => As(SpecificEntropyUnit.CaloriePerGramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in JoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double JoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in JoulesPerKilogramKelvin.
        /// </summary>
        public double JoulesPerKilogramKelvin => As(SpecificEntropyUnit.JoulePerKilogramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in KilocaloriesPerGramKelvin.
        /// </summary>
        public double KilocaloriesPerGramKelvin => As(SpecificEntropyUnit.KilocaloriePerGramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in KilojoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double KilojoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in KilojoulesPerKilogramKelvin.
        /// </summary>
        public double KilojoulesPerKilogramKelvin => As(SpecificEntropyUnit.KilojoulePerKilogramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in MegajoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double MegajoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in MegajoulesPerKilogramKelvin.
        /// </summary>
        public double MegajoulesPerKilogramKelvin => As(SpecificEntropyUnit.MegajoulePerKilogramKelvin);

        #endregion

        #region Static

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit JoulePerKilogramKelvin.
        /// </summary>
        public static SpecificEntropy Zero => new SpecificEntropy(0, BaseUnit);

        /// <summary>
        ///     Get SpecificEntropy from CaloriesPerGramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromCaloriesPerGramKelvin(double caloriespergramkelvin)
#else
        public static SpecificEntropy FromCaloriesPerGramKelvin(QuantityValue caloriespergramkelvin)
#endif
        {
            double value = (double) caloriespergramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.CaloriePerGramKelvin);
        }

        /// <summary>
        ///     Get SpecificEntropy from JoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromJoulesPerKilogramDegreeCelsius(double joulesperkilogramdegreecelsius)
#else
        public static SpecificEntropy FromJoulesPerKilogramDegreeCelsius(QuantityValue joulesperkilogramdegreecelsius)
#endif
        {
            double value = (double) joulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);
        }

        /// <summary>
        ///     Get SpecificEntropy from JoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromJoulesPerKilogramKelvin(double joulesperkilogramkelvin)
#else
        public static SpecificEntropy FromJoulesPerKilogramKelvin(QuantityValue joulesperkilogramkelvin)
#endif
        {
            double value = (double) joulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.JoulePerKilogramKelvin);
        }

        /// <summary>
        ///     Get SpecificEntropy from KilocaloriesPerGramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilocaloriesPerGramKelvin(double kilocaloriespergramkelvin)
#else
        public static SpecificEntropy FromKilocaloriesPerGramKelvin(QuantityValue kilocaloriespergramkelvin)
#endif
        {
            double value = (double) kilocaloriespergramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilocaloriePerGramKelvin);
        }

        /// <summary>
        ///     Get SpecificEntropy from KilojoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilojoulesPerKilogramDegreeCelsius(double kilojoulesperkilogramdegreecelsius)
#else
        public static SpecificEntropy FromKilojoulesPerKilogramDegreeCelsius(QuantityValue kilojoulesperkilogramdegreecelsius)
#endif
        {
            double value = (double) kilojoulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);
        }

        /// <summary>
        ///     Get SpecificEntropy from KilojoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilojoulesPerKilogramKelvin(double kilojoulesperkilogramkelvin)
#else
        public static SpecificEntropy FromKilojoulesPerKilogramKelvin(QuantityValue kilojoulesperkilogramkelvin)
#endif
        {
            double value = (double) kilojoulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilojoulePerKilogramKelvin);
        }

        /// <summary>
        ///     Get SpecificEntropy from MegajoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromMegajoulesPerKilogramDegreeCelsius(double megajoulesperkilogramdegreecelsius)
#else
        public static SpecificEntropy FromMegajoulesPerKilogramDegreeCelsius(QuantityValue megajoulesperkilogramdegreecelsius)
#endif
        {
            double value = (double) megajoulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);
        }

        /// <summary>
        ///     Get SpecificEntropy from MegajoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromMegajoulesPerKilogramKelvin(double megajoulesperkilogramkelvin)
#else
        public static SpecificEntropy FromMegajoulesPerKilogramKelvin(QuantityValue megajoulesperkilogramkelvin)
#endif
        {
            double value = (double) megajoulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.MegajoulePerKilogramKelvin);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificEntropyUnit" /> to <see cref="SpecificEntropy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificEntropy unit value.</returns>
#if WINDOWS_UWP
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static SpecificEntropy From(double value, SpecificEntropyUnit fromUnit)
#else
        public static SpecificEntropy From(QuantityValue value, SpecificEntropyUnit fromUnit)
#endif
        {
            return new SpecificEntropy((double)value, fromUnit);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(SpecificEntropyUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is SpecificEntropy)) throw new ArgumentException("Expected type SpecificEntropy.", nameof(obj));

            return CompareTo((SpecificEntropy)obj);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(SpecificEntropy other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another SpecificEntropy within the given absolute or relative tolerance.
        ///     </para>
        ///     <para>
        ///     Relative tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name="other"/> as a percentage of this quantity's value. <paramref name="other"/> will be converted into
        ///     this quantity's unit for comparison. A relative tolerance of 0.01 means the absolute difference must be within +/- 1% of
        ///     this quantity's value to be considered equal.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within +/- 1% of a (0.02m or 2cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Relative);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Absolute tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name="other"/> as a fixed number in this quantity's unit. <paramref name="other"/> will be converted into
        ///     this quantity's unit for comparison.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Absolute);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Note that it is advised against specifying zero difference, due to the nature
        ///     of floating point operations and using System.Double internally.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name="comparisonType">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        public bool Equals(SpecificEntropy other, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current SpecificEntropy.</returns>
        public override int GetHashCode()
        {
            return new { Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(SpecificEntropyUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this SpecificEntropy to another SpecificEntropy with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A SpecificEntropy with the specified unit.</returns>
        public SpecificEntropy ToUnit(SpecificEntropyUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new SpecificEntropy(convertedValue, unit);
        }

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double AsBaseUnit()
        {
            switch(Unit)
            {
                case SpecificEntropyUnit.CaloriePerGramKelvin: return _value*4.184e3;
                case SpecificEntropyUnit.JoulePerKilogramDegreeCelsius: return _value;
                case SpecificEntropyUnit.JoulePerKilogramKelvin: return _value;
                case SpecificEntropyUnit.KilocaloriePerGramKelvin: return (_value*4.184e3) * 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius: return (_value) * 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramKelvin: return (_value) * 1e3d;
                case SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius: return (_value) * 1e6d;
                case SpecificEntropyUnit.MegajoulePerKilogramKelvin: return (_value) * 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(SpecificEntropyUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case SpecificEntropyUnit.CaloriePerGramKelvin: return baseUnitValue/4.184e3;
                case SpecificEntropyUnit.JoulePerKilogramDegreeCelsius: return baseUnitValue;
                case SpecificEntropyUnit.JoulePerKilogramKelvin: return baseUnitValue;
                case SpecificEntropyUnit.KilocaloriePerGramKelvin: return (baseUnitValue/4.184e3) / 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius: return (baseUnitValue) / 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramKelvin: return (baseUnitValue) / 1e3d;
                case SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius: return (baseUnitValue) / 1e6d;
                case SpecificEntropyUnit.MegajoulePerKilogramKelvin: return (baseUnitValue) / 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static SpecificEntropy Parse(string str)
        {
            return ParseInternal(str, null);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, out SpecificEntropy result)
        {
            return TryParseInternal(str, null, out result);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static SpecificEntropyUnit ParseUnit(string str)
        {
            return ParseUnitInternal(str, null);
        }

        public static bool TryParseUnit(string str, out SpecificEntropyUnit unit)
        {
            return TryParseUnitInternal(str, null, out unit);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        private static SpecificEntropy ParseInternal(string str, [CanBeNull] IFormatProvider provider)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            return QuantityParser.Parse<SpecificEntropy, SpecificEntropyUnit>(str, provider, ParseUnitInternal, From,
                (x, y) => From(x.JoulesPerKilogramKelvin + y.JoulesPerKilogramKelvin, BaseUnit));
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        private static bool TryParseInternal([CanBeNull] string str, [CanBeNull] IFormatProvider provider, out SpecificEntropy result)
        {
            result = default(SpecificEntropy);

            if(string.IsNullOrWhiteSpace(str))
                return false;

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            return QuantityParser.TryParse<SpecificEntropy, SpecificEntropyUnit>(str, provider, TryParseUnitInternal, From,
                (x, y) => From(x.JoulesPerKilogramKelvin + y.JoulesPerKilogramKelvin, BaseUnit), out result);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static SpecificEntropyUnit ParseUnitInternal(string str, IFormatProvider provider = null)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            var unit = UnitParser.Parse<SpecificEntropyUnit>(str.Trim(), provider);

            if (unit == SpecificEntropyUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized SpecificEntropyUnit.");
                newEx.Data["input"] = str;
                newEx.Data["provider"] = provider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <param name="unit">The parsed unit if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        private static bool TryParseUnitInternal(string str, IFormatProvider provider, out SpecificEntropyUnit unit)
        {
            unit = SpecificEntropyUnit.Undefined;

            if(string.IsNullOrWhiteSpace(str))
                return false;

            if(!UnitParser.TryParse<SpecificEntropyUnit>(str.Trim(), provider, out unit))
                return false;

            if(unit == SpecificEntropyUnit.Undefined)
                return false;

            return true;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(Unit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpecificEntropyUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        /// Represents the largest possible value of SpecificEntropy
        /// </summary>
        public static SpecificEntropy MaxValue => new SpecificEntropy(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of SpecificEntropy
        /// </summary>
        public static SpecificEntropy MinValue => new SpecificEntropy(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public QuantityType Type => SpecificEntropy.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => SpecificEntropy.BaseDimensions;
    }
}
