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
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Mole is the amount of substance containing Avagadro's Number (6.02 x 10 ^ 23) of real particles such as molecules,atoms, ions or radicals.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart

    public partial struct AmountOfSubstance : IComparable, IComparable<AmountOfSubstance>
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(AmountOfSubstanceUnit unit, [CanBeNull] IFormatProvider provider)
        {
            return UnitAbbreviationsCache.GetDefaultAbbreviation(unit, provider);
        }

        #region Arithmetic Operators

        public static AmountOfSubstance operator -(AmountOfSubstance right)
        {
            return new AmountOfSubstance(-right.Value, right.Unit);
        }

        public static AmountOfSubstance operator +(AmountOfSubstance left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left.Value + right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static AmountOfSubstance operator -(AmountOfSubstance left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left.Value - right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static AmountOfSubstance operator *(double left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left * right.Value, right.Unit);
        }

        public static AmountOfSubstance operator *(AmountOfSubstance left, double right)
        {
            return new AmountOfSubstance(left.Value * right, left.Unit);
        }

        public static AmountOfSubstance operator /(AmountOfSubstance left, double right)
        {
            return new AmountOfSubstance(left.Value / right, left.Unit);
        }

        public static double operator /(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Moles / right.Moles;
        }

        #endregion

        public static bool operator <=(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Value <= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >=(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Value >= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator <(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Value < right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Value > right.AsBaseNumericType(left.Unit);
        }

        #region Parsing

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
        public static AmountOfSubstance Parse(string str, [CanBeNull] IFormatProvider provider)
        {
            return ParseInternal(str, provider);
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
        public static bool TryParse([CanBeNull] string str, [CanBeNull] IFormatProvider provider, out AmountOfSubstance result)
        {
            return TryParseInternal(str, provider, out result);
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
        public static AmountOfSubstanceUnit ParseUnit(string str, IFormatProvider provider = null)
        {
            return ParseUnitInternal(str, provider);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <param name="unit">The parsed unit if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.TryParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParseUnit(string str, IFormatProvider provider, out AmountOfSubstanceUnit unit)
        {
            return TryParseUnitInternal(str, provider, out unit);
        }

        #endregion

        #region ToString Methods

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <returns>String representation.</returns>
        public string ToString(AmountOfSubstanceUnit unit, [CanBeNull] IFormatProvider provider)
        {
            return ToString(unit, provider, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AmountOfSubstanceUnit unit, [CanBeNull] IFormatProvider provider, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, provider, format);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" />.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AmountOfSubstanceUnit unit, [CanBeNull] IFormatProvider provider, [NotNull] string format, [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }

        #endregion
    }
}
