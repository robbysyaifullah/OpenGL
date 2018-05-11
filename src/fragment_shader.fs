#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec3 Normal;  
in vec3 FragPos;  

uniform sampler2D texture_diffuse1;
uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos; 
uniform vec3 viewPos;

void main() {    
    //FragColor = vec4(1,0,0,1);
    vec4 car_model = texture(texture_diffuse1, TexCoords);
	
	//ambient
	float ambientStrength = 0.3;
    vec3 ambient = ambientStrength * lightColor;
    
    //diffuse
    vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(lightPos - FragPos); 
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;

	//specular
	float specularStrength = 0.5;
	vec3 viewDir = normalize(viewPos - FragPos);
	vec3 reflectDir = reflect(-lightDir, norm);  
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 16);
	vec3 specular = specularStrength * spec * lightColor;  

	//result
	vec3 result = (ambient + diffuse + specular) * objectColor;
    vec4 light = vec4(result, 1.0);
    FragColor = car_model * light;
}