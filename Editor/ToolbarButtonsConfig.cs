using JetBrains.Annotations;
using UnityEditor;
using WhateverDevs.Core.Editor.Utils;
using WhateverDevs.Core.Runtime.Common;
using WhateverDevs.SceneManagement.Runtime.AddressableManagement;
using WhateverDevs.SceneManagement.Runtime.SceneManagement;
using WhateverDevs.TwoDAudio.Runtime;
using Zenject;

#if ODIN_INSPECTOR_3
using Sirenix.OdinInspector;
#endif

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
        #if ODIN_INSPECTOR_3
        [InfoBox("Changing this config recompiles the project, be patient :)")]
        [OnValueChanged("OnEnableToolbarButtonsChange")]
        #endif
        public bool EnableToolbarButtons;

        /// <summary>
        /// Enable the save toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableSaveButton")]
        #endif
        public bool EnableSaveButton;

        /// <summary>
        /// Enable the project folder toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableProjectFolderButton")]
        #endif
        public bool EnableProjectFolderButton;

        /// <summary>
        /// Enable the package manager toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnablePackageManagerButton")]
        #endif
        public bool EnablePackageManagerButton;

        /// <summary>
        /// Enable the project settings toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableProjectSettingsButton")]
        #endif
        public bool EnableProjectSettingsButton;

        /// <summary>
        /// Enable the build toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnableBuildButton")]
        #endif
        public bool EnableBuildButton;

        /// <summary>
        /// Enable the build toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [OnValueChanged("OnEnablePlayButton")]
        #endif
        public bool EnablePlayButton;

        /// <summary>
        /// Reference to the initialization scene.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("General")]
        [ShowIf("EnablePlayButton")]
        #endif
        public SceneAsset InitializationScene;

        /// <summary>
        /// Enable the project context toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Zenject")]
        [OnValueChanged("OnEnableProjectContextButton")]
        #endif
        public bool EnableProjectContextButton;

        /// <summary>
        /// Reference to the project context.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Zenject")]
        [ShowIf("EnableProjectContextButton")]
        #endif
        public ProjectContext ProjectContext;

        /// <summary>
        /// Enable the scene management toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Scene Management")]
        [OnValueChanged("OnEnableSceneManagementButton")]
        #endif
        public bool EnableSceneManagementButton;

        /// <summary>
        /// Reference to the scene manager.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        #endif
        public SceneManager SceneManager;

        /// <summary>
        /// Reference to the AddressableVersionDependence file.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        #endif
        public AddressableVersionDependence AddressableVersionDependence;

        /// <summary>
        /// Reference to the addressable builder.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Scene Management")]
        [ShowIf("EnableSceneManagementButton")]
        #endif
        public AddressablesBuilder AddressablesBuilder;

        /// <summary>
        /// Enable the 2D audio button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("2D Audio")]
        [OnValueChanged("OnEnable2DAudioButton")]
        #endif
        public bool Enable2DAudioLibraryButton;

        /// <summary>
        /// Reference to the audio library.
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("2D Audio")]
        [ShowIf("Enable2DAudioLibraryButton")]
        #endif
        public AudioLibrary AudioLibrary;

        /// <summary>
        /// Enable the console pro toolbar button?
        /// </summary>
        #if ODIN_INSPECTOR_3
        [FoldoutGroup("Third Party Plugins")]
        [OnValueChanged("OnEnableConsoleProButton")]
        #endif
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