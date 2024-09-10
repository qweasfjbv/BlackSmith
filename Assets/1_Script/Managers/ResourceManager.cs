using UnityEngine;


// TODO : Define needed Info classes and appropriate json file
// Especially, Item must be able to "Crafting" -> Include "Ingredients" array 
// Resource and Facility can refer to its' Monobehaviour classes (Base)

public class ResourceInfos
{
    public ResourceInfo[] resources;
}

public class ResourceInfo { }

public class FacilityInfos
{
    public FacilityInfo[] facilities;
}

public class FacilityInfo { }

public class ItemInfos
{
    public ItemInfo[] items;
}

public class ItemInfo { }


public class ResourceManager
{
    /** Paths (Start from Assets/Resources) **/
    private string resourceInfoPath = "JsonData/ResourceData";
    private string facilityInfoPath = "JsonData/FacilityData";
    private string itemInfoPath = "JsonData/ItemData";

    /** Infos **/
    private ResourceInfos resourceInfos = new ResourceInfos();
    private FacilityInfos facilityInfos = new FacilityInfos();
    private ItemInfos itemInfos = new ItemInfos();
    
    public void Init()
    {
        resourceInfos = JsonUtility.FromJson<ResourceInfos>(Resources.Load<TextAsset>(resourceInfoPath).text);
        facilityInfos = JsonUtility.FromJson<FacilityInfos>(Resources.Load<TextAsset>(facilityInfoPath).text);
        itemInfos = JsonUtility.FromJson<ItemInfos>(Resources.Load<TextAsset>(itemInfoPath).text);
    }

    #region Resource Getters
    public ResourceInfo GetResourceInfo(int id)
    {
        return resourceInfos.resources[id];
    }

    public FacilityInfo GetFacilityInfo(int id)
    {
        return facilityInfos.facilities[id];
    }

    public ItemInfo GetItemInfoRef(int id)
    {
        return itemInfos.items[id];
    }

    #endregion


}
