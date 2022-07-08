using System.ComponentModel;

namespace Mopups.Awaitable.Interfaces
{
	public interface IBasePopupViewModel
	{
		bool IsBusy { get; set; }
		event PropertyChangedEventHandler PropertyChanged;
	}
}