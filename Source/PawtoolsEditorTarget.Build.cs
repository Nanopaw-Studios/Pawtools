using Flax.Build;

public class PawtoolsEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add("Pawtools");
        Modules.Add("PawtoolsEditor");
    }
}
