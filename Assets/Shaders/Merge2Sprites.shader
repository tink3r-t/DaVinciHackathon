Shader "2D/TransfromEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_SecondTex("Second Texture", 2D) = "black" {}
		_Color("Color", Color) = (1,1,1,1)
		_Tween("Tween", Range(-0.5,1.5)) = 0
	}
		SubShader
	{
	Tags { "RenderType" = "Transparent" }

	Pass
	{
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		#include "UnityCG.cginc"

		struct appdata
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
		};

		struct v2f
		{
			float2 uv : TEXCOORD0;
			float4 vertex : SV_POSITION;
		};

		sampler2D _MainTex;
		sampler2D _SecondTex;
		float4 _MainTex_ST;
		fixed4 _Color;
		fixed _Tween;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}

		float4 frag(v2f i) : SV_Target
		{
		float t = smoothstep(_Tween,_Tween + 0.1f,i.uv.y);
		return tex2D(_MainTex, i.uv) * (t)+tex2D(_SecondTex, i.uv) * (1 - t);
		float4 col;
		}
		ENDCG
		}
	}
}

