using UnityEngine;
using UnityEditor;


public class MyWindow : EditorWindow
{

	// Add menu item to the Window menu
	[MenuItem("Window/My Window")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		EditorWindow.GetWindow(typeof(MyWindow),false, "My Window");
	}

	// Implement your own editor GUI here.
	void OnGUI()
	{
		Event evt = Event.current;
		//ウインドウ内どこをクリックしてもコンテキストメニューを表示
		Rect contextRect = new Rect(0, 0, Screen.width, Screen.height);

		if (evt.type == EventType.ContextClick)
		{
			Vector2 mousePos = evt.mousePosition;
			if (contextRect.Contains(mousePos))
			{
				// Now create the menu, add items and show it
				GenericMenu menu = new GenericMenu();

				menu.AddItem(new GUIContent("MenuItem1"), false, Callback, "item 1");
				menu.AddItem(new GUIContent("MenuItem2"), false, Callback, "item 2");
				menu.AddSeparator("");
				menu.AddItem(new GUIContent("SubMenu/MenuItem3"), false, Callback, "item 3");

				menu.ShowAsContext();

				evt.Use();
			}
		}
	}

	void Callback(object obj)
	{
		Debug.Log("Selected: " + obj);
	}
}