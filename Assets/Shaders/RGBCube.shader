Shader "RGBCube" {
	Properties
	{
		_RColor("RColor scale", Range(-2,2)) = 0.5
		_GColor("GColor scale", Range(-2,2)) = 0.5
		_BColor("BColor scale", Range(-2,2)) = 0.5
	}

		SubShader{
		Pass{
		CGPROGRAM

	#pragma vertex vert 
	#pragma fragment frag 
	float _RColor;
	float _GColor;
	float _BColor;

	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 col : TEXCOORD0;
	};

	vertexOutput vert(float4 vertexPos : POSITION)

	{
		vertexOutput output;
		output.pos = mul(UNITY_MATRIX_MVP, vertexPos);
		output.col = vertexPos + float4(_RColor, _GColor, _BColor, 0.0);
		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		return input.col;
	}
		ENDCG
	}
	}
}