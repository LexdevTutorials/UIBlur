using UnityEngine;

[ExecuteInEditMode]
public class ConvertToLineMesh : MonoBehaviour
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
            if (mesh.GetTopology(0) != MeshTopology.Lines)
                GeneratePointMesh();
        }
    }

    void GeneratePointMesh()
    {
        int vertexCount = mesh.vertexCount;

        int[] indices = new int[vertexCount * 2];
        for (int i = 0; i < vertexCount; i++)
        {
            indices[2 * i] = i;
            indices[2 * i + 1] = (i + 1) % vertexCount;
        }

        mesh.SetIndices(indices, MeshTopology.Lines, 0);
    }
}