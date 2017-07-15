using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvvm.Test.Base
{
    public abstract class BaseMvvmTest
    {
        protected StubViewModel StubViewModel { get; set; }

        [TestInitialize]
        public void Init()
        {
            StubViewModel = new StubViewModel();
        }
    }
}