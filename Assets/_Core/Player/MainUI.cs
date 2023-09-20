using TMPro;
using UnityEngine;

namespace Core.Player
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] public TMP_Text _playerNameText;
        [SerializeField] public TMP_Text _playerModar;
        [SerializeField] public TMP_Text _playerRam;
        [SerializeField] public TMP_Text _playerWood;
        [SerializeField] public TMP_Text _playerStone;
    }
}