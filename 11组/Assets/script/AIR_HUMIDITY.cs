using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 湿度显示
/// </summary>
public class AIR_HUMIDITY : MonoBehaviour {
	
    #region 字段属性
    /// <summary>
    /// 湿度显示的文本框
    /// </summary>
    private Text text;

    /// <summary>
    /// 定义一个计时器
    /// </summary>
    //float timer = 0f;

    /// <summary>
    /// 文本框显示的数值定义
    /// </summary>
	public static int humidity = 0;
    #endregion

    #region Unity回调
    /// <summary>
    /// 初始化文本框
    /// </summary>
    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    private void Update()
    {

        //timer += Time.deltaTime;
		text.text = humidity.ToString ();
    }
    #endregion

    #region 方法
    // 无连接时随机显示数据
    void SetValues()
    {
        humidity = Random.Range(5, 25);
        text.text = humidity.ToString();
		Debug.Log(text.text);

    }
    #endregion
}
