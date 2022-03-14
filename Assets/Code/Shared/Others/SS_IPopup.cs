using Cysharp.Threading.Tasks;

public interface SS_IPopupModel<T>
{
	void Setup(T model);
}
	
public interface SS_IPopup
{
	void Init();
	UniTask<bool> Open();
	void Dispose();
	void Close();
}