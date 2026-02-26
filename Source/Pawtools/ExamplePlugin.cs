using System;
using FlaxEngine;

namespace Pawtools
{
    /// <summary>
    /// The sample game plugin.
    /// </summary>
    /// <seealso cref="FlaxEngine.GamePlugin" />
    public class Pawtools : GamePlugin
    {
        /// <inheritdoc />
        public Pawtools()
        {
            _description = new PluginDescription
            {
                Name = "Pawtools",
                Category = "Other",
                Author = "Nanopaw Studios",
                AuthorUrl = null,
                HomepageUrl = null,
                RepositoryUrl = "https://github.com/Nanopaw-Studios/Pawtools",
                Description = "an in-house toolkit for the flax game engine.",
                Version = new Version(0, 0, 1),
                IsAlpha = false,
                IsBeta = true,
            };
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();

            Debug.Log("Pawtools Initalized, ready to use.");
        }

        /// <inheritdoc />
        public override void Deinitialize()
        {
            // Use it to cleanup data

            Debug.Log("Pawtools is being deinitalized.");
            base.Deinitialize();
        }
    }
}
