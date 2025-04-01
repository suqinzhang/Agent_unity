using System.Threading.Tasks;
using UnityEngine;

public class SearchAgent : MonoBehaviour, Handle
{
    string Prompt = "帮我锁定几只潜力股";
    string source = "SearchAgent";

    void Start()
    {
        Msg_Context.dic.Add(source, Handle_msg);


    }
    public async Task Handle_msg()
    {
        string send_msg = JsonUtility.ToJson(Msg_Context.ctx);
        var response = await RequestHelper.Send(send_msg, Prompt);
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });

    }


}