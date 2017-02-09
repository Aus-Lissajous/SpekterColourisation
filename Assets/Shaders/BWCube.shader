Shader "BWCube" {
	Properties
	{
		_RColor("RColor scale", Range(-2,2)) = 0.5
		_GColor("GColor scale", Range(-2,2)) = 0.5
		_BColor("BColor scale", Range(-2,2)) = 0.5
	}
		SubShader{
			Pass{
			CGPROGRAM

			#pragma exclude_renderers gles
			#pragma vertex vert 
			#pragma fragment frag 
			float _RColor;
			float _GColor;
			float _BColor;


			struct vertexOutput {
				float4 pos : SV_POSITION;
				float4x4 mat : TEXCOORD0;
				float4 tex : TEXCOORD4;
			};

			vertexOutput vert(float4 vertexPos : POSITION)
			{
				vertexOutput output;

				output.pos = mul(UNITY_MATRIX_MVP, vertexPos);
				output.mat = float4x4(_RColor, _GColor, _BColor, 5.0,
									  _RColor, _GColor, _BColor, 5.0,
									  _RColor, _GColor, _BColor, 5.0,
									  50, 50, -50, -50);
				output.tex = float4(_RColor, _GColor, _BColor, 1000);

				return output;
			}



			float4 frag(vertexOutput input) : COLOR
			{
				return input.mat[1];
			}

				ENDCG
			}
	}
}