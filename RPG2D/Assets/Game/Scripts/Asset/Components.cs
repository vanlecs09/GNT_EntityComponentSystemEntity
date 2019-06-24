using Entitas;

[Game]
public class AssetComponent: IComponent
{
    public string assetName = "";
    public void Initialize(string assetName_)
    {
        assetName = assetName_;
    }
}