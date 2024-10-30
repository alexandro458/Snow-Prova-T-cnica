Shader "Custom/WhiteShader"
{
    Properties
    {
        // No necesitamos ninguna propiedad para este shader b�sico
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

            // Funci�n de v�rtice
            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            // Funci�n de fragmento (devuelve color blanco)
            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(1.0, 1.0, 1.0, 1.0); // Color blanco RGBA
            }
            ENDCG
        }
    }
}
