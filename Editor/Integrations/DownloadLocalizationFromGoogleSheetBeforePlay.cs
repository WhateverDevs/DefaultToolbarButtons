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
        /// Url to refresh from.
        /// </summary>
        public string Url;

        /// <summary>
        /// Reference to the configuration file.
        /// </summary>
        public LocalizerConfigurationFile LocalizationConfigurationFile;

        /// <summary>
        /// Run before playing.
        /// </summary>
        public override void Run() =>
            GoogleSheetLoader.LoadLanguages(Url, LocalizationConfigurationFile.ConfigurationData.LanguagePackDirectory);
    }
}