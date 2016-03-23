using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public GameObject itemPrefab;
	public GameObject myItemPrefab;
    public int itemCount = 10, columnCount = 1;
	[HideInInspector]public int id;
	bool internetCheck;
	public Font customFont;

	void OnGUI ()
	{
		
					if (internetCheck == false) {
						GUI.skin.label.normal.textColor = Color.red;
						GUI.skin.label.fontSize = 30;
						GUI.skin.label.alignment = TextAnchor.MiddleCenter;
						GUI.skin.label.font = customFont;
			GUI.Label (new Rect (Screen.width / 2f -  Screen.width / 8, Screen.height / 2f, Screen.width / 4, Screen.height / 8), "No Data Available");
					}

	}

    void Start()
    {

		int error = PlayerPrefs.GetInt("leaderBoardDataNull");
		if (error == 1) {
			internetCheck = false;
		} else {
			internetCheck = true;
        RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

        //calculate the width and height of each child item.
        float width = containerRectTransform.rect.width / columnCount;
        float ratio = width / rowRectTransform.rect.width;
        float height = rowRectTransform.rect.height * ratio;
        int rowCount = itemCount / columnCount;
        if (itemCount % rowCount > 0)
            rowCount++;

        //adjust the height of the container so that it will just barely fit all its children
        float scrollHeight = height * rowCount;
        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);
		containerRectTransform.localPosition = new Vector2(0, -scrollHeight/2);
        int j = 0;
		for (int k= 0; k<SocketMain.useridArray.Count; k++)
		{
			string s = SocketMain.useridArray[k].ToString();
			s=s.Replace("\"",string.Empty).Trim();
			if(s.Equals(SocketMain.userId)){
				id = 1;
			}
		}
		itemCount = SocketMain.nameArray.Count;
        for (int i = 0; i < itemCount; i++)
        {
            //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
            if (i % columnCount == 0)
                j++;

            //create a new item, name it, and set the parent
//            GameObject newItem = Instantiate(itemPrefab) as GameObject;
			GameObject newItem;
			if(id == 1){
				newItem = Instantiate(myItemPrefab) as GameObject;
				id = 0;
			} else {
				newItem = Instantiate(itemPrefab) as GameObject;
			}
            newItem.name = gameObject.name + " item at (" + i + "," + j + ")";
            newItem.transform.parent = gameObject.transform;
			Text name = newItem.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
			Text score = newItem.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
			Text rank = newItem.transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
//			Debug.Log ("SocketMain.nameArray.Count" + SocketMain.nameArray[i].ToString());
			string lbname = SocketMain.nameArray[i].ToString();	
			lbname=lbname.Replace("\"",string.Empty).Trim();
//			name.text = SocketMain.nameArray[i].ToString();
			name.text = lbname;
//			name.text = "swetha " + i;

			string lbScore = SocketMain.scoreArray[i].ToString();	
			lbScore=lbScore.Replace("\"",string.Empty).Trim();
			score.text = lbScore;

			string lbRank = SocketMain.rankArray[i].ToString();	
			lbRank=lbRank.Replace("\"",string.Empty).Trim();
			rank.text = lbRank;

            //move and size the new item
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();

            float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
            float y = containerRectTransform.rect.height / 2 - height * j;
            rectTransform.offsetMin = new Vector2(x, y);

            x = rectTransform.offsetMin.x + width;
            y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);
			}
        }
    }

}
