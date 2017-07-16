using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvvm.Test.Base;

namespace Mvvm.Test.Tests
{
    [TestClass]
    public class CommandTests : BaseMvvmTest
    {
        [TestMethod]
        public void CommandExecutionWithParameterTest()
        {
            StubViewModel.ChangePropertyCommand = new RelayCommand((o) => StubViewModel.SomeProperty = (int) o);
            StubViewModel.ChangePropertyCommand.Execute(5);
            Assert.AreEqual(5, StubViewModel.SomeProperty);
        }

        [TestMethod]
        public void CommandCanExecuteTest()
        {
            StubViewModel.ChangePropertyCommand = new RelayCommand((o) => { }, o => false);
            Assert.IsFalse(StubViewModel.ChangePropertyCommand.CanExecute(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandWithNullActionCreationTest()
        {
            StubViewModel.ChangePropertyCommand = new RelayCommand(null);
        }
    }
}