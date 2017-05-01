using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormsCrossPlatform.Tests
{
    [TestClass]
    public class MainViewModel_features
    {
        [TestMethod]
        public void AddCommand_명령은_새_Contact_인스턴스를_올바르게_추가합니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            sut.EmailField = "foo@test.com";

            // Act
            sut.AddCommand.Execute(null);

            // Assert
            Assert.AreEqual(1, sut.Contacts.Count());
            Contact actual = sut.Contacts.Single();
            Assert.AreEqual("foo", actual.Name);
            Assert.AreEqual("foo@test.com", actual.Email);
        }

        [TestMethod]
        public void AddCommand_명령은_NameField를_초기화합니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            sut.EmailField = "foo@test.com";

            // Act
            sut.AddCommand.Execute(null);

            // Assert
            Assert.AreEqual(string.Empty, sut.NameField);
        }

        [TestMethod]
        public void AddCommand_명령은_EmailField를_초기화합니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            sut.EmailField = "foo@test.com";

            // Act
            sut.AddCommand.Execute(null);

            // Assert
            Assert.AreEqual(string.Empty, sut.EmailField);
        }

        [TestMethod]
        public void NameField가_입력되지_않으면_AddCommand를_실행하지_못합니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            sut.EmailField = "foo@test.com";

            // Act
            sut.NameField = string.Empty;

            // Assert
            Assert.IsFalse(sut.AddCommand.CanExecute(null), "AddCommand를 실행할 수 있습니다.");
        }

        [TestMethod]
        public void EmailField가_입력되지_않으면_AddCommand를_살행하지_못합니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            sut.EmailField = "foo@test.com";

            // Act
            sut.EmailField = string.Empty;

            // Assert
            Assert.IsFalse(sut.AddCommand.CanExecute(null), "AddCommand를 실행할 수 있습니다.");
        }

        [TestMethod]
        public void NameField가_변경되면_AddCommand가_실행가능_여부를_외부에_알립니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.NameField = "foo";
            bool eventRaised = false;
            sut.AddCommand.CanExecuteChanged += (s, e) => eventRaised = true;

            // Act
            sut.NameField = "bar";

            // Assert
            Assert.IsTrue(eventRaised, "CanExecuteChanged 이벤트가 발생하지 않았습니다.");
        }

        [TestMethod]
        public void EmailField가_변경되면_AddCommand가_실행가능_여부를_외부에_알립니다()
        {
            // Arrange
            var sut = new MainViewModel(); // sut: 테스트 대상 시스템(System Under Test).
            sut.EmailField = "foo@test.com";
            bool eventRaised = false;
            sut.AddCommand.CanExecuteChanged += (s, e) => eventRaised = true;

            // Act
            sut.EmailField = "bar@test.com";

            // Assert
            Assert.IsTrue(eventRaised, "CanExecuteChanged 이벤트가 발생하지 않았습니다.");
        }
    }
}
