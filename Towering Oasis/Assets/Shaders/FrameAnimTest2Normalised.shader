// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33998,y:32660,varname:node_3138,prsc:2|emission-9151-RGB,clip-9151-A;n:type:ShaderForge.SFN_Tex2d,id:9151,x:33780,y:32760,ptovrint:False,ptlb:Sprite Sheet,ptin:_SpriteSheet,varname:node_713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:False|UVIN-3805-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6893,x:32761,y:33211,ptovrint:False,ptlb:Animation,ptin:_Animation,varname:node_8132,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8798,x:30403,y:33321,ptovrint:False,ptlb:Frame Rate,ptin:_FrameRate,varname:node_4327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:30;n:type:ShaderForge.SFN_TexCoord,id:4920,x:31291,y:32249,varname:node_4920,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:9240,x:30885,y:33441,ptovrint:False,ptlb:Frames,ptin:_Frames,varname:node_5604,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:9;n:type:ShaderForge.SFN_ValueProperty,id:917,x:30515,y:32247,ptovrint:False,ptlb:Frames_Width,ptin:_Frames_Width,varname:node_2339,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:16;n:type:ShaderForge.SFN_ValueProperty,id:103,x:30515,y:32343,ptovrint:False,ptlb:Frames_Height,ptin:_Frames_Height,varname:node_430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:16;n:type:ShaderForge.SFN_Vector1,id:7579,x:32556,y:32315,varname:node_7579,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:5438,x:32820,y:32413,varname:node_5438,prsc:2|A-7579-OUT,B-6370-OUT;n:type:ShaderForge.SFN_Get,id:7170,x:32302,y:32498,varname:node_7170,prsc:2|IN-8300-OUT;n:type:ShaderForge.SFN_Multiply,id:4308,x:33041,y:32550,varname:node_4308,prsc:2|A-5438-OUT,B-5899-OUT;n:type:ShaderForge.SFN_Vector1,id:3600,x:30654,y:33153,varname:node_3600,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:453,x:33241,y:32480,varname:node_453,prsc:2|A-4490-OUT,B-4308-OUT;n:type:ShaderForge.SFN_Append,id:3805,x:33571,y:32760,varname:node_3805,prsc:2|A-453-OUT,B-4252-OUT;n:type:ShaderForge.SFN_Divide,id:2979,x:32761,y:33007,varname:node_2979,prsc:2|A-6972-OUT,B-2084-OUT;n:type:ShaderForge.SFN_Multiply,id:9103,x:33028,y:33155,varname:node_9103,prsc:2|A-2979-OUT,B-6893-OUT,C-4035-OUT;n:type:ShaderForge.SFN_Add,id:4252,x:33242,y:33096,varname:node_4252,prsc:2|A-8197-OUT,B-9103-OUT;n:type:ShaderForge.SFN_Vector1,id:4035,x:32761,y:33304,varname:node_4035,prsc:2,v1:-1;n:type:ShaderForge.SFN_Set,id:8300,x:31984,y:33161,varname:NewFrame,prsc:2|IN-9761-OUT;n:type:ShaderForge.SFN_Time,id:7668,x:30893,y:33022,varname:node_7668,prsc:2;n:type:ShaderForge.SFN_Divide,id:3660,x:30885,y:33192,varname:node_3660,prsc:2|A-3600-OUT,B-3003-OUT;n:type:ShaderForge.SFN_Multiply,id:8767,x:31623,y:33161,varname:node_8767,prsc:2|A-6659-OUT,B-3155-OUT;n:type:ShaderForge.SFN_Vector1,id:3123,x:30403,y:33218,varname:node_3123,prsc:2,v1:30;n:type:ShaderForge.SFN_Ceil,id:9761,x:31803,y:33161,varname:node_9761,prsc:2|IN-8767-OUT;n:type:ShaderForge.SFN_Divide,id:6176,x:31112,y:33366,varname:node_6176,prsc:2|A-9240-OUT,B-7506-OUT;n:type:ShaderForge.SFN_Fmod,id:3155,x:31390,y:33239,varname:node_3155,prsc:2|A-5436-OUT,B-6176-OUT;n:type:ShaderForge.SFN_Divide,id:3003,x:30654,y:33248,varname:node_3003,prsc:2|A-3123-OUT,B-8798-OUT;n:type:ShaderForge.SFN_Multiply,id:5436,x:31116,y:33119,varname:node_5436,prsc:2|A-7668-T,B-3660-OUT;n:type:ShaderForge.SFN_Vector1,id:5665,x:32323,y:32574,varname:node_5665,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:6501,x:32556,y:32498,varname:node_6501,prsc:2|A-7170-OUT,B-5665-OUT;n:type:ShaderForge.SFN_Vector1,id:6972,x:32562,y:32963,varname:node_6972,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3188,x:32556,y:32691,ptovrint:False,ptlb:Frame Offset,ptin:_FrameOffset,varname:node_5787,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:5899,x:32820,y:32596,varname:node_5899,prsc:2|A-6501-OUT,B-3188-OUT;n:type:ShaderForge.SFN_Divide,id:881,x:31642,y:32172,varname:node_881,prsc:2|A-4920-U,B-7531-OUT;n:type:ShaderForge.SFN_Divide,id:5136,x:31642,y:32389,varname:node_5136,prsc:2|A-4920-V,B-9005-OUT;n:type:ShaderForge.SFN_Set,id:3777,x:30711,y:32247,varname:FW,prsc:2|IN-917-OUT;n:type:ShaderForge.SFN_Set,id:6193,x:30711,y:32343,varname:FH,prsc:2|IN-103-OUT;n:type:ShaderForge.SFN_Get,id:2084,x:32541,y:33053,varname:node_2084,prsc:2|IN-6193-OUT;n:type:ShaderForge.SFN_Get,id:9005,x:31621,y:32538,varname:node_9005,prsc:2|IN-6193-OUT;n:type:ShaderForge.SFN_Get,id:7531,x:31621,y:32312,varname:node_7531,prsc:2|IN-3777-OUT;n:type:ShaderForge.SFN_Get,id:6370,x:32535,y:32381,varname:node_6370,prsc:2|IN-3777-OUT;n:type:ShaderForge.SFN_Get,id:7506,x:30885,y:33518,varname:node_7506,prsc:2|IN-3777-OUT;n:type:ShaderForge.SFN_Get,id:6659,x:31390,y:33101,varname:node_6659,prsc:2|IN-3777-OUT;n:type:ShaderForge.SFN_Set,id:412,x:31813,y:32172,varname:SmallU,prsc:2|IN-881-OUT;n:type:ShaderForge.SFN_Set,id:5868,x:31813,y:32389,varname:SmallV,prsc:2|IN-5136-OUT;n:type:ShaderForge.SFN_Get,id:4490,x:33041,y:32463,varname:node_4490,prsc:2|IN-412-OUT;n:type:ShaderForge.SFN_Get,id:8197,x:33007,y:33056,varname:node_8197,prsc:2|IN-5868-OUT;proporder:9151-6893-8798-9240-917-103-3188;pass:END;sub:END;*/

