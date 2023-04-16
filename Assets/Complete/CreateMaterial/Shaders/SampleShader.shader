Shader "Custom/SampleShader"
{
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }

		Blend SrcAlpha OneMinusSrcAlpha
		Cull Back

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float4 worldPos : WORLD_POS;
				float3 normal : NORMAL;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.normal = mul(unity_ObjectToWorld, v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float intensity = 1 - abs(dot(normalize(_WorldSpaceCameraPos - i.worldPos), i.normal));
				float4 col = float4(0, 0, 1, intensity);
                return col;
            }
            ENDCG
        }
    }
}
