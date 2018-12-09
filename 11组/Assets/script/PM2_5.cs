using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// PM2.5显示
/// </summary>
public class PM2_5 : MonoBehaviour {
	public static int pm = 0;
    #region 定义的字段属性
    /// <summary>
    /// 显示PM的文本组件
    /// </summary>
    private Text text;

    /// <summary>
    /// 计时器
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// 无连接时显示的内容
    /// </summary>

    #endregion

    #region Unity回调方法
    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
		text.text = pm.ToString();
    }
    #endregion


    void SetValues()
    {
        pm = Random.Range(0, 10);
        text.text = pm.ToString();
    }
}
