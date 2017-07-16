using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public abstract class UnityRepositoryExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            RegisterSettings();
            RegisterRepository();
        }

        protected abstract void RegisterSettings();
        protected abstract void RegisterRepository();
    }
}