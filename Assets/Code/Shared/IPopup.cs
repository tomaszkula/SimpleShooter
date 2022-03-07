using Cysharp.Threading.Tasks;

namespace TSG.Popups
{
	public interface IPopupModel<T>
	{
		void Setup(T model);
	}
	
	public interface IPopup
	{
		void Init();
		UniTask<bool> Open();
		void Dispose();
		void Close();
	}
}