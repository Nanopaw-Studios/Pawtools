using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Editor;

/// <summary>
/// NanoGameData Script.
/// </summary>
public class NanoGameData : Class
{
    public string gameTitle = "Name of Game";
    public string gameAuthor = "Nanopaw Studios";
    public Version gameVersion = new Version(0, 0, 0);

    public NanoGameData(string title, string author, Version version)
    {
        gameTitle = title;
        gameAuthor = author;
        gameVersion = version;
    }
}
