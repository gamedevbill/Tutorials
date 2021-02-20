using UnityEngine;
using UnityEngine.Playables;

public class ShaderMixer : PlayableBehaviour
{
    public string ShaderVarName;
    public ShaderTrack.ShaderControlType VariableType;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Renderer renderer = playerData as Renderer;
        float finalFloat = 0;
        Vector4 finalVector4 = Vector4.zero;
        Color finalColor = Color.black;

        if (renderer == null)
            return;
        
        int inputCount = playable.GetInputCount();

        float totalWeight = 0;

        for (int index = 0; index < inputCount; index++)
        {
            float weight = playable.GetInputWeight(index);
            var inputPlayable = (ScriptPlayable<ShaderPlayable>) playable.GetInput(index);
            var behaviour = inputPlayable.GetBehaviour();

            finalFloat += behaviour.FloatVal * weight;
            finalVector4 += behaviour.VectorVal * weight;
            finalColor += behaviour.ColorVal * weight;

            totalWeight += weight;
        }

        if (totalWeight < 0.5f)
            return;

        Material mat;
        if (Application.isPlaying)
            mat = renderer.material;
        else
            mat = renderer.sharedMaterial;
        
        switch (VariableType)
        {
            case ShaderTrack.ShaderControlType.SetFloat:
                mat.SetFloat(ShaderVarName, finalFloat);
                break;
            case ShaderTrack.ShaderControlType.SetVector:
                mat.SetVector(ShaderVarName, finalVector4);
                break;
            case ShaderTrack.ShaderControlType.SetColor:
                mat.SetColor(ShaderVarName, finalColor);
                break;
        }
    }
}
