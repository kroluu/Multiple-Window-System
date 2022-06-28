namespace UI.GameWindowPanels
{
    public interface ISelectableWindow
    {
        void SelectWindow();
        void DeselectWindow();
        void SetSortingIndex(int _indexToSet);
    }
}