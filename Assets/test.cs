
using System.Threading.Tasks;
using UnityEngine;

public class test : MonoBehaviour
{
    bool flag = true;
    // Start is called before the first frame update
    async void Start()
    {
        // Msg_Context.ctx.Add(new Text_msg { source = "�ϰ�", content = "���ҷ������ڹ��У������Ͷ��" });
        // Selector.flag = 2;
      string msg= await RequestHelper.Send("���ݽ����������ô��", "");
        Debug.Log(msg);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
