// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-507-OUT,spec-163-OUT,gloss-3048-OUT,alpha-2190-OUT;n:type:ShaderForge.SFN_Color,id:914,x:31049,y:31854,ptovrint:False,ptlb:ColorA,ptin:_ColorA,varname:node_914,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:7357,x:31049,y:32030,ptovrint:False,ptlb:ColorB,ptin:_ColorB,varname:node_7357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:4123,x:31261,y:32115,varname:node_4123,prsc:2|A-914-RGB,B-7357-RGB,T-3738-OUT;n:type:ShaderForge.SFN_Vector1,id:163,x:32315,y:32628,varname:node_163,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3048,x:32315,y:32701,varname:node_3048,prsc:2,v1:0;n:type:ShaderForge.SFN_DepthBlend,id:9946,x:30633,y:32802,varname:node_9946,prsc:2|DIST-325-OUT;n:type:ShaderForge.SFN_ValueProperty,id:325,x:30389,y:32802,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_325,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_ViewVector,id:4463,x:30364,y:32958,varname:node_4463,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:6625,x:30364,y:33098,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8711,x:30621,y:33011,varname:node_8711,prsc:2,dt:0|A-4463-OUT,B-6625-OUT;n:type:ShaderForge.SFN_Divide,id:1019,x:30869,y:32992,varname:node_1019,prsc:2|A-9946-OUT,B-8711-OUT;n:type:ShaderForge.SFN_Clamp01,id:3738,x:31047,y:32992,varname:node_3738,prsc:2|IN-1019-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5243,x:31161,y:32772,varname:node_5243,prsc:2|IN-3738-OUT,IMIN-4925-OUT,IMAX-9944-OUT,OMIN-2716-OUT,OMAX-4278-OUT;n:type:ShaderForge.SFN_Vector1,id:4278,x:30889,y:32822,varname:node_4278,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2716,x:30889,y:32766,varname:node_2716,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:9944,x:30704,y:32675,ptovrint:False,ptlb:FoamMax,ptin:_FoamMax,varname:node_9944,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:4925,x:30704,y:32588,ptovrint:False,ptlb:FoamMin,ptin:_FoamMin,varname:node_4925,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1739,x:31536,y:33305,varname:node_1739,prsc:2|IN-3738-OUT,IMIN-8450-OUT,IMAX-5968-OUT,OMIN-426-OUT,OMAX-2150-OUT;n:type:ShaderForge.SFN_Slider,id:8450,x:31021,y:33301,ptovrint:False,ptlb:DepthMin,ptin:_DepthMin,varname:node_8450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:5968,x:31021,y:33404,ptovrint:False,ptlb:DepthMax,ptin:_DepthMax,varname:node_5968,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:426,x:31178,y:33505,varname:node_426,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2150,x:31178,y:33569,varname:node_2150,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:6476,x:31912,y:32662,varname:node_6476,prsc:2|IN-244-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2035,x:32109,y:32701,varname:node_2035,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6476-OUT;n:type:ShaderForge.SFN_Multiply,id:865,x:32188,y:32877,varname:node_865,prsc:2|A-2035-OUT,B-766-OUT;n:type:ShaderForge.SFN_Vector1,id:766,x:31982,y:32901,varname:node_766,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:2190,x:32537,y:32971,varname:node_2190,prsc:2|IN-3150-OUT;n:type:ShaderForge.SFN_Multiply,id:9008,x:31584,y:32548,varname:node_9008,prsc:2|A-7878-OUT,B-4736-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4736,x:31243,y:32645,ptovrint:False,ptlb:FoamPower,ptin:_FoamPower,varname:node_4736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Add,id:2434,x:32092,y:32420,varname:node_2434,prsc:2|A-4123-OUT,B-6476-OUT;n:type:ShaderForge.SFN_Clamp01,id:507,x:32301,y:32420,varname:node_507,prsc:2|IN-2434-OUT;n:type:ShaderForge.SFN_Add,id:3150,x:32365,y:32971,varname:node_3150,prsc:2|A-865-OUT,B-1739-OUT;n:type:ShaderForge.SFN_OneMinus,id:5564,x:31329,y:32772,varname:node_5564,prsc:2|IN-5243-OUT;n:type:ShaderForge.SFN_Tex2d,id:6201,x:30994,y:32353,ptovrint:False,ptlb:FoamTexture,ptin:_FoamTexture,varname:node_6201,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e1938fd8dec9e2141a90ac6144973e1d,ntxv:0,isnm:False|UVIN-2593-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1780,x:31261,y:32373,varname:node_1780,prsc:2|A-4123-OUT,B-6201-RGB;n:type:ShaderForge.SFN_Multiply,id:7878,x:31428,y:32489,varname:node_7878,prsc:2|A-1780-OUT,B-5564-OUT;n:type:ShaderForge.SFN_Power,id:2578,x:31604,y:32922,varname:node_2578,prsc:2|VAL-5564-OUT,EXP-840-OUT;n:type:ShaderForge.SFN_Vector1,id:840,x:31417,y:32985,varname:node_840,prsc:2,v1:5;n:type:ShaderForge.SFN_Add,id:244,x:31745,y:32714,varname:node_244,prsc:2|A-9008-OUT,B-2578-OUT;n:type:ShaderForge.SFN_TexCoord,id:2204,x:30483,y:32309,varname:node_2204,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2593,x:30749,y:32321,varname:node_2593,prsc:2,spu:0.01,spv:0.01|UVIN-2204-UVOUT;proporder:914-7357-325-9944-4925-4736-8450-5968-6201;pass:END;sub:END;*/

