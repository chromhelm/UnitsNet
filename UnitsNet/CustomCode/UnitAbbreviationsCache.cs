﻿// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

using UnitTypeToLookup = System.Collections.Generic.Dictionary<System.Type, UnitsNet.UnitValueAbbreviationLookup>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public static partial class UnitAbbreviationsCache
    {
        private static Dictionary<IFormatProvider, UnitTypeToLookup> looksupsForCulture;

        /// <summary>
        ///     Fallback culture used by <see cref="GetAllAbbreviations{TUnitType}" /> and <see cref="GetDefaultAbbreviation{TUnitType}" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        private static readonly CultureInfo FallbackCulture = new CultureInfo("en-US");

        static UnitAbbreviationsCache()
        {
            looksupsForCulture = new Dictionary<IFormatProvider, UnitTypeToLookup>();

            LoadGeneratedAbbreviations();
        }

        private static void LoadGeneratedAbbreviations()
        {
            foreach(var localization in DefaultLocalizations)
            {
                var culture = new CultureInfo(localization.Item1);
                MapUnitToAbbreviation(localization.Item2, localization.Item3, culture, localization.Item4);
            }
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : Enum
        {
            MapUnitToAbbreviation(typeof(TUnitType), Convert.ToInt32(unit), GlobalConfiguration.DefaultCulture, abbreviations);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider, params string[] abbreviations) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToAbbreviation(unitType, unitValue, formatProvider, abbreviations);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] abbreviations)
		{
            if (!unitType.IsEnum())
                throw new ArgumentException("Must be an enum type.", nameof(unitType));

            if (abbreviations == null)
                throw new ArgumentNullException(nameof(abbreviations));

            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if(!looksupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                quantitiesForProvider = looksupsForCulture[formatProvider] = new UnitTypeToLookup();

            if(!quantitiesForProvider.TryGetValue(unitType, out var unitToAbbreviations))
                unitToAbbreviations = quantitiesForProvider[unitType] = new UnitValueAbbreviationLookup();

            foreach(var abbr in abbreviations)
            {
                unitToAbbreviations.Add(unitValue, abbr);
            }
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            var unitType = typeof(TUnitType);
            var unitValue = Convert.ToInt32(unit);

            var lookup = GetUnitValueAbbreviationLookup(unitType, formatProvider);
            if(lookup == null)
                return $"(no abbreviation for {unitType.Name}.{unit})";

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
                return formatProvider != FallbackCulture ? GetDefaultAbbreviation(unitType, unitValue, FallbackCulture) : $"(no abbreviation for {unitType.Name}.{unit})";

            return abbreviations.First();
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit type and its numeric enum value.
        /// If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(typeof(LengthUnit), 1) => "cm"
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>The default unit abbreviation string.</returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            var lookup = GetUnitValueAbbreviationLookup(unitType, formatProvider);
            if(lookup == null)
                return $"(no abbreviation for {unitType.Name} with numeric value {unitValue})";

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
                return formatProvider != FallbackCulture ? GetDefaultAbbreviation(unitType, unitValue, FallbackCulture) : $"(no abbreviation for {unitType.Name} with numeric value {unitValue})";

            return abbreviations.First();
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static string[] GetAllAbbreviations<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return GetAllAbbreviations(typeof(TUnitType), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static string[] GetAllAbbreviations(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            var lookup = GetUnitValueAbbreviationLookup(unitType, formatProvider);
            if(lookup == null)
                return formatProvider != FallbackCulture ? GetAllAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
                return formatProvider != FallbackCulture ? GetAllAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            return abbreviations.ToArray();
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static string[] GetAllAbbreviations(Type unitType, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            var lookup = GetUnitValueAbbreviationLookup(unitType, formatProvider);
            if(lookup == null)
                return formatProvider != FallbackCulture ? GetAllAbbreviations(unitType, FallbackCulture) : new string[] { };

            return lookup.GetAllAbbreviations();
        }

        internal static UnitValueAbbreviationLookup GetUnitValueAbbreviationLookup(Type unitType, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

            if(!looksupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                return formatProvider != FallbackCulture ? GetUnitValueAbbreviationLookup(unitType, FallbackCulture) : null;

            if(!quantitiesForProvider.TryGetValue(unitType, out var unitToAbbreviations))
                return formatProvider != FallbackCulture ? GetUnitValueAbbreviationLookup(unitType, FallbackCulture) : null;

            return unitToAbbreviations;
        }
    }
}
