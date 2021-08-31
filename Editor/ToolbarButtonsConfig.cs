using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEditor;
using WhateverDevs.Core.Editor.Utils;
using WhateverDevs.Core.Runtime.Common;
using WhateverDevs.SceneManagement.Runtime.AddressableManagement;
using WhateverDevs.SceneManagement.Runtime.SceneManagement;
using WhateverDevs.TwoDAudio.Runtime;
using Zenject;

namespace WhateverDevs.DefaultToolBarButtons.Editor
{
    /// <summary>
    /// Configuration manager for the toolbar buttons that will set scripting defines to enable or disable buttons.
    /// </summary>
    public class ToolbarButtonsConfig : LoggableScriptableObject<ToolbarButtonsConfig>
    {
        /// <summary>
        /// Enable the toolbar buttons?
        /// </summary>
        [InfoBox("Changing this config recompiles the project, be patient :)")]
        [OnValueChanged("OnEnableToolbarButtonsChange")]
        public bool EnableToolbarButtons;
        
        /// <summary>
        /// Enable the save toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableSaveButton")]
        public bool EnableSaveButton;

        /// <summary>
        /// Enable the project folder toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableProjectFolderButton")]
        public bool EnableProjectFolderButton;

        /// <summary>
        /// Enable the package manager toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnablePackageManagerButton")]
        public bool EnablePackageManagerButton;

        /// <summary>
        /// Enable the project settings toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableProjectSettingsButton")]
        public bool EnableProjectSettingsButton;

        /// <summary>
        /// Enable the build toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableBuildButton")]
        public bool EnableBuildButton;
        
        /// <summary>
        /// Enable the build toolbar button?
        /// </summary>
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnablePlayButton")]
        public bool EnablePlayButton;

        [FoldoutGroup("General")]
        [ShowIf("EnablePlayButton")]
        public SceneAsset InitializationScene;

        /// <summary>
        /// Enable the project context toolbar button?
        /// </summary>
        [FoldoutGroup("Zenject")]
        [OnValueChanged("OnEnableProjectContextButton")]
        public bool EnableProjectContextButton;

        /// <summary>
        /// Reference to the project context.
        /// </summary>
        [FoldoutGroup("Zenject")]
        [ShowIf("EnableProjectContextButton")]
        public ProjectContext ProjectContext;

        /// <summary>
        /// Enable the scene management toolbar button?
        /// </summary>
        [FoldoutGroup("Scene Management")]
        [OnValueChanged("OnEnableSceneManagementButton")]
        public bool EnableSceneManagementButton;

        /// <summary>
        /// Reference to the scene manager.
        /// </summary>
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        public SceneManager SceneManager;

        /// <summary>
        /// Reference to the AddressableVersionDependence file.
        /// </summary>
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        public AddressableVersionDependence AddressableVersionDependence;

        /// <summary>
        /// Reference to the addressable builder.
        /// </summary>
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        public AddressablesBuilder AddressablesBuilder;
        
        /// <summary>
        /// Enable the 2D audio button?
        /// </summary>
        [FoldoutGroup("2D Audio")]
        [OnValueChanged("OnEnable2DAudioButton")]
        public bool Enable2DAudioLibraryButton;
        
        /// <summary>
        /// Reference to the audio library.
        /// </summary>
        [FoldoutGroup("2D Audio")]
        [ShowIf("Enable2DAudioLibraryButton")]
        public AudioLibrary AudioLibrary;
        
        /// <summary>
        /// Enable the console pro toolbar button?
        /// </summary>
        [FoldoutGroup("Third Party Plugins")]
        [OnValueChanged("OnEnableConsoleProButton")]
        public bool EnableConsoleProButton;

        /// <summary>
        /// Called when the EnableToolbarButtons property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableToolbarButtonsChange() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS", EnableToolbarButtons);
        
        /// <summary>
        /// Called when the EnableSaveButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableSaveButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_SAVE", EnableSaveButton);

        /// <summary>
        /// Called when the EnableProjectFolderButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableProjectFolderButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_PROJECTFOLDER", EnableProjectFolderButton);

        /// <summary>
        /// Called when the EnablePackageManagerButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnablePackageManagerButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_PACKAGEMANAGER", EnablePackageManagerButton);

        /// <summary>
        /// Called when the EnableProjectSettingsButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableProjectSettingsButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_PROJECTSETTINGS", EnableProjectSettingsButton);

        /// <summary>
        /// Called when the EnableBuildButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableBuildButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_BUILD", EnableBuildButton);
        
        /// <summary>
        /// Called when the EnableBuildButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnablePlayButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_PLAYBUTTON", EnablePlayButton);

        /// <summary>
        /// Called when the EnableProjectContextButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableProjectContextButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_PROJECTCONTEXT", EnableProjectContextButton);

        /// <summary>
        /// Called when the EnableSceneManagementButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableSceneManagementButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_SCENEMANAGEMENT", EnableSceneManagementButton);
        
        /// <summary>
        /// Called when the Enable2DAudioButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnable2DAudioButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_TWODAUDIO", Enable2DAudioLibraryButton);
        
        /// <summary>
        /// Called when the EnableConsoleProButton property is changed.
        /// </summary>
        [UsedImplicitly]
        private void OnEnableConsoleProButton() =>
            ScriptingDefines.SetDefine("WHATEVERDEVS_TOOLBARBUTTONS_CONSOLEPRO", EnableConsoleProButton);
    }
}