using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TabGroup : MonoBehaviour
{
    public TabButtonC[] leftTabs;
    public TabButtonC[] rightTabs;
    public int selectedTabIndex;
    private int _totalTabs;
    
    public Sprite tabIdleL;
    public Sprite tabIdleR;
    public Sprite tabHoverL;
    public Sprite tabHoverR;
    public Sprite tabActiveL;
    public Sprite tabActiveR;
    
    public List<GameObject> pages;

    public void Awake()
    {
        _totalTabs = leftTabs.Length;
    }
    
    public void OnTabEnter(TabButtonC button)
    {
        ResetTabs();
        
        if (button.rightTab && Array.IndexOf(rightTabs, button) != selectedTabIndex)
            button.Background.sprite = tabHoverR;
        
        else if (!button.rightTab)
            button.Background.sprite = tabHoverL;
    }
    
    public void OnTabExit()
    {
        ResetTabs();
    }   
    
    public void OnTabSelected(TabButtonC button)
    {
        if (button.rightTab)
            selectedTabIndex = Array.IndexOf(rightTabs, button);
        
        else
            selectedTabIndex = _totalTabs - Array.IndexOf(rightTabs, button);
        
        rightTabs[selectedTabIndex].Background.sprite = tabActiveR;
        ResetTabs();
        
        for (int i = 0; i < pages.Count; i++)
            if (i == selectedTabIndex)
                pages[i].SetActive(true);
    }

    private void ResetTabs()
    {
        for (int i = 0; i < selectedTabIndex; i++)
        {
            rightTabs[i].gameObject.SetActive(false);
            leftTabs[_totalTabs - i].gameObject.SetActive(true);
            leftTabs[_totalTabs - i].Background.sprite = tabIdleL;
        }

        if (selectedTabIndex <= 0) return;
        leftTabs[_totalTabs - selectedTabIndex].gameObject.SetActive(false);

        for (int i = selectedTabIndex + 1; i < _totalTabs; selectedTabIndex++)
        {
            rightTabs[i].gameObject.SetActive(true);
            rightTabs[i].Background.sprite = tabIdleR;
            leftTabs[_totalTabs - i].gameObject.SetActive(false); 
        }
    }
}
