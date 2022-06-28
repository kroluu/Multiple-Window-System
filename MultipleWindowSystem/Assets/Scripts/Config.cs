using System.IO;
using UnityEngine;

namespace Core.Settings
{
    public enum SerializationFormat { Json, Binary}

    public static class Config
    {
        #region UI

        public const int DEFAULT_GAME_SORTING_INDEX = 1;
        public const float TIME_FOR_PANEL_APPEARANCE = 0.4f;
        public const float TIME_FOR_PANEL_HIDE = 0.2f;

        #endregion
        
    }
}
