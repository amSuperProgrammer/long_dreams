using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    void Start()
    {
        List<Material> objMaterials = GetComponent<Renderer>().materials.ToList();

        foreach (Material mat in objMaterials)
        {
        }
    }
}
