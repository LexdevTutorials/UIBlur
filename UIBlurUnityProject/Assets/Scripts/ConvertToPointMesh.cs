using UnityEngine;

[ExecuteInEditMode]
public class ConvertToPointMesh : MonoBehaviour
{
    private Mesh mesh;

    // Update is called once per frame
    void Update()
    {
        if (mesh == null)
        {
            if (GetComponent<MeshFilter>())
                mesh = GetComponent<MeshFilter>().sharedMesh;
            if (GetComponent<SkinnedMeshRenderer>())
                mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        }
        else
        {
            if (mesh.GetTopology(0) != MeshTopology.Points)
                GeneratePointMesh();
        }
    }
    
    void GeneratePointMesh()
    {
        int vertexCount = mesh.vertexCount;
        
        int[] indices = new int[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            indices[i] = i;
        }

        mesh.SetIndices(indices, MeshTopology.Points, 0);
    }
}
