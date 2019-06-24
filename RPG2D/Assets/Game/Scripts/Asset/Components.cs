using Entitas;

[Game]
public class AssetComponent: IComponent
{
    public string assetName = "";
    public int layerMask = -1;
    public void Initialize(string assetName_, int layerMask_ = -1)
    {
        assetName = assetName_;
        layerMask = layerMask_;
    }
}