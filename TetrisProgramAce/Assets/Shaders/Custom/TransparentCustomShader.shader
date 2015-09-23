Shader "Custom/TransparentCustomShader"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags {"Queue" = "Transparent"}
		Pass
		{
			Material
			{
				Diffuse [_Color]
			}
		Lighting On
		Blend SrcAlpha OneMinusSrcAlpha
		}
	}
	FallBack "Diffuse"
}
