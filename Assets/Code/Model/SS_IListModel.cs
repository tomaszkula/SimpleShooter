public interface SS_IListModel<SS_TItemModel>
{
	SS_TItemModel GetItem(int index);
	int NumItems { get; }
}