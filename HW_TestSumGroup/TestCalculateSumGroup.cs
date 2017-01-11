using System.Collections.Generic;
using FluentAssertions;
using HW_SumGroupCalculator;
using NUnit.Framework;

namespace HW_TestSumGroup
{
    [TestFixture]
    public class TestCalculateSumGroup
    {
        private List<Product> products;

        [SetUp]
        public void Init()
        {
            products = new List<Product>
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
            };
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Sum_Cost_GroupSize_Less_Than_1_Should_Empty(int size)
        {
            Assert.IsEmpty(products.CalculateSumGroup(size, p => p.Cost));
        }

        [Test]
        public void Sum_Cost_GroupSize_3_Should_6_15_24_21()
        {
            //arrange
            var expected = new List<int> {6, 15, 24, 21};

            //act
            var actual = products.CalculateSumGroup(3, p => p.Cost);

            //assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

        [Test]
        public void Sum_Revenue_GroupSize_4_Should_50_66_60()
        {
            //arrange
            var expected = new List<int> {50, 66, 60};

            //act
            var actual = products.CalculateSumGroup(4, p => p.Revenue);

            //assert
            actual.ShouldAllBeEquivalentTo(expected);
        }

        [Test]
        public void Sum_SellPrice_GroupSize_5_Should_115_140_31()
        {
            //arrange
            var expected = new List<int> {115, 140, 31};

            //act
            var actual = products.CalculateSumGroup(5, p => p.SellPrice);

            //assert
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}