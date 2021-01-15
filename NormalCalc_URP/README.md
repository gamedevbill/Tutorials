## Normal Calculation
Project with the results from [How to Calculate Shader Graph Normals](https://gamedevbill.com/shader-graph-normal-calculation/).  This sample includes two top level shader graphs: FullNormalCorrection & SubGraphNormalCorrection.  Each accomplishes the same normal calculation.  One as a flat top-level graph, one using sub-graph helpers.  

Important contents are all in /Assets/NormalCalculation/:
* SimpleDeform - the actual vertex displacement subgraph used for example purposes
* FullNormalCorrection - a graph that recalculates normals all in one graph.  Matches screenshot from tutorial.  Useful for following full logic flow. 
* SubGraphNormalCorrection - same logic as FullNormalCorrection but broken into sub-graphs. Useful to model when actually doing this in real life as it's a lot easier to hook up.
* Neighbors - first stage subgraph. Used by SubGraphNormalCorrection before feeding into the vertex displacement.
* NewNormal - final stage subgraph. Used by SubGraphNormalCorrection after feeding into the vertex displacement.

Please see the tutorial for a complete explanation of what's going on. 

