using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Items : MonoBehaviour
{
    Action<string> _createItemsCallback;
    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
        };

        CreateItems();
    }

    public void CreateItems() {
        string userid = Main.instance.userInfo.UserID;
        StartCoroutine(Main.instance.web.SendItemsID(userid, _createItemsCallback));
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString){
        //Parsing json array string as an array
    //ここでエラー。おそらく現在のSystemではJSONArrayをサポートしていないと思われる。
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray; 
        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone = false;
            string itemID = jsonArray[i].AsObject["itemID"];
            JSONObject itemInfoJson = new JSONObject();

            //Create a callback to get the information from Web.cs
            Action<string> getItemInfoCallback = (itemInfo) => {
                isDone = true;
                JsonArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };
            //Wait until Web.cs calls the callback we passed as parameter
            StartCoroutine(Main.instance.web.GetItem(itemID, getItemInfoCallback));

            //Wait until the callback is called from WEB (info finished downloading)
            yield return new WaitUntil(() =>isDone == true);

            //Instantiate GameObject
            GameObject item = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
            item.transform.SetParent(this.transform);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            //Fill Information
            item.transform.Find("Name").GetComponent<Text>().text = itemInfoJson["name"];
            item.transform.Find("Price").GetComponent<Text>().text = itemInfoJson["price"];
            item.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];

            //continue to the next item
        };
        yield return null;

    }
}
