# Mars Rover App

A sample Console Application for mars rover problem solution developed with C# in .net6.0 framework.

## Usage
* When application startup completed you will be required to enter Mars plateau surface upper coordinates.
* Enter the upper right coordinates as two integers with spaces between.
* After entering upper right coordinates of the plateu, you will be required to enter the first rover landing coordinate with the following format: 

#### Rover Position Format Sample
    coordinate_X coordinate_Y heading_direction (N,S,W,E)
    6 10 N
* After entering rover's landing position you will be required to enter instructions.

#### Instructions Sample
    LMLMLRMLMM
    
    L: Turn Left, M: Move, R: Turn Right
* Once the previous step was completed the application will ask if you want to deploy other rovers. If you respond yes you will be able to another rovers.
* After rover deployment completed the application will print last position of each rover sequentally.

## Prerequirements

* docker desktop (https://www.docker.com/products/docker-desktop)

## How To Run

* Navigate project root directory
* Build and run project with following command: 
```bash
docker compose run marsrover.application 
```

