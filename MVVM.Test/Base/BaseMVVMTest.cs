using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
