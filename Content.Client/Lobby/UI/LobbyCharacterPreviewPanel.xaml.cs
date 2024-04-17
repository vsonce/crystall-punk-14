using System.Numerics;
using Content.Client.UserInterface.Controls;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Lobby.UI;

[GenerateTypedNameReferences]
public sealed partial class LobbyCharacterPreviewPanel : Control
{
    public Button CharacterSetupButton => CharacterSetup;

    public LobbyCharacterPreviewPanel()
    {
        RobustXamlLoader.Load(this);
        UserInterfaceManager.GetUIController<LobbyUIController>().SetPreviewPanel(this);
    }

    public void SetLoaded(bool value)
    {
        Loaded.Visible = value;
        Unloaded.Visible = !value;
    }

    public void SetSummaryText(string value)
    {
        Summary.Text = string.Empty;
    }

    public void SetSprite(EntityUid uid)
    {
        ViewBox.DisposeAllChildren();
        var spriteView = new SpriteView
        {
            OverrideDirection = Direction.South,
            Scale = new Vector2(4f, 4f),
            MaxSize = new Vector2(112, 112),
            Stretch = SpriteView.StretchMode.Fill,
        };
        spriteView.SetEntity(uid);
        ViewBox.AddChild(spriteView);
    }
}
