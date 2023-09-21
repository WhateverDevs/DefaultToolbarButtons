using UnityEngine;
using WhateverDevs.Localization.Editor;

namespace WhateverDevs.DefaultToolBarButtons.Editor.Integrations
{
    /// <summary>
    /// Play hook that refreshes the languages just before building.
    /// </summary>
    [CreateAssetMenu(menuName = "WhateverDevs/Localization/PlayHook",
                     fileName = "DownloadLocalizationFromGoogleSheetBeforePlay")]
    public class DownloadLocalizationFromGoogleSheetBeforePlay : PlayHook
    {
        /// <summary>
        /// Url to refresh from.
        /// </summary>
        public string Url;

        /// <summary>
        /// Directory in which to output the localization (inside assets).
        /// </summary>
        public string OutputDirectory = "Languages/";

        /// <summary>
        /// Run before playing.
        /// </summary>
        public override void Run() => GoogleSheetLoader.LoadLanguages(Url, OutputDirectory);
    }
}