Shader "Shader Forge/FrameAnimTest2Normalised" {
    Properties {
        _SpriteSheet ("Sprite Sheet", 2D) = "bump" {}
        _Animation ("Animation", Float ) = 1
        _FrameRate ("Frame Rate", Float ) = 30
        _Frames ("Frames", Float ) = 9
        _Frames_Width ("Frames_Width", Float ) = 16
        _Frames_Height ("Frames_Height", Float ) = 16
        _FrameOffset ("Frame Offset", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _SpriteSheet; uniform float4 _SpriteSheet_ST;
            uniform float _Animation;
            uniform float _FrameRate;
            uniform float _Frames;
            uniform float _Frames_Width;
            uniform float _Frames_Height;
            uniform float _FrameOffset;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float FW = _Frames_Width;
                float SmallU = (i.uv0.r/FW);
                float4 node_7668 = _Time;
                float NewFrame = ceil((FW*fmod((node_7668.g*(1.0/(30.0/_FrameRate))),(_Frames/FW))));
                float FH = _Frames_Height;
                float SmallV = (i.uv0.g/FH);
                float2 node_3805 = float2((SmallU+((1.0/FW)*((NewFrame-1.0)+_FrameOffset))),(SmallV+((1.0/FH)*_Animation*(-1.0))));
                float4 _SpriteSheet_var = tex2D(_SpriteSheet,TRANSFORM_TEX(node_3805, _SpriteSheet));
                clip(_SpriteSheet_var.a - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _SpriteSheet_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _SpriteSheet; uniform float4 _SpriteSheet_ST;
            uniform float _Animation;
            uniform float _FrameRate;
            uniform float _Frames;
            uniform float _Frames_Width;
            uniform float _Frames_Height;
            uniform float _FrameOffset;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float FW = _Frames_Width;
                float SmallU = (i.uv0.r/FW);
                float4 node_7668 = _Time;
                float NewFrame = ceil((FW*fmod((node_7668.g*(1.0/(30.0/_FrameRate))),(_Frames/FW))));
                float FH = _Frames_Height;
                float SmallV = (i.uv0.g/FH);
                float2 node_3805 = float2((SmallU+((1.0/FW)*((NewFrame-1.0)+_FrameOffset))),(SmallV+((1.0/FH)*_Animation*(-1.0))));
                float4 _SpriteSheet_var = tex2D(_SpriteSheet,TRANSFORM_TEX(node_3805, _SpriteSheet));
                clip(_SpriteSheet_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
