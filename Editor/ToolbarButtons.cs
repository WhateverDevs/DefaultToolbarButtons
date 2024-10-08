﻿using System.IO;
using BennyKok.ToolbarButtons;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using WhateverDevs.SceneManagement.Runtime.AddressableManagement;
using WhateverDevs.SceneManagement.Runtime.SceneManagement;
using WhateverDevs.TwoDAudio.Runtime;
using Zenject;

namespace WhateverDevs.DefaultToolBarButtons.Editor
{
    /// <summary>
    /// Class to add all the buttons we want to the toolbar.
    /// Reference to icons: https://unitylist.com/p/5c3/Unity-editor-icons.
    /// </summary>
    public static class ToolbarButtons
    {
        /// <summary>
        /// Path to the config folder.
        /// </summary>
        private const string ConfigFolder = "Assets/Data/ToolbarButtons/Editor";

        /// <summary>
        /// Path to the config file.
        /// </summary>
        private const string ConfigPath = ConfigFolder + "/Config.asset";

        /// <summary>
        /// Cached reference to the config.
        /// </summary>
        private static ToolbarButtonsConfig config;

        /// <summary>
        /// Open the project folder.
        /// </summary>
        [ToolbarButton("Audio Mixer@2x", "Open toolbar buttons settings", 10)]
        [UsedImplicitly]
        public static void ButtonsConfig()
        {
            CacheConfig();
            Selection.activeObject = config;
        }

        #if WHATEVERDEVS_TOOLBARBUTTONS

        #if WHATEVERDEVS_TOOLBARBUTTONS_SAVE

        /// <summary>
        /// Save the scene and project.
        /// </summary>
        [ToolbarButton("SaveAs@2x", "Save the scene and project.", 9)]
        [UsedImplicitly]
        [MenuItem("WhateverDevs/Toolbar Fallback/Save #&s")]
        public static void Save()
        {
            EditorApplication.ExecuteMenuItem("File/Save");
            EditorApplication.ExecuteMenuItem("File/Save Project");
        }

        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_PROJECTFOLDER
        /// <summary>
        /// Open the project folder.
        /// </summary>
        [ToolbarButton("Folder Icon", "Open project folder.", 8)]
        [UsedImplicitly]
        public static void OpenProjectFolder() => DefaultToolbarButtons.OpenFolder();
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_PACKAGEMANAGER
        /// <summary>
        /// Open the package manager.
        /// </summary>
        [ToolbarButton(iconName = "Package Manager", tooltip = "Package Manager", order = 7)]
        [UsedImplicitly]
        [MenuItem("WhateverDevs/Toolbar Fallback/Packman #&o")]
        public static void OpenPackageManager() => DefaultToolbarButtons.ShowPackageManager();
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_PROJECTSETTINGS
        /// <summary>
        /// Open either project settings or editor settings.
        /// </summary>
        [ToolbarButton("Settings", "Show Settings", 6)]
        [UsedImplicitly]
        public static void OpenSettings()
        {
            GenericMenu menu = new();

            menu.AddItem(new GUIContent("Project"),
                         false,
                         () => EditorApplication.ExecuteMenuItem("Edit/Project Settings..."));

            menu.AddItem(new GUIContent("Preferences"),
                         false,
                         () => EditorApplication.ExecuteMenuItem("Edit/Preferences..."));

            menu.AddItem(new GUIContent("C# Project"), false, OpenCSharpProject);

            menu.ShowAsContext();
        }

