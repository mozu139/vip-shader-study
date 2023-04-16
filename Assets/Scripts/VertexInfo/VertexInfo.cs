using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using VipShaderStudy;

namespace VipShaderStudy.VertexInfo
{
    public class VertexInfo : MonoBehaviour
    {
        [SerializeField] MeshFilter mf;

        void Start()
        {
            // メッシュの各頂点位置を表示
            var positionList = mf.mesh.vertices;
            Common.Logger.Log(positionList, "頂点位置");

            // メッシュの各頂点法線を表示
            var normalList = mf.mesh.normals;
            Common.Logger.Log(normalList, "頂点法線");

            // メッシュの各頂点UVを表示
            var uvList = mf.mesh.uv;
            Common.Logger.Log(uvList, "頂点UV");

            // メッシュ内の三角形を構成する頂点の番号を表示
            var triangles = mf.mesh.triangles;
            Common.Logger.Log(triangles, "三角形を構成する頂点の番号");
        }
    }
}
