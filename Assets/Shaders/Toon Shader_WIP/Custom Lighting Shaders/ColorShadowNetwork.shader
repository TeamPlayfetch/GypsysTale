// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-2068-OUT;n:type:ShaderForge.SFN_Blend,id:2068,x:32986,y:32972,varname:node_2068,prsc:2,blmd:10,clmp:True|SRC-7813-OUT,DST-3753-OUT;n:type:ShaderForge.SFN_Lerp,id:7813,x:32774,y:32727,varname:node_7813,prsc:2|A-3293-RGB,B-6185-OUT,T-5372-OUT;n:type:ShaderForge.SFN_Vector4,id:6185,x:32573,y:32769,varname:node_6185,prsc:2,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_OneMinus,id:5372,x:32623,y:32863,varname:node_5372,prsc:2|IN-7790-OUT;n:type:ShaderForge.SFN_Multiply,id:7790,x:32461,y:32863,varname:node_7790,prsc:2|A-9664-OUT,B-4684-OUT;n:type:ShaderForge.SFN_OneMinus,id:9664,x:32273,y:32863,varname:node_9664,prsc:2|IN-5409-OUT;n:type:ShaderForge.SFN_Vector1,id:4684,x:32273,y:32993,varname:node_4684,prsc:2,v1:10;n:type:ShaderForge.SFN_LightAttenuation,id:5409,x:31877,y:33056,varname:node_5409,prsc:2;n:type:ShaderForge.SFN_Color,id:3293,x:31804,y:32567,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_3293,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1985294,c2:0.1903547,c3:0.1561959,c4:1;n:type:ShaderForge.SFN_Color,id:1010,x:32054,y:33186,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,cmnt:Diffuse Color,varname:node_1010,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7293938,c2:0.7573529,c3:0.4677768,c4:1;n:type:ShaderForge.SFN_Blend,id:8430,x:32420,y:33196,varname:node_8430,prsc:2,blmd:10,clmp:True|SRC-1010-RGB,DST-3293-RGB;n:type:ShaderForge.SFN_Multiply,id:3753,x:32737,y:33148,varname:node_3753,prsc:2|A-5409-OUT,B-8430-OUT,C-1685-RGB;n:type:ShaderForge.SFN_LightColor,id:1685,x:32420,y:33373,varname:node_1685,prsc:2;proporder:3293-1010;pass:END;sub:END;*/

Shader "Shader Forge/ColorShadowNetwork" {
    Properties {
        _ShadowColor ("Shadow Color", Color) = (0.1985294,0.1903547,0.1561959,1)
        _DiffuseColor ("Diffuse Color", Color) = (0.7293938,0.7573529,0.4677768,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _ShadowColor;
            uniform float4 _DiffuseColor;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                LIGHTING_COORDS(0,1)
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = saturate(( (attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb) > 0.5 ? (1.0-(1.0-2.0*((attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb)-0.5))*(1.0-lerp(float4(_ShadowColor.rgb,0.0),float4(0.5,0.5,0.5,1),(1.0 - ((1.0 - attenuation)*10.0))))) : (2.0*(attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb)*lerp(float4(_ShadowColor.rgb,0.0),float4(0.5,0.5,0.5,1),(1.0 - ((1.0 - attenuation)*10.0)))) )).rgb;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _ShadowColor;
            uniform float4 _DiffuseColor;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                LIGHTING_COORDS(0,1)
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = saturate(( (attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb) > 0.5 ? (1.0-(1.0-2.0*((attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb)-0.5))*(1.0-lerp(float4(_ShadowColor.rgb,0.0),float4(0.5,0.5,0.5,1),(1.0 - ((1.0 - attenuation)*10.0))))) : (2.0*(attenuation*saturate(( _ShadowColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_ShadowColor.rgb-0.5))*(1.0-_DiffuseColor.rgb)) : (2.0*_ShadowColor.rgb*_DiffuseColor.rgb) ))*_LightColor0.rgb)*lerp(float4(_ShadowColor.rgb,0.0),float4(0.5,0.5,0.5,1),(1.0 - ((1.0 - attenuation)*10.0)))) )).rgb;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
