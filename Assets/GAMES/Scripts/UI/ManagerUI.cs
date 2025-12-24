using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private DungeonGenerator _dungeonGenerator;
    [SerializeField] private Slider _nbRoomsSlider;
    [SerializeField] private Slider _nbEnemiesSlider;
    [SerializeField] private Slider _nbCoinsSlider;
    [SerializeField] private Slider _seedSlider;

    [SerializeField] private TMP_Text _nbRoomsText;
    [SerializeField] private TMP_Text _nbEnemiesText;
    [SerializeField] private TMP_Text _nbCoinsText;
    [SerializeField] private TMP_Text _seedText;

    private void Start()
    {
        if (_dungeonGenerator == null)
        {
            Debug.LogError("DungeonGenerator reference is not set in ManagerUI.");
        }
        _nbRoomsSlider.value = _dungeonGenerator.nbRooms;
        _nbEnemiesSlider.value = _dungeonGenerator.nbEnemies;
        _nbCoinsSlider.value = _dungeonGenerator.nbCoins;
        _seedSlider.value = _dungeonGenerator.seed;

        UpdateUIText();
    }

    public void SetNbRooms(float nbRooms)
    {
        _dungeonGenerator.nbRooms = (int)nbRooms;
        UpdateUIText();
    }
    public void SetNbEnemies(float nbEnemies)
    {
        _dungeonGenerator.nbEnemies = (int)nbEnemies;
        UpdateUIText();
    }
    public void SetNbCoins(float nbCoins)
    {
        _dungeonGenerator.nbCoins = (int)nbCoins;
        UpdateUIText(); 
    }

    public void SetSeed(float seed)
    {
        _dungeonGenerator.seed = (int)seed;
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        _nbRoomsText.text =  _dungeonGenerator.nbRooms.ToString();
        _nbEnemiesText.text =  _dungeonGenerator.nbEnemies.ToString();
        _nbCoinsText.text =  _dungeonGenerator.nbCoins.ToString();
        _seedText.text =  _dungeonGenerator.seed.ToString();
    }
}
