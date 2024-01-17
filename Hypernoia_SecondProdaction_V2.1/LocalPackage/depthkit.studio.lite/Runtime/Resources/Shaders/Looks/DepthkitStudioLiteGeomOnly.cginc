﻿
//SRP Compatibility
#ifndef DK_CLIP_POS_TRANSFORM
#define DK_CLIP_POS_TRANSFORM(pos) UnityObjectToClipPos(pos)
#endif

#ifndef DK_COLOR_OUT
#define DK_COLOR_OUT fixed4
#endif

DK_EDGEMASK_UNIFORMS

float4x4 _LocalTransform;

struct appdata
{
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;
    uint id : SV_VertexID;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f
{
    float2 packedUV : TEXCOORD0;
    float4 pos : SV_POSITION;
    UNITY_VERTEX_OUTPUT_STEREO
};

v2f vert(appdata v)
{
    v2f o;
    UNITY_SETUP_INSTANCE_ID(v);
#ifdef DK_SRP
    UNITY_TRANSFER_INSTANCE_ID(v, o);
#else
    UNITY_INITIALIZE_OUTPUT(v2f, o);
#endif
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
    

    Vertex vert = dkSampleTriangleBuffer(floor(v.id / 3), v.id % 3);
    o.packedUV = vert.uv.zw; // xy stores perspective uv, zw stores packed uv 
    v.vertex = mul(_LocalTransform, float4(vert.position, 1));
    o.pos = DK_CLIP_POS_TRANSFORM(v.vertex);
    return o;
}

DK_COLOR_OUT frag(v2f i) : SV_Target
{
#ifdef DK_SRP
    UNITY_SETUP_INSTANCE_ID(i);
#endif
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

#if !defined(DK_CORE_SKIP_FRAGMENT_DEPTHSAMPLE) && !defined(DK_DEBUG_EDGEMASK)
    // sample the texture
    uint perspectiveIndex;
    float2 depthUV, colorUV, perspectiveUV;
    dkUnpackUVs(i.packedUV, colorUV, depthUV, perspectiveUV, perspectiveIndex);
    float depth = dkSampleDepth(depthUV, perspectiveIndex, perspectiveUV);
    float alpha = dkValidateNormalizedDepth(perspectiveIndex, depth) ? DK_SAMPLE_EDGEMASK(perspectiveUV, perspectiveIndex, i.pos) : -1.f;
    DK_FRAGMENT_CLIP(alpha, perspectiveIndex)
#endif
    return DK_COLOR_OUT(1, 1, 1, 1);
}