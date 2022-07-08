using Mopups.Awaitable.AbstractClasses;

namespace Mopups.Awaitable.Interfaces
{
    public interface IGenericViewModel<TViewModel> where TViewModel : BasePopupViewModel
    {
        void SetViewModel(TViewModel viewModel);
        TViewModel GetViewModel();
    }
}