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
using System.Globalization;
using System.Linq;
using System.Threading;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Humidity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class HumidityTestsBase
    {
        protected abstract double PercentsInOnePercent { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double PercentsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Humidity((double)0.0, HumidityUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Humidity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(HumidityUnit.Percent, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Humidity(double.PositiveInfinity, HumidityUnit.Percent));
            Assert.Throws<ArgumentException>(() => new Humidity(double.NegativeInfinity, HumidityUnit.Percent));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Humidity(double.NaN, HumidityUnit.Percent));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Humidity(value: 1.0, unitSystem: null));
        }

        [Fact]
        public void Humidity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Humidity(1, HumidityUnit.Percent);

            QuantityInfo<HumidityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Humidity.Zero, quantityInfo.Zero);
            Assert.Equal("Humidity", quantityInfo.Name);
            Assert.Equal(QuantityType.Humidity, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<HumidityUnit>().Except(new[] {HumidityUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
#pragma warning disable 618
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
#pragma warning restore 618
        }

        [Fact]
        public void PercentToHumidityUnits()
        {
            Humidity percent = Humidity.FromPercents(1);
            AssertEx.EqualTolerance(PercentsInOnePercent, percent.Percents, PercentsTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Humidity.From(1, HumidityUnit.Percent);
            AssertEx.EqualTolerance(1, quantity00.Percents, PercentsTolerance);
            Assert.Equal(HumidityUnit.Percent, quantity00.Unit);

        }

        [Fact]
        public void FromPercents_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Humidity.FromPercents(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Humidity.FromPercents(double.NegativeInfinity));
        }

        [Fact]
        public void FromPercents_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Humidity.FromPercents(double.NaN));
        }

        [Fact]
        public void As()
        {
            var percent = Humidity.FromPercents(1);
            AssertEx.EqualTolerance(PercentsInOnePercent, percent.As(HumidityUnit.Percent), PercentsTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var percent = Humidity.FromPercents(1);

            var percentQuantity = percent.ToUnit(HumidityUnit.Percent);
            AssertEx.EqualTolerance(PercentsInOnePercent, (double)percentQuantity.Value, PercentsTolerance);
            Assert.Equal(HumidityUnit.Percent, percentQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Humidity percent = Humidity.FromPercents(1);
            AssertEx.EqualTolerance(1, Humidity.FromPercents(percent.Percents).Percents, PercentsTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Humidity v = Humidity.FromPercents(1);
            AssertEx.EqualTolerance(-1, -v.Percents, PercentsTolerance);
            AssertEx.EqualTolerance(2, (Humidity.FromPercents(3)-v).Percents, PercentsTolerance);
            AssertEx.EqualTolerance(2, (v + v).Percents, PercentsTolerance);
            AssertEx.EqualTolerance(10, (v*10).Percents, PercentsTolerance);
            AssertEx.EqualTolerance(10, (10*v).Percents, PercentsTolerance);
            AssertEx.EqualTolerance(2, (Humidity.FromPercents(10)/5).Percents, PercentsTolerance);
            AssertEx.EqualTolerance(2, Humidity.FromPercents(10)/Humidity.FromPercents(5), PercentsTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Humidity onePercent = Humidity.FromPercents(1);
            Humidity twoPercents = Humidity.FromPercents(2);

            Assert.True(onePercent < twoPercents);
            Assert.True(onePercent <= twoPercents);
            Assert.True(twoPercents > onePercent);
            Assert.True(twoPercents >= onePercent);

            Assert.False(onePercent > twoPercents);
            Assert.False(onePercent >= twoPercents);
            Assert.False(twoPercents < onePercent);
            Assert.False(twoPercents <= onePercent);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Humidity percent = Humidity.FromPercents(1);
            Assert.Equal(0, percent.CompareTo(percent));
            Assert.True(percent.CompareTo(Humidity.Zero) > 0);
            Assert.True(Humidity.Zero.CompareTo(percent) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Humidity percent = Humidity.FromPercents(1);
            Assert.Throws<ArgumentException>(() => percent.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Humidity percent = Humidity.FromPercents(1);
            Assert.Throws<ArgumentNullException>(() => percent.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Humidity.FromPercents(1);
            var b = Humidity.FromPercents(2);

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
        public void Equals_SameType_IsImplemented()
        {
            var a = Humidity.FromPercents(1);
            var b = Humidity.FromPercents(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = Humidity.FromPercents(1);
            object b = Humidity.FromPercents(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = Humidity.FromPercents(1);
            Assert.True(v.Equals(Humidity.FromPercents(1), PercentsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Humidity.Zero, PercentsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Humidity.FromPercents(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Humidity.FromPercents(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Humidity percent = Humidity.FromPercents(1);
            Assert.False(percent.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Humidity percent = Humidity.FromPercents(1);
            Assert.False(percent.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(HumidityUnit.Undefined, Humidity.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(HumidityUnit)).Cast<HumidityUnit>();
            foreach(var unit in units)
            {
                if(unit == HumidityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Humidity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 %Rh", new Humidity(1, HumidityUnit.Percent).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = prevCulture;
            }
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 %Rh", new Humidity(1, HumidityUnit.Percent).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s1"));
                Assert.Equal("0.12 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s2"));
                Assert.Equal("0.123 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s3"));
                Assert.Equal("0.1235 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s4"));
            }
            finally
            {
                CultureInfo.CurrentUICulture = oldCulture;
            }
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s1", culture));
            Assert.Equal("0.12 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s2", culture));
            Assert.Equal("0.123 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s3", culture));
            Assert.Equal("0.1235 %Rh", new Humidity(0.123456, HumidityUnit.Percent).ToString("s4", culture));
        }

        #pragma warning disable 612, 618

        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }

        #pragma warning restore 612, 618

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Humidity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(HumidityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(QuantityType.Humidity, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(Humidity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Humidity.FromPercents(1.0);
            Assert.Equal(new {Humidity.QuantityType, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Humidity.FromPercents(value);
            Assert.Equal(Humidity.FromPercents(-value), -quantity);
        }

    }
}
