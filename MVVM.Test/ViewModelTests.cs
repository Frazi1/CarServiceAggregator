using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVVM.Test
{
    [TestClass]
    public class ViewModelTests : BaseMVVMTest
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
