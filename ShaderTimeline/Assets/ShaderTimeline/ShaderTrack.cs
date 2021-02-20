using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(ShaderControlAsset))]
[TrackBindingType(typeof(Renderer))]
public class ShaderTrack : TrackAsset
{
    public enum ShaderControlType
    {
        SetFloat,
        SetVector,
        SetColor
    }

    public string ShaderVarName;
    public ShaderControlType VariableType;
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<ShaderMixer>.Create(graph, inputCount);
        mixer.GetBehaviour().ShaderVarName = ShaderVarName;
        mixer.GetBehaviour().VariableType = VariableType;
        return mixer;
    }
}
