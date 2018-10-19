Shader "CelShader"
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

            float Shading(float3 normal, float3 lightDir)
            {
                float NdotL = dot(normalize(normal), normalize(lightDir));
                if (NdotL < 0.1f){
                  NdotL = 0.1f;
                }
                else if (NdotL < 0.2f){
                  NdotL = 0.2f;
                }
                else if (NdotL < 0.4f){
                  NdotL = 0.4f;
                }
                else if (NdotL < 0.6f){
                  NdotL = 0.6f;
                }
                else if (NdotL < 0.8f){
                  NdotL = 0.8f;
                }
                else {
                  NdotL = 1.0f;
                }
                return NdotL;
            }

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.worldNormal = mul(v.normal.xyz, (float3x3) unity_WorldToObject);
                return o;
            }

            fixed4 _LightColor0;
            half _Ambient;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = col.rgb* Shading(i.worldNormal, _WorldSpaceLightPos0.xyz)* _LightColor0.rgb + _Ambient;
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
