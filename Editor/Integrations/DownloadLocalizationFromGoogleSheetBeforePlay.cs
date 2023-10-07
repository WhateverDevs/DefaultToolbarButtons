using UnityEngine;
using WhateverDevs.Localization.Editor;
using WhateverDevs.Localization.Runtime;

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
        /// Reference to the localization project settings.
        /// </summary>
        [SerializeField]
        private LocalizerSettings LocalizationProjectSettings;

        /// <summary>
        /// Run before playing.
        /// </summary>
        public override void Run() =>
            GoogleSheetLoader.LoadLanguages(LocalizationProjectSettings.GoogleSheetsDownloadUrls.ToArray(),
                                            LocalizationProjectSettings.LanguagePackDirectory);
    }
}