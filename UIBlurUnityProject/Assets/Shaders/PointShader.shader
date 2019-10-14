Shader "Lexdev/Basic/UnlitPoint"
{
	Properties
	{
		_Color("Color", COLOR) = (1,1,1,1)
		_Size("Size", float) = 1.0
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off

		Pass
		{
			HLSLPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma geometry geom

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2g
			{
				float4 vertex : SV_POSITION;
			};

			struct g2f
			{
				float4 vertex : SV_POSITION;
			};

			float4 _Color;
			float _Size;

			v2g vert(appdata v)
			{
				v2g o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			[maxvertexcount(4)]
			void geom(point v2g p[1], inout TriangleStream<g2f> triStream)
			{
				float SizeY = _Size * _ScreenParams.x / _ScreenParams.y;

				g2f vert;

				vert.vertex = p[0].vertex + float4(_Size, SizeY, 0, 0);
				triStream.Append(vert);

				vert.vertex = p[0].vertex + float4(-_Size, SizeY, 0, 0);
				triStream.Append(vert);

				vert.vertex = p[0].vertex + float4(_Size, -SizeY, 0, 0);
				triStream.Append(vert);

				vert.vertex = p[0].vertex + float4(-_Size, -SizeY, 0, 0);
				triStream.Append(vert);
			}

			fixed4 frag(g2f i) : SV_Target
			{
				return _Color;
			}

			ENDHLSL
		}
	}
}