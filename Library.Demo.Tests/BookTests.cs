

using System;

namespace Library.Demo.Tests
{
    using NUnit.Framework;
    using Library.Domain;
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var author = new Author(1, "Толстой", "Лев", "Николаевич");
            var book = new Book(1, "Война и мир", author);
            var expected = "Война и мир Толстой Л. Н.";

            //act
            var actual = book.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyAuthor_Success()
        {
            // arrange
            var book = new Book(1, "Библия");
            var expected = "Библия";

            //act
            var actual = book.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyAuthors_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = new Book(1, "Библия"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullTitleEmptyAuthors_Fail(string wrongTitle)
        {
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Book(1, wrongTitle));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullTitleEmptyAuthor_Fail(string wrongTitle)
        {
            // arrange
            var author = new Author(1, "Толстой", "Лев", "Николаевич");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Book(1, wrongTitle));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var author = new Author(1, "Толстой", "Лев", "Николаевич");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Book(1, "Война и мир", author));
        }
    }
}