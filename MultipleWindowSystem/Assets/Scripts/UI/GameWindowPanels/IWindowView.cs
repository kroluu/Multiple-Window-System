namespace UI.GameWindowPanels
{
    public interface IWindowView
    {
        void Open();
        void Close();
        void SetSortingIndex(int _index);
    }
}