// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33177,y:32696,varname:node_9361,prsc:2|custl-7011-OUT;n:type:ShaderForge.SFN_Multiply,id:7011,x:32946,y:32935,varname:node_7011,prsc:2|A-2659-OUT,B-6218-RGB,C-562-OUT;n:type:ShaderForge.SFN_Multiply,id:2659,x:32723,y:32935,varname:node_2659,prsc:2|A-4784-OUT,B-964-RGB;n:type:ShaderForge.SFN_LightColor,id:6218,x:32723,y:33079,varname:node_6218,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:562,x:32723,y:33215,varname:node_562,prsc:2;n:type:ShaderForge.SFN_Color,id:964,x:32482,y:33121,ptovrint:False,ptlb:Diff Color,ptin:_DiffColor,varname:node_964,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1074827,c2:0.5220588,c3:0.4705943,c4:1;n:type:ShaderForge.SFN_Power,id:4784,x:32501,y:32935,varname:node_4784,prsc:2|VAL-4858-OUT,EXP-7989-OUT;n:type:ShaderForge.SFN_Add,id:4858,x:32300,y:32935,varname:node_4858,prsc:2|A-720-OUT,B-4364-OUT;n:type:ShaderForge.SFN_Multiply,id:720,x:32105,y:32935,varname:node_720,prsc:2|A-8835-OUT,B-4364-OUT;n:type:ShaderForge.SFN_Dot,id:8835,x:31895,y:32935,varname:node_8835,prsc:2,dt:1|A-6833-OUT,B-8938-OUT;n:type:ShaderForge.SFN_LightVector,id:6833,x:31658,y:32935,varname:node_6833,prsc:2;n:type:ShaderForge.SFN_ViewVector,id:8938,x:31658,y:33084,varname:node_8938,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4364,x:32012,y:33131,varname:node_4364,prsc:2,v1:0.6;n:type:ShaderForge.SFN_ValueProperty,id:7989,x:32251,y:33165,ptovrint:False,ptlb:brightness,ptin:_brightness,varname:node_7989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:964-7989;pass:END;sub:END;*/

Shader "Shader Forge/CustomToonLighting" {
    Properties {
        _DiffColor ("Diff Color", Color) = (0.1074827,0.5220588,0.4705943,1)
        _brightness ("brightness", Float ) = 0.5
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
            uniform float4 _DiffColor;
            uniform float _brightness;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                LIGHTING_COORDS(1,2)
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_4364 = 0.6;
                float3 finalColor = ((pow(((max(0,dot(lightDirection,viewDirection))*node_4364)+node_4364),_brightness)*_DiffColor.rgb)*_LightColor0.rgb*attenuation);
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
            uniform float4 _DiffColor;
            uniform float _brightness;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                LIGHTING_COORDS(1,2)
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_4364 = 0.6;
                float3 finalColor = ((pow(((max(0,dot(lightDirection,viewDirection))*node_4364)+node_4364),_brightness)*_DiffColor.rgb)*_LightColor0.rgb*attenuation);
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
