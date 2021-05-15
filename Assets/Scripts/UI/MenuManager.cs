using System.Linq;
using UnityEngine;
using Zone.Core.Utils;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private Menu[] menus;
    private void Start()
    {
        if (menus.Length == 0) 
        {
            menus = GetComponentsInChildren<Menu>();
        }
    }

    public void OpenMenu(string name)
    {
        var query = menus.Where(item => item.Name == name).ToArray().First();
        OpenMenu(query);
    }
    public void CloseMenu(string name)
    {
        var query = menus.Where(item => item.Name == name).ToArray().First();
        CloseMenu(query);
    }
    
    private void OpenMenu(Menu menu) => menu.Open();

    private void CloseMenu(Menu menu) => menu.Close();



}