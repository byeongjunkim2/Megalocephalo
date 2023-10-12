Shader "Unlit/ToonShader"
{
    Properties
    {
        _ColorA("Color A", Color) = (1, 1, 1, 1)
        _ColorB("Color B", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                half3 normal : NORMAL;
            };

            float4 _MainTex_ST;
            fixed4 _ColorA, _ColorB;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed3 aces(fixed3 x) {
                const fixed a = 2.51;
                const fixed b = 0.03;
                const fixed c = 2.43;
                const fixed d = 0.59;
                const fixed e = 0.14;
                return clamp((x * (a * x + b)) / (x * (c * x + d) + e), 0.0, 1.0);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float dot = clamp(i.normal.y, 0.0f, 1.0f)/2.0 + clamp(sign(i.normal.y), 0.0f, 1.0f)/2.0;
                fixed4 color = _ColorA*(dot) + _ColorB*(1.0 - dot);
                return color;
            }
            ENDCG
        }
    }
}
