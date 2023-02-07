using WhateverDevs.Core.Behaviours;

namespace WhateverDevs.DefaultToolBarButtons.Editor
{
    /// <summary>
    /// Base class for hooks that can be run before playing the application.
    /// </summary>
    public abstract class PlayHook : WhateverScriptable<PlayHook>
    {
        /// <summary>
        /// Run the hook.
        /// </summary>
        public abstract void Run();
    }
}