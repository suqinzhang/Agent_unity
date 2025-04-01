
using System.Threading.Tasks;
using UnityEngine;

public class test : MonoBehaviour
{
    bool flag = true;
    // Start is called before the first frame update
    async void Start()
    {
        // Msg_Context.ctx.Add(new Text_msg { source = "老板", content = "帮我分析近期股市，和相关投资" });
        // Selector.flag = 2;
      string msg= await RequestHelper.Send("杭州今天的天气怎么样", "");
        Debug.Log(msg);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
