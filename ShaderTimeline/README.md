
## Shader Timeline
Project based on the tutorial <coming soon>.  The code in this project provides the baseline for driving shader inputs from Timeilne. Out of the box it supports Float, Vector, and Color inputs. It should be relatively straightforward to extend to other types as needed. Just look at the tutorial to understand what's going on in the system.

* ShaderTimeline/ShaderPlayable.cs - Runtime data holder. Depending on how you extend Timeline, this class can do more, but for us it just needs data.
* ShaderTimeline/ShaderControlAsset.cs - The editor-pair that goes with our above data. It holds the data as you set it in the editor, and has the code needed to create the runtime data holder.
* ShaderTimeline/ShaderTrack.cs - The timeline track. This asset is the actual track added onto the timeline. Each track can hold a collection of ShaderControlAsset’s.
* ShaderTimeline/ShaderMixer.cs - The runtime logic piece.  This is what will take the multiple ShaderPlayable’s and mix them together based on how the parts of the track are overlapping.
* TimelineSample/* - The sample scene, timeline, and shader.

