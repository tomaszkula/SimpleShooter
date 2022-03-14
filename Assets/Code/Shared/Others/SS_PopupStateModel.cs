public class SS_PopupStateModel<T, V> : SS_PopupState<T>, SS_IPopupModel<V> where V : SS_IModel
{
	protected V model;

	public virtual void Setup(V m)
	{
		model = m;
	}
}