        /// <summary>
        /// Open the C# project.
        /// </summary>
        [MenuItem("WhateverDevs/Toolbar Fallback/C# Project #&x")]
        private static void OpenCSharpProject() => EditorApplication.ExecuteMenuItem("Assets/Open C# Project");
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_PROJECTCONTEXT
        /// <summary>
        /// Open the project context.
        /// </summary>
        [ToolbarButton("d_EditCollider", "Project Context", 5)]
        [UsedImplicitly]
        public static void ProjectContext()
        {
            CacheConfig();

            Selection.activeObject =
                AssetDatabase
                   .LoadAssetAtPath<
                        ProjectContext>(AssetDatabase.GetAssetPath(config.ProjectContext));
        }
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_BUILD
        /// <summary>
        /// Opens the Console Pro window.
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        #if UNITY_6000_0_OR_NEWER
        [ToolbarButton("Collab.Build", "Build", 4)]
        #else
        [ToolbarButton("d_SceneViewFX@2x", "Build", 4)]
        #endif
        [UsedImplicitly]
        public static void OpenBuild() =>
            #if UNITY_6000_0_OR_NEWER
            EditorApplication.ExecuteMenuItem("File/Build Profiles");
        #else
            EditorApplication.ExecuteMenuItem("File/Build Settings...");
        #endif
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_SCENEMANAGEMENT
        /// <summary>
        /// Open the addressable groups.
        /// </summary>
        [ToolbarButton("d_Profiler.NetworkOperations@2x", "Addressables", 3)]
        [UsedImplicitly]
        public static void Addressables()
        {
            CacheConfig();

            GenericMenu menu = new GenericMenu();

            menu.AddItem(new GUIContent("Scene Manager"),
                         false,
                         () => Selection.activeObject =
                                   AssetDatabase
                                      .LoadAssetAtPath<
                                           SceneManager>(AssetDatabase.GetAssetPath(config.SceneManager)));

            menu.AddItem(new GUIContent("Addressables/Groups"),
                         false,
                         () => EditorApplication.ExecuteMenuItem("Window/Asset Management/Addressables/Groups"));

            menu.AddItem(new GUIContent("Addressables/Version Dependence"),
                         false,
                         () => Selection.activeObject =
                                   AssetDatabase
                                      .LoadAssetAtPath<
                                           AddressableVersionDependence>(AssetDatabase.GetAssetPath(config
                                                                                     .AddressableVersionDependence)));

            menu.AddItem(new GUIContent("Addressables/Builder"),
                         false,
                         () => Selection.activeObject =
                                   AssetDatabase
                                      .LoadAssetAtPath<
                                           AddressablesBuilder>(AssetDatabase
                                                                   .GetAssetPath(config.AddressablesBuilder)));

            menu.ShowAsContext();
        }
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_TWODAUDIO
        /// <summary>
        /// Open the project context.
        /// </summary>
        [ToolbarButton("d_Profiler.Audio@2x", "Audio Library", 2)]
        [UsedImplicitly]
        public static void AudioLibrary()
        {
            CacheConfig();

            Selection.activeObject =
                AssetDatabase
                   .LoadAssetAtPath<
                        AudioLibrary>(AssetDatabase.GetAssetPath(config.AudioLibrary));
        }
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_CONSOLEPRO
        /// <summary>
        /// Opens the Console Pro window.
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [ToolbarButton("d_Profiler.UIDetails@2x", "Console Pro", 1)]
        [UsedImplicitly]
        [MenuItem("WhateverDevs/Toolbar Fallback/Console Pro #&c")]
        public static void OpenConsolePro() => EditorApplication.ExecuteMenuItem("Window/Console Pro 3");
        #endif

        #if WHATEVERDEVS_TOOLBARBUTTONS_PLAYBUTTON
        /// <summary>
        /// Open the app initialization scene and then play.
        /// Stop playing if it is.
        /// </summary>
        [ToolbarButton("UnityEditor.GameView", "Play from init")]
        [UsedImplicitly]
        [MenuItem("WhateverDevs/Toolbar Fallback/Play #&p")]
        public static void PlayFromInit()
        {
            CacheConfig();

            if (Application.isPlaying)
            {
                EditorApplication.isPlaying = false;
                return;
            }

            try
            {
                EditorUtility.DisplayProgressBar("Loading", "Running play hooks...", .25f);

                foreach (PlayHook playHook in config.PlayHooks) playHook.Run();

                EditorUtility.DisplayProgressBar("Loading", "Loading init scene...", .5f);

                EditorSceneManager.SaveOpenScenes();

                EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(config.InitializationScene));
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            EditorApplication.isPlaying = true;
        }

        #endif

        #endif

        /// <summary>
        /// Cache or create the configuration reference.
        /// </summary>
        private static void CacheConfig()
        {
            if (config != null) return;

            config =
                AssetDatabase.LoadAssetAtPath<ToolbarButtonsConfig>(ConfigPath);

            if (config != null) return;
            if (!Directory.Exists(ConfigFolder)) Directory.CreateDirectory(ConfigFolder);

            config = (ToolbarButtonsConfig) ScriptableObject.CreateInstance(typeof(ToolbarButtonsConfig));
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
        }
    }
}