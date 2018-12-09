using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 温度显示
/// </summary>
public class AIR_TEMPERATURE : MonoBehaviour {
	public static int temperature = 0;
    #region 定义的字段属性
    /// <summary>
    /// 显示温度的文本组件
    /// </summary>
    private Text text;

    /// <summary>
    /// 定义一个计时器
    /// </summary>

    /// <summary>
    /// 无连接的时候显示的内容
    /// </summary>
    
    #endregion

    #region Unity回调方法
    private void Start()
    {
        // 初始化文本组件
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
		text.text = temperature.ToString ();
		//Debug.Log ("1");
    }
    #endregion

    #region 方法
    /// <summary>
    /// 无连接，显示虚拟数据的方法
    /// </summary>
    void SetValues()
    {
        temperature = Random.Range(5, 25);
        text.text = temperature.ToString();
    }
    #endregion
}
