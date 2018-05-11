all :
	g++ src/main.cpp -o main -lglfw -lGLEW -lGL -lglut -lassimp -I src -g -std=c++11
run : 
	./main
