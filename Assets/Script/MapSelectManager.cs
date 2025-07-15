using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelectManager : MonoBehaviour
{
    public Button crystalCaveButton;
    public Button snowfieldButton;
    public Button desertButton;
    public Button confirmButton;

    private string selectedMap = "";

    void Start()
    {
        confirmButton.interactable = false;

        crystalCaveButton.onClick.AddListener(() => SelectMap("CrystalCave"));
        snowfieldButton.onClick.AddListener(() => SelectMap("Snowfield"));
        desertButton.onClick.AddListener(() => SelectMap("Desert"));
        confirmButton.onClick.AddListener(LoadSelectedMap);
    }

    void SelectMap(string mapName)
    {
        selectedMap = mapName;
        confirmButton.interactable = true;
        Debug.Log("Selected map: " + mapName);
    }

    void LoadSelectedMap()
    {
        if (selectedMap == "CrystalCave")
            SceneManager.LoadScene("CrystalCave");
        else if (selectedMap == "Snowfield")
            SceneManager.LoadScene("Snowfield");
        else if (selectedMap == "Desert")
            SceneManager.LoadScene("Desert");
        else
            Debug.LogWarning("No map selected!");
    }
}
