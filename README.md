# Tutorials

This is the home for any projects I decide to create associated with my tutorials.  See [gamedevbill.com](https://gamedevbill.com) for all the tutorials, and [follow me on twitter](https://twitter.com/gamedevbill) to stay up to date!


## Normal Calculation & Normal Calc URP
Projects with the results from [How to Calculate Shader Graph Normals](https://gamedevbill.com/shader-graph-normal-calculation/).  "NormalCaculation" is done in HDRP, and "NormalCalc_URP" is in URP.  These samples include two top level shader graphs: FullNormalCorrection & SubGraphNormalCorrection.  Each accomplishes the same normal calculation.  One as a flat top-level graph, one using sub-graph helpers.  

Important contents are all in /Assets/NormalCalculation/:
* SimpleDeform - the actual vertex displacement subgraph used for example purposes
* FullNormalCorrection - a graph that recalculates normals all in one graph.  Matches screenshot from tutorial.  Useful for following full logic flow. 
* SubGraphNormalCorrection - same logic as FullNormalCorrection but broken into sub-graphs. Useful to model when actually doing this in real life as it's a lot easier to hook up.
* Neighbors - first stage subgraph. Used by SubGraphNormalCorrection before feeding into the vertex displacement.
* NewNormal - final stage subgraph. Used by SubGraphNormalCorrection after feeding into the vertex displacement.

Please see the tutorial for a complete explanation of what's going on. 

## Paper Burn
Based on the [Paper Burn Shader in Unity](https://gamedevbill.com/paper-burn-shader-in-unity/) tutorial.  The one difference is that the tutorial used the crumple paper as the baseline, but this one uses "mathy noise".  The reason being that my crumple uses a texture that's generated by paid-for software and I can't put it up here for public use.  

The relevant pieces are all in Assets/Shaders.  
* BurnData - mostly calculates radius from burn point
* BurnGradient - math for the multi-color gradient between start of burn and transparent hole.
* BurnVertexDisplacement - vertex manipulation based on distance from burn point & edge.
* CalculateBurnNoise - make the burn shape wavy & rough.
* MathyPaperNoise - unlike the the tutorial, this paper is based on mathy noise instead of the texture-driven crumple. 
* Neighbors - subgraph taken from the Normal Calculation sample projec in this same repo
* NewNormal - subgraph taken from the Normal Calculation sample projec in this same repo
* PaperBurn - the top level shader that gets things done. 

## HSV Nodes
Based on the [HSV in Shader Graph](https://gamedevbill.com/) tutorial (Hue-Saturation-Value).  This is not a complete project, but instead just the two nodes needed.

* rgb2hsv - subgraph node to convert from RGB to HSV color space
* hsv2rgb - subgraph node to convert from HSV to RGB color space

## 2D Fire
Based on the [Top Fire Shaders](https://youtu.be/8sJQvFA6GEI) tutorial.
