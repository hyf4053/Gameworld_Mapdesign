using UnityEngine;

//六边形的静态类 方便访问

public static class HexMetrics {
    /*
     * 定义六边形的外径和内径 外径为10 内径为sqrt(3)/ 2
     */
    public const float outerRadius = 10f; 
    public const float innerRadius = outerRadius * 0.866025404f;

    /*
     * 定义六边形的方向，以角向上放置六边形
     * 定义六边形的六个角（以六边形最上的点为中心点，顺时针方向添加点坐标）
     */
    public static Vector3[] corners = {
        new Vector3(0f,0f,outerRadius),
        new Vector3(innerRadius,0f,0.5f*outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };

}