#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;

uniform samplerCube texture1;
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_reflection1;

void main()
{
//    float ratio = 1.00 / 1.52;
//    vec3 I = normalize(Position - cameraPos);
//    vec3 R = refract(I, normalize(Normal), ratio);
//    FragColor = vec4(texture(skybox, R).rgb, 1.0);
    
//    vec3 I = normalize(Position - cameraPos);
//    vec3 R = reflect(I, normalize(Normal));
//    FragColor = vec4(texture(skybox, R).rgb, 1.0);
    
    
    vec3 viewDir = normalize(cameraPos - Position);
    vec3 normal = normalize(Normal);
    
    vec3 R = reflect(- viewDir, normal);
    vec3 reflectMap = vec3(texture(texture_reflection1, TexCoords));
    vec3 reflection = vec3(texture(texture1, R).rgb) * reflectMap;

    float diff = max(normalize(dot(normal, viewDir)), 0.0f);
    vec3 diffuse = diff * vec3(texture(texture_diffuse1, TexCoords));

    FragColor = vec4(diffuse + reflection, 1.0f);
    
    //FragColor = texture(texture_diffuse1, TexCoords);
}
