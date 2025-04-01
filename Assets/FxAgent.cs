using System.Threading.Tasks;
using UnityEngine;

public class FxAgent : MonoBehaviour, Handle
{
    string Prompt = "你是风险分析师，帮我分析交易的风险";
    string source = "FxAgent";


    void Start()
    {
        Msg_Context.dic.Add(source, this);


    }
    public async Task Handle_msg()
    {
        string send_msg = JsonUtility.ToJson(Msg_Context.ctx);
        var response = await RequestHelper.Send(send_msg, Prompt);
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });

    }


}