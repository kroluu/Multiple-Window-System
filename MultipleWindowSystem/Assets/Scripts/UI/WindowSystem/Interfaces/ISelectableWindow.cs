namespace UI.WindowSystem.Interfaces
{
    public interface ISelectableWindow
    {
        void SelectWindow();
        void DeselectWindow();
        void SetSortingIndex(int _indexToSet);
    }
}