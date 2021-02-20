using UnityEngine;
using UnityEngine.Playables;

public class ShaderControlAsset : PlayableAsset
{
    public float FloatVal = 0;
    public Vector4 VectorVal = Vector4.zero;
    public Color ColorVal = Color.black;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ShaderPlayable>.Create(graph);

        ShaderPlayable behavior = playable.GetBehaviour();
        behavior.FloatVal = FloatVal;
        behavior.VectorVal = VectorVal;
        behavior.ColorVal = ColorVal;

        return playable;
    }
}
