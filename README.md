# Mars Rover App

A sample Console Application for mars rover problem solution developed with C# in .net6.0 framework.

## Usage
* The first line must be consist of two integers which defines the pletau surface upper right coordinates.
* Each rover information must be consist of two lines sequentally. First line is landing position of rover, and the second line is instructions to be operated by rover.

#### Rover Position Format Sample
    coordinate_X coordinate_Y heading_direction (N,S,W,E)
    6 10 N
* After entering rover's landing position you will be required to enter instructions.

#### Instructions Explanation
    LMLMLRMLMM
    
    L: Turn Left, M: Move, R: Turn Right

## Prerequirements

* docker desktop (https://www.docker.com/products/docker-desktop)

## How To Run

* Navigate project root directory
* Build and run project with following command: 
```bash
docker build -t mars-rover .
docker run -i mars-rover
```
* After application startup completed you can manually enter input data and test the application.

## Running with bulk data

* Navigate project root directory
* Build and run project with following command: (you should specify the custom_test_file location described below)

```bash
docker run -i mars-rover < custom_test_file.txt > output_file.txt
cat output_file.txt
```

* You can also use two test input files (test.txt, test_detailed.txt) that have been prepared before. Before using them you should pull LFS files with following command:
```bash
git lfs pull
```

