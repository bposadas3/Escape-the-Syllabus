using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{

	// Drag & Drop the vertical layout group here
	public VerticalLayoutGroup verticalLayoutGroup ;
	public GameObject gameManager;

	//TEMPORARY LIST
	private List<string> stringList;

    // Start is called before the first frame update
    void Start()
    {
		stringList.Add ("Butthole");
    }

    // Update is called once per frame
    void Update()
    {
		// ... In your function
		RectTransform parent = verticalLayoutGroup.GetComponent<RectTransform>() ;
		for( int index = 0 ; index < 1 ; index++ )
		{
			GameObject g = new GameObject( stringList[index] ) ;
			UnityEngine.UI.Text t = g.AddComponent<UnityEngine.UI.Text>();
			g.AddComponent<RectTransform>().SetParent( parent ) ;
			t.text = stringList[index] ;
		}
    }
}
