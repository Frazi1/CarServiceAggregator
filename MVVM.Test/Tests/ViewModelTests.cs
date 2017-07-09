using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvvm.Test.Base;

namespace Mvvm.Test.Tests
{
    [TestClass]
    public class ViewModelTests : BaseMvvmTest
    {
        [TestMethod]
        public void NotificationExecutionTest()
        {
            StubViewModel.PropertyChanged += Stubvm_PropertyChanged;
            StubViewModel.SomeProperty = 10;
        }

        private void Stubvm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Assert.AreEqual(e.PropertyName, "SomeProperty");
        }
    }
}
