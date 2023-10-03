using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ViewComponent;

namespace LoginModule
{
    public class LoggedInView : ViewCore
    {
        [SerializeField] private Button loggedInViewPanel;
        [SerializeField] private Button logOutButton;

        public void Init()
        {
        }

        public void SetListener(Action logOut, Action onLoggedInViewPanelClick)
        {
            logOutButton.onClick.AddListener(() => { logOut(); });
            loggedInViewPanel.onClick.AddListener(() => { onLoggedInViewPanelClick(); });
        }
    }
}