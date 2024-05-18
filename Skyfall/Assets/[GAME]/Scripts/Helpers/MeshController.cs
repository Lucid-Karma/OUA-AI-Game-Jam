using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class MeshController : MonoBehaviour
{
    public ParticleSystem destructionEffect;
    public float sliceDelay = 0.5f;  // Time delay before completely destroying the sliced parts

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
             StartCoroutine(SliceAndDestroyHouse(other.gameObject));
        }
    }

    IEnumerator SliceAndDestroyHouse(GameObject house)
    {
        // Play destruction effect
        ParticleSystem effect = Instantiate(destructionEffect, house.transform.position, Quaternion.identity);
        effect.Play();

        // Slice the house
        SliceObject(house);

        // Wait for a while before destroying the slices
        yield return new WaitForSeconds(sliceDelay);

        // Destroy the remaining parts of the house
        Destroy(house);
    }

    void SliceObject(GameObject obj)
    {
        MeshFilter[] meshFilters = obj.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter meshFilter in meshFilters)
        {
            Mesh originalMesh = meshFilter.mesh;
            SlicedHull slicedHull = SliceMesh(originalMesh, meshFilter.transform.position);

            if (slicedHull != null)
            {
                GameObject lowerHull = CreateMeshPiece(slicedHull.lowerHull, meshFilter);
                GameObject upperHull = CreateMeshPiece(slicedHull.upperHull, meshFilter);

                lowerHull.AddComponent<Rigidbody>().mass = 1;
                upperHull.AddComponent<Rigidbody>().mass = 1;

                Destroy(meshFilter.gameObject);  // Destroy the original part
            }
        }
    }

    SlicedHull SliceMesh(Mesh mesh, Vector3 position)
    {
        return mesh.Slice(position, Vector3.up);
    }

    GameObject CreateMeshPiece(Mesh mesh, MeshFilter original)
    {
        GameObject piece = new GameObject("SlicedPiece");
        piece.transform.position = original.transform.position;
        piece.transform.rotation = original.transform.rotation;

        MeshFilter meshFilter = piece.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = piece.AddComponent<MeshRenderer>();
        meshRenderer.materials = original.GetComponent<MeshRenderer>().materials;

        return piece;
    }
}
