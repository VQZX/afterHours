// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "GUI_Flusk/Text Shader" {
    Properties {
        _MainTex ("Font Texture", 2D) = "white" {}
        _Color ("Text Color", Color) = (1,1,1,1)
        _Blur ("Blur Amount", Range(0,0.5) ) = 0
    }

    SubShader {

        Tags {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
        }
        Lighting Off Cull Off ZTest Always ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            uniform fixed4 _Color;
            half _Blur;

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color * _Color;
                o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = i.color;
                col.a *= tex2D(_MainTex, i.uv).a;
                
                col += tex2D(_MainTex, float2(i.uv.x - 5.0 * _Blur, i.uv.y)) * 0.025;
                col += tex2D(_MainTex, float2(i.uv.x - 4.0 * _Blur, i.uv.y)) * 0.05;
                col += tex2D(_MainTex, float2(i.uv.x - 3.0 * _Blur, i.uv.y)) * 0.09;
                col += tex2D(_MainTex, float2(i.uv.x - 2.0 * _Blur, i.uv.y)) * 0.12;
                col += tex2D(_MainTex, float2(i.uv.x - _Blur, i.uv.y)) * 0.15;
                col += tex2D(_MainTex, float2(i.uv.x, i.uv.y)) * 0.16;
                col += tex2D(_MainTex, float2(i.uv.x + _Blur, i.uv.y)) * 0.15;
                col += tex2D(_MainTex, float2(i.uv.x + 2.0 * _Blur, i.uv.y)) * 0.12;
                col += tex2D(_MainTex, float2(i.uv.x + 3.0 * _Blur, i.uv.y)) * 0.09;
                col += tex2D(_MainTex, float2(i.uv.x + 4.0 * _Blur, i.uv.y)) * 0.05;
                col += tex2D(_MainTex, float2(i.uv.x + 5.0 * _Blur, i.uv.y)) * 0.025;
                
                return col;
            }
            ENDCG
        }  
    }
}
