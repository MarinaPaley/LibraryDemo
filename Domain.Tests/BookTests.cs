namespace Domain.Tests
{
    using Domain;
    using NUnit.Framework;

    [TestFixture]
    public class BookTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var book = new Book(1, "Война и мир");

            // act
            var result = book.ToString();

            // assert
            Assert.AreEqual("Война и мир", result);
        }

        [Test]
        public void MyTestMethod()
        {
            // arrange
            var book = new Book(1, "Война и мир");
            var author0 = new Author(1, "Тестовый", "Автор");
            var author1 = new Author(1, "Тестовый", "Автор");

            // act
            book.Authors.Add(author0);
            book.Authors.Add(author1);

            // assert
            Assert.AreEqual(1, book.Authors.Count);
        }
    }
}
