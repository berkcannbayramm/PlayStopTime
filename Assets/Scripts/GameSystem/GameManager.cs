using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBGameStudios.Managers
{
    public class GameManager : MonoBehaviour
    {
        public bool CanClick { get; set; }
        

        private void Awake()
        {
            Application.targetFrameRate = 60;
            BBSystems.instance.MoneyManager.UpdateMoneyText();
        }

        public void WinState()
        {
            BBSystems.instance.PanelManager.AppearPanel(0);
        }

        public void LoseState()
        {
            BBSystems.instance.PanelManager.AppearPanel(1);
        }
    }
}