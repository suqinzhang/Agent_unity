
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Selector : MonoBehaviour, Handle
{
    public static Selector instance;
    string Prompt = "你是选择器，帮我选择下一个agent";
    string source = "Selector";
    public static int flag = 0;     //0这个群聊停止，1启动选择，2，agent工作
    string next = "";
    public Text text;
    float r = 158f / 255f;
    float g = 122f / 255f;
    float b = 192f / 255f;
 
    void Start()
    {
        instance = this;

    }

    void Update()
    {
        
        if (flag == 2)
        {
            flag = 0;
            
            _ = Handle_msg();
            
        }
        if (flag == 1)
        {
            flag = 0;
            if (Msg_Context.dic.ContainsKey(next))
            {
                _ = Msg_Context.dic[next].Handle_msg();
                
            }
            else
            {
                Debug.Log("没有这个agent");
            }
            
        }

    }

    public async Task Handle_msg()
    {
       Image color= GetComponent<Image>();
        color.color = new Color(r, g, b);
        flag = 0;
        Msg_Context.ctx.Add(new Text_msg { source = "user", content = Prompt });
        string _send_msg = JsonConvert.SerializeObject( Msg_Context.ctx);
        var response = await RequestHelper.Send( _send_msg);
        var select = JsonUtility.FromJson<Select_Msg>(response);
        if (!select.stop)
        {
            text.text = $"下一个发言的Agent是{select.next}";
            next = select.next;
        }
        else
        {
            text.text = $"所有Agent都发言完毕，选择器停止工作";
            test.flag = 1;
        }
        
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });
        color.color = new Color(1, 1, 1);

        await Task.Delay(3000);
        flag = select.stop ?  0 : 1;
     
        
    }
}


public class Select_Msg
{
    public string next;
    public bool stop;
}