Shader "Shader Forge/Water" {
    Properties {
        _ColorA ("ColorA", Color) = (0.1,0,1,1)
        _ColorB ("ColorB", Color) = (1,0,0,1)
        _Depth ("Depth", Float ) = 10
        _FoamMax ("FoamMax", Range(0, 1)) = 1
        _FoamMin ("FoamMin", Range(0, 1)) = 0
        _FoamPower ("FoamPower", Float ) = 8
        _DepthMin ("DepthMin", Range(0, 1)) = 0
        _DepthMax ("DepthMax", Range(0, 1)) = 0
        _FoamTexture ("FoamTexture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _ColorA;
            uniform float4 _ColorB;
            uniform float _Depth;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _DepthMin;
            uniform float _DepthMax;
            uniform float _FoamPower;
            uniform sampler2D _FoamTexture; uniform float4 _FoamTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 1.0 - 0.0; // Convert roughness to gloss
                float perceptualRoughness = 0.0;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float node_3738 = saturate((saturate((sceneZ-partZ)/_Depth)/dot(viewDirection,i.normalDir)));
                float3 node_4123 = lerp(_ColorA.rgb,_ColorB.rgb,node_3738);
                float4 node_9513 = _Time;
                float2 node_2593 = (i.uv0+node_9513.g*float2(0.01,0.01));
                float4 _FoamTexture_var = tex2D(_FoamTexture,TRANSFORM_TEX(node_2593, _FoamTexture));
                float node_2716 = 0.0;
                float node_5564 = (1.0 - (node_2716 + ( (node_3738 - _FoamMin) * (1.0 - node_2716) ) / (_FoamMax - _FoamMin)));
                float3 node_6476 = saturate(((((node_4123*_FoamTexture_var.rgb)*node_5564)*_FoamPower)+pow(node_5564,5.0)));
                float3 diffuseColor = saturate((node_4123+node_6476)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_426 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor,saturate(((node_6476.r*0.5)+(node_426 + ( (node_3738 - _DepthMin) * (1.0 - node_426) ) / (_DepthMax - _DepthMin)))));
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _ColorA;
            uniform float4 _ColorB;
            uniform float _Depth;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _DepthMin;
            uniform float _DepthMax;
            uniform float _FoamPower;
            uniform sampler2D _FoamTexture; uniform float4 _FoamTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 1.0 - 0.0; // Convert roughness to gloss
                float perceptualRoughness = 0.0;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float node_3738 = saturate((saturate((sceneZ-partZ)/_Depth)/dot(viewDirection,i.normalDir)));
                float3 node_4123 = lerp(_ColorA.rgb,_ColorB.rgb,node_3738);
                float4 node_6160 = _Time;
                float2 node_2593 = (i.uv0+node_6160.g*float2(0.01,0.01));
                float4 _FoamTexture_var = tex2D(_FoamTexture,TRANSFORM_TEX(node_2593, _FoamTexture));
                float node_2716 = 0.0;
                float node_5564 = (1.0 - (node_2716 + ( (node_3738 - _FoamMin) * (1.0 - node_2716) ) / (_FoamMax - _FoamMin)));
                float3 node_6476 = saturate(((((node_4123*_FoamTexture_var.rgb)*node_5564)*_FoamPower)+pow(node_5564,5.0)));
                float3 diffuseColor = saturate((node_4123+node_6476)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_426 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor * saturate(((node_6476.r*0.5)+(node_426 + ( (node_3738 - _DepthMin) * (1.0 - node_426) ) / (_DepthMax - _DepthMin)))),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _ColorA;
            uniform float4 _ColorB;
            uniform float _Depth;
            uniform float _FoamMax;
            uniform float _FoamMin;
            uniform float _FoamPower;
            uniform sampler2D _FoamTexture; uniform float4 _FoamTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_3738 = saturate((saturate((sceneZ-partZ)/_Depth)/dot(viewDirection,i.normalDir)));
                float3 node_4123 = lerp(_ColorA.rgb,_ColorB.rgb,node_3738);
                float4 node_9540 = _Time;
                float2 node_2593 = (i.uv0+node_9540.g*float2(0.01,0.01));
                float4 _FoamTexture_var = tex2D(_FoamTexture,TRANSFORM_TEX(node_2593, _FoamTexture));
                float node_2716 = 0.0;
                float node_5564 = (1.0 - (node_2716 + ( (node_3738 - _FoamMin) * (1.0 - node_2716) ) / (_FoamMax - _FoamMin)));
                float3 node_6476 = saturate(((((node_4123*_FoamTexture_var.rgb)*node_5564)*_FoamPower)+pow(node_5564,5.0)));
                float3 diffColor = saturate((node_4123+node_6476));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float roughness = 0.0;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
