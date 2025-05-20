using System;
using System.Collections.Generic;
using UnityEngine;

namespace TFG.UIElements.Buttons.TabSystems
{
    public class TabGroupSide : MonoBehaviour
    {
        public TabButtonSide[] tabs;
        public TabButtonSide selectedTab;

        public Sprite tabIdle;
        public Sprite tabHover;
        public Sprite tabActive;

        public List<GameObject> pages;

        public void OnTabEnter(TabButtonSide button)
        {
            ResetTabs();

            if (button != selectedTab)
                button.Background.sprite = tabHover;
        }

        public void OnTabExit()
        {
            ResetTabs();
        }

        public void OnTabSelected(TabButtonSide button)
        {
            selectedTab = button;
            button.Background.sprite = tabActive;

            ResetTabs();

            for (int i = 0; i < pages.Count; i++)
                if (i == Array.IndexOf(tabs, button))
                    pages[i].SetActive(true);
        }

        private void ResetTabs()
        {
            foreach (TabButtonSide button in tabs)
                button.Background.sprite = tabIdle;
        }
    }
}