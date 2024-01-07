using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAndSkinManager : Singleton<WeaponAndSkinManager>
{
    [SerializeField] List<GameObject> weaponSkinList = new List<GameObject>();
    [SerializeField] List<GameObject> weaponList = new List<GameObject>();
    [SerializeField] List<Material> pantMaterials = new List<Material>();
    [SerializeField] List<Material> skinMaterials = new List<Material>();
    [SerializeField] SkinnedMeshRenderer pantMeshrendered;
    [SerializeField] Camera secondCamera;
    [SerializeField] string weaponTag;

    [SerializeField] MeshFilter weaponMeshFiler;
    [SerializeField] MeshRenderer weaponMeshRenderer;

    [SerializeField] MeshFilter hairMeshFiler;
    [SerializeField] MeshRenderer hairMeshRenderer;
    [SerializeField] Player player;
    Enemy enemyCom;
    public int currentWeapon = 0;
    int randPant;
    int randSkin;


    public string GetNextWeapon()
    {
        if (currentWeapon >= weaponSkinList.Count - 1)
            return weaponSkinList[currentWeapon].name;
        weaponSkinList[currentWeapon].SetActive(false);
        currentWeapon++;
        weaponSkinList[currentWeapon].SetActive(true);
        return weaponSkinList[currentWeapon].name;
    }

    public string GetBackWeapon()
    {
        if (currentWeapon <= 0)
            return weaponSkinList[currentWeapon].name;

        weaponSkinList[currentWeapon].SetActive(false);
        currentWeapon--;
        weaponSkinList[currentWeapon].SetActive(true);
        return weaponSkinList[currentWeapon].name;

    }

    public void SelectWeapon()
    {
        weaponMeshFiler.mesh = CacheComponent.GetMeshFilter(weaponSkinList[currentWeapon]).mesh;
        weaponMeshRenderer.materials = CacheComponent.GetMeshRenderer(weaponSkinList[currentWeapon]).sharedMaterials;
        player.SetWeaponTag(weaponList[currentWeapon].tag);
    }


    public string GetWeapon()
    {
        return weaponTag;
    }

    public void GetRandomEnemyWeaponAndSkin(GameObject enemy)
    {
        int randomIndex = Random.Range(0, weaponList.Count);
        randPant = Random.Range(0, pantMaterials.Count);
        randSkin = Random.Range(0, skinMaterials.Count);
        enemyCom = CacheComponent.GetEnemyComponent(enemy.transform);
        enemyCom.ChangeSkin(pantMaterials[randPant], skinMaterials[randSkin], weaponList[randomIndex].tag);
        enemyCom.ChangeWeaponSkin(CacheComponent.GetMeshFilter(weaponSkinList[randomIndex]), CacheComponent.GetMeshRenderer(weaponSkinList[randomIndex]));
    }


    public void ChangePant(Material m)
    {
        pantMeshrendered.material = m;
    }

    public void ChangeHair(MeshFilter meshFilter, MeshRenderer meshRenderer, Vector3 scale, Vector3 pos, float rotX)
    {
        hairMeshFiler.mesh = meshFilter.sharedMesh;
        hairMeshRenderer.materials = meshRenderer.sharedMaterials;
        hairMeshFiler.transform.localScale= scale;
        hairMeshFiler.transform.SetLocalPositionAndRotation(pos, Quaternion.Euler(rotX, 0,0));


     

    }

    public void ChangeLayerOfCamera(string showLayerName, string hideLayerName, string hideLayerName2)
    {
        int showLayerMask = 1 << LayerMask.NameToLayer(showLayerName);
        int hideLayerMask = ~(1 << LayerMask.NameToLayer(hideLayerName));
        int hideLayerMask2 = ~(1 << LayerMask.NameToLayer(hideLayerName2));



        secondCamera.cullingMask = showLayerMask & hideLayerMask & hideLayerMask2;
    }

}
