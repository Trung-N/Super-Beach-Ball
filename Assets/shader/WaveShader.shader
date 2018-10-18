Shader "WaveShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Ambient ("Ambient intensity", Range(0., 0.5)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "LightMode"="ForwardBase" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : NORMAL;
            };

            float LightToonShading(float3 normal, float3 lightDir)
            {
                float NdotL = dot(normalize(normal), normalize(lightDir));
                if (NdotL < 0.8f){
                  NdotL = 0.8f;
                }
                return NdotL;
            }

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata_full v)
            {
								float k = 2 * UNITY_PI/ 3;
								float f = k * (v.vertex.x - 1 * _Time.y);
								float4 displacement = float4(2.5*cos(f), 0, 0.0f, 0.0f);
								v.vertex.y = 2.5*sin(f);

                float3 tangent = normalize(float3(
                  1 - k * 2.5 * sin(f),
                  k * 2.5 * cos(f),
                  0
                ));
                float3 normal = float3(-tangent.y, tangent.x, 0);

                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex) + displacement;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.worldNormal = normal;


                return o;
            }

            fixed4 _LightColor0;
            half _Ambient;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = col.rgb* LightToonShading(i.worldNormal, _WorldSpaceLightPos0.xyz)* _LightColor0.rgb + _Ambient;
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
