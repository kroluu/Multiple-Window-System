namespace UI.WindowSystem.Interfaces
{
    public interface IWindowVisibility
    {
        void Open(bool _immediatelyShow=false);
        void Close(bool _immediatelyHide=false);
        void SetSortingIndex(int _index);

    }
}